using System.Text;
using System.Text.Json;

namespace Requests;

public partial class FormPage : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string endpoint = "https://fi.jcaguilar.dev/v1/escuela/persona";

    public FormPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
    }

    private string GetSexoValue()
    {
        string _sexo = "";

        // Obteniendo el valor del radioButton sexo
        foreach (var child in radioBtnSexo.Children)
        {
            if (child is RadioButton radioButton && radioButton.IsChecked)
            {
                _sexo = radioButton.Content.ToString().Substring(0, 1).ToLower();
                break; // Salir del bucle despu�s de encontrar el seleccionado
            }
        }

        return _sexo;
    }

    private int GetRolValue()
    {
        int rolValue = 0;

        // Recorrer el grupo de RadioButton
        foreach (var child in radioBtnRol.Children)
        {
            if (child is RadioButton radioButton && radioButton.IsChecked)
            {
                switch (radioButton.Content.ToString())
                {
                    case "Alumno":
                        rolValue = 1;
                        break;
                    case "Profesor":
                        rolValue = 2;
                        break;
                    case "Administrativo":
                        rolValue = 3;
                        break;
                    case "Otro":
                        rolValue = 4;
                        break;
                }
                break; // Salir del bucle despu�s de encontrar el RadioButton seleccionado
            }
        }

        return rolValue;
    }


    private async void ButtonPost_Clicked(object sender, EventArgs e)
    {
        // Obteniendo los datos de texto del formulario
        string _nombre = txtNombre.Text;
        string _apellido = txtApellido.Text;
        string _fh_nac = txtFhNac.Text;

        // Obteniendo el sexo por radio button
        string _sexo = GetSexoValue();

        // Obteniendo el id_rol por radio button
        int _id_rol = GetRolValue();

        // Creando el objeto persona
        PersonaModel persona = new PersonaModel(_nombre, _apellido, _sexo, _fh_nac, _id_rol);

        // Serializar a JSON
        string jsonData = JsonSerializer.Serialize(persona);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        // Comprobando que no queden campos vac�os
        if (_id_rol == 0)
        {
            _ = DisplayAlert("Entrada inv�lida",
                "Por favor, llene los campos antes de subir el formulario.", "OK");

            return;
        }

        try
        {
            // Hacer la petici�n POST
            var response = await _httpClient.PostAsync(endpoint, content);

            // Manejar la respuesta
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                await DisplayAlert("�xito", $"Respuesta del servidor: {jsonResponse}", "OK");
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"C�digo de error: {response.StatusCode}\nDetalles: {errorResponse}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurri� un error: {ex.Message}", "OK");
        }
    }
}