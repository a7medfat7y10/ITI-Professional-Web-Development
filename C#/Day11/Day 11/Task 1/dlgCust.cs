using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class dlgCust : Form
    {
        public string userText
        {
            get => txtInput.Text;
            set => txtInput.Text = value;
        }
        public dlgCust()
        {
            InitializeComponent();
        }

    }
}
