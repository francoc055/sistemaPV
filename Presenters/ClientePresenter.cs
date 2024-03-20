using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using systemPV.Models;
using systemPV.Views;

namespace systemPV.Presenters
{
    public class ClientePresenter
    {
        private readonly ICLienteView _view;
        private readonly AppDbContext appDbContext;

        public ClientePresenter(ICLienteView view)
        {
            _view = view;
            _view.Guardar += GuardarCliente;
            _view.Mostrar += MostrarClientes;
            _view.Eliminar += EliminarCliente;
            _view.ObtenerId += ObtenerId;

            appDbContext = new AppDbContext();
        }

        public int IdClienteSeleccionado { get; set; }


        private void GuardarCliente(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = _view.Nombre,
                Direccion = _view.Direccion
            };

            appDbContext.DbCliente.Add(cliente);
            appDbContext.SaveChanges();

            MostrarClientes(sender, e);
        }

        public void MostrarClientes(object sender, EventArgs e)
        {
            var listaClientes = appDbContext.DbCliente.ToList();
            _view.ListaClientes = listaClientes;
        }

        private void EliminarCliente(object sender, EventArgs e)
        {
            var cliente = appDbContext.DbCliente.Find(_view.Id);

            if (cliente != null)
            {
                appDbContext.DbCliente.Remove(cliente);
                appDbContext.SaveChanges();
            }

            MostrarClientes(sender, e);
        }

        private void ObtenerId(object sender, EventArgs e)
        {
            if (sender is DataGridView dataGridView && dataGridView.CurrentCell != null)
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                if (row.Cells["Id"].Value != null && int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                {
                    IdClienteSeleccionado = id;
                    _view.btnEliminar.Enabled = true;
                }
            }
        }
    }
}
