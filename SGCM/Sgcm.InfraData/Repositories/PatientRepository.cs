using MySql.Data.MySqlClient;
using Sgcm.Dominio.Entidades;
using Sgcm.Dominio.Interfaces;
using Sgcm.InfraData.DbContext;
using System.Data;

namespace Sgcm.InfraData.Repositories
{
    public class PatientRepository : DBContext, IPatientRepository
    {
        private const string TABLA = "patients";
        private const string WHERE = " WHERE pat_id=";

        private string SELECTALL, INSERT, UPDATE, DELETE;

        public PatientRepository()
        {
            #region SQL

            //pat_id, pat_person_id, pat_ch_id, pat_state

            SELECTALL = $"SELECT * FROM {TABLA} ";

            UPDATE = $"UPDATE {TABLA} SET pat_id = @pat_id," +
                                        "pat_person_id=@pat_person_id," +
                                        "pat_ch_id=@pat_ch_id," +
                                        "pat_state=@pat_state" +
                                        WHERE + "@pat_id";

            INSERT = $"INSERT INTO {TABLA} (pat_id," +
                                            "pat_person_id," +
                                            "pat_ch_id," +
                                            "pat_state)" +
                                            " VALUES(@pat_id," +
                                            "@pat_person_id," +
                                            "@pat_ch_id," +
                                            "@pat_state)";

            DELETE = $"DELETE FROM {TABLA}{WHERE}";

            #endregion SQL
        }

        #region QUERYS

        public async Task<IEnumerable<Patient>> GetByFieldValueAsync(string value, string field)
        {
            string nfiled = string.IsNullOrEmpty(field) ? "pat_person_id" : "";
            var result = await Execute($"{SELECTALL} WHERE {field} = '{value}'");
            return result.Count < 1 ? null : result;
        }

        public async Task<IEnumerable<Patient>> GeatAllAsync() => await Execute(SELECTALL);

        public async Task<Patient> GetByIdAsync(string entityId)
        {
            var result = await Execute($"{SELECTALL}{WHERE}'{entityId}'");
            return result.Count < 1 ? null : result.First();
        }

        #endregion QUERYS

        #region COMMANDS

        public async Task<int> SaveAsync(Patient entity)
        {
            LoadParameters(entity);
            var temp = await GetByIdAsync(entity.Pac_id);
            var result = temp == null ? await ExecuteNonQueryAsync(INSERT) : await ExecuteNonQueryAsync(UPDATE);
            return result;
        }

        public async Task<int> DeleteAsync(string entityId)
        {
            var entity = await GetByIdAsync(entityId);
            return entity == null ? 0 : await ExecuteNonQueryAsync(DELETE + entityId);
        }

        public async Task<int> ClearAsync() => await ExecuteNonQueryAsync($"TRUNCATE {TABLA}");

        #endregion COMMANDS

        #region METODOS PRIVADOS

        private void LoadParameters(Patient entity)
        {
            //pat_id, pat_person_id, pat_ch_id, pat_state
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@pat_id",entity.Pac_id),
                new MySqlParameter("@pat_person_id",entity.Pac_personId),
                new MySqlParameter("@pat_ch_id",entity.Pac_hcId),
                new MySqlParameter("@pat_state",entity.Pac_state)
            };
        }

        private async Task<List<Patient>> Execute(string consultaSQL)
        {
            var list = new List<Patient>();
            using (var dataTable = await ExecuteQueryAsync(consultaSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //pat_id, pat_person_id, pat_ch_id, pat_state
                    list.Add(new Patient
                    {
                        Pac_id = row["pat_id"].ToString(),
                        Pac_personId = row["pat_person_id"].ToString(),
                        Pac_hcId = Convert.ToInt32(row["pat_ch_id"]),
                        Pac_state = Convert.ToInt32(row["pat_state"])
                    });
                }
            }
            return list;
        }

        #endregion METODOS PRIVADOS
    }
}