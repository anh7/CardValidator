using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardValidator2.Business.Models
{
    public class ValidateResult
    {
        public Result Result { get; set; }
        public string CardType { get; set; }
    }

    public enum Result
    {
        Valid = 1,
        Invalid,
        NotExist
    }
}