using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para Asistentes.xaml
    /// </summary>
    public partial class Asistentes : Window
    {
        public Asistentes()
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
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtape.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txttel.Text, @"^\d+$"))
            {
                //ProyectoFinal db = new ProyectoFinal();
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                Asistente asi = new Asistente();
                asi.Nombre = txtnombre.Text;
                asi.Apellido = txtape.Text;
                asi.Telefono = int.Parse(txttel.Text);
                db.Asistente.Add(asi);
                db.SaveChanges();
            }
            else { MessageBox.Show("Solo Letras en #nombre y #direccion y solo numeros en #Telefono "); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtape.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txttel.Text, @"^\d+$") && Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                int id = int.Parse(txtid.Text);
                var asi = db.Asistente.SingleOrDefault(x => x.AsistenteId == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
                if (asi != null)
                {
                    asi.Nombre = txtnombre.Text;
                    asi.Apellido = txtape.Text;
                    asi.Telefono = int.Parse(txttel.Text);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo Letras en #nombre y #apellido y numeros en #telefono y #ID"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtid.Text, @"^\d+$"))
            {
                ProyectoFinal.BD.ProyectoFinal db = new BD.ProyectoFinal();
                var reg = from s in db.Asistente
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
                var reg = from s in db.Asistente
                          where s.AsistenteId == id
                          select new
                          {
                              s.Nombre,
                              s.Apellido,
                              s.Telefono
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
                var asi = db.Asistente.SingleOrDefault(x => x.AsistenteId == id);/*from x in db.Empleado
                      where x.id == id
                      select x;*/
                if (asi != null)
                {
                    db.Asistente.Remove(asi);

                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }
        }
    }
