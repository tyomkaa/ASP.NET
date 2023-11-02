using MAS_2.Data;
using MAS_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MAS_2.Controllers
{
    public class ZgloszenieController : Controller
    {
        private readonly MVCDBContext mVCDB;

        public ZgloszenieController(MVCDBContext mVCDB)
        {
            this.mVCDB = mVCDB;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var zgloszenia = await mVCDB.Zgloszenies
                .Include(z => z.Klient)
                .Include(z => z.MateracLateksowy)
                .ToListAsync();

            return View(zgloszenia);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Klienci = mVCDB.Klient.ToList();
            ViewBag.Materace = mVCDB.MateracLateksowy.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int klientID, int materacID, Zgloszenie zgloszenie)
        {
            var klient = await mVCDB.Klient.FindAsync(klientID);
            var materac = await mVCDB.MateracLateksowy.FindAsync(materacID);

            if (klient == null || materac == null)
            {
                return HttpNotFound();
            }

            var z = new Zgloszenie()
            {
                Klient = klient,
                MateracLateksowy = materac,
                DataZainicjalizowania = DateTime.Now,
                DataZrealizowania = DateTime.Now.AddDays(7), 
                Status = "w trakcie przetwarzania"
            };

            await mVCDB.Zgloszenies.AddAsync(z);
            await mVCDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var zgloszenie = await mVCDB.Zgloszenies.FindAsync(id);
            if (zgloszenie == null)
            {
                return HttpNotFound();
            }

            return View(zgloszenie);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var zgloszenie = await mVCDB.Zgloszenies.FindAsync(id);
            if (zgloszenie == null)
            {
                return HttpNotFound();
            }

            zgloszenie.Status = status;
            await mVCDB.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var zgloszenie = await mVCDB.Zgloszenies.FindAsync(id);
            if (zgloszenie == null)
            {
                return HttpNotFound();
            }

            mVCDB.Zgloszenies.Remove(zgloszenie);
            await mVCDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var zgloszenie = await mVCDB.Zgloszenies
                .Include(z => z.Klient)
                .Include(z => z.MateracLateksowy)
                .FirstOrDefaultAsync(z => z.ID == id);

            if (zgloszenie == null)
            {
                return HttpNotFound();
            }

            return View(zgloszenie);
        }

    }
}
