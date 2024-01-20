using System.Collections.ObjectModel;

namespace Sgcm.App.DTOs
{
    public class PersonEmails : ObservableCollection<EmailDto>
    { }

    public class EmailDto
    {
        //email_link, email_personid, email_type, email_state
        public string Email_link { get; set; }

        public string Email_personId { get; set; }
        public int Email_type { get; set; }
        public int Email_state { get; set; }
    }
}