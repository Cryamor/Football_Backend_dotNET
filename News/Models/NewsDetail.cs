using System;
namespace News.Models
{
	public class NewsDetail
	{
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public DateTime CreateTime { get; set; }
        public string PicUrl { get; set; }
    }
}

