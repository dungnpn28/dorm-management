using System;
using System.Collections.Generic;

namespace DormitoryManagement.Models;

public partial class RoomAllocation
{
    public int AllocationId { get; set; }

    public int? ResidentId { get; set; }

    public int? BedId { get; set; }

    public DateTime MoveInDate { get; set; }

    public DateTime? MoveOutDate { get; set; }

    public virtual Bed? Bed { get; set; }

    public virtual User? Resident { get; set; }
}
