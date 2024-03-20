using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using systemPV.Models;

namespace systemPV.Views
{
    public interface ICLienteView
    {
        int Id { get; }
        string Nombre { get; set; }
        string Direccion { get; set; }


        //eventos
        event EventHandler Guardar;
        event EventHandler Mostrar;
        event EventHandler Eliminar;
        event DataGridViewCellEventHandler ObtenerId;

        Button btnEliminar { get; }
        List<Cliente> ListaClientes { set; }


    }
}
