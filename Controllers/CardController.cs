using Microsoft.AspNetCore.Mvc;
using CSharpest.Services;


//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 11/3/23
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSharpest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        // GET: <CardsController>
        [HttpGet]
        public String Get()
        {
           return _cardService.Get();
        }
    }
}
