using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class SettingUpdateDto
    {
        public string? SettingName { get; set; }

        public string? SettingValue { get; set; }
    }
}