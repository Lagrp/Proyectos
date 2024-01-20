using AppDTO;
using AppServices.Servicios;
using System.Collections.Generic;

namespace UI.Desktop.VistaModelo
{
    public class DataAuxiliarVM
    {
        DataAuxiliarServicio dataAuxiliarServicio;

        public DataAuxiliarVM()
        {
            dataAuxiliarServicio= new DataAuxiliarServicio();
        }

        #region AUXILIARES PERSONA

        public IEnumerable<TipodocDto> TablaTipoDocs => dataAuxiliarServicio.GetTableTipodocs();
        public IEnumerable<GeneroDto> TablaGeneros =>dataAuxiliarServicio.GetTableGeneros();
        public IEnumerable<DepartamentoDto> TablaDepartamentos => dataAuxiliarServicio.GetTableDepartamentos();
        public IEnumerable<ProvinciaDto> TablaProvincias => dataAuxiliarServicio.GetTableProvincias();
        public IEnumerable<DistritoDto> TablaDistritos => dataAuxiliarServicio.GetTableDistritos();
        public IEnumerable<TiposTelDto> TablaTiposTel => dataAuxiliarServicio.GetTableTiposTel();
        public IEnumerable<OperTelDto> TablaOpersTel=> dataAuxiliarServicio.GetTableOpersTel();

        #endregion AUXILIARES PERSONA

        #region AUXILIARES USUARIO 

        public IEnumerable<PerfilDto> TablaPerfiles => dataAuxiliarServicio.GetTablePerfiles();
        public IEnumerable<EstadoDto> TablaEstadosSistema => dataAuxiliarServicio.GetTableEstados();

        public DistritoDto GetDistrito(int id) => dataAuxiliarServicio.GetDistrito(id);

        #endregion AUXILIARES USUARIO
    }
}