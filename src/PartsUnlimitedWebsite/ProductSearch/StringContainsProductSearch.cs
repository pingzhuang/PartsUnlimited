using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PartsUnlimited.Models;

namespace PartsUnlimited.ProductSearch
{
    public class StringContainsProductSearch : IProductSearch
    {
        private readonly IPartsUnlimitedContext _context;

        public StringContainsProductSearch(IPartsUnlimitedContext context)
        {
            _context = context;
        }

		// TODO: Change this to return List of ProductViewModel?
        public async Task<IEnumerable<Product>> Search(string query)
        {
			try
			{
				var cleanQuery = query;
				
				var q = _context.Products
					.Where(p => p.Title.ToLower().Contains(cleanQuery));

				return await q.ToListAsync();
			}
			catch
			{
				return new List<Product>();
			}
        }

	}
}
