using Dapper;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Country
{
    public class CountryService : Repository<Country>,ICountryService
    {
        public CountryService(string connectionString) : base(connectionString) { }

        public override void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> FindAllWithAsync(Country t)
        {
            using (var conn = GetOpenConnection())
            {
                var query = "usp_Country_Set";
                var param = new DynamicParameters();
                param.Add("@CountryName", t.CountryName);

                var list = await SqlMapper.QueryAsync<Country>(conn, query, param, commandType: CommandType.StoredProcedure);
                return list;

            }
        }

        public override async Task<Country> FindAsync(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var query = "usp_Country_Set";
                var param = new DynamicParameters();
                param.Add("@CountryID", id);

                return await SqlMapper.QueryFirstOrDefaultAsync<Country>(conn, query, param: param, commandType: CommandType.StoredProcedure);

            }
        }

        public override async Task<IEnumerable<Country>> GetAllAsync()
        {
            using (var conn = GetOpenConnection())
            {
                var sql = "SELECT * FROM Country;";
                //var res = conn.QueryMultiple(sql);

                var results = conn.QueryMultiple(@"
                   select * from TTT; 
                     SELECT * FROM Country;
                    ");
              //  var users = results.Read<User>();
                var companies = results.Read();
                var companies1 = results.Read();
                return await conn.QueryAsync<Country>(sql);
            }
        }

        public override async void InsertAsync(Country entity)
        {
            using (var conn = GetOpenConnection())
            {
                var query = "usp_Country_Ins";
                var param = new DynamicParameters();
                param.Add("@CountryName", entity.CountryName);
                param.Add("@Code", entity.Code);
                param.Add("@CreateDate", entity.CreateDate);
                param.Add("@IsActive", entity.IsActive);
                param.Add("@IsClosed", entity.IsClosed);
                param.Add("@ModifyBy", entity.ModifyBy);
                param.Add("@ModifyDate", entity.ModifyDate);
                param.Add("@Rest", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var list = await SqlMapper.QueryAsync<Country>(conn, query, param, commandType: CommandType.StoredProcedure);
                int newID = param.Get<int>("Rest");
                // return list;

            }
        }

        public override void UpdateAsync(Country entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
