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
    /// Interaction logic for BookViewer.xaml
    /// </summary>
    /// 






    public partial class BookViewer : Window
    {
        public BookViewer()
        {
            InitializeComponent();
            FILL_LIB_DATA();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FILL_LIB_DATA()
        {
            SqlConnection LIB_DB_CONN = new SqlConnection();
            LIB_DB_CONN.ConnectionString = LIB_DB_CONN.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Mike\\Desktop\\E-Library\\E-Library\\E-Library\\BOOK_DB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlCommand LIB_DB_COMMAND = new SqlCommand("SELECT * FROM BOOKS_IN_LIB", LIB_DB_CONN);
            
            try
            {
                LIB_DB_CONN.Open();

                SqlDataAdapter DB_LIB_ADAPTER = new SqlDataAdapter();
                DB_LIB_ADAPTER.SelectCommand = LIB_DB_COMMAND;
                DataTable LIB_DB_DATA = new DataTable("Book Availability");
                DB_LIB_ADAPTER.Fill(LIB_DB_DATA);

                dataGrid_LIB_VIEWER.ItemsSource = LIB_DB_DATA.DefaultView;

                LIB_DB_CONN.Close();

            }
            catch (Exception LIB_DB_EXCEPTION)
            {
                MessageBox.Show(LIB_DB_EXCEPTION.ToString());
            }


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            
        }
    }
}
