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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad__WPF_
{

    
    public partial class MainWindow : Window
    {
        String filePath;

        public MainWindow()
        {
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {   
            // Font size
            for (int i = 8; i < 32; i += 2)
            {
                var item = new ComboBoxItem();
                item.Content = i;
                cbFontSize.Items.Add(item);
            }
            // Fonts
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                cbFonts.Items.Add(fontFamily.Source);
            }
            cbFonts.SelectedIndex = 0;
        }
        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
            //int row = tbxEditor.GetLineIndexFromCharacterIndex(tbxEditor.CaretIndex);
            //int col = tbxEditor.CaretIndex - tbxEditor.GetCharacterIndexFromLineIndex(row);
            //tblCursorPosition.Text = "Line: " + (row + 1) + ", Char: " + (col + 1);
            
        }



        private void cbFonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFonts.SelectedItem != null)
            {
                tbxEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cbFonts.SelectedItem);
            }
        }

        private void cbFontSize_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cbFontSize.SelectedItem != null)
            {
                //tbxEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, );
            }
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName =  System.IO.Path.GetFileName(filePath);
            dlg.DefaultExt = ".txt"; 
            dlg.Filter = "Text documents (.txt)|*.txt|RTF documents (.rtf)|*.rtf"; 

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                filePath = dlg.FileName;
                if (Path.GetExtension(filePath) == "rtf")
                {
                    
                }
                else
                {
                    using (TextWriter tr = new StreamWriter(filePath))
                    {
                        tr.Write(new TextRange(tbxEditor.Document.ContentStart, tbxEditor.Document.ContentEnd).Text);
                    }
                }
                

            }
        }



    }
}
