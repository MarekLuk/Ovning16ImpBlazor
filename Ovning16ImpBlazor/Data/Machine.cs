namespace Ovning16ImpBlazor.Data
{
    public class Machine
    {
    
      
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? Color { get; set; }
        public int? Speed { get; set; }
        public bool IsMachnieOnline { get; set; }

        public DateTime LatestDataSent { get; set; }
       

    }
}
