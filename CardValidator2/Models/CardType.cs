//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CardValidator2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CardType
    {
        public int CardTypeId { get; set; }
        public string CardTypeName { get; set; }
        public string ValidateRegex { get; set; }
        public string ExpiryYearCheckMethod { get; set; }
        public string ExpiryYearCheckType { get; set; }
        public int RuleOrder { get; set; }
    }
}
