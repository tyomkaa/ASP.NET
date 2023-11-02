using MAS_2.Data;
using MAS_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAS_2.Controllers
{
    public class KlientController : Controller
    {
        private readonly MVCDBContext mVCDB;

        public KlientController(MVCDBContext mVCDB)
        {
            this.mVCDB = mVCDB;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var klients = await mVCDB.Klient.ToListAsync();
            return View(klients);
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
        public async Task<IActionResult> Create(Klient klient)
        {
            var k = new Klient()
            {
                ID = klient.ID,
                Imie = klient.Imie,
                Nazwisko = klient.Nazwisko,
                Email = klient.Email,
                NumerTelefonu = klient.NumerTelefonu
            };

            await mVCDB.Klient.AddAsync(k);
            await mVCDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var kl = await mVCDB.Klient.FindAsync(id);
            if (kl == null)
            {
                return HttpNotFound();
            }
            mVCDB.Klient.Remove(kl);
            await mVCDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
