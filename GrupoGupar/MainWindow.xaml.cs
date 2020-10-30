using GrupoGupar.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrupoGupar
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainController controller;
        public MainWindow()
        {
            InitializeComponent();
            this.controller = new MainController(this);
        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            RibbonButton btn = (RibbonButton)sender;
            this.controller.OpenTabProductos(btn.Label);
        }

        private void BtnEntradas_Click(object sender, RoutedEventArgs e)
        {
            RibbonButton btn = (RibbonButton)sender;
            this.controller.OpenTabEntradas(btn.Label);
        }

        private void BtnSalidas_Click(object sender, RoutedEventArgs e)
        {
            RibbonButton btn = (RibbonButton)sender;
            this.controller.OpenTabSalidas(btn.Label);
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            RibbonButton btn = (RibbonButton)sender;
            this.controller.OpenTabClientes(btn.Label);
        }
    }
}
