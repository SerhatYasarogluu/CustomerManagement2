using CustomerManagement.BLL;
using CustomerManagement.DAL;
using CustomerManagement.DAL.Absract;
using CustomerManagement.DAL.Context;
using CustomerManagement.DAL.Entity;
using CustomerManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace CustomerUI
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var customerOperations = host.Services.GetRequiredService<CustomerOperations>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nİşlem seçiniz:");
                Console.WriteLine("1. Müşteri ekle");
                Console.WriteLine("2. Müşeri sil");
                Console.WriteLine("3. Müşteri güncelle");
                Console.WriteLine("4. Müşteri listele");
                Console.WriteLine("5. Müşteri Getir");
                Console.WriteLine("6. Exit");
                Console.Write("Seçim yapınız: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        await customerOperations.AddCustomer();
                        break;
                    case "2":
                        await customerOperations.RemoveCustomer();
                        break;
                    case "3":
                        await customerOperations.UpdateCustomer();
                        break;
                    case "4":
                        await customerOperations.ListCustomers();
                        break;
                    case "5":
                        await customerOperations.GetById();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Geçerli işlem gir.");
                        break;
                }

            }
            await host.RunAsync();

        }
        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=.;Database=MyDataBase;Trusted_Connection=True;TrustServerCertificate=True"));
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped<CustomerOperations>(); 
            });


    }
}