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
    public class RequestFlowsController : Controller
    {
        private readonly RequestPortalContext _context;

        public RequestFlowsController(RequestPortalContext context)
        {
            _context = context;
        }

        // GET: RequestFlows
        public async Task<IActionResult> Index()
        {
            var requestPortalContext = _context.RequestFlows.Include(r => r.ApproverSsnNavigation).Include(r => r.Request);
            return View(await requestPortalContext.ToListAsync());
        }

        // GET: RequestFlows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RequestFlows == null)
            {
                return NotFound();
            }

            var requestFlow = await _context.RequestFlows
                .Include(r => r.ApproverSsnNavigation)
                .Include(r => r.Request)
                .FirstOrDefaultAsync(m => m.RequestFlowId == id);
            if (requestFlow == null)
            {
                return NotFound();
            }

            return View(requestFlow);
        }

        // GET: RequestFlows/Create
        public IActionResult Create()
        {
            ViewData["ApproverSsn"] = new SelectList(_context.Employees, "Ssn", "Ssn");
            ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "RequestId");
            return View();
        }

        // POST: RequestFlows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestFlowId,RequestId,ApproverSsn,CreateDate,CloseDate,Status,Explanation")] RequestFlow requestFlow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestFlow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApproverSsn"] = new SelectList(_context.Employees, "Ssn", "Ssn", requestFlow.ApproverSsn);
            ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "RequestId", requestFlow.RequestId);
            return View(requestFlow);
        }

        // GET: RequestFlows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RequestFlows == null)
            {
                return NotFound();
            }

            var requestFlow = await _context.RequestFlows.FindAsync(id);
            if (requestFlow == null)
            {
                return NotFound();
            }
            ViewData["ApproverSsn"] = new SelectList(_context.Employees, "Ssn", "Ssn", requestFlow.ApproverSsn);
            ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "RequestId", requestFlow.RequestId);
            return View(requestFlow);
        }

        // POST: RequestFlows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestFlowId,RequestId,ApproverSsn,CreateDate,CloseDate,Status,Explanation")] RequestFlow requestFlow)
        {
            if (id != requestFlow.RequestFlowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestFlow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestFlowExists(requestFlow.RequestFlowId))
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
            ViewData["ApproverSsn"] = new SelectList(_context.Employees, "Ssn", "Ssn", requestFlow.ApproverSsn);
            ViewData["RequestId"] = new SelectList(_context.Requests, "RequestId", "RequestId", requestFlow.RequestId);
            return View(requestFlow);
        }

        // GET: RequestFlows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RequestFlows == null)
            {
                return NotFound();
            }

            var requestFlow = await _context.RequestFlows
                .Include(r => r.ApproverSsnNavigation)
                .Include(r => r.Request)
                .FirstOrDefaultAsync(m => m.RequestFlowId == id);
            if (requestFlow == null)
            {
                return NotFound();
            }

            return View(requestFlow);
        }

        // POST: RequestFlows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RequestFlows == null)
            {
                return Problem("Entity set 'RequestPortalContext.RequestFlows'  is null.");
            }
            var requestFlow = await _context.RequestFlows.FindAsync(id);
            if (requestFlow != null)
            {
                _context.RequestFlows.Remove(requestFlow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestFlowExists(int id)
        {
          return (_context.RequestFlows?.Any(e => e.RequestFlowId == id)).GetValueOrDefault();
        }
    }
}
