using MAS_2.Data;
using MAS_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAS_2.Controllers
{
    public class MateracLateksowyController : Controller
    {
        private readonly MVCDBContext mVCDB;

        public MateracLateksowyController(MVCDBContext mVCDB)
        {
            this.mVCDB = mVCDB;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var materace = await mVCDB.MateracLateksowy.ToListAsync();
            return View(materace);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MateracLateksowy materac)
        {
            var m = new MateracLateksowy()
            {
                ID = materac.ID,
                Rodzaj = materac.Rodzaj,
                Cecha = materac.Cecha,
                Wysokosc = materac.Wysokosc,
                Sztywnosc = materac.Sztywnosc,
                Przeznaczenie = materac.Przeznaczenie,
                Cena = materac.Cena,
                Type = materac.Type,
            };

            await mVCDB.MateracLateksowy.AddAsync(m);
            await mVCDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ml = await mVCDB.MateracLateksowy.FindAsync(id);
            if (ml == null)
            {
                return HttpNotFound();
            }
            mVCDB.MateracLateksowy.Remove(ml);
            await mVCDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
