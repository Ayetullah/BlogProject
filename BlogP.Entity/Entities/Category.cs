using BlogP.Core.Entities;

namespace BlogP.Entity.Entities
{
	public class Category: EntityBase
	{
		public string Name { get; set; }
		public ICollection<Article> Articles { get; set; }
	}
}
