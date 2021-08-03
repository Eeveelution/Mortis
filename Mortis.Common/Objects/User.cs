using System;
using EeveeTools.Database;
using Mortis.Common.Abstracts;

namespace Mortis.Common.Objects {
    public class User : IMigratable {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordBcrypt { get; set; }
        public string Country { get; set; }
        public DateTime SilenceEnd { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastSeen { get; set; }

        public UserStats StandardStats { get; set; }
        public UserStats TaikoStats { get; set; }
        public UserStats CatchStats { get; set; }
        public UserStats ManiaStats { get; set; }

        public void Create(DatabaseContext ctx) {
            ctx.MySqlNonQuery("DROP IF EXISTS `users`");

            const string creationSql = @"
                CREATE TABLE `users` (
                    UserId bigint AUTO_INCREMENT PRIMARY KEY,
                    Username varchar(32) CHARSET UTF8 NOT NULL,
                    Email varchar(254) NOT NULL,
                    PasswordBcrypt char(60) NOT NULL,
                    Country char(2) DEFAULT 'XX' NOT NULL,
                    SilenceEnd datetime DEFAULT CURRENT_TIMESTAMP(),
                    CreationTime datetime DEFAULT CURRENT_TIMESTAMP(),
                    LastSeen datetime DEFAULT CURRENT_TIMESTAMP(),
                    
                    CONSTRAINT users_username_constraint UNIQUE (Username),
                    CONSTRAINT users_email_constraint UNIQUE (Email)
                );
            ";

            ctx.MySqlNonQuery(creationSql);
        }

        public void Drop(DatabaseContext ctx) {
            ctx.MySqlNonQuery("DROP IF EXISTS `users`");
        }

        public static User FromDatabase(DatabaseContext ctx, string username) {
           // User databaseUser = new
        }
    }
}
