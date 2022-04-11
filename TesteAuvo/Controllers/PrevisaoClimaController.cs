using System.Web.Mvc;
using TesteAuvo.Data;
using TesteAuvo.Repositories;

namespace TesteAuvo.Controllers
{
    public class PrevisaoClimaController : Controller
    {
        private IClimaTempoRepository _climaRepository;

        private ClimaTempoDbContext db = new ClimaTempoDbContext();

        public PrevisaoClimaController()
        {
           _climaRepository = new ClimaTempoRepository(new ClimaTempoDbContext());
        }


        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Index(int? CidadeId)
        {
            var previsaoSemanal = _climaRepository.FindClimaSemanal(CidadeId);

            ViewBag.CidadeId = new SelectList(db.Cidades, "Id", "Nome");

            if (Request.IsAjaxRequest())
                return PartialView("_ResultadoPrevisaoSemanal", previsaoSemanal);
            return View("Index", previsaoSemanal);
        }

        [ChildActionOnly]
        public ActionResult PrevisaoClimaTempMaxima()
        {
            var previsaoClimaTempMaxima = _climaRepository.FindClimaMaximo();
                
            return PartialView("_PrevisaoClimaTempMaxima", previsaoClimaTempMaxima);
        }

        [ChildActionOnly]
        public ActionResult PrevisaoClimaTempMinima()
        {
            var previsaoClimaTempMinima = _climaRepository.FindClimaMinimo();

            return PartialView("_PrevisaoClimaTempMinima", previsaoClimaTempMinima);
        }
  
    }
}
