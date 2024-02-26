using System;
using System.Collections.Generic;

namespace DormitoryManagement.Models;

public partial class Dormitory
{
    public int DormitoryId { get; set; }

    public string DormitoryName { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
