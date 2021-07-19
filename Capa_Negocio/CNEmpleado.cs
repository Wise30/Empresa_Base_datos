using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

using Proyectos_ayuntamiento;

namespace Capa_Negocio
{
    public  class CNEmpleado
    {
        //Preparamos los datos para insertar un nuevo Suplidor. A los parametros recibidos les pongo el prefijo p
        public static string Insertar(int pId_empleado, string pnombre, string papellido,
        string pfecha_nacimiento, string pcedula_pasaporte, string pmovil, string ptelefono,
        string pdireccion)
        {
            //creamos un nuevo objeto de la clase suplidor
            CDEmpleado objempleado = new CDEmpleado();

            //Asignamos a cada Propiedad de la clase el valor del parámetro correspondiente
            objempleado.Id_empleado = pId_empleado;
            objempleado.nombre = pnombre;
            objempleado.apellido = papellido;
            objempleado.fecha_nacimiento = pfecha_nacimiento;
            objempleado.cedula_pasaporte = pcedula_pasaporte;
            objempleado.movil = pmovil;
            objempleado.telefono = ptelefono;
            objempleado.direccion = pdireccion;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objempleado.Insertar(objempleado);
        }
        //Llama al método actualizar estudiante
        public static string Actualizar(int pId_empleado, string pnombre, string papellido,
        string pfecha_nacimiento, string pcedula_pasaporte, string pmovil, string ptelefono,
        string pdireccion)
        {
            //creamos un nuevo objeto de la clase suplidor
            CDEmpleado objempleado = new CDEmpleado();
            //Asignamos a cada Propiedad de la clase el valor del parámetro correspondiente
            objempleado.Id_empleado = pId_empleado;
            objempleado.nombre = pnombre;
            objempleado.apellido = papellido;
            objempleado.fecha_nacimiento = pfecha_nacimiento;
            objempleado.cedula_pasaporte = pcedula_pasaporte;
            objempleado.movil = pmovil;
            objempleado.telefono = ptelefono;
            objempleado.direccion = pdireccion;
            //Llamamos al método Actualizar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objempleado.Actualizar(objempleado);
        }

    }
}
