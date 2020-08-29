using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace TPFinal_OlivieriMatias
{
    class Conexion
    {
        //Hace búsquedas
        public DataSet consultador(string query)
        {

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=EMPLEADOS_DB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    return ds;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ups... algo salió mal" + ex);

                    DataSet ds = new DataSet();
                    return ds;
                }

            }
        }


        //Opera en BBDD
        public bool operador (string query)
        {
            bool exito = true;
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=EMPLEADOS_DB;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                


            }
            catch (Exception e)
            {
                exito = false;
                MessageBox.Show("Ups... algo no salió bien..." + e);

            }
           
                return exito;
            
            
        }


        
    }
}
