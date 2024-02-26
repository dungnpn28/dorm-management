using System;
using System.Collections.Generic;

namespace DormitoryManagement.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int? DormitoryId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int Floor { get; set; }

    public int? RoomTypeId { get; set; }

    public int AvailabilityStatus { get; set; }

    public virtual ICollection<Bed> Beds { get; set; } = new List<Bed>();

    public virtual Dormitory? Dormitory { get; set; }

    public virtual ICollection<ElectricityBill> ElectricityBills { get; set; } = new List<ElectricityBill>();

    public virtual RoomType? RoomType { get; set; }

    public virtual ICollection<WaterBill> WaterBills { get; set; } = new List<WaterBill>();
}
