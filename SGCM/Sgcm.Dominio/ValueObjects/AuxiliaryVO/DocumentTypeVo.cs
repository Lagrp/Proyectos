namespace Sgcm.Dominio.ValueObjects.AuxiliaryVO
{
    public class DocumentTypeVo
    {
        //tdoc_id, tdoc_name, tdoc_abrev, tdoc_icon
        public int Tdoc_id { get; set; }

        public string? Tdoc_name { get; set; }
        public string? Tdoc_abrev { get; set; }
        public string? Tdoc_icon { get; set; }
    }
}