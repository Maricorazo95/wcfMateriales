using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WcfService1
{
    public class IMaterialesService : MaterialesService
    {
        string cadenaConexion = ConfigurationManager.ConnectionStrings["ConectionDB"].ConnectionString;
        public int EditarMaterial(material material)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("stp_Material_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaterialId", material.MaterialId1);
                cmd.Parameters.AddWithValue("@Nombre", material.Nombre1);
                cmd.Parameters.AddWithValue("@PiezasUnidad", material.PiezasUnidad1);
                cmd.Parameters.AddWithValue("@UnidadAlmacenId", material.UnidadAlmacenId1);
                cmd.Parameters.AddWithValue("@UnidadCompraId", material.UnidadCompraId1);
                cmd.Parameters.AddWithValue("@EstatusId", material.EstatusId1);
                cmd.Parameters.AddWithValue("@FamiliaId", material.FamiliaId1);
                cmd.Parameters.AddWithValue("@TipoMaterialId", material.TipoMaterialId1);
                cmd.Parameters.AddWithValue("@Costo", material.Costo1);

                res = cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Error al Editar", e);
            }

            return res;
        }

        public int EliminarMaterial(int materialId)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("stp_Material_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaterialId", materialId);

                res = cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Error al Eliminar", e);
            }

            return res;
        }

        public List<material> ListaMateriales()
        {
            List<material> LstMateriales = new List<material>();
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("stp_Materiales_GetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        LstMateriales.Add(new material {
                            MaterialId1 = rd.GetInt32(0),
                            Nombre1 = rd.GetString(1)
                        });
                    }
                }
                else
                {
                    throw new Exception("No hay Registros");
                }

                con.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Error al Eliminar", e);
            }

            return LstMateriales;
        }

        public int NuevoMaterial(material material)
        {
            int res = 0;
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("stp_Material_Create", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Nombre", material.Nombre1);
                cmd.Parameters.AddWithValue("@PiezasUnidad", material.PiezasUnidad1);
                cmd.Parameters.AddWithValue("@UnidadAlmacenId", material.UnidadAlmacenId1);
                cmd.Parameters.AddWithValue("@UnidadCompraId", material.UnidadCompraId1);
                cmd.Parameters.AddWithValue("@EstatusId", material.EstatusId1);
                cmd.Parameters.AddWithValue("@FamiliaId", material.FamiliaId1);
                cmd.Parameters.AddWithValue("@TipoMaterialId", material.TipoMaterialId1);
                cmd.Parameters.AddWithValue("@Costo", material.Costo1);

                res = cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Error al Insertar", e);
            }

            return res;
        }

        public material ObtenerMaterial(int materialId)
        {
            material nmaterial = new material();
            try
            {
                SqlConnection con = new SqlConnection(cadenaConexion);
                con.Open();
                SqlCommand cmd = new SqlCommand("stp_Material_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaterialId", materialId);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    if(rd.Read())
                    {
                        nmaterial.MaterialId1 = rd.GetInt32(0);
                        nmaterial.Nombre1 = rd.GetString(1);
                    }
                }
                else
                {
                    throw new Exception("No hay Registros");
                }

                con.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Error al Eliminar", e);
            }

            return nmaterial;
        }
    }
}
