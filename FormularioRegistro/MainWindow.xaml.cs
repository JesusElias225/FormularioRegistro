using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;

namespace FormularioRegistro
{
    public sealed partial class MainWindow : Window
    {
        // Lista donde se guardan los alumnos registrados
        private List<Alumno> alumnos = new List<Alumno>();

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Registros de alumnos";

            // Imagen del icono 
            this.AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets", "FormularioRegistro.ico"));

            // Aqui se cargan los datos
            CargarDatos();
        }

        // Cargar los datos iniciales 
        private void CargarDatos()
        {
            ActualizarLista();
        }

        // Llenar el ListView con los alumnos de la lista
        private void ActualizarLista()
        {
            lstAlumnos.Items.Clear();

            foreach (Alumno alumno in alumnos)
            {
                lstAlumnos.Items.Add(alumno);
            }

            if (alumnos.Count == 1)
            {
                lblTotal.Text = "1 alumno";
            }
            else
            {
                lblTotal.Text = alumnos.Count + " alumnos";
            }
        }

        // Boton de Guardar
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Validar que no haya campos vacios
            if (txtNombre.Text == "" || txtMatricula.Text == "" || txtCorreo.Text == "" || cmbCarrera.SelectedItem == null)
            {
                MostrarMensaje("Llena todos los campos antes de guardar.", false);
                return;
            }

            // Validar que el correo tenga @
            if (!txtCorreo.Text.Contains("@"))
            {
                MostrarMensaje("El correo debe incluir @.", false);
                return;
            }

            // Crear el alumno con los datos del formulario
            Alumno nuevo = new Alumno(
                txtNombre.Text,
                txtMatricula.Text,
                txtCorreo.Text,
                cmbCarrera.SelectedItem?.ToString() ?? "");

            alumnos.Add(nuevo);
            ActualizarLista();
            LimpiarCampos();
            MostrarMensaje("Alumno guardado. Total de registros: " + alumnos.Count, true);
        }

        // Boton de Limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            infoMensaje.IsOpen = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtMatricula.Text = "";
            txtCorreo.Text = "";
            cmbCarrera.SelectedIndex = -1;
        }

        // Muestra el mensaje si salio bien o si hubo error
        private void MostrarMensaje(string texto, bool exito)
        {
            infoMensaje.Message = texto;

            if (exito)
            {
                infoMensaje.Title = "Listo";
                infoMensaje.Severity = InfoBarSeverity.Success;
            }
            else
            {
                infoMensaje.Title = "Error";
                infoMensaje.Severity = InfoBarSeverity.Error;
            }

            infoMensaje.IsOpen = true;
        }
    }
}