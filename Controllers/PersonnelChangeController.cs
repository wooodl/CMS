using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComprehensiveManagementSystem.Data;
using ComprehensiveManagementSystem.Models;

namespace ComprehensiveManagementSystem.Controllers
{
    public class PersonnelChangeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonnelChangeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonnelChange - 主页面，显示所有标签
        public IActionResult Index()
        {
            return View();
        }

        // GET: PersonnelChange/TabData - 获取指定标签的数据
        public async Task<IActionResult> TabData(PersonnelChangeType changeType, string? searchName, int page = 1, int pageSize = 20)
        {
            var query = _context.PersonnelChanges
                .Include(pc => pc.Personnel)
                .ThenInclude(p => p.Department)
                .Include(pc => pc.PreviousOrganization)
                .Include(pc => pc.NewOrganization)
                .Where(pc => !pc.IsDeleted && pc.ChangeType == changeType);

            // 搜索条件
            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(pc => pc.Personnel != null && pc.Personnel.Name.Contains(searchName));
            }

            // 分页
            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(pc => pc.ChangeDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.SearchName = searchName;
            ViewBag.ChangeType = changeType;
            ViewBag.ChangeTypeName = GetChangeTypeDisplayName(changeType);
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            return PartialView("_TabDataPartial", items);
        }

