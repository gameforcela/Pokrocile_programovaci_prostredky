namespace Pokrocile_programovaci_prostredky.Api.Data
{
    public class RevizeData
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        public DateTime? DateTime { get; set; }

        public Guid VybaveniId { get; set; }
        public VybaveniData Vybaveni { get; set; } = null!;
    }
}
