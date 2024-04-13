namespace rsanchezT2.Vistas;

public partial class VInicio : ContentPage
{
	public VInicio()
	{
		InitializeComponent();
        estudiantePicker.Items.Add("Juan Pérez");
        estudiantePicker.Items.Add("María Rodríguez");
        estudiantePicker.Items.Add("Carlos Gómez");
        estudiantePicker.Items.Add("Ana López");
        estudiantePicker.Items.Add("Luisa Martínez");

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (estudiantePicker.SelectedIndex == -1)
        {
            DisplayAlert("Error", "Por favor, seleccione un estudiante.", "Aceptar");
            return;
        }
        double seguimiento1, examen1, seguimiento2, examen2;

        // Validar los rangos de calificaciones
        if (double.TryParse(seguimiento1Entry.Text, out seguimiento1) && seguimiento1 >= 0.1 && seguimiento1 <= 10 &&
            double.TryParse(examen1Entry.Text, out examen1) && examen1 >= 0.1 && examen1 <= 10 &&
            double.TryParse(seguimiento2Entry.Text, out seguimiento2) && seguimiento2 >= 0.1 && seguimiento2 <= 10 &&
            double.TryParse(examen2Entry.Text, out examen2) && examen2 >= 0.1 && examen2 <= 10)
        {
            double notaParcial1 = (seguimiento1 * 0.3) + (examen1 * 0.2);
            double notaParcial2 = (seguimiento2 * 0.3) + (examen2 * 0.2);
            double notaFinal = notaParcial1 + notaParcial2;

            string estado;
            if (notaFinal >= 7)
                estado = "Aprobado";
            else if (notaFinal >= 5 && notaFinal <= 6.9)
                estado = "Complementario";
            else
                estado = "Reprobado";

            string resultadoString = $"Nombre: {estudiantePicker.SelectedItem}\n" +
                                     $"Fecha: {fechaPicker.Date.ToString("dd/MM/yyyy")}\n" +
                                     $"Nota Parcial 1: {notaParcial1}\n" +
                                     $"Nota Parcial 2: {notaParcial2}\n" +
                                     $"Nota Final: {notaFinal}\n" +
                                     $"Estado: {estado}";

            DisplayAlert("Resultados", resultadoString, "Aceptar");
        }
        else
        {
            DisplayAlert("Error", "Por favor, ingrese calificaciones entre 0.1 y 10.", "Aceptar");
        }

    }
}