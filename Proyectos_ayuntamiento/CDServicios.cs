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
    class CDServicios
    {
        private int dId_servicio;
        private string dservicio, dempresa, drepresentante, dnumero_cell_representante, ddireccion_empresa, dtipo_servicio, ddescripcion;

        public CDServicios()
        {

        }
        public CDServicios(int pId_servicio,
                          string pservicio,
                          string pempresa,
                          string prepresentante,
                          string pnumero_cell_representante,
                          string pdireccion_empresa,
                          string ptipo_servicio,
                          string pdescripcion
                          )
        {
            dId_servicio = pId_servicio;
            dservicio = pservicio;
            dempresa = pempresa;
            drepresentante = prepresentante;
            dnumero_cell_representante = pnumero_cell_representante;
            ddireccion_empresa = pdireccion_empresa;
            dtipo_servicio = ptipo_servicio;
            ddescripcion = pdescripcion;
        }

        public int Id_servicio
        {
            get { return dId_servicio; }
            set { dId_servicio = value; }
        }
        public string servicio
        {
            get { return dservicio; }
            set { dservicio = value; }
        }
        public string empresa
        {
            get { return dempresa; }
            set { dempresa = value; }
        }
        public string representante
        {
            get { return drepresentante; }
            set { drepresentante = value; }
        }
        public string numero_cell_representante
        {
            get { return dnumero_cell_representante; }
            set { dnumero_cell_representante = value; }
        }
        public string direccion_empresa
        {
            get { return ddireccion_empresa; }
            set { ddireccion_empresa = value; }
        }
        public string tipo_servicio
        {
            get { return dtipo_servicio; }
            set { dtipo_servicio = value; }
        }
        public string descripcion
        {
            get { return ddescripcion; }
            set { ddescripcion = value; }
        }

        public string Insertar(CDServicios objServicios)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = SIGDPconexion.miconexion;
                SqlCommand micomando = new SqlCommand("EmpleadoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@Id_servicio", objServicios.Id_servicio);
                micomando.Parameters.AddWithValue("@servicio", objServicios.servicio);
                micomando.Parameters.AddWithValue("@empresa", objServicios.empresa);
                micomando.Parameters.AddWithValue("@representante", objServicios.representante);
                micomando.Parameters.AddWithValue("@numero_cell_representante", objServicios.numero_cell_representante);
                micomando.Parameters.AddWithValue("@direccion_empresa", objServicios.direccion_empresa);
                micomando.Parameters.AddWithValue("@tipo_servicio", objServicios.tipo_servicio);
                micomando.Parameters.AddWithValue("@descripcion", objServicios.descripcion);


                mensaje = micomando.ExecuteNonQuery() == 1 ? "Inserción de datos completada correctamente" :
                "No se pudo Insertar correctamente el nuevo Servicio!";

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

        public string Actualizar(CDServicios objServicios)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = SIGDPconexion.miconexion;
                SqlCommand micomando = new SqlCommand("ProyectoActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@Id_servicio", objServicios.Id_servicio);
                micomando.Parameters.AddWithValue("@servicio", objServicios.servicio);
                micomando.Parameters.AddWithValue("@empresa", objServicios.empresa);
                micomando.Parameters.AddWithValue("@representante", objServicios.representante);
                micomando.Parameters.AddWithValue("@numero_cell_representante", objServicios.numero_cell_representante);
                micomando.Parameters.AddWithValue("@direccion_empresa", objServicios.direccion_empresa);
                micomando.Parameters.AddWithValue("@tipo_servicio", objServicios.tipo_servicio);
                micomando.Parameters.AddWithValue("@descripcion", objServicios.descripcion);

                mensaje = micomando.ExecuteNonQuery() == 1 ? "Actualización completada correctamente" :
                "No se pudo Actualizar correctamente los datos del Servicio!";
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

