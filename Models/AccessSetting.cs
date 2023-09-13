using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessSetting
{
    public int SettingId { get; set; }

    public string? SettingName { get; set; }

    public string? SettingValue { get; set; }
}
