using systemPV.Models;
using systemPV.Presenters;
using systemPV.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace systemPV
{
    public partial class ClienteForm : Form, ICLienteView
    {
        private ClientePresenter _presenter;
        public ClienteForm()
        {
            InitializeComponent();
            _presenter = new ClientePresenter(this);

            btnEliminar.Enabled = false;
        }

        public int Id { get => ObtenerIdSeleccionado(); }
        public string Nombre
        {
            get => txtNombre.Text;
            set => txtNombre.Text = value;
        }
        public string Direccion
        {
            get => txtDireccion.Text;
            set => txtDireccion.Text = value;
        }
        public List<Cliente> ListaClientes
        {
            set
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = value;
            }
        }

        Button ICLienteView.btnEliminar => this.btnEliminar;

        public event DataGridViewCellEventHandler ObtenerId
        {
            add => dataGridView1.CellClick += value;
            remove => dataGridView1.CellClick += value;
        }

        public event EventHandler Guardar
        {
            add => btnAgregar.Click += value;
            remove => btnAgregar.Click -= value;
        }

        public event EventHandler Mostrar
        {
            add => Load += value;
            remove => Load -= value;
        }

        public event EventHandler Eliminar
        {
            add => btnEliminar.Click += value;
            remove => btnEliminar.Click -= value;
        }

        private int ObtenerIdSeleccionado()
        {
            MessageBox.Show(_presenter.IdClienteSeleccionado.ToString());
            return _presenter.IdClienteSeleccionado;
        }
    }
}