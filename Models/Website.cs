namespace Watcher.Models
{
    public class Website
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Interval { get; set; }
        public int Threshold { get; set; }

        public string User { get; set; }
    }
}
