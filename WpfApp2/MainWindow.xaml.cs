using System.Windows;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp2
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

        private void RichTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string richText = new TextRange(RichTextBox.Document.ContentStart,RichTextBox.Document.ContentEnd).Text;
            if(checkBox.IsChecked == true) 
            {
                if (TextBox.Text == String.Empty) 
                {
                    MessageBox.Show("Write File Name");
                    return;
                }
            File.WriteAllText(TextBox.Text, richText);
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                TextBox.Text = dialog.FileName;
            }
            FlowDocument myFlowDoc = new FlowDocument();
            RichTextBox.Document = myFlowDoc;
            TextRange textRange = new TextRange(
            RichTextBox.Document.ContentStart,
                RichTextBox.Document.ContentEnd
            );
            textRange.Text = File.ReadAllText(dialog.FileName);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument myFlowDoc = new FlowDocument();
            RichTextBox.Document = myFlowDoc;
            TextRange textRange = new TextRange(
                RichTextBox.Document.ContentStart,
                RichTextBox.Document.ContentEnd
            );
            if (TextBox.Text == string.Empty)
            {
                MessageBox.Show("Write File name to textbox");
                return;
            }
            File.WriteAllText(TextBox.Text, textRange.Text);
            textRange.Text = string.Empty;
            TextBox.Text = string.Empty;
        }

        private void ButtonCut_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox.Cut();
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox.Copy();
        }

        private void ButtonPaste_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox.Paste();
        }

        private void ButtonSelectAll_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox.SelectAll();
        }
    }
}