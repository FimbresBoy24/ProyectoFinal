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
    /// <summary>
    /// Lógica de interacción para Proveedores.xaml
    /// </summary>
    public partial class Proveedores : Window
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtdir.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtgiro.Text, @"^[a-zA-Z]+$"))
            {
            //ProyectoFinal db = new ProyectoFinal();
            ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
            Proveedor pro = new Proveedor();
            pro.NombreProveedor = txtnombre.Text;
            pro.Direccion = txtdir.Text;
            pro.Giro = txtgiro.Text;
            db.Proveedor.Add(pro);
            db.SaveChanges();
           }
            else { MessageBox.Show("Solo Letras en #nombre, #direccion y #giro "); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
             if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtdir.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtgiro.Text, @"^[a-zA-Z]+$")&& Regex.IsMatch(txtid.Text, @"^\d+$"))
                {
            ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
            int id = int.Parse(txtid.Text);
            var pro = db.Proveedor.SingleOrDefault(x => x.ProveedorId == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
            if(pro != null){
                pro.NombreProveedor = txtnombre.Text;
                pro.Direccion = txtdir.Text;
                pro.Giro = txtgiro.Text;
                db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo Letras en #nombre, #direccion y #giro y numeros en #ID"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
                {
                    ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                    var reg = from s in db.Proveedor
                        select s;
                        dbgrid.ItemsSource = reg.ToList();
                }
                else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
             if (Regex.IsMatch(txtid.Text, @"^\d+$"))
                {
            ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
            int id = int.Parse(txtid.Text);
            var reg = from s in db.Proveedor
                      where s.ProveedorId == id
                      select new
                      {
                          s.NombreProveedor,
                          s.Direccion,
                          s.Giro
                      };
            dbgrid.ItemsSource = reg.ToList();
        }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                int id = int.Parse(txtid.Text);
                var pro = db.Proveedor.SingleOrDefault(x => x.ProveedorId == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
                if (pro != null)
                {
                    db.Proveedor.Remove(pro);

                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }
        }
    }
