using MySql.Data.MySqlClient;
using Sgcm.Dominio.Entidades;
using Sgcm.Dominio.Interfaces;
using Sgcm.InfraData.DbContext;
using System.Data;

namespace Sgcm.InfraData.Repositories
{
    public class EmailRepository : DBContext, IEmailRepository
    {
        private const string TABLA = "emails";
        private const string WHERE = "WHERE email_link=";

        private string SELECTALL, INSERT, UPDATE, DELETE;

        public EmailRepository()
        {
            #region SQL

            //email_link, email_person_id, email_type, email_state

            SELECTALL = $"SELECT * FROM {TABLA} ";

            INSERT = $"INSERT INTO {TABLA} VALUES(@email_link," +
                                                "@email_person_id," +
                                                "@email_type," +
                                                "@email_state)";

            UPDATE = $"UPDATE {TABLA} SET email_person_id=@email_person_id," +
                                        "email_type=@email_type, " +
                                        "email_state=@email_state " +
                                        WHERE + "@email_link";

            DELETE = $"DELETE FROM {TABLA} ";

            #endregion SQL
        }

        #region QUERYS

        public async Task<IEnumerable<Email>> GetByFieldValueAsync(string value,string field)
        {
            string nfield = string.IsNullOrEmpty(field) ? "email_person_id" : field;
            var result = await Execute($"{SELECTALL} WHERE {nfield} = '{value}'");
            return result.Count < 1 ? null : result;
        }

        public async Task<IEnumerable<Email>> GeatAllAsync() => await Execute(SELECTALL);

        public async Task<Email> GetByIdAsync(string entityId)
        {
            var email = await Execute($"{SELECTALL} {WHERE}'{entityId}'");
            return email.Count < 1 ? null : email.First();
        }

        #endregion QUERYS

        #region COMMANDS

        public async Task<int> SaveAsync(Email entity)
        {
            CargaParametros(entity);
            var temp = await GetByIdAsync(entity.Email_link);
            return temp == null ? await ExecuteNonQueryAsync(INSERT) : await ExecuteNonQueryAsync(UPDATE);
        }

        public async Task<int> DeleteAsync(string entityId)
        {
            var entity = GetByIdAsync(entityId);
            return entity == null ? 0 : await ExecuteNonQueryAsync(DELETE + entityId);
        }

        public async Task<int> ClearAsync() => await ExecuteNonQueryAsync($"TRUNCATE {TABLA}");

        #endregion COMMANDS

        #region METODOS PRIVADOS

        private void CargaParametros(Email entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@email_link", entity.Email_link),
                new MySqlParameter("@email_person_id", entity.Email_personid),
                new MySqlParameter("@email_type",entity.Email_type),
                new MySqlParameter("@email_state",entity.Email_state)
            };
        }

        private async Task<List<Email>> Execute(string consultaSQL)
        {
            var list = new List<Email>();
            using (var dataTable = await ExecuteQueryAsync(consultaSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(new Email
                    {
                        Email_link = row["email_link"].ToString(),
                        Email_personid = row["email_person_id"].ToString(),
                        Email_type = Convert.ToInt32(row["email_type"]),
                        Email_state = Convert.ToInt32(row["email_state"])
                    });
                }
            }
            return list;
        }

        #endregion METODOS PRIVADOS
    }
}