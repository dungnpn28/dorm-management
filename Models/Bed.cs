using System;
using System.Collections.Generic;

namespace DormitoryManagement.Models;

public partial class Bed
{
    public int BedId { get; set; }

    public int? RoomId { get; set; }

    public int BedNumber { get; set; }

    public virtual ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();

    public virtual Room? Room { get; set; }

    public virtual ICollection<RoomAllocation> RoomAllocations { get; set; } = new List<RoomAllocation>();
}
