using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface ICardHolderRepo{
        IEnumerable<CardHolder> GetAllCardHolders();
        CardHolder GetCardHolderById(int id);
        void AddRights(int id, AccessRight right);
        void DelRight(int id, AccessRight right);
        void AddCitizenIdCard(int id, CitizenIdCard card);
        void DelCitizenIdCard(int holderId);
        void AddCard(int id, Card card);
        void DelCard(int id, Card card);
        void CreateCardHolder(CardHolder item);
        void UpdateCardHolder(CardHolder item);
        void DelCardHolder(CardHolder item);
        bool SaveChanges();    
    }
}