using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaulas
{
    static class Variables
    {
        public static string usuarioId, empleadoId;

        public static void UsuarioId(string id)
        {
            usuarioId = id;
        }

        public static void EmpleadoId(string id)
        {
            empleadoId = id;
        }
    }
}
