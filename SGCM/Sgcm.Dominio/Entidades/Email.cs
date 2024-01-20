namespace Sgcm.Dominio.Entidades
{
    public class Email
    {
        //email_Id, email_personId, email_link, email_type, email_state

        public string Email_link { get; set; }
        public string? Email_personid { get; set; }
        public int Email_type { get; set; }
        public int Email_state { get; set; }
    }
}