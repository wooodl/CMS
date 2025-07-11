using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComprehensiveManagementSystem.Data;
using ComprehensiveManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComprehensiveManagementSystem.Controllers
{
    [Authorize]
    public class OrganizationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organization
        public IActionResult Index()
        {
            return View();
        }

        // GET: Organization/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .Include(o => o.Parent)
                .Include(o => o.Children)
                .Include(o => o.Personnel)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // GET: Organization/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ParentId"] = new SelectList(await GetParentOrganizations(), "Id", "Name");
            return View();
        }

        // POST: Organization/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Type,DisplayOrder,Location,Remark,ParentId")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                organization.CreatedAt = DateTime.Now;
                organization.UpdatedAt = DateTime.Now;
                _context.Add(organization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ParentId"] = new SelectList(await GetParentOrganizations(), "Id", "Name", organization.ParentId);
            return View(organization);
        }

        // GET: Organization/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            ViewData["ParentId"] = new SelectList(await GetParentOrganizations(id), "Id", "Name", organization.ParentId);
            return View(organization);
        }

        // POST: Organization/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,DisplayOrder,Location,Remark,ParentId,CreatedAt")] Organization organization)
        {
            if (id != organization.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    organization.UpdatedAt = DateTime.Now;
                    _context.Update(organization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.Id))
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

            ViewData["ParentId"] = new SelectList(await GetParentOrganizations(id), "Id", "Name", organization.ParentId);
            return View(organization);
        }

        // GET: Organization/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _context.Organizations
                .Include(o => o.Parent)
                .Include(o => o.Children)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }

        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organization = await _context.Organizations
                .Include(o => o.Children)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (organization != null)
            {
                // 检查是否有子机构
                if (organization.Children.Any())
                {
                    TempData["ErrorMessage"] = "不能删除存在子机构的机构，请先删除子机构。";
                    return RedirectToAction(nameof(Delete), new { id = id });
                }

                _context.Organizations.Remove(organization);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // 获取树形数据的API
        [HttpGet]
        [AllowAnonymous] // 临时添加，便于调试
        public async Task<IActionResult> GetTreeData()
        {
            try
            {
                var organizations = await _context.Organizations
                    .OrderBy(o => o.DisplayOrder)
                    .ToListAsync();

                Console.WriteLine($"找到 {organizations.Count} 个机构");
                
                var treeData = BuildTreeData(organizations, null);
                Console.WriteLine($"构建的树形数据节点数: {treeData.Count}");
                
                return Json(new { success = true, data = treeData });
            }
            catch (Exception ex)
            {
                // 记录错误日志
                Console.WriteLine($"GetTreeData error: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return Json(new { success = false, error = ex.Message });
            }
        }

        private bool OrganizationExists(int id)
        {
            return _context.Organizations.Any(e => e.Id == id);
        }

        private async Task<List<Organization>> GetParentOrganizations(int? excludeId = null)
        {
            var query = _context.Organizations.AsQueryable();
            
            if (excludeId.HasValue)
            {
                query = query.Where(o => o.Id != excludeId.Value);
            }

            return await query.OrderBy(o => o.DisplayOrder).ToListAsync();
        }

        private List<object> BuildTreeData(List<Organization> organizations, int? parentId)
        {
            var result = new List<object>();
            var children = organizations.Where(o => o.ParentId == parentId).OrderBy(o => o.DisplayOrder).ToList();

            foreach (var org in children)
            {
                var node = new
                {
                    id = org.Id,
                    title = org.Name,
                    type = org.Type.ToString(),
                    displayOrder = org.DisplayOrder,
                    location = org.Location,
                    remark = org.Remark,
                    children = BuildTreeData(organizations, org.Id)
                };
                result.Add(node);
            }

            return result;
        }
    }
}