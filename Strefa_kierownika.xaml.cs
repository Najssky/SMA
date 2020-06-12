using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirmaApp
{

    public partial class Strefa_kierownika : Window
    {
      
        public Strefa_kierownika()
        {
            InitializeComponent();
        }
        public void UserAdd_Click(object sender, RoutedEventArgs e)
        {
            string imie = Imie.Text;
            string nazwisko = Nazwisko.Text;
            string login = Login.Text;
            string haslo = Haslo.Text;
            string stanowisko = ((ComboBoxItem)Stanowisko.SelectedItem).Tag.ToString();
            int stanValue = int.Parse(stanowisko);


            SqlConnection conn = new SqlConnection
            {
                ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=F:\FIRMAAPPEXE\FIRMAAPP\BIN\DEBUG\SMADB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            };
            conn.Open();
            string query = "INSERT INTO Uzytkownicy (Imie,Nazwisko,Login,Haslo,Id_stanowiska) VALUES ( @imie,@nazwisko,@login,@haslo,@stanowisko)";



            if ((imie == "") || (nazwisko == "") || (login == "") || (haslo == ""))
            {
                MessageBox.Show("Uzupełnij wszystkie pola");
            }
            else
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@imie", imie);
                cmd.Parameters.AddWithValue("@nazwisko", nazwisko);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@haslo", haslo);
                cmd.Parameters.AddWithValue("@stanowisko", stanValue);
                SqlDataReader useradd = cmd.ExecuteReader(); 

                MessageBox.Show("Pomyślnie dodano użytkownika");
            }

        }
        public void UserDelete_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;

            SqlConnection conn = new SqlConnection
            {
                ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=F:\FIRMAAPPEXE\FIRMAAPP\BIN\DEBUG\SMADB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            };
            conn.Open();
            string querydel = "DELETE FROM Uzytkownicy WHERE Login=@login";
            SqlCommand cmd = new SqlCommand(querydel, conn);
            cmd.Parameters.AddWithValue("@login", login);
            SqlDataReader userdelete = cmd.ExecuteReader();
            MessageBox.Show("Pomyślnie usunięto użytkownika");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Panel_glowny back = new Panel_glowny();
            back.Show();
            this.Close();
        }
    }
}
