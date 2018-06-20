using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardValidator2.Business.Models
{
    public class ValidateResponse
    {
        public ValidateResponse(ValidateResult result)
        {
            Result = result.Result.ToString();
            CardType = result.CardType;
        }
        public string Result { get; set; }
        public string CardType { get; set; }
    }
}