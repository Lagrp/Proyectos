using MySql.Data.MySqlClient;
using Sgcm.Dominio.Entidades;
using Sgcm.Dominio.Interfaces;
using Sgcm.Dominio.ValueObjects.PesonaVO;
using Sgcm.InfraData.DbContext;
using System.Data;

namespace Sgcm.InfraData.Repositories
{
    public class PersonRepository : DBContext, IPersonRepository
    {
        //sql
        private const string TABLA = "persons";

        private const string WHERE = " WHERE person_id=";
        private string SELECTALL, INSERT, UPDATE, DELETE;

        //Constructores
        public PersonRepository()
        {
            #region SQL

            //person_id, per_doctype, per_docnumber, per_name, per_secondname, per_surname, per_secondsurname, per_birthday, per_gender_id, per_address, per_ubigeo, per_ruc, per_photo, per_createtime, per_edittime, per_canceltime, per_secure_id, per_securepolicy, per_patien_tid

            SELECTALL = $"SELECT * FROM {TABLA} ";

            UPDATE = $"UPDATE {TABLA} SET person_id = @person_id," +
                                            "per_doctype=@per_doctype," +
                                            "per_docnumber=@per_docnumber," +
                                            "per_name=@per_name," +
                                            "per_secondname=@per_secondname," +
                                            "per_surname=@per_surname," +
                                            "per_secondsurname=@per_secondsurname," +
                                            "per_birthday=@per_birthday," +
                                            "per_gender_id=@per_gender_id," +
                                            "per_address=@per_address," +
                                            "per_ubigeo=@per_ubigeo," +
                                            "per_ruc=@per_ruc," +
                                            "per_photo=@per_photo," +
                                            "per_createtime=@per_createtime," +
                                            "per_edittime=@per_edittime," +
                                            "per_canceltime=@per_canceltime," +
                                            "per_secure_id=@per_secure_id," +
                                            "per_securepolicy=@per_securepolicy," +
                                            "per_patient_id=@per_patient_id " +
                                            WHERE + "@person_id";

            INSERT = $"INSERT INTO {TABLA} (person_id," +
                                            "per_doctype," +
                                            "per_docnumber," +
                                            "per_name," +
                                            "per_secondname," +
                                            "per_surname," +
                                            "per_secondsurname," +
                                            "per_birthday," +
                                            "per_gender_id," +
                                            "per_address," +
                                            "per_ubigeo," +
                                            "per_ruc," +
                                            "per_photo," +
                                            "per_createtime," +
                                            "per_edittime," +
                                            "per_canceltime," +
                                            "per_secure_id," +
                                            "per_securepolicy," +
                                            "per_patient_id)" +
                                            " VALUES(@person_id, " +
                                            "@per_doctype," +
                                            "@per_docnumber," +
                                            "@per_name," +
                                            "@per_secondname," +
                                            "@per_surname," +
                                            "@per_secondsurname," +
                                            "@per_birthday," +
                                            "@per_gender_id," +
                                            "@per_address," +
                                            "@per_ubigeo," +
                                            "@per_ruc," +
                                            "@per_photo," +
                                            "@per_createtime," +
                                            "@per_edittime," +
                                            "@per_canceltime," +
                                            "@per_secure_id," +
                                            "@per_securepolicy," +
                                            "@per_patient_id)";

            DELETE = $"DELETE FROM {TABLA}{WHERE}";

            #endregion SQL
        }

        #region QUERYS

        public async Task<IEnumerable<Person>> GetByFieldValueAsync(string field, string value)
        {
            var result = await Execute($"{SELECTALL} WHERE {field} = '{value}'");
            return result.Count < 1 ? null : result;
        }

        public async Task<IEnumerable<Person>> GeatAllAsync() => await Execute(SELECTALL);

        public async Task<Person> GetByIdAsync(string entityId)
        {
            var person = await Execute($"{SELECTALL}{WHERE}'{entityId}'");
            return person.Count < 1 ? null : person.First();
        }

