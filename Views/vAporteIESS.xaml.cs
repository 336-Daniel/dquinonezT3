namespace dquinonezT3.Views;

public partial class vAporteIESS : ContentPage
{
	public vAporteIESS()
	{
		InitializeComponent();
	}

    public vAporteIESS(string identificacion ,string nombre, string apellido, string fecha, string correo, double salario)
    {
        InitializeComponent();


        lblIdentificacion.Text = "Número de identificación: " + identificacion;
        lblNombre.Text = "Nombre: " + nombre;
        lblApellido.Text = "Apellido: " + apellido;
        lblFecha.Text = "Fecha: " + fecha;
        lblCorreo.Text = "Correo: " + correo;
        lblSalario.Text = "Salario: $" + salario;

        double aporteMensual = (salario * 9.45) / 100;
        
        lblAporteIESS.Text = "Aporte al IESS: "+ aporteMensual.ToString("F2");


    }


    private  async void btnExportarAArchivo_Clicked(object sender, EventArgs e)
    {
        try
        {
            string rutaCarpeta = FileSystem.AppDataDirectory;
            string rutaArchivo = Path.Combine(rutaCarpeta, "contactos.txt");

            string contenido = "--- Nuevo Registro ---" + Environment.NewLine +
                           lblIdentificacion.Text + Environment.NewLine +
                           lblNombre.Text + Environment.NewLine +
                           lblApellido.Text + Environment.NewLine +
                           lblFecha.Text + Environment.NewLine +
                           lblCorreo.Text + Environment.NewLine +
                           lblSalario.Text + Environment.NewLine +
                           lblAporteIESS.Text + Environment.NewLine +
                           "----------------------" + Environment.NewLine;

            File.AppendAllText(rutaArchivo, contenido);

            await DisplayAlert("Éxito", $"Datos exportados correctamente.\nGuardado en: {rutaArchivo}", "OK");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Ocurrió un error al guardar el archivo: " + ex.Message, "OK");

        }

    }
}