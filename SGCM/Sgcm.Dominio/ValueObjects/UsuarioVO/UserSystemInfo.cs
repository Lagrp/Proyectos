namespace Sgcm.Dominio.ValueObjects.UsuarioVO
{
    public record UserSystemInfo
    {
        private static DateTime _defaultDate = Convert.ToDateTime("0001-01-01");

        public DateTime CreateTime { get; init; }
        public DateTime EditTime { get; init; }
        public DateTime CancelTime { get; init; }
        public int StateId { get; init; }

        internal UserSystemInfo(DateTime createTime, DateTime editTime, int stateId, DateTime cancelTime)
        {
            this.CreateTime = createTime.Date;
            this.EditTime = editTime.Date;
            this.CancelTime = cancelTime.Date;
            this.StateId = stateId;
        }
        public static UserSystemInfo Create(DateTime createTime, DateTime editTime, int stateId, DateTime cancelTime)
        {
            if (cancelTime == null)
                cancelTime= _defaultDate;

            return createTime < DateTime.MinValue || editTime < DateTime.MinValue || stateId < 1 ?
                throw new ArgumentNullException("SystemInfo: el valor del no debe ser nulo ") :
                new UserSystemInfo(createTime, editTime, stateId, cancelTime);
        }
    }
}