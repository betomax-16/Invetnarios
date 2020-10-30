using GrupoGupar.Services;
using GrupoGupar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GrupoGupar.Controllers
{
    public class MainController
    {
        private MainWindow main;

        public MainController(MainWindow form)
        {
            this.main = form;
        }

        public void OpenTabProductos(string name)
        {
            try
            {
                var result = from FabTab.FabTabItem tab in this.main.tabMain.Items
                             where tab.Name == name
                             select tab;
                if (result.Count() == 0)
                {
                    ProductosView view = new ProductosView();

                    FabTab.FabTabItem item = new FabTab.FabTabItem();
                    item.Name = name;
                    item.Header = name.Replace('_', ' ');
                    item.Content = view;
                    item.IsSelected = true;
                    this.main.tabMain.Items.Add(item);
                }
                else
                {
                    result.First().IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                LogService.Save(this, ex);
                MessageBox.Show(ex.Message, "Error inesperado.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void OpenTabEntradas(string name)
        {
            try
            {
                var result = from FabTab.FabTabItem tab in this.main.tabMain.Items
                             where tab.Name == name
                             select tab;
                if (result.Count() == 0)
                {
                    EntradasView view = new EntradasView();

                    FabTab.FabTabItem item = new FabTab.FabTabItem();
                    item.Name = name;
                    item.Header = name.Replace('_', ' ');
                    item.Content = view;
                    item.IsSelected = true;
                    this.main.tabMain.Items.Add(item);
                }
                else
                {
                    result.First().IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                LogService.Save(this, ex);
                MessageBox.Show(ex.Message, "Error inesperado.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void OpenTabSalidas(string name)
        {
            try
            {
                var result = from FabTab.FabTabItem tab in this.main.tabMain.Items
                             where tab.Name == name
                             select tab;
                if (result.Count() == 0)
                {
                    SalidasView view = new SalidasView();

                    FabTab.FabTabItem item = new FabTab.FabTabItem();
                    item.Name = name;
                    item.Header = name.Replace('_', ' ');
                    item.Content = view;
                    item.IsSelected = true;
                    this.main.tabMain.Items.Add(item);
                }
                else
                {
                    result.First().IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                LogService.Save(this, ex);
                MessageBox.Show(ex.Message, "Error inesperado.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void OpenTabClientes(string name)
        {
            try
            {
                var result = from FabTab.FabTabItem tab in this.main.tabMain.Items
                             where tab.Name == name
                             select tab;
                if (result.Count() == 0)
                {
                    ClientesView view = new ClientesView();

                    FabTab.FabTabItem item = new FabTab.FabTabItem();
                    item.Name = name;
                    item.Header = name.Replace('_', ' ');
                    item.Content = view;
                    item.IsSelected = true;
                    this.main.tabMain.Items.Add(item);
                }
                else
                {
                    result.First().IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                LogService.Save(this, ex);
                MessageBox.Show(ex.Message, "Error inesperado.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
