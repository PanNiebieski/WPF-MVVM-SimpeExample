using DSevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DListCustomers.Controls
{
    public class CustomerListViewModel
    {
        private ICustomersRepository _repository = new CustomersRepository();

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            Customers = new ObservableCollection<Customer>(_repository.GetCustomersAsync().Result);
        }

        public ObservableCollection<Customer> Customers { get; set; }
    }
}
