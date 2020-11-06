using GrupoGupar.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GrupoGupar.Views
{
    /// <summary>
    /// Lógica de interacción para CRUDProductoView.xaml
    /// </summary>
    public partial class CRUDProductoView : Window
    {
        private Productos producto;
        public List<Categorias> categorias;
        public CRUDProductoView(Productos producto = null)
        {
            InitializeComponent();
            
            using (InventariosEntities db = new InventariosEntities())
            {
                this.categorias = db.Categorias.ToListAsync().Result;
                this.cbCategoria.ItemsSource = this.categorias;
                if (this.categorias.Count > 0)
                {
                    this.cbCategoria.SelectedIndex = 0;
                }
            }
            this.producto = producto;
            if (this.producto != null)
            {
                this.lbTitulo.Content = "Editar Producto";
                this.btnEliminar.Visibility = Visibility.Visible;
                this.txtCodigo.Text = producto.id;
                this.txtNombre.Text = producto.nombre;
                this.txtDescripcion.Text = producto.descripcion;
                this.cbCategoria.SelectedValue = producto.idCategoria;
                this.txtCodigo.IsEnabled = false;
            }
            else
            {
                this.lbTitulo.Content = "Nuevo Producto";
                this.btnEliminar.Visibility = Visibility.Hidden;
                this.producto = new Productos();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            using (InventariosEntities db = new InventariosEntities())
            {
                if (this.lbTitulo.Content == "Nuevo Producto")
                {
                    this.producto.id = this.txtCodigo.Text;
                    this.producto.nombre = this.txtNombre.Text;
                    this.producto.descripcion = this.txtDescripcion.Text;
                    this.producto.idCategoria = this.cbCategoria.SelectedValue.ToString();
                    db.Productos.Add(this.producto);
                }
                else
                {
                    db.Productos.Attach(this.producto);
                    this.producto.id = this.txtCodigo.Text;
                    this.producto.nombre = this.txtNombre.Text;
                    this.producto.descripcion = this.txtDescripcion.Text;
                    this.producto.idCategoria = this.cbCategoria.SelectedValue.ToString();
                }


                db.SaveChanges();
            }
            this.DialogResult = true;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            using (InventariosEntities db = new InventariosEntities())
            {
                db.Productos.Attach(this.producto);
                db.Productos.Remove(this.producto);
                db.SaveChanges();
            }
            this.DialogResult = true;
        }
    }
}
