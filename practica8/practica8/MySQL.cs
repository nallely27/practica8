using System;
using MySql.Data.MySqlClient;
namespace practica8
{
	public class MySQL
	{
		protected MySqlConnection myConnection;
		public MySQL ()
		{
		}
		protected void abrirConexion(){
			string connectionString =
				"Server=localhost;" +
					"Database=videojuego;" +
					"User ID=root;" +
					"Password=hola;" +
					"Pooling=false;";
			this.myConnection = new MySqlConnection(connectionString);
			this.myConnection.Open();
		}

		protected void cerrarConexion(){
			this.myConnection.Close(); 
			this.myConnection = null;
		}
	}
}



