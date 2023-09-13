using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class SettingInsertDto
    {
        public string? SettingName { get; set; }

        public string? SettingValue { get; set; }
    }
}