using GrupoGupar.Controllers;
using GrupoGupar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
        public DbSet<Productos> productos;
        public ProductosView()
        {
            InitializeComponent();
            this.contorller = new ProductosController(this);
            this.contorller.SearchProducts();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.contorller.OpenDetailProductForm();
        }

        private void dgProductos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    Productos producto = (Productos)grid.SelectedItem;
                    this.contorller.OpenDetailProductForm(producto);
                }
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.contorller.SearchProducts();
        }
    }
}
