﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LvivAdviser.Domain.Entities
{
	[Table("Rating")]
	class Rating
	{
		[Key]
		public int ID { get; set; }

		public int Rate { get; set; }
		public string Comment { get; set; }

		[ForeignKey("User")]
		public int UserID { get; set; }

		public User User { get; set; }

		[ForeignKey("Content")]
		public int ContentID { get; set; }
		
		public Content Content { get; set; }
	}
}
