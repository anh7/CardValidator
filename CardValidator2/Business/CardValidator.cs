using CardValidator2.Business.Models;
using CardValidator2.Models;

namespace CardValidator2.Business
{
    public class CardValidator
    {
        private CardValidatorEntities db = new CardValidatorEntities();
        
        public ValidateResult Validate(int cardNumber)
        {
            var cardId = db.CardExists(cardNumber);
            return new ValidateResult();
        }
    }
}