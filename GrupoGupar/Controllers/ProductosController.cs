using GrupoGupar.Models;
using GrupoGupar.Models.Joins;
using GrupoGupar.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrupoGupar.Controllers
{
    public class ProductosController
    {
        private ProductosView main;
        private Productos producto;
        public List<ProductoCategoria> productos;

        public ProductosController(ProductosView form)
        {
            this.main = form;
            this.producto = new Productos();
            this.productos = new List<ProductoCategoria>();
            using (InventariosEntities db = new InventariosEntities())
            {
                List<Categorias> categorias = db.Categorias.ToListAsync().Result;
                this.main.cbCategoria.ItemsSource = categorias;
                if (categorias.Count > 0)
                {
                    categorias.Insert(0, new Categorias() { id="", nombre=""});
                    this.main.cbCategoria.SelectedIndex = 0;
                }
            }
        }

        public void OpenDetailProductForm(Productos producto = null)
        {
            CRUDProductoView form = new CRUDProductoView(producto);
            if (form.ShowDialog() == true)
            {
                this.SearchProducts();
            }
        }

        public void SearchProducts()
        {

            using (InventariosEntities db = new InventariosEntities())
            {
                ProductoCategoria producto = new ProductoCategoria();
                producto.id = string.IsNullOrEmpty(this.main.txtCodigo.Text) ? null : this.main.txtCodigo.Text;
                producto.nombre = string.IsNullOrEmpty(this.main.txtNombre.Text) ? null : this.main.txtNombre.Text;
                producto.descripcion = string.IsNullOrEmpty(this.main.txtDescripcion.Text) ? null : this.main.txtDescripcion.Text;
                if (this.main.cbCategoria.SelectedValue != null && !string.IsNullOrEmpty(this.main.cbCategoria.SelectedValue.ToString()))
                {
                    producto.idCategoria = this.main.cbCategoria.SelectedValue.ToString();
                }

                //StringBuilder query = new StringBuilder("select [Productos].[id] ,[Productos].[nombre] ,[descripcion] ,[idCategoria] ,[Categorias].[nombre] as Categoria from productos inner join Categorias on Productos.idCategoria = Categorias.id where ");
                //foreach (PropertyInfo propertyInfo in producto.GetType().GetProperties())
                //{
                //    var data = propertyInfo.GetValue(producto, null);
                //    string value = data == null ? null : data.ToString();
                //    if (!string.IsNullOrEmpty(value))
                //    {
                //        query.Append(string.Concat("Productos.", propertyInfo.Name, " like '", $"%{value}%' and "));
                //    }
                //}

                //if (query.ToString().Substring(query.Length - 6, 5) == "where")
                //{
                //    query = query.Remove(query.Length - 6, 5);
                //}
                //else
                //{
                //    query = query.Remove(query.Length - 5, 4);
                //}

                //this.main.dgProductos.ItemsSource = db.Productos.SqlQuery(query.ToString()).ToList();
                var query = from p in db.Productos
                            join c in db.Categorias on p.idCategoria equals c.id
                            select new ProductoCategoria
                            {
                                id = p.id,
                                nombre = p.nombre,
                                descripcion = p.descripcion,
                                idCategoria = p.idCategoria,
                                Categoria = c.nombre
                            };

                var lambda = this.FiltroLambda<ProductoCategoria>(producto, "id");
                this.productos = query.Where(lambda).ToList();
                this.main.dgProductos.ItemsSource = this.productos;
            }
        }

        public Func<T, bool> FiltroLambda<T>(T obj, string id)
        {
            var lambda = this.GetExpressionAllPropertiesObject(obj, id);
            return lambda.Compile();
        }

        private Expression GetExpression<T>(ParameterExpression param, string propertyName, object propertyValue)
        {
            //var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(param, propertyName);
            Expression expression = null;
            if (typeof(T).GetProperty(propertyName).PropertyType == typeof(string))
            {
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var someValue = Expression.Constant(propertyValue, typeof(string));
                expression = Expression.Call(propertyExp, method, someValue);
            }
            else
            {
                var constant = Expression.Constant(propertyValue);
                expression = Expression.Equal(propertyExp, constant);
            }

            return expression;
        }

        private Expression<Func<T, bool>> GetExpressionAllPropertiesObject<T>(T obj, string id)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, id);
            Expression expression = null;
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (property.GetValue(obj) != null)
                {
                    Expression auxExp = this.GetExpression<T>(parameterExp, property.Name, property.GetValue(obj));
                    if (expression == null)
                    {
                        expression = auxExp;
                    }
                    else
                    {
                        expression = Expression.And(expression, auxExp);
                    }
                }
            }

            if (expression == null)
            {
                var constant = Expression.Constant(null);
                expression = Expression.NotEqual(propertyExp, constant);
            }

            return Expression.Lambda<Func<T, bool>>(expression, parameterExp);
        }
    }
}
