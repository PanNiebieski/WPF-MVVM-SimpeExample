using DData;

namespace DSevices
{

    public interface ICustomersRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
    }

    public class FakeCustomersRepository : ICustomersRepository
    {

        public Task<Customer> AddCustomerAsync(Customer customer)
        {
            customers.Add(customer);

            return Task.FromResult(customer);
        }

        public Task DeleteCustomerAsync(int customerId)
        {
            var c = customers.First(k => k.Id == customerId);

            customers.Remove(c);

            return Task.CompletedTask;
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            var c = customers.First(k => k.Id == id);

            var newc = new Customer();

            newc.FirstName = c.FirstName; newc.LastName = c.LastName;
            newc.Street = c.Street; newc.Email = c.Email;
            newc.Phone = c.Phone; newc.City = c.City;

            return Task.FromResult(newc);
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            List<Customer> newList = new List<Customer>(customers);

            return Task.FromResult(newList);
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var c = customers.First(k => k.Id == customer.Id);



            c.FirstName = customer.FirstName; c.LastName = customer.LastName;
            c.Street = customer.Street; c.Email = customer.Email;
            c.Phone = customer.Phone; c.City = customer.City;
            

            return Task.FromResult(c);
        }


        List<Customer> customers = new List<Customer>()
        {
            new Customer()
            {
                City = "Biała Podlaska",
                Email = "C@gmail.com",
                FirstName = "Cezary",
                LastName = "Walenciuk",
                Id = 1,
                Orders = new List<Order>(),
                Phone = "+48 121 231 555",
                State = "Mazowieckie",
                StoreId = 1,
                Street = "Laskowa 12/11",
                Zip = "21-500"

            }
        };



    }
}