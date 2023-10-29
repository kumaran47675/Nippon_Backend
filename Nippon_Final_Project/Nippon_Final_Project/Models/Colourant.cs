using System;
using System.Collections.Generic;

namespace Nippon_Final_Project.Models;

public partial class Colourant
{
    public DateOnly Date { get; set; }

    public string Colourants { get; set; } = null!;

    public int BatchNo { get; set; }

    public int Quantity { get; set; }

    public DateOnly? Mfg { get; set; }

    public string? DispensingMachine { get; set; }

    public string RequestId { get; set; } = null!;

    public DateTimeOffset EntryDate { get; set; }

    public int Status { get; set; }
}
