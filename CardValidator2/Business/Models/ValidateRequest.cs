namespace CardValidator2.Business.Models
{
    public class ValidateRequest
    {
        public decimal CardNumber { get; set; }
        public string ExpiryDate { get; set; }
    }
}