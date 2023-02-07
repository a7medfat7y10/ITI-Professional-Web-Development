using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace task1_InkCanvas_Paint
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

        private void Change_Color(object sender, RoutedEventArgs e)
        {

            switch (((RadioButton)sender).Content.ToString())
            {
                case "Red":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Red;
                    break;

                case "Green":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Green;
                    break;

                case "Blue":

                    InkCan.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
            }
        }

        private void Change_Mode(object sender, RoutedEventArgs e)
        {

            switch (((RadioButton)sender).Content.ToString())
            {
                case "Ink":

                    InkCan.EditingMode = InkCanvasEditingMode.Ink;
                    break;

                case "Select":

                    InkCan.EditingMode = InkCanvasEditingMode.Select;
                    break;

                case "Erase":

                    InkCan.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;

                case "Erase by strock":

                    InkCan.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }

        private void Draw_Shapes(object sender, RoutedEventArgs e)
        {

            switch (((RadioButton)sender).Content.ToString())
            {
                case "Ellipse":

                    InkCan.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                    break;

                case "Rectangle":

                    InkCan.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                    break;
            }
        }

        private void Brush_Size(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content.ToString())
            {
                case "Small":

                    InkCan.DefaultDrawingAttributes.Height = 2;
                    InkCan.DefaultDrawingAttributes.Width = 2;
                    break;

                case "Normal":

                    InkCan.DefaultDrawingAttributes.Height = 4;
                    InkCan.DefaultDrawingAttributes.Width = 4;
                    break;
                case "Large":

                    InkCan.DefaultDrawingAttributes.Height = 6;
                    InkCan.DefaultDrawingAttributes.Width = 6;
                    break;
            }
        }

        private void New(object sender, RoutedEventArgs e)
        {
            InkCan.Strokes.Clear();
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            InkCan.CopySelection();
        }

        private void Cut(object sender, RoutedEventArgs e)
        {
            InkCan.CutSelection();
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            InkCan.Paste();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                InkCan.Strokes.Save(fs);

                fs.Close();
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (openFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);

                InkCan.Strokes = new StrokeCollection(fs);
                fs.Close();
            }
        }


    }
}
