using CustomerManagement.DAL.Absract;
using CustomerManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerManagement.BLL
{
    public class CustomerOperations
    {
        private IRepository<Customer> _customerRepository;

        bool validPhone = false;
        
        public CustomerOperations(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            
        }

        public async Task AddCustomer()
        {
            Console.Write("Müşteri ismi: ");
            string name = Console.ReadLine();
            string phoneNumber = string.Empty;
            while (!validPhone)
            {
                Console.Write("Telefon numarası: ");
                phoneNumber = Console.ReadLine();

                string phoneRegex = @"^(\+90|0)([0-9]{10})$";
                Regex regex = new Regex(phoneRegex);

                if (!regex.IsMatch(phoneNumber))
                {
                    Console.WriteLine("Geçerli bir Türk telefon numarası girin. Örnek: +905551234567 veya 05551234567");
                }
                else
                {
                    validPhone = true;
                }
            }

            var customer = new Customer { Name = name, PhoneNumber = phoneNumber };
            await _customerRepository.AddAsync(customer);
            Console.WriteLine("Müşteri başarıyla eklendi.");
        }

        public async Task RemoveCustomer()
        {
            Console.Write("Silinecek Müşterinin ID'sini giriniz: ");
            int id = int.Parse(Console.ReadLine());
            var customer = await _customerRepository.GetByIdAsync(id);
            await _customerRepository.DeleteAsync(customer);
            Console.WriteLine("Müşteri silindi.");
        }

        public async Task UpdateCustomer()
        {
            Console.Write("Güncellenecek Müşterinin Id sini giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer != null)
            {
                Console.Write("Yeni Müşterinin ismi: ");
                string newName = Console.ReadLine();
                Console.Write("Yeni Müşterinin Telefonu: ");
                string newPhoneNumber = Console.ReadLine();

                customer.Name = newName;
                customer.PhoneNumber = newPhoneNumber;
                await _customerRepository.UpdateAsync(customer);
                Console.WriteLine("Müşteri başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Böyle bir müşteri yok.");
            }
        }

        public async Task GetById()
        {
            Console.Write("Getirilmesini istediğiniz Müşteri Id sini giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            var customer=await _customerRepository.GetByIdAsync(id);
            if (customer != null)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.PhoneNumber}");
            }
            else { Console.WriteLine("Böyle bir Müşteri yok"); };
        }

        public async Task ListCustomers()
        {
            var customers =await _customerRepository.GetAllAsync();
            if (customers.Any())
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.PhoneNumber}");
                }
            }
            else
            {
                Console.WriteLine("Müşteri bulunamadı.");
            }
        }
    }
}
