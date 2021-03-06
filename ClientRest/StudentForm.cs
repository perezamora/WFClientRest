﻿using System;
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
            this.InitHttpHeader();
            InitializeComponent();
        }

        private void InitHttpHeader()
        {
            var baseurl = System.Configuration.ConfigurationManager.AppSettings[Recursos.Literales.baseendopint];
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void BtnAction_Click(object sender, EventArgs e)
        {
            LoadAlumnoData();
            var accion = Environment.GetEnvironmentVariable(Recursos.Literales.accion, EnvironmentVariableTarget.User);
            switch ((OpcAccion)Enum.Parse(typeof(OpcAccion), accion.ToString(), true))
            {
                case OpcAccion.Create:
                    var create = await CreateStudentAsync();
                    ShowStudent(create);
                    break;
                case OpcAccion.Read:
                    var read = await ReadStudentAsync();
                    ShowStudent(read);
                    break;
                case OpcAccion.Delete:
                    var code = await DeleteStudentAsync();
                    break;
                case OpcAccion.Update:
                    var delete = await UpdateStudenAsync();
                    ShowStudent(delete);
                    break;
               case OpcAccion.GetAll:
                    var list = await GetStudents();
                    ShowAllStudent(list);
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
                case OpcAccion.GetAll:
                    this.HideFieldFormReadDelete();
                    Environment.SetEnvironmentVariable(Recursos.Literales.accion, Recursos.Literales.AllItems, EnvironmentVariableTarget.User);
                    break;
            }
        }


        private OpcAccion AccionSelecionadaCombo()
        {
            var index = listAction.SelectedIndex;
            var formato = listAction.Items[index].ToString() ?? Environment.GetEnvironmentVariable(Recursos.Literales.accion, EnvironmentVariableTarget.User);
            return (OpcAccion)Enum.Parse(typeof(OpcAccion), formato.ToString(), true);
        }

        private void ShowAllStudent(List<Student> lalumnos)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = lalumnos;
        }

        private void ShowStudent(Student alumno)
        {
            dataGridView1.ReadOnly = true;
            List<Student> lalumnos = new List<Student>();
            lalumnos.Add(alumno);
            dataGridView1.DataSource = lalumnos;
        }

        private async Task<List<Student>> GetStudents()
        {
            return await Task<List<Student>>.Run(() => ReadAllStudentAsync().Result);
        }

        private async Task<List<Student>> ReadAllStudentAsync()
        {
            var id = Convert.ToInt32(alumno.ID);

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://api.myjson.com/bins/z7577");
                //HttpResponseMessage response = await client.GetAsync(Recursos.Literales.getAll);
                response.EnsureSuccessStatusCode();
                List<Student> alumnos = new List<Student>();
                using (HttpContent content = response.Content)
                {
                    alumnos = await response.Content.ReadAsAsync<List<Student>>();

                    if (response.StatusCode.ToString() != "OK")
                    {
                        var redis = RedisStore.RedisCache;
                        var key = "listaAlumnos";
                        return JsonConvert.DeserializeObject<List<Student>>(redis.StringGet(key));
                    }
                    else
                    {
                        var redis = RedisStore.RedisCache;
                        redis.StringSet("listaAlumnos",JsonConvert.SerializeObject(alumnos));
                        return alumnos;
                    }

                }

            }catch(Exception)
            {
                return null;
            }
        }
        
        private async Task<Student> ReadStudentAsync()
        {
            var id = Convert.ToInt32(alumno.ID);
           /* var endpoint = $"api/Student/ReadStudent/{id}";
            HttpResponseMessage response = await client.GetAsync(endpoint);*/
            HttpResponseMessage response = await client.GetAsync("https://api.myjson.com/bins/dcu3n");
            response.EnsureSuccessStatusCode();

            using (HttpContent content = response.Content)
            {
                alumno = await response.Content.ReadAsAsync<Student>();
                return alumno;
            }

        }

        private async Task<Student> CreateStudentAsync()
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(Recursos.Literales.add, alumno);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Student>();
        }

        private async Task<HttpStatusCode> DeleteStudentAsync()
        {
            try
            {
                var id = Convert.ToInt32(alumno.ID);
                var endpoint = $"api/Student/DeleteStudent/{id}";
                HttpResponseMessage response = await client.DeleteAsync(endpoint);
                return response.StatusCode;
            }
            catch (HttpRequestException)
            {
                return HttpStatusCode.Forbidden;
            }

        }

        private async Task<Student> UpdateStudenAsync()
        {
            var id = Convert.ToInt32(alumno.ID);
            var endpoint = $"api/Student/UpdateStudent/{id}";
            HttpResponseMessage response = await client.PutAsJsonAsync(endpoint, alumno);
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

        private void HelloBtn_Click(object sender, EventArgs e)
        {
            textShow.Text = "Hello Mindundi!!!";
        }
    }
}
