namespace Sgcm.App.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        #region QUERY'S

        public async Task<UserDto> GetUserByPersonId(string personId)
        {
            var user = await _userRepository.GetByFieldValueAsync(value: personId);
            if (user == null || user.Count() != 1)
                return null;
            return GetUserDto(user.First());
        }

        #endregion QUERY'S

        #region COMMAND'S

        public async Task<int> SaveUserAsync(UserDto userDto) => await _userRepository.SaveAsync(GetUser(userDto));

        #endregion COMMAND'S

        #region METODOS PRIVDOS

        private UserDto GetUserDto(User user)
        {
            return new UserDto
            {
                User_Id = user.User_Id,
                User_PersonId = user.User_PersonId,
                User_Profileid = user.User_LoginSystem.ProfileId,
                User_Specialty = user.User_ProfileInfo.Specialty,
                User_Colegiatura = user.User_ProfileInfo.Colegiatura,
                User_Login = user.User_LoginSystem.UserLogin,
                User_Password = user.User_LoginSystem.Password,
                User_Photo = user.User_Photo,
                User_CreateTime = user.User_SystemInfo.CreateTime.ToString("dd/MM/yyyy"),
                User_EditTime = user.User_SystemInfo.EditTime.ToString("dd/MM/yyyy"),
                User_CancelTime = user.User_SystemInfo.CancelTime.ToString("dd/MM/yyyy"),
                User_StateId = user.User_SystemInfo.StateId,
            };
        }

        private User GetUser(UserDto userDto)
        {
            var user = new User();
            user.User_Id = userDto.User_Id;
            user.User_PersonId = userDto.User_PersonId;
            user.GetLoginSystem(userDto.User_Login, userDto.User_Profileid, userDto.User_Password);
            user.GetProfileInfo(userDto.User_Specialty, userDto.User_Colegiatura);
            user.GetSystemInfo(Convert.ToDateTime(userDto.User_CreateTime),
                Convert.ToDateTime(userDto.User_EditTime),
                userDto.User_StateId,
                Convert.ToDateTime(userDto.User_CancelTime));
            user.User_Photo = userDto.User_Photo;

            return user;
        }

        #endregion METODOS PRIVDOS
    }
}

//.ToString("MM/dd/yyyy")