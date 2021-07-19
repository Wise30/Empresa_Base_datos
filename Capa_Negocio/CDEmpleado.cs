using System;

namespace Capa_Negocio
{
    internal class CDEmpleado
    {
        internal int Id_empleado;

        public CDEmpleado()
        {
        }

        public string nombre { get; internal set; }
        public string apellido { get; internal set; }
        public string fecha_nacimiento { get; internal set; }
        public string cedula_pasaporte { get; internal set; }
        public string movil { get; internal set; }
        public string telefono { get; internal set; }
        public string direccion { get; internal set; }

        internal string Insertar(CDEmpleado objempleado)
        {
            throw new NotImplementedException();
        }

        internal string Actualizar(CDEmpleado objempleado)
        {
            throw new NotImplementedException();
        }
    }
}