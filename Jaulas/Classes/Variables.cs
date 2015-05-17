using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaulas
{
    static class Variables
    {
        public static string usuarioId, empleadoId, materiaId, productoId;

        public static void UsuarioId(string id)
        {
            usuarioId = id;
        }

        public static void EmpleadoId(string id)
        {
            empleadoId = id;
        }

        public static void MateriaId(string id)
        {
            materiaId = id;
        }

        public static void ProductoId(string id)
        {
            productoId = id;
        }
    }
}
