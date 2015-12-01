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
    /// Lógica de interacción para Cuentas.xaml
    /// </summary>
    public partial class Cuentas : Window
    {
        public Cuentas()
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
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtcontra.Text, @"^[a-zA-Z]+$"))
            {
                //ProyectoFinal db = new ProyectoFinal();
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                CuentaProveedor cue = new CuentaProveedor();
                cue.Usuario = txtnombre.Text;
                cue.Contrasena = txtcontra.Text;
                db.CuentaProveedor.Add(cue);
                db.SaveChanges();
            }
            else { MessageBox.Show("Solo Letras en #nombre y #contrasena "); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtcontra.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                int id = int.Parse(txtid.Text);
                var cue = db.CuentaProveedor.SingleOrDefault(x => x.CuentaId == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
                if (cue != null)
                {
                    cue.Usuario = txtnombre.Text;
                    cue.Contrasena = txtcontra.Text;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo Letras en #nombre, y #contrasena y numeros en #ID"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                var reg = from s in db.CuentaProveedor
                          select s;
                dbgrid.ItemsSource = reg.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                int id = int.Parse(txtid.Text);
                var cue = db.CuentaProveedor.SingleOrDefault(x => x.CuentaId == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
                if (cue != null)
                {
                    db.CuentaProveedor.Remove(cue);

                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                int id = int.Parse(txtid.Text);
                var reg = from s in db.CuentaProveedor
                          where s.CuentaId == id
                          select new
                          {
                              s.Usuario,
                              s.Contrasena
                          };
                dbgrid.ItemsSource = reg.ToList();
            }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }
    }
}
