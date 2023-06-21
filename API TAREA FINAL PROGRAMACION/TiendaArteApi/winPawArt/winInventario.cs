using Newtonsoft.Json;
using System.Text;
using TiendaArteApi.Models.Dto;

namespace winPawArt
{
    public partial class winInventario : Form
    {
        public winInventario()
        {
            InitializeComponent();
        }

        private void winInventario_Load(object sender, EventArgs e)
        {
            GetAllInventario();
        }


        #region Actualizar
        private async void GetAllInventario()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:5009/api/Inventario"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var productos = await response.Content.ReadAsStringAsync();
                        dgvInventario.DataSource = JsonConvert.DeserializeObject<List<InventarioDto>>(productos).ToList();
                    }
                    else
                    {
                        MessageBox.Show($"No se puede obtener la lista de Inventario: {response.StatusCode}");
                    }
                }
            }
        }
        #endregion

        #region Agregar

        private void btnAgregarInventario_Click(object sender, EventArgs e)
        {
            AñadirInventario();
        }

        public async void AñadirInventario()
        {
            InventarioCreateDto inventarioCreateDto = new InventarioCreateDto();
            inventarioCreateDto.ProductName = txtNombreProductoInventario.Text;
            inventarioCreateDto.ProductDescription = txtDescripcionInventario.Text;
            inventarioCreateDto.ProductUnit = Convert.ToInt32(txtProductoUnitarioInventario.Text);
            inventarioCreateDto.ProductPrice = Convert.ToDouble(txtPrecioDeVentaInventario.Text);
            using (var client = new HttpClient())
            {
                var serializedInventario = JsonConvert.SerializeObject(inventarioCreateDto);
                var content = new StringContent(serializedInventario, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5009/api/Inventario", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto agregdado");
                }
                else
                {
                    MessageBox.Show($"Error al guardar el ptoducto: {response.Content.ReadAsStringAsync().Result}");
                }
                Clear();
                GetAllInventario();
            }
        }
        #endregion

        #region Limpiar

        private void Clear()
        {
            txtProductoID.Text = string.Empty;
            txtNombreProductoInventario.Text = string.Empty;
            txtDescripcionInventario.Text = string.Empty;
            txtProductoUnitarioInventario.Text = string.Empty;
            txtPrecioDeVentaInventario.Text = string.Empty;
        }
        #endregion

        #region Editar
        private void btnModificarInventario_Click(object sender, EventArgs e)
        {
            if (id != "")
                ModificarInventario();
        }

        private async void ModificarInventario()
        {
            InventarioUpdateDto inventarioDto = new InventarioUpdateDto();
            inventarioDto.ProductCode = id;
            inventarioDto.ProductName = txtNombreProductoInventario.Text;
            inventarioDto.ProductDescription = txtDescripcionInventario.Text;
            inventarioDto.ProductUnit = Convert.ToInt32(txtProductoUnitarioInventario.Text);
            inventarioDto.ProductPrice = Convert.ToDouble(txtPrecioDeVentaInventario.Text);


            using (var client = new HttpClient())
            {
                var producto = JsonConvert.SerializeObject(inventarioDto);
                var content = new StringContent(producto, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(String.Format("{0}/{1}", "http://localhost:5009/api/Inventario", id), content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto actualizado");
                }
                else
                {
                    MessageBox.Show($"Error al actualizar el producto: {response.StatusCode}");
                }
                Clear();
                GetAllInventario();
            };
        }
        #endregion


        #region Eliminar
        private void btnEliminarInventario_Click(object sender, EventArgs e)
        {
            if (id != "")
                EliminarInventario();
        }

        private static string id = "";

        private async void EliminarInventario()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5009/api/Inventario");
                /*var student = JsonConvert.SerializeObject(studentDto);
                var content = new StringContent(student, Encoding.UTF8, "application/json");*/
                var response = await client.DeleteAsync(String.Format("{0}/ProductCode:string?id={1}", "http://localhost:5009/api/Inventario", id));
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto eliminado con exito");
                }
                else
                {
                    MessageBox.Show($"No se pudo eliminar el producto: {response.StatusCode}");
                }
                Clear();
                GetAllInventario();
            };

        }
        #endregion

        #region Index
        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAgregarInventario.Enabled = false;
            btnModificarInventario.Enabled = true;
            btnEliminarInventario.Enabled = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInventario.Rows[e.RowIndex];
                txtProductoID.Text = row.Cells["ProductCode"].Value.ToString();
                txtNombreProductoInventario.Text = row.Cells["ProductName"].Value.ToString();
                txtDescripcionInventario.Text = row.Cells["ProductDescripcion"].Value.ToString();
                txtProductoUnitarioInventario.Text = row.Cells["ProductUnit"].Value.ToString();
                txtPrecioDeVentaInventario.Text = row.Cells["ProductPrice"].Value.ToString();
            }
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre;
            string descripcion;
            string unitario;
            string precio;

            foreach (DataGridViewRow row in dgvInventario.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    id = row.Cells[0].Value.ToString();
                    nombre = row.Cells[1].Value.ToString();
                    descripcion = row.Cells[2].Value.ToString();
                    unitario = row.Cells[3].Value.ToString();
                    precio = row.Cells[4].Value.ToString();

                    txtProductoID.Text = Convert.ToString(id);
                    txtNombreProductoInventario.Text = nombre;
                    txtDescripcionInventario.Text = descripcion;
                    txtProductoUnitarioInventario.Text = unitario;
                    txtPrecioDeVentaInventario.Text = precio;

                }
            }
        }

        #endregion

    }


}
