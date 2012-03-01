using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            bool isCompanyEmpty = false;

            if (string.IsNullOrWhiteSpace(this.companyTextBox.Text))
            {
                isCompanyEmpty = true;

                this.companyError.Text = "Company name is empty";
            }
            else
            {
                this.companyError.Text = string.Empty;
            }

            if (!isCompanyEmpty && !string.IsNullOrWhiteSpace(this.emailTextBox.Text))
            {
                this.customersListView.Items.Add(this.companyTextBox.Text);
            }
        }
    }
}
