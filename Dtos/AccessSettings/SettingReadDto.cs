using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class SettingReadDto
    {
        public int SettingId { get; set; }

        public string? SettingName { get; set; }

        public string? SettingValue { get; set; }
    }
}