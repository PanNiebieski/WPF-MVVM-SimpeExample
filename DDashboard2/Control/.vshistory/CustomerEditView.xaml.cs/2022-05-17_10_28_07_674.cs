using DData;
using DSevices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DDashboard.Controls
{
    /// <summary>
    /// Interaction logic for CustomerEditView.xaml
    /// </summary>
    public partial class CustomerEditView : UserControl
    {
        private ICustomersRepository _repository = new FakeCustomersRepository();
        private Customer _customer = null;

        public CustomerEditView()
        {
            InitializeComponent();
        }

        public int CustomerId
        {
            get { return (int)GetValue(CustomerIdProperty); }
            set { SetValue(CustomerIdProperty, value); }
        }

        public static readonly DependencyProperty CustomerIdProperty =
            DependencyProperty.Register("CustomerId", typeof(int),
            typeof(CustomerEditView), new PropertyMetadata(0));

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            _customer = await _repository.GetCustomerAsync(CustomerId);
            DataContext = _customer;
        }

        private async void OnSave(object sender, RoutedEventArgs e)
        {
            // TODO: Validate input... call business rules... etc...
            _customer.FirstName = firstNameTextBox.Text;
            _customer.LastName = lastNameTextBox.Text;
            _customer.Phone = phoneTextBox.Text;
            await _repository.UpdateCustomerAsync(_customer);
        }

        private async void OnReload(object sender, RoutedEventArgs e)
        {
            _customer = await _repository.GetCustomerAsync(CustomerId);
            //DataContext = _customer;
        }
    }
}

