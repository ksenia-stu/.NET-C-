using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11CarOwnersEF
{
	public class Owner
	{
		//owner id
		public int Id { get; set; }

		//owner name
		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		//number of cars owner has
		[NotMapped]
		int CarsNumber 
		{ get 
			{
				return CarsInGarage.Count();
			} 
		} // compute only, don't store in DB

		//photo of owner
		public byte[] Photo { get; set; } // blob

		//cars owner has
		public ICollection<Car> CarsInGarage { get; set; } // one to many
	}
}
