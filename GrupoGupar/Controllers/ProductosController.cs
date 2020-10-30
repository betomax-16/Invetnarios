using GrupoGupar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoGupar.Controllers
{
    public class ProductosController
    {
        private ProductosView main;

        public ProductosController(ProductosView form)
        {
            this.main = form;
        }

        public void OpenDetailProductForm()
        {
            CRUDProductoView form = new CRUDProductoView();
            form.ShowDialog();
        }
    }
}
