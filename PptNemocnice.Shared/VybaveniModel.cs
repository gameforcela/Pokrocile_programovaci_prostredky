namespace PptNemocnice.Shared
{
    public class VybaveniModel
    {
        public string name { get; set; }
        public DateTime BoughtData { get; set; }
        public DateTime LastRevisionDate { get; set; }
        public bool NeedsRevision => DateTime.Now - LastRevisionDate > TimeSpan.FromDays(365 * 2);

        public bool IsInEditMode { get; set; }

        public VybaveniModel(string name, DateTime BoughtData, DateTime LastRevisionDate)
        {
            this.name = name;
            this.BoughtData = BoughtData;
            this.LastRevisionDate = LastRevisionDate;
            IsInEditMode = false;
        }
    }
}
