using MySql.Data.MySqlClient;
using Sgcm.Dominio.Entidades;
using Sgcm.Dominio.Interfaces;
using Sgcm.InfraData.DbContext;
using System.Data;

namespace Sgcm.InfraData.Repositories
{
    public class NetRepository : DBContext, INetRepository
    {
        private const string TABLA = "nets";
        private const string WHERE = " WHERE net_url=";

        private string SELECTALL, INSERT, UPDATE, DELETE;

        public NetRepository()
        {
            #region SQL

            //net_url, net_person_id, net_nettype, net_state

            SELECTALL = $"SELECT * FROM {TABLA} ";

            INSERT = $"INSERT INTO {TABLA} (net_url," +
                                            "net_person_id," +
                                            "net_nettype," +
                                            "net_state) " +
                                            "VALUES(@net_url," +
                                            "@net_person_id," +
                                            "@net_nettype," +
                                            "@net_state)";

            UPDATE = $"UPDATE {TABLA} SET net_person_id=@net_person_id," +
                                      "net_nettype=@net_nettype," +
                                      "net_state=@net_state" +
                                      WHERE + "@net_url";

            DELETE = $"DELETE FROM {TABLA}{WHERE}";

            #endregion SQL
        }

        #region QUERYS

        public async Task<IEnumerable<Net>> GetByFieldValueAsync(string value, string field)
        {
            string nfield = string.IsNullOrEmpty(field) ? "net_person_id" : field;
            var result = await Execute($"{SELECTALL} WHERE {nfield} = '{value}'");
            return result.Count < 1 ? null : result;
        }

        public async Task<IEnumerable<Net>> GeatAllAsync() => await Execute(SELECTALL);

        public async Task<Net> GetByIdAsync(string entityId)
        {
            var net = await Execute($"{SELECTALL}{WHERE}'{entityId}'");
            return net.Count < 1 ? null : net.First();
        }

        #endregion QUERYS

        #region COMMANDS

        public async Task<int> SaveAsync(Net entity)
        {
            CargaParametros(entity);
            var temp = await GetByIdAsync(entity.Net_url);
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

        private void CargaParametros(Net entity)
        {
            parameters = new List<MySqlParameter>
            {
                //net_url, net_person_id, net_nettype, net_state
                new MySqlParameter("@net_url",entity.Net_url),
                new MySqlParameter("@net_person_id", entity.Net_personid),
                new MySqlParameter("@net_nettype", entity.Net_nettype),
                new MySqlParameter("@net_state",entity.Net_state)
            };
        }

        private async Task<List<Net>> Execute(string consultaSQL)
        {
            var list = new List<Net>();
            using (var dataTable = await ExecuteQueryAsync(consultaSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(new Net
                    {
                        //net_url, net_person_id, net_nettype, net_state
                        Net_url = row["net_url"].ToString(),
                        Net_personid = row["net_person_id"].ToString(),
                        Net_nettype = Convert.ToInt32(row["net_nettype"]),
                        Net_state = Convert.ToInt32(row["net_state"])
                    });
                }
            }
            return list;
        }

        #endregion METODOS PRIVADOS
    }
}