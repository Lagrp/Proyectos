namespace Sgcm.Dominio.ValueObjects.PesonaVO
{
    public record Ubigeo
    {
        public string Address { get; init; }
        public int Ubdis_Id { get; init; }
        public int UbProv_Id { get; init; }
        public int UbDep_Id { get; init; }

        internal Ubigeo(string address, int ubdis_Id, int ubProv_Id, int ubDep_Id)
        {
            this.Address = address;
            this.Ubdis_Id = ubdis_Id;
            this.UbProv_Id = ubProv_Id;
            this.UbDep_Id = ubDep_Id;
        }
        public static Ubigeo Create(string address, int ubdis_Id)
        {
            if (!string.IsNullOrEmpty(address) && ubdis_Id > 0)
            {
                var prov = (int)double.Truncate(ubdis_Id / 100);
                var dpto = (int)double.Truncate(ubdis_Id / 10000);
                return new Ubigeo(address, ubdis_Id, prov, dpto);
            }
            else
            {
                throw new ArgumentNullException("Ubigeo: el valor del no debe ser nulo ");
            }
        }
    }
}