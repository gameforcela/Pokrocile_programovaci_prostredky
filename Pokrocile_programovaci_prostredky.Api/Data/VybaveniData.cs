namespace Pokrocile_programovaci_prostredky.Api.Data
{
    public class VybaveniData
    {
        public Guid Id { get; set; }        
        public string Name { get; set; } = "";        
        public double PriceCzk { get; set; }
        public DateTime BoughtDateTime { get; set; }
        public DateTime LastRevision { get; set; }
    }
}
