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

namespace task3_bonus_text_editor
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

        private void _setText(object sender, RoutedEventArgs e)
        {
            _text.Text = "Replace default text with initial text value";
        }

        private void _SelectAll(object sender, RoutedEventArgs e)
        {
            _text.Focus();
            _text.SelectAll();
        }

        private void _Clear(object sender, RoutedEventArgs e)
        {
            _text.Clear();
        }

        private void _prepend(object sender, RoutedEventArgs e)
        {
            _text.Text = "*** Prepended text *** " + _text.Text;
        }

        private void _insert(object sender, RoutedEventArgs e)
        {
            _text.Text = _text.Text.Insert(_text.CaretIndex, " *** inserted text *** ");
        }

        private void _append(object sender, RoutedEventArgs e)
        {
            _text.AppendText("*** appended text ***");
        }

        private void _cut(object sender, RoutedEventArgs e)
        {
            _text.Cut();
            if (Clipboard.ContainsText(TextDataFormat.Text))
                MessageBox.Show($" Cut: {Clipboard.GetText(TextDataFormat.Text)}");
            else
                MessageBox.Show($" Select text to cutt first");
        }

        private void _paste(object sender, RoutedEventArgs e)
        {
            _text.Paste();
        }

        private void _undo(object sender, RoutedEventArgs e)
        {
            _text.Undo();
        }

        private void left(object sender, RoutedEventArgs e)
        {
            _text.TextAlignment = TextAlignment.Left;
        }

        private void center(object sender, RoutedEventArgs e)
        {
            _text.TextAlignment = TextAlignment.Center;

        }

        private void right(object sender, RoutedEventArgs e)
        {
            _text.TextAlignment = TextAlignment.Right;

        }

        private void _editable(object sender, RoutedEventArgs e)
        {
            _text.IsReadOnly = false;

        }

        private void _readOnly(object sender, RoutedEventArgs e)
        {
            _text.IsReadOnly = true;
        }
    }
}
