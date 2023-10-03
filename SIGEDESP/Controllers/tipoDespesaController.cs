using SIGEDESP.Data;
using SIGEDESP.Models;
using Microsoft.AspNetCore.Mvc;

namespace SIGEDESP.Controllers
{
    public class TipoDespesaController : Controller
    {
        readonly private ApplicationDBContext _db;
        
        public TipoDespesaController(ApplicationDBContext db)
        {
            _db=db;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoDespesaModel> tipoDespesa = _db.tipoDespesa;
            return View(tipoDespesa);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(TipoDespesaModel tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                _db.tipoDespesa.Add(tipoDespesa);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id ==0)
            {
                return NotFound();
            }
            TipoDespesaModel tipoDespesa = _db.tipoDespesa.FirstOrDefault(x => x.Id == id);

            if (tipoDespesa == null)
            {
                return NotFound();
            }

            return View(tipoDespesa);
        }

        [HttpPost]
        public IActionResult Editar(TipoDespesaModel tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                _db.tipoDespesa.Update(tipoDespesa);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tipoDespesa);
        }
        [HttpGet]

       public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            TipoDespesaModel tipoDespesa = _db.tipoDespesa.FirstOrDefault(x => x.Id == id);

            if (tipoDespesa == null)
            {
                return NotFound();
            }
            return View(tipoDespesa);
        }
        [HttpPost]

        public IActionResult Excluir(TipoDespesaModel tipoDespesa)
        {
            if (tipoDespesa == null)
            {
                return NotFound();
            }
            _db.tipoDespesa.Remove(tipoDespesa);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
