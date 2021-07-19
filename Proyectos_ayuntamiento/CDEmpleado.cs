using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace Proyectos_ayuntamiento
{
    class CNEmpleado
    {
        private int dId_empleado;
        private string dnombre, dapellido, dfecha_nacimiento, dcedula_pasaporte, dmovil, dtelefono, ddireccion;

        public CNEmpleado()
        {

        }
        public CNEmpleado(int pId_empleado,
                          string pnombre,
                          string papellido,
                          string pfecha_nacimiento,
                          string pcedula_pasaporte,
                          string pmovil,
                          string ptelefono,
                          string pdireccion
                          )
        {
            dId_empleado = pId_empleado;
            dnombre = pnombre;
            dapellido = papellido;
            dfecha_nacimiento = pfecha_nacimiento;
            dcedula_pasaporte = pcedula_pasaporte;
            dmovil = pmovil;
            dtelefono = ptelefono;
            ddireccion = pdireccion;
        }

        public int Id_empleado
        {
            get { return dId_empleado; }
            set { dId_empleado = value; }
        }
        public string nombre
        {
            get { return dnombre; }
            set { dnombre = value; }
        }
        public string apellido
        {
            get { return dapellido; }
            set { dapellido = value; }
        }
        public string fecha_nacimiento
        {
            get { return dfecha_nacimiento; }
            set { dfecha_nacimiento = value; }
        }
        public string cedula_pasaporte
        {
            get { return dcedula_pasaporte; }
            set { dcedula_pasaporte = value; }
        }
        public string movil
        {
            get { return dmovil; }
            set { dmovil = value; }
        }
        public string telefono
        {
            get { return dtelefono; }
            set { dtelefono = value; }
        }
        public string direccion
        {
            get { return ddireccion; }
            set { ddireccion = value; }
        }

        public string Insertar(CNEmpleado objEmpleado)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = SIGDPconexion.miconexion;
                SqlCommand micomando = new SqlCommand("EmpleadoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pId_empleado", objEmpleado.Id_empleado);
                micomando.Parameters.AddWithValue("@pnombre", objEmpleado.nombre);
                micomando.Parameters.AddWithValue("@papellido", objEmpleado.apellido);
                micomando.Parameters.AddWithValue("@pfecha_nacimiento", objEmpleado.fecha_nacimiento);
                micomando.Parameters.AddWithValue("@pcedula_pasaporte", objEmpleado.cedula_pasaporte);
                micomando.Parameters.AddWithValue("@pmovil", objEmpleado.movil);
                micomando.Parameters.AddWithValue("@ptelefono", objEmpleado.telefono);
                micomando.Parameters.AddWithValue("@pdireccion", objEmpleado.direccion);


                mensaje = micomando.ExecuteNonQuery() == 1 ? "Inserción de datos completada correctamente" :
                "No se pudo Insertar correctamente el nuevo Empleado!";

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }

        public string Actualizar(CNEmpleado objEmpleado)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = SIGDPconexion.miconexion;
                SqlCommand micomando = new SqlCommand("ProyectoActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@Id_empleado", objEmpleado.Id_empleado);
                micomando.Parameters.AddWithValue("@nombre", objEmpleado.nombre);
                micomando.Parameters.AddWithValue("@apellido", objEmpleado.apellido);
                micomando.Parameters.AddWithValue("@fecha_nacimiento", objEmpleado.fecha_nacimiento);
                micomando.Parameters.AddWithValue("@cedula_pasaporte", objEmpleado.cedula_pasaporte);
                micomando.Parameters.AddWithValue("@movil", objEmpleado.movil);
                micomando.Parameters.AddWithValue("@telefono", objEmpleado.telefono);
                micomando.Parameters.AddWithValue("@direccion", objEmpleado.direccion);

                mensaje = micomando.ExecuteNonQuery() == 1 ? "Actualización completada correctamente" :
                "No se pudo Actualizar correctamente los datos del Empleado!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }

    }

}
