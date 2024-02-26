using System;
using System.Collections.Generic;

namespace DormitoryManagement.Models;

public partial class ElectricityBill
{
    public int BillId { get; set; }

    public int? RoomId { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public decimal Amount { get; set; }

    public int? PaymentStatus { get; set; }

    public virtual Room? Room { get; set; }
}
