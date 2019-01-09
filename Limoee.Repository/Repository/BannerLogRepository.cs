using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Limoee.Domain.BannerAgg;
using Limoee.Infrastructure.Domain;
using Limoee.Repository.Infrastructure;

namespace Limoee.Repository.Repository
{
    public class BannerLogRepository : BaseRepository<BannerLog, Guid>, IBannerLogRepository
    {
        public BannerLogRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public override PagedResult<BannerLog> GetMany(Expression<Func<BannerLog, bool>> expressionQuery, int pageIndex = 1, int pageSize = 30)
        {
            throw new NotImplementedException();
        }

        public void BannerLogBulkInsert(ISet<Guid> bannerIds)
        {
            if (!bannerIds.Any()) return;

            using (var connection = new SqlConnection(DataContext.Database.Connection.ConnectionString))
            {

                // Create a DataTable with the modified rows.
                var bannerIDsDataTable = ToDataTableID(bannerIds.ToList());

                // Configure the SqlCommand and SqlParameter.
                var insertCommand = new SqlCommand("Log_Banner_Displaying", connection);
                insertCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@BannerIDs", bannerIDsDataTable);
                tvpParam.SqlDbType = SqlDbType.Structured;

                connection.Open();
                // Execute the command.
                insertCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        private static DataTable ToDataTableID(IEnumerable<Guid> items)
        {
            var dataTable = new DataTable("BannerIDs");

            dataTable.Columns.Add("ID");

            foreach (var item in items)
            {
                dataTable.Rows.Add(new object[] { item });
            }

            return dataTable;
        }
    }



}
