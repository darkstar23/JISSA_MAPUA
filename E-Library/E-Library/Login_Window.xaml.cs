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
using System.Data.SqlClient;
using System.Configuration;
namespace E_Library
{
    /// <summary>
    /// Interaction logic for Login_Window.xaml
    /// </summary>
    public partial class Login_Window : Window
    {
        public Login_Window()
        {
            InitializeComponent();
        }

        private void textBox_UName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBox_UName.Text = "";
        }

        private void texBox_Pass_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            texBox_Pass.Text = "";
        }

        private void textBox_UName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox_USER = (TextBox)sender;
            textBox_USER.Text = string.Empty;
            textBox_USER.GotFocus -= textBox_UName_GotFocus;

        }

        private void texBox_Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox_PASS = (TextBox)sender;
            textBox_PASS.Text = string.Empty;
            textBox_PASS.GotFocus -= texBox_Pass_GotFocus;
        }

        private void button_Login_Click(object sender, RoutedEventArgs e)
        {



            SqlConnection CRED_CONN = new SqlConnection();

            CRED_CONN.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mike\\Desktop\\E-Library\\E-Library\\E-Library\\BOOK_SAMPLE_DB.mdf;Connect Timeout=30;User ID=" + textBox_UName.Text + ";Password=" + texBox_Pass.Text + "";

            try
            {
                CRED_CONN.Open();

                MessageBox.Show("Connection to DB is a success!");
            }
            catch(Exception DB_EXCEPTION)
            {
                MessageBox.Show(DB_EXCEPTION.Message.ToString());
            }
            
        }
    }
}
