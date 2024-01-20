using Sgcm.InfraSoporte.Autentificacion;

namespace Sgcm.App.Services
{
    public class LoginService
    {
        private IUserRepository _userRepository;
        private IPersonRepository _personRepository;

        public LoginService()
        {
            _userRepository = new UserRepository();
            _personRepository = new PersonRepository();
        }

        public int ValidateUserId(string user, string password)
        {
            Task.Run(async () =>
            {
                var validUser = await _userRepository.GetValidUser(user, password);
                if (validUser != null)
                {
                    var person = await _personRepository.GetByIdAsync(validUser.User_PersonId);

                    ActiveUser.UserId = validUser.User_Id;
                    ActiveUser.UserLogin = validUser.User_LoginSystem.UserLogin;
                    ActiveUser.ProfileId = validUser.User_LoginSystem.ProfileId;
                    ActiveUser.ShortName = person.PersonName.ShortName();
                    ActiveUser.User_Photo = person.Per_Photo;
                }
                else
                {
                    ActiveUser.Clear();
                }
            }).GetAwaiter().GetResult();
            return ActiveUser.UserId;
        }

        public string NewUserValidation()
        {
            return "validacion de usuario nuevo";
        }
    }
}