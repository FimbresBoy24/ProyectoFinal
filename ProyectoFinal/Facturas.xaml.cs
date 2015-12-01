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
using ProyectoFinal.BD;
using System.Text.RegularExpressions;

namespace ProyectoFinal
{
    public partial class Facturas : Window
    {
        private Servicio tempServicio = null;
        private List<Servicio> AgregarAlGrid;
        public Facturas()
        {
            InitializeComponent();
            AgregarAlGrid = new List<Servicio>();
        }

        private void actualizaGrid()
        {

            var registros = from s in AgregarAlGrid
                            select new
                            {
                                s.ServicioId,
                                s.NombreServicio,
                                s.Precio,
                                s.ProveedorProveedorId,
                            };
            grid.ItemsSource = null;
            grid.ItemsSource = registros;

            tot.Content = string.Format("Total: {0} ", AgregarAlGrid.Sum(x => x.Precio).ToString("C"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (cbpro.SelectedIndex > -1 && cbser.SelectedIndex > -1 && cbasis.SelectedIndex > -1)
            {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();

                int id = int.Parse(cbser.Text);
                Servicio p = db.Servicio.SingleOrDefault(x => x.ServicioId == id);

                if (p != null)
                {
                    tempServicio = p;
                }

                AgregarAlGrid.Add(new Servicio()
                {
                    ServicioId = tempServicio.ServicioId,
                    NombreServicio = tempServicio.NombreServicio,
                    Precio = tempServicio.Precio,
                    ProveedorProveedorId = tempServicio.ProveedorProveedorId,
                });

                actualizaGrid();
                tempServicio = null;
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar un elemento en cada campo", "precaucion", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
            Factura fac = new Factura();

            fac.ServicioServicioId = (int)cbser.SelectedValue;
            fac.Fecha = DateTime.Now;
            fac.AsistenteAsistenteId = (int)cbasis.SelectedValue;
            fac.ProveedorIdProveedor = (int)cbpro.SelectedValue;

            //actualizaGrid();
            db.Factura.Add(fac);
            db.SaveChanges();
            MessageBox.Show("Se Guardaron los datos");
            CleanUp();
                      
        }

        private void Button_Loaded_1(object sender, RoutedEventArgs e)
        {
      
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
    
            cbpro.ItemsSource = db.Proveedor.ToList();
            cbpro.DisplayMemberPath = "NombreProveedor";
            cbpro.SelectedValuePath = "ProveedorId";

            cbasis.ItemsSource = db.Asistente.ToList();
            cbasis.DisplayMemberPath = "AsistenteId";
            cbasis.SelectedValuePath = "AsistenteId";

            cbser.ItemsSource = db.Servicio.ToList();
            cbser.DisplayMemberPath = "ServicioId";
            cbser.SelectedValuePath = "ServicioId";
            
        }

        private void CleanUp()
        {

            AgregarAlGrid = new List<Servicio>();
            tot.Content = "Total: $0.00";
            grid.ItemsSource = null;
            grid.Items.Refresh();
            //Tmp variable is erased using null
            tempServicio = null;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CleanUp();
        }

        private void cbpro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (cbpro.SelectedIndex > -1 && cbser.SelectedIndex > -1 && cbasis.SelectedIndex > -1)
            {
                MessageBox.Show("El monto " + tot.Content + "\nEl ID del proveedor que le atendio fue: " + cbpro.SelectedValue, "Gracias por su compra", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar un elemento en cada campo", "precaucion", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            }
    }
}
