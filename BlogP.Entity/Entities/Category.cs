﻿using BlogP.Core.Entities;

namespace BlogP.Entity.Entities
{
	public class Category: EntityBase
	{
		public Category()
		{

		}

		public Category(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
		public ICollection<Article> Articles { get; set; }
	}
}
