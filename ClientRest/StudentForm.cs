using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using static ClientRest.ListAcciones;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ClientRest
{
    public partial class StudentForm : Form
    {
        private Student alumno;
        private HttpClient client;

        public StudentForm()
        {
            alumno = new Student();
            client = new HttpClient();
            
            client.BaseAddress = new Uri("http://localhost:50590/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            var accion = Environment.GetEnvironmentVariable(Recursos.Literales.accion, EnvironmentVariableTarget.User);
            switch ((OpcAccion)Enum.Parse(typeof(OpcAccion), accion.ToString(), true))
            {
                case OpcAccion.Create:
                    break;
                case OpcAccion.Read:
                    var t = Task<Student>.Run(ReadStudentAsync);
                    ShowStudent(t.Result);
                    break;
                case OpcAccion.Delete:

                    break;
                case OpcAccion.Update:

                    break;
            }
        }

        private void listAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            var accion = this.AccionSelecionadaCombo();
            switch (accion)
            {
                case OpcAccion.Create:
                    Environment.SetEnvironmentVariable(Recursos.Literales.accion, Recursos.Literales.Create, EnvironmentVariableTarget.User);
                    break;
                case OpcAccion.Read:
                    Environment.SetEnvironmentVariable(Recursos.Literales.accion, Recursos.Literales.Read, EnvironmentVariableTarget.User);
                    break;
                case OpcAccion.Update:
                    Environment.SetEnvironmentVariable(Recursos.Literales.accion, Recursos.Literales.Update, EnvironmentVariableTarget.User);
                    break;
                case OpcAccion.Delete:
                    Environment.SetEnvironmentVariable(Recursos.Literales.accion, Recursos.Literales.Delete, EnvironmentVariableTarget.User);
                    break;
            }
        }


        private OpcAccion AccionSelecionadaCombo()
        {
            var index = listAction.SelectedIndex;
            var formato = listAction.Items[index].ToString() ?? Environment.GetEnvironmentVariable(Recursos.Literales.accion, EnvironmentVariableTarget.User);
            return (OpcAccion)Enum.Parse(typeof(OpcAccion), formato.ToString(), true);
        }

        private void ShowStudent(Student alumno)
        {
            textId.Text = Convert.ToString(alumno.Id);
            textName.Text = alumno.Name;
            textSurname.Text = alumno.Apellidos;
            textDni.Text = alumno.Dni;
            BirthDate.Value = alumno.FechaNac;
            dataGridView1.ReadOnly = true;
            List<Student> lalumnos = new List<Student>();
            lalumnos.Add(alumno);
            dataGridView1.DataSource = lalumnos;
        }

        private async Task<Student> ReadStudentAsync()
        {
            var path = "https://api.myjson.com/bins/u3bwz";
            using (var client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();

                using (HttpContent content = response.Content)
                {
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    //alumno = JsonConvert.DeserializeObject<Student>(responseBody);
                    alumno = await response.Content.ReadAsAsync<Student>();
                    return alumno;
                }
            }

        }

        private async Task<Uri> CreateStudentAsync(Student student)
        {
            string endpoint = "api/Student/AddStudent";
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, student);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
        }
    }
}
