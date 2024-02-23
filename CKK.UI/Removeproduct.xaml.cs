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

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for Removeproduct.xaml
    /// </summary>
    public partial class Removeproduct : Window
    {
        public Removeproduct()
        {
            InitializeComponent();
        }
        public int id;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            id = Convert.ToInt32(DeleteId.Text);
            this.DialogResult = true;
            this.Close();
        }
    }
}
