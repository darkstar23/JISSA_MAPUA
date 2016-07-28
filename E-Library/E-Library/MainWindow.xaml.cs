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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace E_Library_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BOOK_REGISTER_Click(object sender, RoutedEventArgs e)
        {
            label.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void E_Library_System_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void E_Library_System_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BOOK_ADD_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection CRED_CONN_LIB = new SqlConnection();
            CRED_CONN_LIB.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mike\\Desktop\\E-Library\\E-Library\\E-Library\\BOOK_DB.mdf;Integrated Security=True;Connect Timeout=30";


            try
            {
                CRED_CONN_LIB.Open();

                /*
                 * String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES(@id,@username,@password, @email)";

                SqlCommand command = new SqlCommand(query, db.Connection);
                command.Parameters.Add("@id","abc");
                command.Parameters.Add("@username","abc");
                command.Parameters.Add("@password","abc");
                command.Parameters.Add("@email","abc");

                command.ExecuteNonQuery();
                */

                String DB_QUERY = "INSERT INTO BOOKS_IN_LIB (CALL_NUM, BOOK_TITLE, BOOK_GENRE) VALUES (@Call_Number, @Book_Title, @Book_Genre)";

                SqlCommand LIB_COMMAND = new SqlCommand(DB_QUERY, CRED_CONN_LIB);

                //this.ComboBox.GetItemText(this.ComboBox.SelectedItem);
                //MessageBox.Show(selected);
                

                LIB_COMMAND.Parameters.AddWithValue("@Call_Number", textBox_CALL_NUM.Text);
                LIB_COMMAND.Parameters.AddWithValue("@Book_Title", textBox_BOOK_DESCRIPT.Text);

                LIB_COMMAND.Parameters.AddWithValue("@Book_Genre", textBox_BOOK_GENRE.SelectedValue.ToString());

                LIB_COMMAND.ExecuteNonQuery();

                MessageBox.Show("Book added to Library!");

                CRED_CONN_LIB.Close();
                
            }
            catch (Exception DB_EXCEPTION)
            {
                MessageBox.Show(DB_EXCEPTION.Message.ToString());

                CRED_CONN_LIB.Close();
            }
        }
    }
}
