using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class CardHolderReadDto
    {
        public int ChId { get; set; }

        public int? FacId { get; set; }

        public string ChFname { get; set; } = null!;

        public string ChLname { get; set; } = null!;

        public DateTime? ChDob { get; set; }

        public int? ChGender { get; set; }

        public string ChAddr { get; set; } = null!;

        public string ChTel { get; set; } = null!;

        public string? ChEmail { get; set; }

        public byte[]? ChPhotos { get; set; }
        public int? ChType { get; set; }

        public virtual ICollection<AccessRightReadDto> AccessRights { get; set; } = new List<AccessRightReadDto>();

        public virtual ICollection<CardReadDto> Cards { get; set; } = new List<CardReadDto>();

        public virtual CitizenIDCardReadDto? CitizenIdCard { get; set; }

        public virtual FacilityReadDto? Fac { get; set; }

    }
}