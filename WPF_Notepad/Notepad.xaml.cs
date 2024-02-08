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
using System.Windows.Shapes;

namespace WPF_Notepad
{
    /// <summary>
    /// Interaction logic for Notepad.xaml
    /// </summary>
    public partial class Notepad : Window
    {
        public Notepad()
        {
            InitializeComponent();
        }


        // File Buttons
        #region fileButtons
        private void new_butt_Click(object sender, RoutedEventArgs e)
        {
            text_box.Text = string.Empty;
            text_box.Focus();
        }

        private void open_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            //--------------------
            openFileDialog.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //--------------------
            openFileDialog.ShowDialog();
            //--------------------
            if (openFileDialog.FileName != null)
            {
                text_box.Text = System.IO.File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
            }
        }

        private void save_butt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
            //--------------------
            saveFile.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFile.AddExtension = true;
            //--------------------
            saveFile.ShowDialog();
            //--------------------
            if (saveFile.FileName != null)
            {
                System.IO.File.WriteAllText(saveFile.FileName, text_box.Text, Encoding.UTF8);
            }
        }

        private void exit_butt_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        // Edit Buttons
        #region editButtons
        private void undo_butt_Click(object sender, RoutedEventArgs e)
        {
            text_box.Undo();
        }

        private void redo_butt_Click(object sender, RoutedEventArgs e)
        {
            text_box.Redo();
        }

        private void cut_butt_Click(object sender, RoutedEventArgs e)
        {
            text_box.Cut();
        }

        private void copy_butt_Click(object sender, RoutedEventArgs e)
        {
            text_box.Copy();
        }

        private void paste_butt_Click(object sender, RoutedEventArgs e)
        {
            text_box.Paste();
        }
        

        private void select_all_butt_Click(object sender, RoutedEventArgs e)
        {
            text_box.Focus();
            text_box.SelectAll();
        }
        #endregion

        private void wrap_butt_Click(object sender, RoutedEventArgs e)
        {
            if (wrap_butt.IsChecked == true)
            {
                text_box.TextWrapping = TextWrapping.Wrap;
                text_box.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            else
            {
                text_box.TextWrapping = TextWrapping.NoWrap;
                text_box.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            }
        }

        // Zoom Buttons
        #region zoomButtons
        private void zoom_in_butt_Click(object sender, RoutedEventArgs e)
        {
            if (text_box.FontSize + 4 < 100)
            {
                text_box.FontSize = text_box.FontSize + 4;
            }
            
        }

        private void zoom_out_butt_Click(object sender, RoutedEventArgs e)
        {
            if (text_box.FontSize - 4 > 4)
            {
                text_box.FontSize = text_box.FontSize - 4;
            }
            
        }

        private void default_zoom_butt_Click(object sender, RoutedEventArgs e)
        {
            text_box.FontSize = 16;
        }
        #endregion

        private void help_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Help MessageBox", "Help Section");
        }

        private void about_button_Click(object sender, RoutedEventArgs e)
        {
            WPF_Notepad.about_us ab = new about_us();
            ab.ShowDialog();
        }
    }
}
