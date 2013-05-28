using System;
using MySql.Data.MySqlClient;
using System.Collections;

namespace practica8
{
	public class Acciones : MySQL
	{
		public Acciones ()
		{
		}
		public ArrayList obtenerTodos(){
			this.abrirConexion();
			MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
			                                          this.myConnection);
			MySqlDataReader myReader = myCommand.ExecuteReader();	

			ArrayList juegos = new ArrayList();
			while (myReader.Read()){
				Juego juego = new Juego();
				juego.id = myReader["id"].ToString();
				juego.nombre = myReader["nombre"].ToString();
				juego.anio = myReader["anio"].ToString();
				juegos.Add(juego);
			}

			myReader.Close();
			myReader = null;
			myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
			return juegos;
		}

		private string querySelect(){
			return "SELECT * " +
				"FROM Videojuego, fabricante WHERE fabricante_id = fabricante.id";
	}
}
