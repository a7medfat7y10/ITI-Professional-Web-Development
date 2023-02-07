using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        double first_num;
        double result;
        public MainWindow()
        {
            InitializeComponent();
        }
        //input
        private void Click_Number(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text == "0")
                ResultBox.Text = "0";
            else
                ResultBox.Text += ((Button)sender).Content.ToString();
        }
        private void Dot(object sender, RoutedEventArgs e)
        {
            if (!ResultBox.Text.Contains("."))
                ResultBox.Text += ".";
        }

        //Operations
        private void Add(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text == String.Empty)
                first_num = 0;
            else
                first_num = Double.Parse(ResultBox.Text);

            OperationsBox.Text = first_num.ToString() + "+";
            ResultBox.Text = "";
        }
        private void Subtract(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text == String.Empty)
                first_num = 0;
            else
                first_num = Double.Parse(ResultBox.Text);

            OperationsBox.Text = first_num.ToString() + "-";
            ResultBox.Text = "";
        }
        private void Multiply(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text == String.Empty)
                first_num = 0;
            else
                first_num = Double.Parse(ResultBox.Text);

            OperationsBox.Text = first_num.ToString() + "x";
            ResultBox.Text = "";
        }
        private void Division(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text == String.Empty)
                first_num = 0;
            else
                first_num = Double.Parse(ResultBox.Text);

            OperationsBox.Text = first_num.ToString() + "/";
            ResultBox.Text = "";
        }

        //Equal
        private void Click_Equal(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text == String.Empty)
                result = 0;
            else if (OperationsBox.Text.Contains("+"))
                result = first_num + Double.Parse(ResultBox.Text);
            else if (OperationsBox.Text.Contains("-"))
                result = first_num - Double.Parse(ResultBox.Text);
            else if (OperationsBox.Text.Contains("x"))
                result = first_num * Double.Parse(ResultBox.Text);
            else if (OperationsBox.Text.Contains("/"))
                result = first_num / Double.Parse(ResultBox.Text);
            else
                result = 0;
            OperationsBox.Text = string.Empty;
            ResultBox.Text = result.ToString();
        }

        //Clear functions
        private void Clear_one(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text.Length > 0)
                ResultBox.Text = ResultBox.Text.Substring(0, ResultBox.Text.Length - 1);
        }
        private void Clear_All(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = String.Empty;
            OperationsBox.Text = String.Empty;
        }

    }
}
