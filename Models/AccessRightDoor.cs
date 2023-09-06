using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessRightDoor
{
    public int Id { get; set; }

    public int? RightId { get; set; }

    public int? DoorId { get; set; }

    public virtual Door? Door { get; set; }

    public virtual AccessRight? Right { get; set; }
}
