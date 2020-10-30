using GrupoGupar.Controllers;
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

namespace GrupoGupar.Views
{
    /// <summary>
    /// Lógica de interacción para ProductosView.xaml
    /// </summary>
    public partial class ProductosView : UserControl
    {
        private ProductosController contorller;
        public ProductosView()
        {
            InitializeComponent();
            this.contorller = new ProductosController(this);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.contorller.OpenDetailProductForm();
        }
    }
}
