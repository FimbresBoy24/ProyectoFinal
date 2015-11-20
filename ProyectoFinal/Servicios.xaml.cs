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
    /// Lógica de interacción para Servicios.xaml
    /// </summary>
    public partial class Servicios : Window
    {
        public Servicios()
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
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtpre.Text, @"^\d+$"))
            {
                //ProyectoFinal db = new ProyectoFinal();
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                Servicio ser = new Servicio();
                ser.NombreServicio = txtnombre.Text;
                ser.Precio = float.Parse(txtpre.Text);
                db.Servicio.Add(ser);
                db.SaveChanges();
            }
            else { MessageBox.Show("Solo Letras en #nombre y numeros en #precio"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtpre.Text, @"^\d+$") && Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                int id = int.Parse(txtid.Text);
                var ser = db.Servicio.SingleOrDefault(x => x.ServicioId == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
                if (ser != null)
                {
                    ser.NombreServicio = txtnombre.Text;
                    ser.Precio = int.Parse(txtpre.Text);                   
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo Letras en #nombre y numeros en #precio y #ID"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
             if (Regex.IsMatch(txtid.Text, @"^\d+$"))
                {
                    ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                    var reg = from s in db.Servicio
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
                var ser = db.Servicio.SingleOrDefault(x => x.ServicioId == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
                if (ser != null)
                {
                    db.Servicio.Remove(ser);

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
                var reg = from s in db.Servicio
                          where s.ServicioId == id
                          select new
                          {
                              s.NombreServicio,
                              s.Precio
                          };
                dbgrid.ItemsSource = reg.ToList();
            }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }
        }
    }
