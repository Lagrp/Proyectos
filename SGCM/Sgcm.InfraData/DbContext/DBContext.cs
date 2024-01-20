using MySql.Data.MySqlClient;
using System.Data;

namespace Sgcm.InfraData.DbContext
{
    public abstract class DBContext : Connection
    {
        protected List<MySqlParameter>? parameters;

        #region METODOS SYNCRONOS

        protected int ExecuteNonQuery(string transactSql)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transactSql;
                    command.CommandType = CommandType.Text;
                    foreach (MySqlParameter item in parameters)
                    {
                        command.Parameters.Add(item);
                    }
                    parameters.Clear();
                    return command.ExecuteNonQuery();
                }
            }
        }

        protected DataTable ExecuteQuery(string transactSql)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = new(transactSql, connection))
                {
                    var dataTable = new DataTable();
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
        }

        #endregion METODOS SYNCRONOS

        #region METODOS ASYNCRONOS

        protected async Task<int> ExecuteNonQueryAsync(string transactSql)
        {
            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transactSql;
                    command.CommandType = CommandType.Text;
                    foreach (MySqlParameter item in parameters)
                    {
                        command.Parameters.Add(item);
                    }
                    parameters.Clear();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        protected async Task<DataTable> ExecuteQueryAsync(string transactSql)
        {
            using (MySqlConnection connection = GetConnection())
            {
                await connection.OpenAsync();
                using (MySqlCommand command = new(transactSql, connection))
                {
                    var dataTable = new DataTable();
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        await adapter.FillAsync(dataTable);
                    }
                    return dataTable;
                }
            }
        }

        #endregion METODOS ASYNCRONOS
    }
}