using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class User
{
    public int UsrId { get; set; }

    public string UsrAcct { get; set; } = null!;

    public string UsrPwd { get; set; } = null!;

    public string UsrFname { get; set; } = null!;

    public string UsrLname { get; set; } = null!;

    public string? UsrTel { get; set; }

    public string? UsrDept { get; set; }
}
