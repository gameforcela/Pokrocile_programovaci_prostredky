namespace Ppt_01
{
    public class VybaveniModel
    {
        public string name { get; set; }
        public DateTime BoughtData { get; set; }
        public DateTime LastRevisionDate { get; set; }
        public bool NeedsRevision { get; set; }

        public VybaveniModel(string name, DateTime BoughtData, DateTime LastRevisionDate, bool NeedsRevision)
        {
            this.name = name;
            this.BoughtData = BoughtData;
            this.LastRevisionDate = LastRevisionDate;
            this.NeedsRevision = NeedsRevision;
        }
    }
}
