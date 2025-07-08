using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComprehensiveManagementSystem.Data;
using ComprehensiveManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace ComprehensiveManagementSystem.Controllers
{
    [Authorize]
    public class PersonnelBasicInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonnelBasicInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonnelBasicInfo
        public async Task<IActionResult> Index(string searchString, int? departmentId, Gender? gender, int pageNumber = 1, int pageSize = 10)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentDepartment"] = departmentId;
            ViewData["CurrentGender"] = gender;

            // 获取部门列表用于筛选
            ViewData["Departments"] = new SelectList(_context.Departments, "Id", "Name", departmentId);

            var personnel = _context.PersonnelBasicInfos
                .Include(p => p.Department)
                .Where(p => !p.IsDeleted)
                .AsQueryable();

            // 搜索过滤
            if (!string.IsNullOrEmpty(searchString))
            {
                personnel = personnel.Where(p => p.Name.Contains(searchString) 
                    || p.IdCard.Contains(searchString)
                    || (p.Phone != null && p.Phone.Contains(searchString)));
            }

            // 部门过滤
            if (departmentId.HasValue)
            {
                personnel = personnel.Where(p => p.DepartmentId == departmentId);
            }

            // 性别过滤
            if (gender.HasValue)
            {
                personnel = personnel.Where(p => p.Gender == gender);
            }

            // 分页
            var totalCount = await personnel.CountAsync();
            var items = await personnel
                .OrderBy(p => p.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["TotalCount"] = totalCount;
            ViewData["PageNumber"] = pageNumber;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalCount / (double)pageSize);

            return View(items);
        }

        // GET: PersonnelBasicInfo/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var personnel = await _context.PersonnelBasicInfos
                .Include(p => p.Department)
                .Include(p => p.RewardPunishments.Where(rp => !rp.IsDeleted))
                .Include(p => p.Histories.Where(h => !h.IsDeleted))
                .Include(p => p.Spouse)
                .Include(p => p.FamilyMembers.Where(fm => !fm.IsDeleted))
                .Include(p => p.WorkRecords.Where(wr => !wr.IsDeleted))
                .Include(p => p.ActivityRecords.Where(ar => !ar.IsDeleted))
                .FirstOrDefaultAsync(m => m.PersonnelId == id && !m.IsDeleted);

            if (personnel == null)
            {
                return NotFound();
            }

            return View(personnel);
        }

        // GET: PersonnelBasicInfo/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: PersonnelBasicInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Gender,BirthDate,NativePlace,Education,IdCard,HireDate,PoliticalStatus,PartyJoinDate,MaritalStatus,PersonnelCategory,Grade,LastGradeAdjustmentDate,TreatmentLevel,LastTreatmentAdjustmentDate,DepartmentId,DepartmentJoinDate,Position,Duty,DutyLevel,RankAssessmentDate,LastAssessmentResult,ExcellentCount,PhotoPath,Phone,HomeAddress,WorkAddress")] PersonnelBasicInfo personnelBasicInfo)
        {
            if (ModelState.IsValid)
            {
                // 检查身份证号是否已存在
                var existingPersonnel = await _context.PersonnelBasicInfos
                    .FirstOrDefaultAsync(p => p.IdCard == personnelBasicInfo.IdCard && !p.IsDeleted);
                
                if (existingPersonnel != null)
                {
                    ModelState.AddModelError("IdCard", "该身份证号已存在");
                    ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", personnelBasicInfo.DepartmentId);
                    return View(personnelBasicInfo);
                }

                personnelBasicInfo.PersonnelId = Guid.NewGuid();
                personnelBasicInfo.CreatedAt = DateTime.Now;
                personnelBasicInfo.UpdatedAt = DateTime.Now;
                
                _context.Add(personnelBasicInfo);
                await _context.SaveChangesAsync();
                
                TempData["SuccessMessage"] = "人员信息创建成功！";
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", personnelBasicInfo.DepartmentId);
            return View(personnelBasicInfo);
        }

        // GET: PersonnelBasicInfo/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var personnelBasicInfo = await _context.PersonnelBasicInfos
                .FirstOrDefaultAsync(p => p.PersonnelId == id && !p.IsDeleted);
            
            if (personnelBasicInfo == null)
            {
                return NotFound();
            }
            
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", personnelBasicInfo.DepartmentId);
            return View(personnelBasicInfo);
        }

        // POST: PersonnelBasicInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonnelId,Name,Gender,BirthDate,NativePlace,Education,IdCard,HireDate,PoliticalStatus,PartyJoinDate,MaritalStatus,PersonnelCategory,Grade,LastGradeAdjustmentDate,TreatmentLevel,LastTreatmentAdjustmentDate,DepartmentId,DepartmentJoinDate,Position,Duty,DutyLevel,RankAssessmentDate,LastAssessmentResult,ExcellentCount,PhotoPath,Phone,HomeAddress,WorkAddress,CreatedAt")] PersonnelBasicInfo personnelBasicInfo)
        {
            if (id != personnelBasicInfo.PersonnelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 检查身份证号是否被其他人员使用
                    var existingPersonnel = await _context.PersonnelBasicInfos
                        .FirstOrDefaultAsync(p => p.IdCard == personnelBasicInfo.IdCard 
                            && p.PersonnelId != personnelBasicInfo.PersonnelId 
                            && !p.IsDeleted);
                    
                    if (existingPersonnel != null)
                    {
                        ModelState.AddModelError("IdCard", "该身份证号已被其他人员使用");
                        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", personnelBasicInfo.DepartmentId);
                        return View(personnelBasicInfo);
                    }

                    personnelBasicInfo.UpdatedAt = DateTime.Now;
                    _context.Update(personnelBasicInfo);
                    await _context.SaveChangesAsync();
                    
                    TempData["SuccessMessage"] = "人员信息更新成功！";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnelBasicInfoExists(personnelBasicInfo.PersonnelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", personnelBasicInfo.DepartmentId);
            return View(personnelBasicInfo);
        }

        // GET: PersonnelBasicInfo/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var personnelBasicInfo = await _context.PersonnelBasicInfos
                .Include(p => p.Department)
                .FirstOrDefaultAsync(m => m.PersonnelId == id && !m.IsDeleted);
            
            if (personnelBasicInfo == null)
            {
                return NotFound();
            }

            return View(personnelBasicInfo);
        }

        // POST: PersonnelBasicInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var personnelBasicInfo = await _context.PersonnelBasicInfos
                .FirstOrDefaultAsync(p => p.PersonnelId == id && !p.IsDeleted);
            
            if (personnelBasicInfo != null)
            {
                // 软删除：设置IsDeleted标志
                personnelBasicInfo.IsDeleted = true;
                personnelBasicInfo.UpdatedAt = DateTime.Now;
                
                // 同时软删除相关记录
                var relatedRecords = await _context.PersonnelRewardPunishments
                    .Where(rp => rp.PersonnelId == id && !rp.IsDeleted)
                    .ToListAsync();
                relatedRecords.ForEach(rp => { rp.IsDeleted = true; rp.UpdatedAt = DateTime.Now; });

                var histories = await _context.PersonnelHistories
                    .Where(h => h.PersonnelId == id && !h.IsDeleted)
                    .ToListAsync();
                histories.ForEach(h => { h.IsDeleted = true; h.UpdatedAt = DateTime.Now; });

                var spouse = await _context.PersonnelSpouses
                    .FirstOrDefaultAsync(s => s.PersonnelId == id && !s.IsDeleted);
                if (spouse != null)
                {
                    spouse.IsDeleted = true;
                    spouse.UpdatedAt = DateTime.Now;
                }

                var familyMembers = await _context.PersonnelFamilyMembers
                    .Where(fm => fm.PersonnelId == id && !fm.IsDeleted)
                    .ToListAsync();
                familyMembers.ForEach(fm => { fm.IsDeleted = true; fm.UpdatedAt = DateTime.Now; });

                var workRecords = await _context.PersonnelWorkRecords
                    .Where(wr => wr.PersonnelId == id && !wr.IsDeleted)
                    .ToListAsync();
                workRecords.ForEach(wr => { wr.IsDeleted = true; wr.UpdatedAt = DateTime.Now; });

                var activityRecords = await _context.PersonnelActivityRecords
                    .Where(ar => ar.PersonnelId == id && !ar.IsDeleted)
                    .ToListAsync();
                activityRecords.ForEach(ar => { ar.IsDeleted = true; ar.UpdatedAt = DateTime.Now; });

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "人员信息删除成功！";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PersonnelBasicInfoExists(Guid id)
        {
            return _context.PersonnelBasicInfos.Any(e => e.PersonnelId == id && !e.IsDeleted);
        }

        // AJAX 获取人员列表用于其他模块引用
        [HttpGet]
        public async Task<IActionResult> GetPersonnelList(string term)
        {
            var personnel = await _context.PersonnelBasicInfos
                .Where(p => !p.IsDeleted && (string.IsNullOrEmpty(term) || p.Name.Contains(term)))
                .Select(p => new { 
                    id = p.PersonnelId, 
                    text = $"{p.Name} ({p.IdCard.Substring(p.IdCard.Length - 4)})"
                })
                .Take(20)
                .ToListAsync();

            return Json(personnel);
        }
    }
}