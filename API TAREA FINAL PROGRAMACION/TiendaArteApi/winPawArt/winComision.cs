using Newtonsoft.Json;
using System.Text;
using TiendaArteApi.Models.Dto;

namespace winPawArt
{
    public partial class winComision : Form
    {
        public winComision()
        {
            InitializeComponent();
        }

        private void winComision_Load(object sender, EventArgs e)
        {
            GetAllComisiones();
        }


        #region Actualizar
        private async void GetAllComisiones()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:5009/api/Comisiones"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var comision = await response.Content.ReadAsStringAsync();
                        dgvComision.DataSource = JsonConvert.DeserializeObject<List<ComisionDto>>(comision).ToList();
                    }
                    else
                    {
                        MessageBox.Show($"No se puede obtener la lista de comisiones: {response.StatusCode}");
                    }
                }
            }
        }

        #endregion

        #region Agregar
        private void btnAgregarComision_Click(object sender, EventArgs e)
        {
            AgregarComision();
        }

        private async void AgregarComision()
        {
            ComisionCreateDto comisionCreateDto = new ComisionCreateDto();
            comisionCreateDto.ClienteName = txtNombreClienteComision.Text;
            comisionCreateDto.Descripcion = txtDescripcionComision.Text;
            comisionCreateDto.Direccion = txtDireccionComision.Text;
            comisionCreateDto.FechaEntrega = Convert.ToDateTime(txtFechaEntregaComision.Text);
            using (var client = new HttpClient())
            {
                var serializedComision = JsonConvert.SerializeObject(comisionCreateDto);
                var content = new StringContent(serializedComision, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5009/api/Comisiones", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Comision agregdado");
                }
                else
                {
                    MessageBox.Show($"Error al guardar el comision: {response.Content.ReadAsStringAsync().Result}");
                }
                Clear();
                GetAllComisiones();
            }
        }

        #endregion

        #region Limpiar
        private void Clear()
        {
            txtComisionID.Text = string.Empty;
            txtNombreClienteComision.Text = string.Empty;
            txtDescripcionComision.Text = string.Empty;
            txtDireccionComision.Text = string.Empty;
            txtFechaEntregaComision.Text = string.Empty;
        }
        #endregion

        #region Editar

        private void btnModificarComision_Click(object sender, EventArgs e)
        {
            if (id != 0) 
                ModificarComision();
        }

        private static int id = 0;

        private async void ModificarComision()
        {
            ComisionUpdateDto comisionDto = new ComisionUpdateDto();
            comisionDto.ComisionCode = id;
            comisionDto.ClienteName = txtNombreClienteComision.Text;
            comisionDto.Descripcion = txtDescripcionComision.Text;
            comisionDto.Direccion = txtDireccionComision.Text;
            comisionDto.FechaEntrega = Convert.ToDateTime(txtFechaEntregaComision.Text);

            using (var client = new HttpClient())
            {
                var comision = JsonConvert.SerializeObject(comisionDto);
                var content = new StringContent(comision, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(String.Format("{0}/ComisionCode:int?id={1}", "http://localhost:5009/api/Comisiones", id), content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Comision actualizada");
                }
                else
                {
                    MessageBox.Show($"Error al actualizar la comision: {response.StatusCode}");
                }
                Clear();
                GetAllComisiones();
            };
        }
        #endregion

        #region Eliminar
        private void btnEliminarComision_Click(object sender, EventArgs e)
        {
            if (id != 0)
                EliminarComision();
        }

        private async void EliminarComision()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5009/api/Comisiones");
                /*var student = JsonConvert.SerializeObject(studentDto);
                var content = new StringContent(student, Encoding.UTF8, "application/json");*/
                var response = await client.DeleteAsync(String.Format("{0}/ComisionCode:int?id={1}", "http://localhost:5009/api/Comisiones", id));
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Comision eliminada con exito");
                }
                else
                {
                    MessageBox.Show($"No se pudo eliminar la comision: {response.StatusCode}");
                }
                Clear();
                GetAllComisiones();
            };
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Index
        private void dgvComision_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAgregarComision.Enabled = false;
            btnModificarComision.Enabled = true;
            btnEliminarComision.Enabled = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvComision.Rows[e.RowIndex];
                txtComisionID.Text = row.Cells["ComisionCode"].Value.ToString();
                txtNombreClienteComision.Text = row.Cells["ClientName"].Value.ToString();
                txtDescripcionComision.Text = row.Cells["Descripcion"].Value.ToString();
                txtDireccionComision.Text = row.Cells["Direccion"].Value.ToString();
                txtFechaEntregaComision.Text = row.Cells["FechaEntrega"].Value.ToString();
            }
        }

        private void dgvComision_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre;
            string descripcion;
            string direccion;
            string FechaEntrega;

            foreach (DataGridViewRow row in dgvComision.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    id = int.Parse(row.Cells[0].Value.ToString());
                    nombre = row.Cells[1].Value.ToString();
                    descripcion = row.Cells[2].Value.ToString();
                    direccion = row.Cells[3].Value.ToString();
                    FechaEntrega = row.Cells[4].Value.ToString();

                    txtComisionID.Text = Convert.ToString(id);
                    txtNombreClienteComision.Text = nombre;
                    txtDescripcionComision.Text = descripcion;
                    txtDireccionComision.Text = direccion;
                    txtFechaEntregaComision.Text = FechaEntrega;

                }
            }
        }

        #endregion
    }
}
