using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CapaDeDatos
{
    public class ConexionBase
    {
        protected string CadenaConexion = ConexionSQL.LeerConexion();
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public DataTable Datos { get; set; }

    }
}
