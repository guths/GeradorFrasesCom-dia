using System;
using System.Collections.Generic;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            var quoteView = new QuoteView();
            var quote = _service.GetAnyQuote();

            if (quote == null)
                return new NotFoundResult();

            quoteView.Actor = quote.Actor;
            quoteView.Detail = quote.Detail;
            quoteView.Id = quote.Id;

            return new ActionResult<QuoteView>(quoteView);
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            var quoteView = new QuoteView();
            var quote = _service.GetAnyQuote(actor);

            if (quote == null)
                return new NotFoundResult();

            quoteView.Actor = quote.Actor;
            quoteView.Detail = quote.Detail;
            quoteView.Id = quote.Id;

            return new ActionResult<QuoteView>(quoteView);
        }

    }
}
