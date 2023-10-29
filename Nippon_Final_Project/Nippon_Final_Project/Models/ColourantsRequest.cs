namespace Nippon_Final_Project.Models
{
    public class ColourantsRequest
    {
        public DateOnly Date { get; set; }

        public string Colourants { get; set; } = null!;

        public int BatchNo { get; set; }

        public int Quantity { get; set; }

        public DateOnly? Mfg { get; set; }

        public string? DispensingMachine { get; set; }

        

       

       

    }
}
