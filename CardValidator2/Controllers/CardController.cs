using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using CardValidator2.Models;
using CardValidator2.Business.Models;
using CardValidator2.Business;

namespace CardValidator2.Controllers
{
    public class CardController : ApiController
    {
        private CardValidator _cardValidator = new CardValidator();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Card/5
        [AcceptVerbs("GET")]
        [ResponseType(typeof(ValidateResult))]
        public ValidateResult Validate(int cardNumber)
        {
            return _cardValidator.Validate(cardNumber);
        }
    }
}