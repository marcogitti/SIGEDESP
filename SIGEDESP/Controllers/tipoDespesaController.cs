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
            IEnumerable<tipoDespesaModel> tipoDespesas = _db.tipoDespesas;
            return View(tipoDespesas);
        }
    }
}
