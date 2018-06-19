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
        
        public ValidateResult Validate(ValidateRequest card)
        {
            var result = new ValidateResult();

            // Check existence
            var cardIdResult = _db.CardExists(card.CardNumber).FirstOrDefault();
            var cardId = card == null || !cardIdResult.HasValue ? -1 : cardIdResult.Value;
            if (cardId < 1)
                result.Result = CardResult.NotExist;

            // Check card type
            if (_cardTypes == null)
            {
                _cardTypes = _db.CardTypes.OrderBy(t => t.RuleOrder).ToList();
            }

            var cardNumberString = card.CardNumber.ToString();
            foreach (var cardType in _cardTypes)
            {
                if ((!string.IsNullOrEmpty(cardType.ValidateRegex) && Regex.IsMatch(cardNumberString, cardType.ValidateRegex)) ||
                    string.IsNullOrEmpty(cardType.ValidateRegex))
                {
                    result.CardType = cardType.CardTypeName;
                    //Check card valid by year
                    if (!string.IsNullOrEmpty(cardType.ExpiryYearCheckMethod) && cardId > 0)
                    {
                        if (cardType.ExpiryYearCheckMethod == "SKIP")
                            result.Result = CardResult.Valid;
                        else
                            result.Result =
                                IsExpiryYearValid(
                                    cardType.ExpiryYearCheckType, 
                                    cardType.ExpiryYearCheckMethod, 
                                    card.ExpiryDate) ?
                                CardResult.Valid : CardResult.Invalid;
                    }
                    break;
                }
            } // End of foreach (var cardType in _cardTypes)


            return result;
        }


        private bool IsExpiryYearValid(string type, string method, string expiryDate)
        {
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(method))
                return true;
            if (string.IsNullOrEmpty(expiryDate))
                return false;
            try
            {
                var methodInfo = Type.GetType(type).GetMethod(method);
                var expiryYear = 0;
                if (int.TryParse((expiryDate.Substring(Math.Max(0, expiryDate.Length - 4))), out expiryYear))
                {
                    var result = methodInfo.Invoke(null, new object[] { expiryYear });
                    var isValid = false;
                    if (result != null && bool.TryParse(result.ToString(), out isValid))
                        return isValid;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
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