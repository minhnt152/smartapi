using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlCardRepo : ICardRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlCardRepo(SmAccessParkingContext context){
            _context = context;
        }


        public void CreateCard(Card item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }
            _context.Cards.Add(item);
        }

        public void DelCard(Card item)
        {
            if(item==null){
                throw new ArgumentNullException(nameof(item));
            }

           Card itemn = _context.Cards.Single(a => a.CardId == item.CardId);
           itemn.CardState = 3;
        }

        public IEnumerable<Card> GetAllCards()
        {
             return _context.Cards.Where(x => x.CardState !=3).ToArray();
        }

        public IEnumerable<Card> GetCardByChId(int id)
        {
             return _context.Cards.Where(x => x.ChId==id && x.CardState !=3).ToArray();
        }

        public Card GetCardById(int id)
        {
            return _context.Cards.FirstOrDefault(x => x.CardId==id && x.CardState !=3);
        }

        public Card GetCardByPrintId(string id)
        {
            return _context.Cards.FirstOrDefault(x => x.PrintCardId==id && x.CardState !=3);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCard(Card item)
        {
            Card item1 = _context.Cards.Single(x => x.CardId == item.CardId && x.CardState !=3);
            item1 = item;
        }
    }
}