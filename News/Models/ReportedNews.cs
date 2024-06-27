using System;
namespace News.Models
{
	public class ReportedNews
	{
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime ReportTime { get; set; }
        public long ReporterId { get; set; }
        public long NewsId { get; set; }
        public string ReporterName { get; set; }
    }
}

