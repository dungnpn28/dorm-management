using System;
using System.Collections.Generic;
using System.Globalization;

namespace DormitoryManagement.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public int MaxBeds { get; set; }

    public decimal? PricePerMonth { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public string PricePerMonthToString => string.Format(new CultureInfo("vi-VN"), "{0:C}", PricePerMonth);

    public string TotalPriceToString => string.Format(new CultureInfo("vi-VN"), "{0:C}", PricePerMonth * 4);
}
