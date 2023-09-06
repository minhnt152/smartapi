using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class CardHolderUpdateDto
    {
        public string ChFname { get; set; } = null!;

        public string ChLname { get; set; } = null!;

        public DateTime? ChDob { get; set; }

        public int? ChGender { get; set; }

        public string ChAddr { get; set; } = null!;

        public string ChTel { get; set; } = null!;

        public string? ChEmail { get; set; }

        public byte[]? ChPhotos { get; set; }

    }
}