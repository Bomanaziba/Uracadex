using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Uracadex.DatabaseModel;
using Uracadex.Models;

namespace Uracadex.Controllers
{
    public class SNARSController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        
        // GET: SNARS
        public ActionResult Index(string message)
        {
            return View(new HomeViewModel { Message = message });
        }

        public async Task<ActionResult> List()
        {
            return View(await SNARSList());
        }

        // GET: SNARS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sNARS = await SNARS(id);
            if (sNARS == null)
            {
                return HttpNotFound();
            }
            return View(sNARS);
        }

        // GET: SNARS/Create
        public async  Task<ActionResult> Create()
        {
            var model = new SNARS_FormViewModel();

            model.UniversityDropDown = await University();

            return View(model);
        }

        // POST: SNARS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SNARSId,FirstName,LastName,Phone,Email,UniversityId,CourseOfStudy,Category,Request,ResearchInterest")] SNARS sNARS)
        {
            if (ModelState.IsValid)
            {
                _db.SNARS.Add(sNARS);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", new { message= "Thank you" });
            }

            return View(sNARS);
        }

        // GET: SNARS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sNARS = await SNARSEdit(id);

            sNARS.UniversityDropDown = await University();

            if (sNARS == null)
            {
                return HttpNotFound();
            }
            return View(sNARS);
        }

        // POST: SNARS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SNARSId,FirstName,LastName,Phone,Email,UniversityId,CourseOfStudy,Category,Request,ResearchInterest")] SNARS sNARS)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sNARS).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sNARS);
        }

        // GET: SNARS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sNARS = await SNARS(id);
            if (sNARS == null)
            {
                return HttpNotFound();
            }
            return View(sNARS);
        }

        // POST: SNARS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SNARS sNARS = await _db.SNARS.FindAsync(id);
            _db.SNARS.Remove(sNARS);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<List<SelectListItem>> University()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem
            {
                Text = "[Choose...]",
                Value  = "-1"
            });

            var universityList = await _db.Universities.ToListAsync();

            foreach (var uni in universityList)
            {
                items.Add(new SelectListItem
                {
                    Text = uni.Name,
                    Value = uni.Id.ToString()
                });
            }
            return items;
        }

        public async Task<SNARSListViewModel> SNARSList()
        {
            var snars = new SNARSListViewModel();

            var result = await (from d in _db.SNARS
                          join w in _db.Universities on d.UniversityId equals w.Id
                          select new SNARSViewModel
                          {
                              SNARSId = d.SNARSId,
                              LastName = d.LastName,
                              FirstName = d.FirstName,
                              University = w.Name,
                              Email = d.Email,
                              Level = d.Level,
                              Course = d.CourseOfStudy,
                              Request = d.Request,
                              ResearchInterest = d.ResearchInterest
                          }).ToListAsync();

            snars.SNARSList = result;

            return snars;

        }

        public async Task<SNARSViewModel> SNARS(int? id)
        {

            return await (from d in _db.SNARS
                                join w in _db.Universities on d.UniversityId equals w.Id
                                select new SNARSViewModel
                                {
                                    SNARSId = d.SNARSId,
                                    LastName = d.LastName,
                                    FirstName = d.FirstName,
                                    University = w.Name,
                                    Email = d.Email,
                                    Level = d.Level,
                                    Course = d.CourseOfStudy,
                                    Request = d.Request,
                                    ResearchInterest = d.ResearchInterest
                                }).Where(p=>p.SNARSId == id).FirstOrDefaultAsync();
        }

        public async Task<SNARS_FormViewModel> SNARSEdit(int? id)
        {

            return await (from d in _db.SNARS
                          select new SNARS_FormViewModel
                          {
                              SNARSId = d.SNARSId,
                              LastName = d.LastName,
                              FirstName = d.FirstName,
                              UniversityId = d.UniversityId,
                              Email = d.Email,
                              Level = d.Level,
                              CourseOfStudy = d.CourseOfStudy,
                              Request = d.Request,
                              ResearchInterest = d.ResearchInterest
                          }).Where(p => p.SNARSId == id).FirstOrDefaultAsync();
        }
    }
}
