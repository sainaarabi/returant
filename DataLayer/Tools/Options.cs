using DataLayer.Tools.Enums;

namespace DataLayer.Tools
{
    public class Options
    {
        public Options() : base()
        {

        }

        public Provider Provider { get; set; }
        public string ConnectionString { get; set; }
    }
}
