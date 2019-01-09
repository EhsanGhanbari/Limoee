using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limoee.Domain.CompetitionAgg;

namespace Limoee.Repository
{
    public class LimoeelInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LimoeeDataContext>
    {
        protected override void Seed(LimoeeDataContext context)
        {
            var stringbuilder = new StringBuilder();


            stringbuilder.AppendLine(
                "CREATE TYPE [dbo].[BannerIdsTableType] AS TABLE ([BannerID] UNIQUEIDENTIFIER NOT NULL); ");
            context.Database.ExecuteSqlCommand(stringbuilder.ToString());
            
            stringbuilder.Clear();
            stringbuilder.AppendLine(" CREATE PROCEDURE [dbo].[Log_Banner_Displaying]");
            stringbuilder.AppendLine(" @BannerIDs [dbo].[BannerIdsTableType] readonly");
            stringbuilder.AppendLine(" AS ");
            stringbuilder.AppendLine(" DECLARE @today Date =  GETUTCDATE(),@BannerId uniqueidentifier");
            stringbuilder.AppendLine(" DECLARE BannerIDs_Cursor CURSOR FORWARD_ONLY FOR SELECT BannerID FROM @BannerIDs");
            stringbuilder.AppendLine(" OPEN BannerIDs_Cursor");
            stringbuilder.AppendLine(" FETCH NEXT FROM BannerIDs_Cursor INTO @BannerId");
            stringbuilder.AppendLine(" WHILE @@FETCH_STATUS = 0");
            stringbuilder.AppendLine(" BEGIN");
            stringbuilder.AppendLine(" UPDATE BannerLog SET [Count] = ([Count] + 1) WHERE DisplayDate= @today AND BannerId = @BannerId");
            stringbuilder.AppendLine(" IF @@ROWCOUNT=0");
            stringbuilder.AppendLine(" INSERT INTO BannerLog (DisplayDate,BannerId,[Count]) VALUES (@today , @BannerId,1)");
            stringbuilder.AppendLine(" FETCH NEXT FROM BannerIDs_Cursor INTO @BannerId");
            stringbuilder.AppendLine(" END");
            stringbuilder.AppendLine(" CLOSE BannerIDs_Cursor");
            stringbuilder.AppendLine(" DEALLOCATE BannerIDs_Cursor");
            stringbuilder.AppendLine(" RETURN 0");

            context.Database.ExecuteSqlCommand(stringbuilder.ToString());

            var competitions = new List<Competition>()
            {
                new Competition()
                {
                    Description = "مسابقه آزمایشی شماره یک",
                    Id = Guid.NewGuid(),
                    Title = "مسابقه شماره 1",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(-23)
                },
                new Competition()
                {
                    Description = "مسابقه آزمایشی شماره یک",
                    Id = Guid.NewGuid(),
                    Title = "مسابقه شماره 2",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(-23)
                },
                new Competition()
                {
                    Description = "مسابقه آزمایشی شماره ذو",
                    Id = Guid.NewGuid(),
                    Title = "مسابقه شماره 3",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(-23)
                },
                new Competition()
                {
                    Description = "مسابقه آزمایشی شماره چهار",
                    Id = Guid.NewGuid(),
                    Title = "مسابقه شماره 4",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(-23)
                },
                new Competition()
                {
                    Description = "مسابقه آزمایشی شماره پنج",
                    Id = Guid.NewGuid(),
                    Title = "مسابقه شماره 5",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(-23)
                },
                new Competition()
                {
                    Description = "مسابقه آزمایشی شماره شش",
                    Id = Guid.NewGuid(),
                    Title = "مسابقه شماره 6",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(-23)
                },
            };

            competitions.ForEach(x => context.Competitions.Add(x));

            context.SaveChanges();


        }
    }
}
