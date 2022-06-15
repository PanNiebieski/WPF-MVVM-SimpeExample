using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DData;
using DSevices;

namespace DDashboard.Controls
{

        // This class implements INotifyPropertyChanged
        // to support one-way and two-way bindings
        // (such that the UI element updates when the source
        // has been changed dynamically)
        public class Customer1 : INotifyPropertyChanged
        {
            private string name;
            // Declare the event
            public event PropertyChangedEventHandler PropertyChanged;

            public Customer1() { 


            }

        public Customer1(string value)
        {
            this.name = value;
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }







    public class CustomerEditViewModel : INotifyPropertyChanged
    {
        public ICommand SaveCommand { get; set; }

        public ICommand ReloadCommand { get; set; }

        public async void LoadCustomer()
        {
            Customer = await _repository.
                GetCustomerAsync(CustomerId);
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


        private Customer _customer;
        private ICustomersRepository _repository = new FakeCustomersRepository();

        public CustomerEditViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
            ReloadCommand = new RelayCommand(OnReload);
        }



        public int CustomerId { get; set; }


        private async void OnSave()
        {
            Customer = await _repository.UpdateCustomerAsync(Customer);
        }

        private async void OnReload()
        {
            Customer = await _repository.GetCustomerAsync(CustomerId);
        }
    }



}
