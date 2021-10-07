using EFCodeFirstLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstLib.Controllers
{
    public class CustomersController
    {
        private readonly AppDbContext _context;

        public CustomersController()
        {
            _context = new AppDbContext();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers
                                        .OrderBy(c => c.Name)
                                        .ToListAsync();
        }


    }
}
