using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Dtos;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlCardHolderRepo : ICardHolderRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlCardHolderRepo(SmAccessParkingContext context){
            _context = context;
        }

        public void AddCard(int id, Card card)
        {
            Card item = _context.Cards.FirstOrDefault(x=>x.CardId==card.CardId);
            if(item!=null)
            {
                item.ChId=id;
            }
        }

        public void AddCitizenIdCard(int id, CitizenIdCard card)
        {
            var items = _context.CitizenIdCards.Where(x=>x.ChId == id);
            if(items.Count()<=0){
                card.ChId = id;
                _context.CitizenIdCards.Add(card);
            }
        }

        public void AddRights(int id, AccessRight right)
        {
            AccessRightHolder arh = new AccessRightHolder();
            arh.RightId = right.RightId;
            arh.ChId = id;
            _context.AccessRightHolders.Add(arh);  
        }

        public void CreateCardHolder(CardHolder item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }            
            _context.CardHolders.Add(item);
        }

        public void DelCard(int id, Card card)
        {
            Card item = _context.Cards.FirstOrDefault(x=>x.CardId==card.CardId);
            if(item.ChId==id)
            {
                item.ChId=null;
            }
        }

        public void DelCardHolder(CardHolder item)
        {
            CardHolder item1 = _context.CardHolders.Single(a => a.ChId == item.ChId);
            item1.ChType = 0; //Del
        }

        public void DelCitizenIdCard(int holderId)
        {
            _context.CitizenIdCards.Remove(_context.CitizenIdCards.FirstOrDefault(x=>x.ChId==holderId));
        }

        public void DelRight(int id, AccessRight right)
        {
            _context.AccessRightHolders.Remove(_context.AccessRightHolders.FirstOrDefault(x=>x.ChId==id&&x.RightId==right.RightId));
        }

        public IEnumerable<CardHolder> GetAllCardHolders()
        {
            return _context.CardHolders.Where(x=> x.ChType>0).ToArray();
        }

        public CardHolder GetCardHolderById(int id)
        {
            return _context.CardHolders.FirstOrDefault(item => item.ChId == id && item.ChType >0);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCardHolder(CardHolder item)
        {
            CardHolder item1 = _context.CardHolders.Single(a => a.ChId == item.ChId && item.ChType >0);
            item1=item;
        }
    }
}