namespace winPawArt
{
    public partial class winPawArt : Form
    {
        public winPawArt()
        {
            InitializeComponent();
        }

        private void CargarForm<MiForm>() where MiForm : Form, new()
        {
            /*if (this.panel2.Controls.Count > 0)
            {
                this.panel2.Controls.RemoveAt(0);
            }
            Form f = new Form();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();*/

            Form formulario;
            formulario = panel2.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panel2.Controls.Add(formulario);
                panel2.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            CargarForm<winInventario>();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            CargarForm<winVentas>();
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            CargarForm<winComision>();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}