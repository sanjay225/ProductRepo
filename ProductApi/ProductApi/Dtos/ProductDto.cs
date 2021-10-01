using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Dtos
{
    public class ProductDto
    {
		[Column("product_desc")]
		[Required]
		public string ProductDesc { get; set; }

		[Column("price")]
		[Required]
		public double Price { get; set; }

		[Column("quantity")]
		[Required]
		[Range(0, 1000, ErrorMessage = "Enter quantity between 0 to 1000")]
		public int Quantity { get; set; }

	}
}
