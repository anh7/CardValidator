using CardValidator2.Business.Models;
using CardValidator2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CardValidator2.Business
{
    public class CardValidator : IDisposable
    {
        private CardValidatorEntities _db = new CardValidatorEntities();
        private List<CardType> _cardTypes = null;
        
        public ValidateResult Validate(decimal cardNumber)
        {
            // Check existence
            var cardId = _db.CardExists(cardNumber);
            var result = new ValidateResult();
            if (cardId < 1)
                result.Result = CardResult.NotExist;

            // Check card type
            if (_cardTypes == null)
            {
                _cardTypes = _db.CardTypes.OrderBy(t => t.RuleOrder).ToList();
            }

            var cardNumberString = cardNumber.ToString();
            foreach (var cardType in _cardTypes)
            {
                if (Regex.IsMatch(cardNumberString, cardType.ValidateRegex))
                {
                    result.CardType = cardType.CardTypeName;
                    if (!string.IsNullOrEmpty(cardType.ExpiryYearCheck))
                    {

                    }
                    break;
                }
            }

            return result;
        }

        #region IDisposable Support

        public void Dispose()
        {
            _cardTypes = null;
            _db.Dispose();
        }

        #endregion
    }
}