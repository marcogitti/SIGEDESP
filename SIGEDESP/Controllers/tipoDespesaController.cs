using SIGEDESP.Data;
using SIGEDESP.Models;
using Microsoft.AspNetCore.Mvc;

namespace SIGEDESP.Controllers
{
    public class tipoDespesaController : Controller
    {
        readonly private ApplicationDBContext _db;
        
        public tipoDespesaController(ApplicationDBContext db)
        {
            _db=db;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoDespesaModel> tipoDespesas = _db.Descricoes;
            return View(tipoDespesas);
        }
        [HttpPost]
        public IActionResult Cadastrar(TipoDespesaModel tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                _db.Descricoes.Add(tipoDespesa);
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
            tipoDespesaModel tipoDespesa = _db.Descricoes.FirstOrDefault(x => x.Id == id);

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

            return View(tipoDespesa);
        }
    }
}
