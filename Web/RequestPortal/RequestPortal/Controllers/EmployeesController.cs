using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RequestPortal.RequestPortalDB;

namespace RequestPortal.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly RequestPortalContext _context;

        public EmployeesController(RequestPortalContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var requestPortalContext = _context.Employees.Include(e => e.City).Include(e => e.Company).Include(e => e.Department).Include(e => e.ManagerSsnNavigation).Include(e => e.User);
            return View(await requestPortalContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Company)
                .Include(e => e.Department)
                .Include(e => e.ManagerSsnNavigation)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Ssn == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId");
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId");
            ViewData["ManagerSsn"] = new SelectList(_context.Employees, "Ssn", "Ssn");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ssn,FirstName,LastName,PhoneNumber,Mail,ManagerSsn,UserId,CityId,DepartmentId,CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", employee.CityId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", employee.CompanyId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
            ViewData["ManagerSsn"] = new SelectList(_context.Employees, "Ssn", "Ssn", employee.ManagerSsn);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", employee.UserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", employee.CityId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", employee.CompanyId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
            ViewData["ManagerSsn"] = new SelectList(_context.Employees, "Ssn", "Ssn", employee.ManagerSsn);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", employee.UserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ssn,FirstName,LastName,PhoneNumber,Mail,ManagerSsn,UserId,CityId,DepartmentId,CompanyId")] Employee employee)
        {
            if (id != employee.Ssn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Ssn))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", employee.CityId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", employee.CompanyId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
            ViewData["ManagerSsn"] = new SelectList(_context.Employees, "Ssn", "Ssn", employee.ManagerSsn);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", employee.UserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Company)
                .Include(e => e.Department)
                .Include(e => e.ManagerSsnNavigation)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Ssn == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'RequestPortalContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.Ssn == id)).GetValueOrDefault();
        }
    }
}
