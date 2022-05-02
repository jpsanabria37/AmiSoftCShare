using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using AmiSoftCShare.Models;

namespace MvcMovie.Controllers
{
    public class TipoDocumentoController : Controller
    {
        // 
        private readonly amisoftdatabaseContext _context;

        public TipoDocumentoController(amisoftdatabaseContext context){
            _context = context;
        }
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            IEnumerable<TipoDocumento> colTipoDocumentos = _context.TipoDocumentos;
            return View(colTipoDocumentos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoDocumento tipoDocumento){
            try
            {
                if(ModelState.IsValid){
                    _context.TipoDocumentos.Add(tipoDocumento);
                    _context.SaveChanges();
                    TempData["ResultOk"] = "Record added Successfully!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}