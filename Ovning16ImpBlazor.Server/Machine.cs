namespace Ovning16ImpBlazor.Server
{
    
        public class Machine
        {


            public Guid Id { get; set; }

            public string? Name { get; set; }
            public string? Color { get; set; }
            public int? Speed { get; set; }
            public bool IsOnline { get; set; }

            public DateTime LatestDataSent { get; set; }


        }
    
}
