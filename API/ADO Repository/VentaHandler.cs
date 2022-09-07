using API.Model;
using System.Data;
using System.Data.SqlClient;

namespace API.ADO_Repository
{
    public static class VentaHandler
    {
        public static string ConnectionString = "DESKTOP-L2KI5RL/MSSQLSERVER01;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlconnection))
                {
                    sqlconnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                                ventas.Add(venta);
                            }
                        }
                    }
                    sqlconnection.Close();
                }
            }
            return ventas;
        }
        public static bool CrearVenta(Venta venta)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario] (Comentarios) VALUES (@comentariosParameter)";
                {
                    {
                        SqlParameter comentariosParameter = new SqlParameter("@comentariosParameter", SqlDbType.VarChar) { Value = venta.Comentarios };
                        
                        sqlConnection.Open();

                        using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                        {
                            sqlCommand.Parameters.Add(comentariosParameter);

                            int numberOfRows = sqlCommand.ExecuteNonQuery();

                            if (numberOfRows > 0)

                            { 
                                resultado = true;
                            }
                        }
                        sqlConnection.Close();
                    }

                }
                return resultado;
            }
        }
        public static bool EliminarVenta(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Venta WHERE Id = @id";

                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                sqlParameter.Value = id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close();

                return resultado;
            }
        }
    }
}