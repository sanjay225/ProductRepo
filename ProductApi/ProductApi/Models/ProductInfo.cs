using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
	public class ProductInfo
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

		[Column("created_date")]
		public DateTime CreatedDate { get; set; }
		
		[Key]
		[Column("product_id")]
		public Guid ProductId { get; set; }
	}
}
