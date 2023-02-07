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

namespace task1_students_list
{
    public partial class MainWindow : Window
    {
        List<Student> students;
        public MainWindow()
        {
            students = new List<Student>()
            {
                new Student(1, "Marwan Fathy", 24, 90, "123 st.", "/1.jpg" ), 
                new Student(2, "Selim Hashem", 24, 90, "222 st.", "/2.jpg" ),
                new Student(3, "Morad Selim", 24, 90, "345 st.", "/4.jpg" ),
                new Student(4, "Salma Omar", 24, 90, "567 st.", "/3.jpg"),
            };
            InitializeComponent();
            lst.ItemsSource = students;
        }
    }
}
