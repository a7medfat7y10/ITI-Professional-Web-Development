using System;
using System.Collections.Generic;
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

namespace task2_form_inputs
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

        private void _ok(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($" Name:   {fName.Text} {lName.Text} \n" +
                $"Gender:   {gender.Text} \n" +
                $"Address:  {address.Text} \n" +
                $"Phone:    {phone.Text} \n" +
                $"Mobile:   {mobile.Text} \n" +
                $"Email:    {email.Text} \n" +
                $"Job Title:   {job_title.Text} \n");
        }

        private void _cancel(object sender, RoutedEventArgs e)
        {
            fName.Text = string.Empty;
            lName.Text = string.Empty;
            address.Text = string.Empty;
            gender.Text = string.Empty;
            phone.Text = string.Empty;
            mobile.Text = string.Empty;
            email.Text = string.Empty;
            job_title.Text = string.Empty;
        }
    }


}
