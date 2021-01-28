using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11CarOwnersEF
{
	public class Car
	{
		//car id
		public int Id { get; set; }

		//make model
		public string MakeModel { get; set; }
		
		//owner Id
		public int OwnerId { get; set; }

		//car's owner
		public Owner Owner { get; set; }
	}
}
