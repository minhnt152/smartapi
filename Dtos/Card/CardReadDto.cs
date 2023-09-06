using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class CardReadDto
    {
        public int CardId { get; set; }

        public int? ChId { get; set; }

        public string PrintCardId { get; set; } = null!;

        public int CardType { get; set; }

        public int CardState { get; set; }

        public string CardNo { get; set; } = null!;

        public DateOnly IssDate { get; set; }

        public DateOnly VldDate { get; set; }

        public DateOnly ExpDate { get; set; }

        public string? Descr { get; set; }

    }
}