namespace Sgcm.App.Validations
{
    public static class UserValidationsService
    {
        public static bool UseValidation(UserDto userDto)
        {
            if (userDto == null)
                return false;
            if (string.IsNullOrEmpty(userDto.User_PersonId))
                return false;
            if (userDto.User_Profileid < 1)
                return false;
            if (string.IsNullOrEmpty(userDto.User_Login))
                return false;

            return true;
        }
    }
}