namespace Sgcm.Dominio.ValueObjects.PesonaVO
{
    public record PersonSysInfo
    {
        private static DateTime _defaultDate = Convert.ToDateTime("1900-01-01");

        public DateTime CreateTime { get; init; }
        public DateTime EditTime { get; init; }
        public DateTime CancelTime { get; init; }

        internal PersonSysInfo(DateTime createTime, DateTime editTime, DateTime cancelTime)
        {
            this.CreateTime = createTime;
            this.EditTime = editTime;
            this.CancelTime = cancelTime;
        }

        public static PersonSysInfo Create(DateTime createTime, DateTime editTime, DateTime cancelTime)
        {
            if (cancelTime == null)
                cancelTime = _defaultDate;
            return createTime < DateTime.MinValue || editTime < DateTime.MinValue ?
                throw new ArgumentNullException("PersonaSysInfo: el valor del no debe ser nulo ") :
                new PersonSysInfo(createTime, editTime, cancelTime);
        }
    }
}