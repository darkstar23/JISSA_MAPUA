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
using System.Data;

namespace E_Library
{
    /// <summary>
    /// Interaction logic for Login_Window.xaml
    /// </summary>
    /// 

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

        private void textBox_UName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox_USER = (TextBox)sender;
            textBox_USER.Text = string.Empty;
            textBox_USER.GotFocus -= textBox_UName_GotFocus;

        }

        private void button_Login_Click(object sender, RoutedEventArgs e)
        {



            SqlConnection CRED_CONN_USER = new SqlConnection();
            CRED_CONN_USER.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mike\\Desktop\\E-Library\\E-Library\\E-Library\\USERS_DB.mdf;Integrated Security=True;Connect Timeout=30";



            try
            {
                CRED_CONN_USER.Open();

                SqlCommand USER_COMMAND = new SqlCommand("SELECT * FROM USER_CREDENTIALS WHERE U_NAME='" + textBox_UName.Text + "' AND U_PASS='" + texBox_Pass.Password + "'", CRED_CONN_USER);
                USER_COMMAND.CommandType = CommandType.Text;

                SqlDataAdapter USER_ADAPTER = new SqlDataAdapter();

                USER_ADAPTER.SelectCommand = USER_COMMAND;

                DataSet USER_DATASET = new DataSet();

                USER_ADAPTER.Fill(USER_DATASET);


                if(USER_DATASET.Tables[0].Rows.Count>0)
                {
                    string USER_TYPE1 = "admin";

                    if (USER_TYPE1 == USER_DATASET.Tables[0].Rows[0]["U_TYPE"].ToString())
                    {
                        string USER_NAME = USER_DATASET.Tables[0].Rows[0]["U_NAME"].ToString();
                        string USER_PASS = USER_DATASET.Tables[0].Rows[0]["U_PASS"].ToString();

                        E_Library_System.MainWindow SubWindow = new E_Library_System.MainWindow();

                        SubWindow.Show();

                        this.Close();

                        CRED_CONN_USER.Close();
                    }
                    else
                    {
                        string USER_NAME = USER_DATASET.Tables[0].Rows[0]["U_NAME"].ToString();
                        string USER_PASS = USER_DATASET.Tables[0].Rows[0]["U_PASS"].ToString();
                        MessageBox.Show("you are not an administrator, " + USER_NAME + "!");

                        CRED_CONN_USER.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid username or password.");

                    CRED_CONN_USER.Close();
                }
            }
            catch(Exception DB_EXCEPTION)
            {
                MessageBox.Show(DB_EXCEPTION.Message.ToString());

                CRED_CONN_USER.Close();
            }
            
        }
    }
}
