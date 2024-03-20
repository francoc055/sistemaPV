using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systemPV.Models
{
    public class Vianda
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }


    }
}
