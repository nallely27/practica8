using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	private int x;
	private int y;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.tabla;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	private void tabla(){
		this.titulo();
		this.encabezado();	
		this.cuerpo();
		this.Child.ShowAll();
	}
	private void titulo(){
		Gtk.Label etiqueta = new global::Gtk.Label ();
		this.etiqueta("lblTitle", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">VIDEOJUEGOS</span>");
		etiqueta.UseMarkup = true;
		this.fixed1.Add (etiqueta);
		global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[etiqueta]));
		w11.X = 60;
		w11.Y = 10;

	}


	private void encabezado(){		
		this.x = 25;
		this.y = 58;
		this.etiqueta("lblID", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">ID</span>");
		this.x += 100;
		this.etiqueta("lblNombre", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">NOMBRE</span>");
		this.x += 200;
		this.etiqueta("lblAnio", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">AÑO</span>");
		this.x += 200;
		this.etiqueta("lblOpciones", "<span size=\"14000\" foreground=\"BLUE\" weight=\"bold\">OPCIONES</span>");

	}

	private void etiqueta(string nombre, string markup){
		Gtk.Label etiqueta = new global::Gtk.Label ();
		etiqueta.Name = nombre;
		etiqueta.Markup = markup;
		etiqueta.UseMarkup = true;
		this.fixed2.Add (etiqueta);
		global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[etiqueta]));
		w11.X = this.x;
		w11.Y = this.y;
	}


	private void cuerpo(){
		Acciones acciones = new Acciones();
		System.Collections.ArrayList juegos = acciones.obtenerTodos();
		foreach(Juego juego in juegos){
			this.x = 25;
			this.y += 40;
			this.registro(juego);
		}
	}


	private void registro(Juego juego){
		this.etiqueta("lblID_" + juego.id, "<span size=\"12000\" foreground=\"#000000\">" + juego.id + "</span>");
		this.x += 100;
		this.etiqueta("lblnombre_" + juego.id, "<span size=\"12000\" foreground=\"#000000\">" + juego.nombre + "</span>");
		this.x += 200;
		this.etiqueta("lblanio_" + juego.id, "<span size=\"12000\" foreground=\"#000000\">" + juego.anio + "</span>");
		this.x += 200;

		this.opciones (juego);  //muestra un boton de mostrar id por cada registro


	}


	protected virtual void OnfileClicked (object sender, System.EventArgs e)//evento para programar el boton de manera dinamica
	{
		Gtk.Button btnFile = (Gtk.Button) sender;
		string id = btnFile.Name.Replace("btnMostrar", "");

		MessageDialog md = new MessageDialog (null, 
		                                      DialogFlags.Modal,
		                                      MessageType.Info, 
		                                      ButtonsType.None, id);//
		md.Show();

	}


	private void opciones(Juego juego){ 
		this.boton("btnMostrarID"+juego.id, "MostrarID", "gtk-file");

	}



	private void boton(string nombre, string label, string imagen){
		Gtk.Button boton = new global::Gtk.Button ();
		boton.CanFocus = true;
		boton.Name = nombre;
		boton.UseUnderline = true;
		// Container child btnNuevo.Gtk.Container+ContainerChild
		global::Gtk.Alignment w1 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		global::Gtk.HBox w2 = new global::Gtk.HBox ();
		w2.Spacing = 2;
		// Container child GtkHBox.Gtk.Container+ContainerChild
		/*global::Gtk.Image w3 = new global::Gtk.Image ();
		w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, imagen, global::Gtk.IconSize.Button);
		w2.Add (w3);
		Este era el boton nuevo*/
		// Container child GtkHBox.Gtk.Container+ContainerChild
		global::Gtk.Label w5 = new global::Gtk.Label ();
		w5.LabelProp = global::Mono.Unix.Catalog.GetString (label);
		w5.UseUnderline = true;
		w2.Add (w5);
		w1.Add (w2);
		boton.Add (w1);
		this.fixed2.Add (boton);
		global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[boton]));
		w9.X = this.x;
		w9.Y = this.y - 10;
		if(imagen == "gtk-file")//linea que aniade el evento a los botones dinamicos
			boton.Clicked += new global::System.EventHandler (this.OnfileClicked); 

	}



}
