using System;
using System.Threading.Tasks;
using EFCodeFirstLib;
using EFCodeFirstLib.Controllers;

namespace EFCodeFirst
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var ordCtrl = new OrdersController();
            var orders = await ordCtrl.GetAll();
            orders.ForEach(o => Console.WriteLine($"{o.Description} | {o.Customer.Name}"));
            var custCtrl = new CustomersController();
            var customers = await custCtrl.GetAll();
            customers.ForEach(c => Console.WriteLine(c.Name));
        }
    }
}
