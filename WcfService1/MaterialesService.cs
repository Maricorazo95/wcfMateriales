using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface MaterialesService
    {

        [OperationContract]
        List<material> ListaMateriales();

        [OperationContract]
        material ObtenerMaterial(int materiaId);

        [OperationContract]
        int EliminarMaterial(int materialId);

        [OperationContract]
        int EditarMaterial(material material);

        [OperationContract]
        int NuevoMaterial(material material);
    }

    [DataContract]
    public class material
    {
        int MaterialId;
        string Nombre;
        short PiezasUnidad;
        short TipoMaterialId;
        byte UnidadCompraId;
        byte UnidadAlmacenId;
        short FamiliaId;
        byte EstatusId;
        decimal Costo;

        public int MaterialId1 { get => MaterialId; set => MaterialId = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public short PiezasUnidad1 { get => PiezasUnidad; set => PiezasUnidad = value; }
        public short TipoMaterialId1 { get => TipoMaterialId; set => TipoMaterialId = value; }
        public byte UnidadCompraId1 { get => UnidadCompraId; set => UnidadCompraId = value; }
        public byte UnidadAlmacenId1 { get => UnidadAlmacenId; set => UnidadAlmacenId = value; }
        public short FamiliaId1 { get => FamiliaId; set => FamiliaId = value; }
        public byte EstatusId1 { get => EstatusId; set => EstatusId = value; }
        public decimal Costo1 { get => Costo; set => Costo = value; }
    }
}
