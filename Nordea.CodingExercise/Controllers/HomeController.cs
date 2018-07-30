using Nordea.CodingExercise.Models;
using Nordea.CodingExercise.Services;
using System.Linq;
using System.Web.Mvc;

namespace Nordea.CodingExercise.Controllers
{
    public class HomeController : Controller
    {
        IParserService _parserService;
        public HomeController()
            : this(new ParserService())
        {
        }

        public HomeController(IParserService parserService)
        {
            _parserService = parserService;
        }

        public ActionResult Index()
        {
            return View(new ParserViewModel() { Parsers = _parserService.GetAllParsers()});
        }

        public JsonResult Parse(ParserViewModel parserViewModel)
        {
            var result = _parserService.Parse(parserViewModel.TextToParse, parserViewModel.Parsers.First());
            return Json(result);
        }
    }
}