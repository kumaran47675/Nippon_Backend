using System;
using System.Collections.Generic;

namespace Nippon_Final_Project.Models;

public partial class MasterPage
{
    public string Depot { get; set; } = null!;

    public int UserId { get; set; }

    public string UserName { get; set; } = null!;
}
