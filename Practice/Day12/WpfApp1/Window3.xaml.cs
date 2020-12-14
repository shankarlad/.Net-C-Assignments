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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lstBox1.Items.Add(txtAdd.Text);
            txtAdd.Text = "";
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //lstBox1.Items.Remove(lstBox1.SelectedItem);
            lstBox1.Items.RemoveAt(lstBox1.Items.IndexOf(lstBox1.SelectedItem));
        }

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            lstBox2.Items.Add(lstBox1.SelectedItem);
            lstBox1.Items.Remove(lstBox1.SelectedItem);
        }

        private void lstMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            lstBox1.Items.Add(lstBox2.SelectedItem);
            lstBox2.Items.Remove(lstBox2.SelectedItem);
        }
    }
}
