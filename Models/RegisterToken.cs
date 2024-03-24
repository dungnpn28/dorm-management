using System;
using System.Collections.Generic;

namespace DormitoryManagement.Models;

public partial class RegisterToken
{
    public int TokenId { get; set; }

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public DateTime Dob { get; set; }

    public DateTime ExpireDate { get; set; }

    public string TokenCode { get; set; } = null!;
}
