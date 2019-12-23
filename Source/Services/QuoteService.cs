using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var quotes = _context.Quotes.Where(x => x.Actor != null).ToList();

            return quotes
                .OrderBy(x => _randomService.RandomInteger(quotes.Count) > 0)
                .FirstOrDefault();
        }

        public Quote GetAnyQuote(string actor)
        {
            var quotes = _context.Quotes.Where(x => x.Actor.Equals(actor)).ToList();
            
            return quotes
                .OrderBy(x => _randomService.RandomInteger(quotes.Count))
                .FirstOrDefault();
        }
    }
}