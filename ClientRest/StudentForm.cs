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
using System.Net;

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
            InitializeComponent();
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            this.InitHttpHeader();
            LoadAlumnoData();
            var accion = Environment.GetEnvironmentVariable(Recursos.Literales.accion, EnvironmentVariableTarget.User);
            switch ((OpcAccion)Enum.Parse(typeof(OpcAccion), accion.ToString(), true))
            {
                case OpcAccion.Create:
                    HideFieldFormReadDelete();
                    ShowStudent(Task<Student>.Run(CreateStudentAsync).Result);
                    break;
                case OpcAccion.Read:
                    ShowStudent(Task<Student>.Run(ReadStudentAsync).Result);
                    break;
                case OpcAccion.Delete:
                    var code = Task<HttpStatusCode>.Run(DeleteStudentAsync).Result;
                    break;
                case OpcAccion.Update:
                    ShowStudent(Task<Student>.Run(UpdateStudenAsync).Result);
                    break;
            }
            ResetFieldForm();
        }

        private void listAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            var accion = this.AccionSelecionadaCombo();
            switch (accion)
            {
                case OpcAccion.Create:
                    this.ShowFieldFormReadDelete();
                    Environment.SetEnvironmentVariable(Recursos.Literales.accion, Recursos.Literales.Create, EnvironmentVariableTarget.User);
                    break;
                case OpcAccion.Read:
                    this.HideFieldFormReadDelete();
                    Environment.SetEnvironmentVariable(Recursos.Literales.accion, Recursos.Literales.Read, EnvironmentVariableTarget.User);
                    break;
                case OpcAccion.Update:
                    this.ShowFieldFormReadDelete();
                    Environment.SetEnvironmentVariable(Recursos.Literales.accion, Recursos.Literales.Update, EnvironmentVariableTarget.User);
                    break;
                case OpcAccion.Delete:
                    this.HideFieldFormReadDelete();
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
            dataGridView1.ReadOnly = true;
            List<Student> lalumnos = new List<Student>();
            lalumnos.Add(alumno);
            dataGridView1.DataSource = lalumnos;
        }

        private void InitHttpHeader()
        {
            var baseurl = System.Configuration.ConfigurationManager.AppSettings[Recursos.Literales.baseendopint];
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<Student> ReadStudentAsync()
        {
            var id = Convert.ToInt32(alumno.ID);
            var endpoint = $"api/Student/ReadStudent/{id}";

            HttpResponseMessage response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            using (HttpContent content = response.Content)
            {
                var baseurl = System.Configuration.ConfigurationManager.AppSettings[Recursos.Literales.baseendopint];
                alumno = await response.Content.ReadAsAsync<Student>();
                return alumno;
            }

        }

        private async Task<Student> CreateStudentAsync()
        {
            var endpoint = "api/Student/AddStudent";

            alumno.Guid = Guid.NewGuid();
            HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, alumno);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Student>();
        }

        private async Task<HttpStatusCode> DeleteStudentAsync()
        {
            var id = Convert.ToInt32(alumno.ID);
            var endpoint = $"api/Student/DeleteStudent/{id}";
            HttpResponseMessage response = await client.DeleteAsync(endpoint);
            return response.StatusCode;
        }

        private async Task<Student> UpdateStudenAsync()
        {
            var id = Convert.ToInt32(alumno.ID);
            var endpoint = $"api/Student/UpdateStudent/{id}";
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/products/{id}", alumno);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Student>();
        }

        private void ResetFieldForm()
        {
            textId.Text = "";
            textName.Text = "";
            textSurname.Text = "";
            textDni.Text = "";
            BirthDate.Text = "";
        }

        private void LoadAlumnoData()
        {
            alumno.ID = textId.Text == "" ? 0 : Convert.ToInt32(textId.Text);
            alumno.Nombre = textName.Text;
            alumno.Apellidos = textSurname.Text;
            alumno.DNI = textDni.Text;
            alumno.FechaDeNacimiento = BirthDate.Value;
        }

        private void HideFieldFormReadDelete()
        {
            textName.Visible = false;
            textSurname.Visible = false;
            textDni.Visible = false;
            BirthDate.Visible = false;
            labelName.Visible = false;
            labelSurname.Visible = false;
            labelDni.Visible = false;
            labelBirth.Visible = false;
        }

        private void ShowFieldFormReadDelete()
        {
            textName.Visible = true;
            textSurname.Visible = true;
            textDni.Visible = true;
            BirthDate.Visible = true;
            labelName.Visible = true;
            labelSurname.Visible = true;
            labelDni.Visible = true;
            labelBirth.Visible = true;
        }
    }
}
