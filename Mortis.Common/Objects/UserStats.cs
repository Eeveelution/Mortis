using EeveeTools.Database;
using EeveeTools.Helpers;
using Mortis.Common.Abstracts;
using MySqlConnector;

namespace Mortis.Common.Objects {
    public class UserStats : IMigratable {
        public long UserId { get; set; }
        public byte Mode { get; set; }

        public ulong RankedScore { get; set; }
        public ulong TotalScore { get; set; }
        public double Performance { get; set; }
        public ulong Playcount { get; set; }
        public double Accuracy { get; set; }
        public uint MaxCombo { get; set; }

        public int Rank { get; set; }

        public void Create(DatabaseContext ctx) {
            ctx.MySqlNonQuery("DROP IF EXISTS `stats`");

            const string creationSql = @"
                CREATE TABLE `stats` (
                    UserId bigint AUTO_INCREMENT,
                    Mode tinyint NOT NULL,
                    
                    RankedScore bigint unsigned DEFAULT 0 NOT NULL,
                    TotalScore bigint unsigned DEFAULT 0 NOT NULL,
                    Playcount bigint unsigned DEFAULT 0 NOT NULL,
                    Performance double DEFAULT 0.0 NOT NULL,
                    Accuracy double DEFAULT 0.0 NOT NULL,
                    MaxCombo int unsigned DEFAULT 0 NOT NULL,
                    
                    PRIMARY KEY(UserId, Mode)
                );
            ";

            ctx.MySqlNonQuery(creationSql);
        }
        public void Drop(DatabaseContext ctx) {
            ctx.MySqlNonQuery("DROP IF EXISTS `stats`");
        }

        public static UserStats FromDatabase(DatabaseContext ctx, long userId, int mode) {
            UserStats stats = new();

            const string sql = "SELECT * FROM `stats` WHERE UserId=@userid";

            MySqlParameter[] sqlParameters = new[] {
                new MySqlParameter("@userid", userId)
            };

            stats.MapObject(ctx.MySqlQuery(sql, sqlParameters)[0]);

            return stats;
        }
    }
}
