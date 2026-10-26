
namespace dquinonezT3.Views;

public partial class vContactos : ContentPage
{
	public vContactos()
	{
		InitializeComponent();
        
    }

    
    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {

        // Validar que hayan seleccionado algo en el picker
        if (pkIdentificacion.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Debe seleccionar un tipo de identificación", "OK");
            return;
        }

        string tipo = pkIdentificacion.SelectedItem.ToString();
        string idTexto = txtIdentificacion.Text ?? ""; // Usamos ?? "" para evitar nulos

        // Validar que hayan ingresado la cantidad correcta al momento de guardar
        if (tipo == "CI" && idTexto.Length != 10)
        {
            await DisplayAlert("Alerta", "La Cédula debe tener exactamente 10 números.", "OK");
            return;
        }
        else if (tipo == "RUC" && idTexto.Length != 13)
        {
            await DisplayAlert("Alerta", "El RUC debe tener exactamente 13 números.", "OK");
            return;
        }
        else if (string.IsNullOrWhiteSpace(idTexto))
        {
            await DisplayAlert("Alerta", "La identificación no puede estar vacía.", "OK");
            return;
        }

        try
        {
            string identificacion = txtIdentificacion.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string fecha = dpFecha.Date.Value.ToString("dd/MM/yyyy");
            string correo = txtCorreo.Text;
            double salario = Convert.ToDouble(txtSalario.Text);

            await Navigation.PushAsync(new vAporteIESS(identificacion,nombre, apellido, fecha, correo, salario));



        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            
        }
        




    }

    private async void btnVerContactos_Clicked(object sender, EventArgs e)
    {
        string identificacion = txtIdentificacion.Text;
        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string fecha = dpFecha.Date.Value.ToString("dd/MM/yyyy");
        string correo = txtCorreo.Text;
        double salario = Convert.ToDouble(txtSalario.Text);

        await Navigation.PushAsync(new vAporteIESS(identificacion, nombre, apellido, fecha, correo, salario));
    }

    private void pkIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtIdentificacion.Text = string.Empty;

        string identificacion = pkIdentificacion.SelectedItem.ToString();

        if (identificacion == "CI")
        {
            txtIdentificacion.MaxLength = 10;
            txtIdentificacion.Keyboard = Keyboard.Numeric;
        }
        else if (identificacion == "RUC")
        {
            txtIdentificacion.MaxLength = 13;
            txtIdentificacion.Keyboard = Keyboard.Numeric;
        }
        else if (identificacion == "Pasaporte")
        {
            txtIdentificacion.MaxLength = 30;
            txtIdentificacion.Keyboard = Keyboard.Text;
        }
    }
}