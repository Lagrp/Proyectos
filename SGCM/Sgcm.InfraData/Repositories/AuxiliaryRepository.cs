using Sgcm.Dominio.Interfaces;
using Sgcm.Dominio.ValueObjects.AuxiliaryVO;
using Sgcm.InfraData.DbContext;
using System.Collections.Generic;
using System.Data;

namespace Sgcm.InfraData.Repositories
{
    public class AuxiliaryRepository : DBContext, IAuxiliaryRepository
    {
        public async Task<IEnumerable<DocumentTypeVo>> TableDocumentTypes(int Id = 0)
        {
            string mSQL = "SELECT * FROM doctypes";
            if (Id > 0) mSQL += $" WHERE tdoc_id='{Id}'";
            var list = new List<DocumentTypeVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //tdoc_id, tdoc_name, tdoc_abrev, tdoc_icon
                    list.Add(new DocumentTypeVo
                    {
                        Tdoc_id = Convert.ToInt32(row["tdoc_id"]),
                        Tdoc_name = row["tdoc_name"].ToString(),
                        Tdoc_abrev = row["tdoc_abrev"].ToString(),
                        Tdoc_icon = row["tdoc_icon"].ToString(),
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<GenderVo>> TableGenders(int Id = 0)
        {
            string mSQL = "SELECT * FROM genders";
            if (Id > 0) mSQL += $" WHERE gen_id='{Id}'";
            var list = new List<GenderVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                //gen_id, gen_type
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(new GenderVo
                    {
                        Gen_id = Convert.ToInt32(row["gen_id"]),
                        Gen_type = row["gen_type"].ToString(),
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<DptoVo>> TableDepartamentos(int Id = 0)
        {
            string mSQL = "SELECT * FROM ubdpto";
            if (Id > 0) mSQL += $" WHERE ubdep_id='{Id}'";

            var list = new List<DptoVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //ubdep_id, ubdep_name
                    list.Add(new DptoVo
                    {
                        Ubdep_id = Convert.ToInt32(row["ubdep_id"]),
                        Ubdep_name = row["ubdep_name"].ToString(),
                    });
                }
            }
            return list;
        }

        //public async Task<IEnumerable<ProvinciaVo>> TableProvinciasByDptoId(int dptoId)
        //{
        //    //ubprov_id, ubprov_name, ubprov_ubdep_id
        //    string mSQL = $"SELECT * FROM ubprov WHERE ubprov_ubdep_id='{dptoId}'";

        //}

        public async Task<IEnumerable<ProvinciaVo>> TableProvincias(int dptoId = 0)
        {
            string mSQL = "SELECT * FROM ubprov";
            mSQL += dptoId > 0 ? $" WHERE ubprov_ubdep_id='{dptoId}'" : "";

            var list = new List<ProvinciaVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //ubprov_id, ubprov_name, ubprov_ubdep_id
                    list.Add(new ProvinciaVo
                    {
                        Ubprov_id = Convert.ToInt32(row["ubprov_id"]),
                        Ubprov_name = row["ubprov_name"].ToString(),
                        Ubprov_ubdepid = Convert.ToInt32(row["ubprov_ubdep_id"]),
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<UbigeoVo>> TableUbigeo(int valor = 0)
        {
            string mSQL = "SELECT * FROM ubigeo";
            mSQL += valor > 0 ? $" WHERE ubg_prov_id='{valor}'" : "";

            var list = new List<UbigeoVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //ubg_id, ubg_name, ubg_prov_id, ubg_dep_id
                    list.Add(new UbigeoVo
                    {
                        Ubdis_id = Convert.ToInt32(row["ubg_id"]),
                        Ubdis_name = row["ubg_name"].ToString(),
                        Ubdis_ubprovid = Convert.ToInt32(row["ubg_prov_id"]),
                        Ubdis_ubdepid = Convert.ToInt32(row["ubg_dep_id"]),
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<StateVo>> TableStates(int Id = 0)
        {
            string mSQL = "SELECT * FROM states";
            if (Id > 0) mSQL += $" WHERE est_id='{Id}'";

            var list = new List<StateVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(new StateVo
                    {
                        Est_id = Convert.ToInt32(row["est_id"]),
                        Est_estado = row["est_state"].ToString(),
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<ProfileVo>> TableProfile(int Id = 0)
        {
            string mSQL = "SELECT * FROM profile";
            if (Id > 0) mSQL += $" WHERE profile_id='{Id}'";

            var list = new List<ProfileVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //profile_id, pro_level
                    list.Add(new ProfileVo
                    {
                        Profile_id = Convert.ToInt32(row["profile_id"]),
                        Pro_level = row["pro_level"].ToString(),
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<TypeOfUseVo>> TableTypeOfUse(int Id = 0)
        {
            string mSQL = "SELECT * FROM typeofuse";
            if (Id > 0) mSQL += $" WHERE type_id='{Id}'";

            var list = new List<TypeOfUseVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //type_id, type_name, type_icon
                    list.Add(new TypeOfUseVo
                    {
                        Type_id = Convert.ToInt32(row["type_id"]),
                        Type_name = row["type_name"].ToString(),
                        Type_icon = row["type_icon"].ToString(),
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<PhoneOperatorVo>> TablePhoneOperators(int Id = 0)
        {
            string mSQL = "SELECT * FROM phoneoper";
            if (Id > 0) mSQL += $" WHERE opet_id='{Id}'";

            var list = new List<PhoneOperatorVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //opet_id, opet_name, opet_logo
                    list.Add(new PhoneOperatorVo
                    {
                        Opet_id = Convert.ToInt32(row["opet_id"]),
                        Opet_name = row["opet_name"].ToString(),
                        Opet_logo = row["opet_logo"].ToString(),
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<NetTypesVo>> TableNetTypes(int Id = 0)
        {
            string mSQL = "SELECT * FROM nettype";
            if (Id > 0) mSQL += $" WHERE nett_id='{Id}'";

            var list = new List<NetTypesVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //nett_id, nett_name, nett_ico, nett_urlbase
                    list.Add(new NetTypesVo
                    {
                        Nett_id = Convert.ToInt32(row["nett_id"]),
                        Nett_name = row["nett_name"].ToString(),
                        Nett_ico = row["nett_ico"].ToString(),
                        Nett_urlbase = row["nett_urlbase"].ToString()
                    });
                }
            }
            return list;
        }

        public async Task<IEnumerable<SecureVo>> TableSecures()
        {
            string mSQL = "SELECT * FROM secure";
            var list = new List<SecureVo>();
            using (var dataTable = await ExecuteQueryAsync(mSQL))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //sec_id, sec_name
                    list.Add(new SecureVo
                    {
                        Sec_Id = Convert.ToInt32(row["sec_id"]),
                        Sec_Name = row["sec_name"].ToString(),
                    });
                }
            }
            return list;
        }
    }
}