namespace Sgcm.App.Services
{
    public class MainService
    {
        private IUserRepository _userRepository;

        public MainService()
        {
            _userRepository = new UserRepository();
        }

        //public async Task ActiveUser(int userId)
        //{
        //    var user = await _userRepository.GetByIdAsync(userId.ToString());

        //    var activeUser = new ActiveUser
        //    {
        //        User_Id = user.User_Id,
        //        UserLogin = user.User_SystemInfo.UserLogin,
        //        AccessLevelId = user.User_SystemInfo.AccessLevelId,
        //        ShortName = user.User_Person.PersonName.ShortName(),
        //        User_Photo = user.User_Photo
        //    };
        //    return activeUser;
        //}
    }
}