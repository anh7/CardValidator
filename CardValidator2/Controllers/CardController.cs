﻿using System.Web.Http;
using System.Web.Http.Description;
using CardValidator2.Business.Models;
using CardValidator2.Business;

namespace CardValidator2.Controllers
{
    public class CardController : ApiController
    {
        private CardValidator _cardValidator = new CardValidator();

        protected override void Dispose(bool disposing)
        {
            _cardValidator.Dispose();
            base.Dispose(disposing);
        }

        // GET: Card/5
        [AcceptVerbs("GET","POST")]
        [ResponseType(typeof(ValidateResponse))]
        public ValidateResponse Validate(ValidateRequest request)
        {
            return new ValidateResponse(_cardValidator.Validate(request));
        }
    }
}