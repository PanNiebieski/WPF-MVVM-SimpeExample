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
        }

        public Task DeleteCustomerAsync(int customerId)
        {
            var c = customers.First(k => k.Id == id);

            customers.Remove(c);
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            var c = customers.First(k => k.Id == id);

            return Task.FromResult(c);
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(customers);
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
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