        // GET: PersonnelChange/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelChange = await _context.PersonnelChanges
                .Include(pc => pc.Personnel)
                .ThenInclude(p => p.Department)
                .Include(pc => pc.PreviousOrganization)
                .Include(pc => pc.NewOrganization)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);

            if (personnelChange == null)
            {
                return NotFound();
            }

            return View(personnelChange);
        }

        // GET: PersonnelChange/Create - 通用创建
        public async Task<IActionResult> Create(PersonnelChangeType? changeType)
        {
            var model = new PersonnelChange();
            if (changeType.HasValue)
            {
                model.ChangeType = changeType.Value;
            }
            
            await PrepareViewBag(model);
            ViewBag.ChangeType = changeType;
            ViewBag.ChangeTypeName = changeType.HasValue ? GetChangeTypeDisplayName(changeType.Value) : "";
            
            return View(model);
        }

        // GET: PersonnelChange/CreateByType/{changeType} - 按类型创建
        public async Task<IActionResult> CreateByType(PersonnelChangeType changeType)
        {
            var model = new PersonnelChange
            {
                ChangeType = changeType,
                ChangeDate = DateTime.Today
            };
            
            await PrepareViewBag(model);
            ViewBag.ChangeTypeName = GetChangeTypeDisplayName(changeType);
            
            return PartialView("_CreateEditModal", model);
        }

        // POST: PersonnelChange/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonnelChange personnelChange, bool isModal = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    personnelChange.CreatedAt = DateTime.Now;
                    personnelChange.UpdatedAt = DateTime.Now;
                    _context.Add(personnelChange);
                    await _context.SaveChangesAsync();
                    
                    if (isModal)
                    {
                        return Json(new { success = true, message = "保存成功！" });
                    }
                    
                    TempData["SuccessMessage"] = "人员变动记录保存成功！";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // 记录模型验证错误
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) })
                        .ToList();
                    
                    if (isModal)
                    {
                        return Json(new { success = false, message = "表单验证失败：" + string.Join("; ", errors.SelectMany(e => e.Errors)) });
                    }
                    
                    TempData["ErrorMessage"] = "表单验证失败：" + string.Join("; ", errors.SelectMany(e => e.Errors));
                }
            }
            catch (Exception ex)
            {
                if (isModal)
                {
                    return Json(new { success = false, message = $"保存失败：{ex.Message}" });
                }
                TempData["ErrorMessage"] = $"保存失败：{ex.Message}";
            }

            await PrepareViewBag(personnelChange);
            ViewBag.ChangeTypeName = GetChangeTypeDisplayName(personnelChange.ChangeType);
            return isModal ? PartialView("_CreateEditModal", personnelChange) : View(personnelChange);
        }

        // GET: PersonnelChange/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelChange = await _context.PersonnelChanges
                .FirstOrDefaultAsync(pc => pc.Id == id && !pc.IsDeleted);

            if (personnelChange == null)
            {
                return NotFound();
            }

            await PrepareViewBag(personnelChange);
            ViewBag.ChangeTypeName = GetChangeTypeDisplayName(personnelChange.ChangeType);
            return View(personnelChange);
        }

        // GET: PersonnelChange/EditByType/{id} - 按类型编辑（模态框）
        public async Task<IActionResult> EditByType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelChange = await _context.PersonnelChanges
                .FirstOrDefaultAsync(pc => pc.Id == id && !pc.IsDeleted);

            if (personnelChange == null)
            {
                return NotFound();
            }

            await PrepareViewBag(personnelChange);
            ViewBag.ChangeTypeName = GetChangeTypeDisplayName(personnelChange.ChangeType);
            
            return PartialView("_CreateEditModal", personnelChange);
        }

        // POST: PersonnelChange/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonnelId,ChangeType,ChangeDate,ChangeReason,PreviousOrganizationId,NewOrganizationId,PreviousPosition,NewPosition,PreviousGrade,NewGrade,PreviousPoliticalStatus,NewPoliticalStatus,EffectiveDate,ProcessedBy,ApprovedBy,Status,Remarks,AttachmentPath,CreatedBy,CreatedAt")] PersonnelChange personnelChange, bool isModal = false)
        {
            if (id != personnelChange.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    personnelChange.UpdatedAt = DateTime.Now;
                    _context.Update(personnelChange);
                    await _context.SaveChangesAsync();
                    
                    if (isModal)
                    {
                        return Json(new { success = true, message = "修改成功！" });
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnelChangeExists(personnelChange.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    if (isModal)
                    {
                        return Json(new { success = false, message = $"修改失败：{ex.Message}" });
                    }
                    ModelState.AddModelError("", ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }

            if (isModal)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { success = false, message = "表单验证失败：" + string.Join("; ", errors) });
            }

            await PrepareViewBag(personnelChange);
            ViewBag.ChangeTypeName = GetChangeTypeDisplayName(personnelChange.ChangeType);
            return View(personnelChange);
        }

        // GET: PersonnelChange/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnelChange = await _context.PersonnelChanges
                .Include(pc => pc.Personnel)
                .ThenInclude(p => p.Department)
                .Include(pc => pc.PreviousOrganization)
                .Include(pc => pc.NewOrganization)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);

            if (personnelChange == null)
            {
                return NotFound();
            }

            return View(personnelChange);
        }

        // POST: PersonnelChange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personnelChange = await _context.PersonnelChanges.FindAsync(id);
            if (personnelChange != null)
            {
                personnelChange.IsDeleted = true;
                personnelChange.UpdatedAt = DateTime.Now;
                _context.PersonnelChanges.Update(personnelChange);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // API: 根据人员ID获取人员基本信息
        [HttpGet]
        public async Task<IActionResult> GetPersonnelInfo(Guid personnelId)
        {
            var personnel = await _context.PersonnelBasicInfos
                .Include(p => p.Department)
                .FirstOrDefaultAsync(p => p.PersonnelId == personnelId && !p.IsDeleted);

            if (personnel == null)
            {
                return NotFound();
            }

            return Json(new
            {
                name = personnel.Name,
                gender = personnel.Gender.ToString(),
                birthDate = personnel.BirthDate.ToString("yyyy-MM-dd"),
                nativePlace = personnel.NativePlace,
                politicalStatus = personnel.PoliticalStatus,
                grade = personnel.Grade,
                department = personnel.Department?.Name,
                departmentId = personnel.DepartmentId,
                position = personnel.Position,
                duty = personnel.Duty
            });
        }

        private bool PersonnelChangeExists(int id)
        {
            return _context.PersonnelChanges.Any(e => e.Id == id && !e.IsDeleted);
        }

        private async Task PrepareViewBag(PersonnelChange? personnelChange = null)
        {
            // 人员列表
            ViewBag.PersonnelId = new SelectList(
                await _context.PersonnelBasicInfos
                    .Where(p => !p.IsDeleted)
                    .Select(p => new { p.PersonnelId, p.Name })
                    .ToListAsync(),
                "PersonnelId", "Name", personnelChange?.PersonnelId);

            // 机构列表 - 只使用Organization表
            var organizations = await _context.Organizations
                .Where(o => o.Type == OrganizationType.Department)
                .OrderBy(o => o.DisplayOrder)
                .ThenBy(o => o.Name)
                .Select(o => new { o.Id, o.Name })
                .ToListAsync();
            
            ViewBag.PreviousOrganizationId = new SelectList(organizations, "Id", "Name", personnelChange?.PreviousOrganizationId);
            ViewBag.NewOrganizationId = new SelectList(organizations, "Id", "Name", personnelChange?.NewOrganizationId);

            // 变动类型列表
            ViewBag.ChangeTypes = Enum.GetValues(typeof(PersonnelChangeType))
                .Cast<PersonnelChangeType>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = GetChangeTypeDisplayName(e),
                    Selected = personnelChange?.ChangeType == e
                }).ToList();

            // 变动状态列表
            ViewBag.StatusList = Enum.GetValues(typeof(PersonnelChangeStatus))
                .Cast<PersonnelChangeStatus>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = GetStatusDisplayName(e),
                    Selected = personnelChange?.Status == e
                }).ToList();
        }

        private string GetChangeTypeDisplayName(PersonnelChangeType changeType)
        {
            return changeType switch
            {
                PersonnelChangeType.Onboard => "入职",
                PersonnelChangeType.Resign => "离职",
                PersonnelChangeType.TransferIn => "调入",
                PersonnelChangeType.TransferOut => "调出",
                PersonnelChangeType.Promotion => "晋升",
                PersonnelChangeType.PartyDevelopment => "党员发展",
                PersonnelChangeType.PositionChange => "职务变动",
                PersonnelChangeType.OrganizationTransfer => "机构变动",
                _ => changeType.ToString()
            };
        }

        private string GetStatusDisplayName(PersonnelChangeStatus status)
        {
            return status switch
            {
                PersonnelChangeStatus.Pending => "待审批",
                PersonnelChangeStatus.Approved => "已批准",
                PersonnelChangeStatus.Rejected => "已拒绝",
                PersonnelChangeStatus.Effective => "已生效",
                PersonnelChangeStatus.Cancelled => "已撤销",
                _ => status.ToString()
            };
        }

    }
}