        #endregion QUERYS

        #region COMMANDS

        public async Task<int> SaveAsync(Person entity)
        {
            PersonLoadParameters(entity);
            var temp = await GetByIdAsync(entity.PersonId.ID);
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

        private void PersonLoadParameters(Person person)
        {
            //person_id, per_doctype, per_docnumber, per_name, per_secondname, per_surname, per_secondsurname, per_birthday, per_gender_id, per_address, per_ubigeo, per_ruc, per_photo, per_createtime, per_edittime, per_canceltime, per_secure_id, per_securepolicy, per_patien_tid

            parameters = new List<MySqlParameter>
            {
            new MySqlParameter("@person_id", person.PersonId.ID),
            new MySqlParameter("@per_doctype", person.PersonId.DocumentType),
            new MySqlParameter("@per_docnumber", person.PersonId.DocumentNumber),
            new MySqlParameter("@per_name", person.PersonName.FirstName),
            new MySqlParameter("@per_secondname", person.PersonName.SecondName),
            new MySqlParameter("@per_surname", person.PersonName.Surname),
            new MySqlParameter("@per_secondsurname", person.PersonName.SecondSurname),
            new MySqlParameter("@per_birthday", person.Person_Info.Birthdate),
            new MySqlParameter("@per_gender_id", person.Person_Info.GenderId),
            new MySqlParameter("@per_address", person.PersonUbigeo.Address),
            new MySqlParameter("@per_ubigeo", person.PersonUbigeo.Ubdis_Id),
            new MySqlParameter("@per_ruc", person.PersonId.RUC),
            new MySqlParameter("@per_photo", person.Per_Photo),
            new MySqlParameter("@per_createtime", person.Person_SysInfo.CreateTime),
            new MySqlParameter("@per_edittime", DateTime.Now),
            new MySqlParameter("@per_cancelTime", person.Person_SysInfo.CancelTime),
            new MySqlParameter("@per_secure_id", person.Person_Info.Per_SecureId),
            new MySqlParameter("@per_securepolicy", person.Person_Info.Per_SecurePolicy),
            new MySqlParameter("@per_patient_id", person.Per_PatientId)
            };
        }

        private async Task<List<Person>> Execute(string consultaSQL)
        {
            var list = new List<Person>();

            using (var dataTable = await ExecuteQueryAsync(consultaSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //person_id, per_doctype, per_docnumber, per_name, per_secondname, per_surname, per_secondsurname, per_birthday, per_gender_id, per_address, per_ubigeo, per_ruc, per_photo, per_createtime, per_edittime, per_canceltime, per_secure_id, per_securepolicy, per_patient_id

                    var entity = new Person();

                    entity.SetID(Convert.ToInt32(row["per_doctype"]),
                                    row["per_docnumber"].ToString(),
                                    row["person_id"].ToString(),
                                    row["per_ruc"].ToString());
                    entity.SetName(row["per_name"].ToString(),
                                    row["per_surname"].ToString(),
                                    row["per_secondsurname"].ToString(),
                                    row["per_secondname"].ToString());
                    entity.SetUbigeo(row["per_address"].ToString(),
                                    Convert.ToInt32(row["per_ubigeo"]));
                    entity.SetInfo(Convert.ToInt32(row["per_gender_id"]),
                                   Convert.ToDateTime(row["per_birthday"]),
                                   Convert.ToInt32(row["per_secure_id"]),
                                   row["per_securepolicy"].ToString());
                    entity.SetSysInfo(Convert.ToDateTime(row["per_createtime"]),
                                      Convert.ToDateTime(row["per_edittime"]),
                                      Convert.ToDateTime(row["per_cancelTime"]));
                    entity.Per_PatientId = row["per_patient_id"].ToString();
                    entity.Per_Photo = (byte[]?)row["per_photo"];

                    list.Add(entity);
                }
                return list;
            }
        }

        #endregion METODOS PRIVADOS
    }
}