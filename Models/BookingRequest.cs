using System;
using System.Collections.Generic;

namespace DormitoryManagement.Models;

public partial class BookingRequest
{
    public int BookId { get; set; }

    public int ResidentId { get; set; }

    public int BedId { get; set; }
}
