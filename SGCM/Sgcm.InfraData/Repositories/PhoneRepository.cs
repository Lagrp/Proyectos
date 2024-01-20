using MySql.Data.MySqlClient;
using Sgcm.Dominio.Entidades;
using Sgcm.Dominio.Interfaces;
using Sgcm.InfraData.DbContext;
using System.Data;

namespace Sgcm.InfraData.Repositories
{
    public class PhoneRepository : DBContext, IPhoneRepository
    {
        private const string TABLA = "phones";
        private const string WHERE = " WHERE pho_number=";

        private string SELECTALL, INSERT, UPDATE, DELETE;

        public PhoneRepository()
        {
            #region SQL

            //pho_number, pho_person_id, pho_oper_id, pho_state, pho_typeuse

            SELECTALL = $"SELECT * FROM {TABLA}";

            INSERT = $"INSERT INTO {TABLA} (pho_number," +
                                           "pho_person_id," +
                                           "pho_oper_id," +
                                           "pho_state," +
                                           "pho_typeuse) " +
                                           "VALUES(@pho_number," +
                                           "@pho_person_id," +
                                           "@pho_oper_id," +
                                           "@pho_state," +
                                           "@pho_typeuse)";

            UPDATE = $"UPDATE {TABLA} SET pho_number=@pho_number," +
                                      "pho_person_id=@pho_person_id," +
                                      "pho_oper_id=@pho_oper_id," +
                                      "pho_state=@pho_state," +
                                      "pho_typeuse=@pho_typeuse" +
                                      WHERE + "@pho_number";

            DELETE = $"DELETE FROM {TABLA}{WHERE}";

            #endregion SQL
        }

        #region QUERYS

        public async Task<IEnumerable<Phone>> GetByFieldValueAsync(string value, string field)
        {
            string nfield = string.IsNullOrEmpty(field) ? "pho_person_id" : field;
            var result = await Execute($"{SELECTALL} WHERE {nfield} = '{value}'");
            return result.Count < 1 ? null : result;
        }

        public async Task<IEnumerable<Phone>> GeatAllAsync() => await Execute($"{SELECTALL}");

        public async Task<Phone> GetByIdAsync(string entityId)
        {
            var phone = await Execute($"{SELECTALL}{WHERE}'{entityId}'");
            return phone.Count < 1 ? null : phone.First();
        }

        #endregion QUERYS

        #region COMMANDS

        public async Task<int> SaveAsync(Phone entity)
        {
            CargaParametros(entity);
            var phone = await GetByIdAsync(entity.Pho_number);
            return phone == null ? await ExecuteNonQueryAsync(INSERT) : await ExecuteNonQueryAsync(UPDATE);
        }

        public async Task<int> DeleteAsync(string entityId)
        {
            var entity = GetByIdAsync(entityId);
            return entity == null ? 0 : await ExecuteNonQueryAsync(DELETE + entityId);
        }

        public async Task<int> ClearAsync() => await ExecuteNonQueryAsync($"TRUNCATE {TABLA}");

        #endregion COMMANDS

        #region METODOS PRIVADOS

        private void CargaParametros(Phone entity)
        {
            //pho_number, pho_personid, pho_operid, pho_state, pho_typeuse
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@pho_number",entity.Pho_number),
                new MySqlParameter("@pho_person_id",entity.Pho_personid),
                new MySqlParameter("@pho_oper_id",entity.Pho_operid),
                new MySqlParameter("@pho_state",entity.Pho_state),
                new MySqlParameter("@pho_typeuse",entity.Pho_typeuse)
            };
        }

        private async Task<List<Phone>> Execute(string consultaSQL)
        {
            var list = new List<Phone>();
            using (var dataTable = await ExecuteQueryAsync(consultaSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(new Phone
                    {
                        Pho_number = row["pho_number"].ToString(),
                        Pho_personid = row["pho_person_id"].ToString(),
                        Pho_operid = Convert.ToInt32(row["pho_oper_id"]),
                        Pho_state = Convert.ToInt32(row["Pho_state"]),
                        Pho_typeuse = Convert.ToInt32(row["pho_typeuse"])
                    });
                }
            }
            return list;
        }

        #endregion METODOS PRIVADOS
    }
}