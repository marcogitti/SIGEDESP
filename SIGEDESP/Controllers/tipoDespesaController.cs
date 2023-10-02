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
                _db.Descricoes.Add(TipoDespesa);
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
            TipoDespesaModel tipoDespesa = _db.Descricoes.FirstOrDefault(x => x.Id == id);

            if (tipoDespesa == null)
            {
                return NotFound();
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
    }
}
