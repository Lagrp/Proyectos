using MySql.Data.MySqlClient;
using Sgcm.Dominio.Entidades;
using Sgcm.Dominio.Interfaces;
using Sgcm.InfraData.DbContext;
using System.Data;

namespace Sgcm.InfraData.Repositories
{
    public class UserRepository : DBContext, IUserRepository

    {
        private const string TABLA = "users";
        private const string WHERE = " WHERE user_id=";

        private string SELECTALL, INSERT, UPDATE, DELETE;

        //Constructores
        public UserRepository()
        {

            #region CONSULTA SQL

            //user_id, usu_person_id, usu_profile_id, usu_specialty, usu_colegiatura, usu_login, usu_password, usu_createtime, usu_edittime, usu_canceltime, usu_state


            SELECTALL = $"SELECT * FROM {TABLA} ";

            INSERT = $"INSERT INTO {TABLA}(usu_person_id," +
                                           "usu_profile_id," +
                                           "usu_specialty,"+
                                           "usu_colegiatura,"+
                                           "usu_login,"+
                                           "usu_createtime,"+
                                           "usu_edittime,"+
                                           "usu_canceltime,"+
                                           "usu_state) "+
                                           "VALUES(@usu_person_id,"+
                                           "@usu_profile_id,"+
                                           "@usu_specialty,"+
                                           "@usu_colegiatura,"+
                                           "@usu_login,"+
                                           "@usu_createtime,"+
                                           "@usu_edittime,"+
                                           "@usu_canceltime,"+
                                           "@usu_state)";

            UPDATE = $"UPDATE {TABLA} SET user_id=@user_id," +
                                        "usu_person_id=@usu_person_id," +
                                        "usu_profile_id=@usu_profile_id," +
                                        "usu_specialty=@usu_specialty," +
                                        "usu_colegiatura=@usu_colegiatura," +
                                        "usu_login=@usu_login," +
                                        "usu_password=@usu_password," +
                                        "usu_createtime=@usu_createtime," +
                                        "usu_edittime=@usu_edittime," +
                                        "usu_canceltime=@usu_canceltime," +
                                        "usu_state=@usu_state" +
                                        WHERE + "@user_id";

            DELETE = $"DELETE FROM {TABLA}{WHERE}";

            #endregion CONSULTA SQL
        }

        #region QUERYS

        public async Task<IEnumerable<User>> GetByFieldValueAsync(string value, string field)
        {
            string nfield = string.IsNullOrEmpty(field) ? "usu_person_id" : field;
            var result = await Execute($"{SELECTALL} WHERE {nfield} = '{value}'");
            return result.Count < 1 ? null : result;
        }

        public async Task<IEnumerable<User>> GeatAllAsync() => await Execute(SELECTALL);

        public async Task<User> GetByIdAsync(string userId)
        {
            var user = await Execute($"{SELECTALL}{WHERE}{userId}");
            return user.Count < 1 ? null : user.First();
        }

        public async Task<User> GetValidUser(string userLogin, string password)
        {
            string SQL = $"SELECT * FROM {TABLA} WHERE usu_login='{userLogin}' AND usu_password='{password}' AND usu_state='1'";
            try
            {
                var validUser = await Execute(SQL);
                return validUser.First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion QUERYS

        #region COMMANDS

        public async Task<int> SaveAsync(User user)
        {
            UserLoadParameters(user);
            var validUer = await GetByIdAsync(user.User_Id.ToString());
            var result = validUer == null ? await ExecuteNonQueryAsync(INSERT) : await ExecuteNonQueryAsync(UPDATE);
            return result;
        }

        public async Task<int> DeleteAsync(string userId)
        {
            var user = GetByIdAsync(userId);
            return user == null ? 0 : await ExecuteNonQueryAsync(DELETE + userId);
        }

        public async Task<int> ClearAsync() => await ExecuteNonQueryAsync($"TRUNCATE {TABLA}");

        #endregion COMMANDS

        #region METODOS PRIVADOS

        private void UserLoadParameters(User user)
        {
            parameters = new List<MySqlParameter>
            {
            new MySqlParameter("@user_id", user.User_Id),
            new MySqlParameter("@usu_person_id", user.User_PersonId),
            new MySqlParameter("@usu_profile_id", user.User_LoginSystem.ProfileId),
            new MySqlParameter("@usu_specialty", user.User_ProfileInfo.Specialty),
            new MySqlParameter("@usu_colegiatura", user.User_ProfileInfo.Colegiatura),
            new MySqlParameter("@usu_login", user.User_LoginSystem.UserLogin),
            new MySqlParameter("@usu_photo", user.User_Photo),
            new MySqlParameter("@usu_createtime", user.User_SystemInfo.CreateTime),
            new MySqlParameter("@usu_edittime", DateTime.Now),
            new MySqlParameter("@usu_canceltime",user.User_SystemInfo.CancelTime),
            new MySqlParameter("@usu_state", user.User_SystemInfo.StateId)
            };
        }
        private async Task<List<User>> Execute(string consultaSQL)
        {
            var users = new List<User>();
            using (var dataTable = await ExecuteQueryAsync(consultaSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var user = new User();
                    user.User_Id = Convert.ToInt32(row["user_id"]);
                    user.User_PersonId = row["usu_person_id"].ToString();
                    user.GetLoginSystem(row["usu_login"].ToString(),
                                        Convert.ToInt32(row["usu_profile_id"]),
                                        row["usu_password"].ToString());
                    user.GetProfileInfo(row["usu_specialty"].ToString(),
                                        row["usu_colegiatura"].ToString());
                    user.GetSystemInfo(Convert.ToDateTime(row["usu_createtime"]),
                                        Convert.ToDateTime(row["usu_edittime"]),
                                        Convert.ToInt32(row["usu_state"]),
                                        Convert.ToDateTime(row["usu_canceltime"]));
                    users.Add(user);
                }
            }
            return users;
        }
    }

    #endregion METODOS PRIVADOS
}