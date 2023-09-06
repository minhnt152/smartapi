using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface ICardRepo{
        IEnumerable<Card> GetAllCards();
        Card GetCardById(int id);
        IEnumerable<Card> GetCardByChId(int id);
        Card GetCardByPrintId(string id);
        void CreateCard(Card item);
        void UpdateCard(Card item);
        void DelCard(Card item);
        bool SaveChanges();    
    }
}