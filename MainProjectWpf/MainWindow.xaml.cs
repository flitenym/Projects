using Brail;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MainProjectWpf
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (List<BrailLetter> brailText, List<string> errorInfo) = BrailTranslater.TranslateText(TextBox.Text);
            if (errorInfo.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errorInfo));
                return;
            }
            BrailPaint.Paint(brailText, Canvas);
        }
    }
}
