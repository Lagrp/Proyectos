namespace Sgcm.App.DTOs
{
    //user_id, usu_personid, usu_profileid, usu_specialty, usu_colegiatura,
    //usu_login, usu_password, usu_photo, usu_createTime, usu_edittime, usu_canceltime, usu_state
    public class UserDto
    {
        public int User_Id { get; set; }
        public string User_PersonId { get; set; }
        public int User_Profileid { get; set; }
        public string? User_Specialty { get; set; }
        public string? User_Colegiatura { get; set; }
        public string User_Login { get; set; }
        public string User_Password { get; set; }
        public byte[]? User_Photo { get; set; }
        public string User_CreateTime { get; set; }
        public string User_EditTime { get; set; }
        public string User_CancelTime { get; set; }
        public int User_StateId { get; set; }
    }
}