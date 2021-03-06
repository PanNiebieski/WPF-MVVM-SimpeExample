using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDashboard.Control
{
    public class CustomerEditViewModel : INotifyPropertyChanged
    {
        private Customer _customer;
        private ICustomersRepository _repository = new CustomersRepository();

        public CustomerEditViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                if (value != _customer)
                {
                    _customer = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Customer"));
                }
            }
        }

        public Guid CustomerId { get; set; }
        public ICommand SaveCommand { get; set; }

        public async void LoadCustomer()
        {
            Customer = await _repository.GetCustomerAsync(CustomerId);
        }

        private async void OnSave()
        {
            Customer = await _repository.UpdateCustomerAsync(Customer);
        }
    }
}
