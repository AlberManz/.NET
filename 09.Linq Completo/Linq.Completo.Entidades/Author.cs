using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Completo.Entidades
{
	public class Author
	{
		public int AuthorId { get; set; }
		public string Name { get; set; }

		public Author(int authorId, string name)
		{
			AuthorId = authorId;
			Name = name;
		}

		public static List<Author> Authors()
		{
			return new List<Author>
			{
				new Author(1, "Miguel de Cervantes"),
				new Author(2, "Charles Dickens"),
				new Author(3, "J. R. R. Tolkien"),
				new Author(4, "Antoine de Saint-Exupéry"),
				new Author(5, "Cao Xueqin"),
				new Author(6, "Lewis Car"),
				new Author(7, "Agatha Christie"),
				new Author(8, "C. S. Lewis"),
				new Author(9, "Dan Brown"),
				new Author(10, "J. D. Salinger"),
			};
		}

	}
}
