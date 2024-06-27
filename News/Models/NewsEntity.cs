using System;
namespace News.Models
{
	public class NewsEntity
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Tags { get; set; }
		public DateTime CreateTime { get; set; }
		public bool HasPic { get; set; }
		public bool HasVideo { get; set; }
	}
}

