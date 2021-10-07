using EFCodeFirstLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstLib.Controllers
{
    public class OrdersController
    {
        private AppDbContext _context;

        public OrdersController()
        {
            _context = new AppDbContext();
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                        .Include(x => x.Customer)
                        .ToListAsync();
        }
    }
}
