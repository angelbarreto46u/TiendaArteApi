using Newtonsoft.Json;
using System.Text;
using TiendaArteApi.Models.Dto;

namespace winPawArt
{
    public partial class winVentas : Form
    {
        public winVentas()
        {
            InitializeComponent();
        }

        private void winVentas_Load(object sender, EventArgs e)
        {
            GetAllVentas();
        }

        #region Actualizar
        private async void GetAllVentas()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:5009/api/Ventas"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ventas = await response.Content.ReadAsStringAsync();
                        var displaydata = JsonConvert.DeserializeObject<List<VentasDto>>(ventas);
                        dgvVentas.DataSource = displaydata.ToList();
                    }
                    else
                    {
                        MessageBox.Show($"No se puede obtener la lista de ventas: {response.StatusCode}");
                    }
                }
            }
        }
        #endregion

        #region Agregar

        private void btnAgregarVentas_Click(object sender, EventArgs e)
        {
            AgregarVentas();
        }

        private async void AgregarVentas()
        {
            VentasCreateDto ventasCreateDto = new VentasCreateDto();
            ventasCreateDto.ClienteName = txtNombreClienteVentas.Text;
            ventasCreateDto.Solicitud = txtSolicitudVentas.Text;
            ventasCreateDto.PrecioVenta = Convert.ToDouble(txtPrecioDeVentaVentas.Text);
            ventasCreateDto.Direccion = txtDireccionVentas.Text;
            ventasCreateDto.FechaEntrega = Convert.ToDateTime(txtFechaEntregaVentas.Text);
            using (var client = new HttpClient())
            {
                var serializedVentas = JsonConvert.SerializeObject(ventasCreateDto);
                var content = new StringContent(serializedVentas, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5009/api/Ventas", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Venta agregdada");
                }
                else
                {
                    MessageBox.Show($"Error al guardar la venta: {response.Content.ReadAsStringAsync().Result}");
                }
                Clear();
                GetAllVentas();
            }
        }
        #endregion

        #region Editar
        private void btnModificarVentas_Click(object sender, EventArgs e)
        {
            /*if (dgvVentas.SelectedRows.Count > 0)
            {
                DataGridViewRow filaseleccionada = dgvVentas.SelectedRows[0];
                filaseleccionada.Cells[0].Value = txtVentasID;
                filaseleccionada.Cells[1].Value = txtNombreClienteVentas;
                filaseleccionada.Cells[2].Value = txtSolicitudVentas;
                filaseleccionada.Cells[3].Value = txtPrecioDeVentaVentas;
                filaseleccionada.Cells[4].Value = txtDireccionVentas;
                filaseleccionada.Cells[5].Value = txtFechaEntregaVentas;
            }*/
            if (id != 0)
                ModificarVentas();
        }


        private async void ModificarVentas()
        {
            VentasUpdateDto ventasDto = new VentasUpdateDto();
            ventasDto.VentasCode = id;
            ventasDto.ClienteName = txtNombreClienteVentas.Text;
            ventasDto.Solicitud = txtSolicitudVentas.Text;
            ventasDto.PrecioVenta = Convert.ToDouble(txtPrecioDeVentaVentas.Text);
            ventasDto.Direccion = txtDireccionVentas.Text;
            ventasDto.FechaEntrega = Convert.ToDateTime(txtFechaEntregaVentas.Text);

            /*DataGridViewRow selectFila = dgvVentas.SelectedRows[0];
            var contenido = selectFila.Cells.Cast<DataGridViewCell>()
                .Select(c => c.Value.ToString())
                .ToList();*/

            using (var client = new HttpClient())
            {
                var venta = JsonConvert.SerializeObject(ventasDto);
                var content = new StringContent(venta, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(String.Format("{0}/VentasCode:int?id={1}", "http://localhost:5009/api/Ventas", id), content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Venta actualizada");
                }
                else
                {
                    MessageBox.Show($"Error al actualizar la venta: {response.StatusCode}");
                }
                Clear();
                GetAllVentas();
            };
        }

        #endregion

        #region Eliminar
        private void btnEliminarVentas_Click(object sender, EventArgs e)
        {
            if (id != 0)
                EliminarVentas();
        }

        private static int id = 0;

        private async void EliminarVentas()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5009/api/Ventas");

                var response = await client.DeleteAsync(String.Format("{0}/VentasCode:int?id={1}", "http://localhost:5009/api/Ventas", id));

                /*DataGridViewRow selectFila = dgvVentas.SelectedRows[0];
                var content = selectFila.Cells.Cast<DataGridViewCell>()
                    .Select(c => c.Value.ToString())
                    .ToList();
                var student = JsonConvert.SerializeObject(studentDto);
                var content = new StringContent(student, Encoding.UTF8, "application/json");*/
                

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Venta eliminada con exito");
                }
                else
                {
                    MessageBox.Show($"No se pudo eliminar la Venta: {response.StatusCode}");
                }
                Clear();
                GetAllVentas();
            };
        }

        #endregion

        #region Index
        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre;
            string solicitud;
            string direccion;
            string FechaEntrega;
            string precioVenta;

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    id = int.Parse(row.Cells[0].Value.ToString());
                    nombre = row.Cells[1].Value.ToString();
                    solicitud = row.Cells[2].Value.ToString();
                    precioVenta = row.Cells[3].Value.ToString();
                    direccion = row.Cells[4].Value.ToString();
                    FechaEntrega = row.Cells[5].Value.ToString();

                    txtVentasID.Text = Convert.ToString(id);
                    txtNombreClienteVentas.Text = nombre;
                    txtSolicitudVentas.Text = solicitud;
                    txtPrecioDeVentaVentas.Text = precioVenta;
                    txtDireccionVentas.Text = direccion;
                    txtFechaEntregaVentas.Text = FechaEntrega;

                }
            }

        }

        #endregion

        #region Limpiar
        private void Clear()
        {
            txtVentasID.Text=string.Empty;
            txtNombreClienteVentas.Text = string.Empty;
            txtSolicitudVentas.Text = string.Empty;
            txtDireccionVentas.Text = string.Empty;
            txtFechaEntregaVentas.Text = string.Empty;
            txtPrecioDeVentaVentas.Text = string.Empty;
        }
        #endregion

    }
}
