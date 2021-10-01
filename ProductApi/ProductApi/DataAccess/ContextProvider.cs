using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ConfirmationSelfRegistrationServices.DataAccess
{
	public class ContextProvider : DbContext
	{
		public ContextProvider(DbContextOptions<ContextProvider> options)
				: base(options)
		{
		}

		public virtual DbSet<ProductInfo> Products { get; set; }
	}
}
