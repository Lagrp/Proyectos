namespace Sgcm.InfraSoporte.Autentificacion
{
    public static class ActiveUser
    {
        public static int UserId { get; set; }
        public static string UserLogin { get; set; }
        public static string ShortName { get; set; }
        public static int ProfileId { get; set; }
        public static byte[]? User_Photo { get; set; }

        public static void Clear()
        {
            UserId = 0;
            UserLogin = "";
            ShortName = "";
            ProfileId = 0;
            User_Photo = null;
        }
    }
}