using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardValidator2.Business.Models
{
    public class ValidateResult
    {
        public ValidateResult()
        {
            Result = CardResult.NotExist;
            CardType = "Unknown";
        }
        public CardResult Result { get; set; }
        public string CardType { get; set; }
    }

    public enum CardResult
    {
        Valid = 1,
        Invalid,
        NotExist
    }
}