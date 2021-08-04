using System;
using System.Collections.Generic;
using EeveeTools.Database;
using EeveeTools.Helpers;
using Mortis.Common.Abstracts;
using MySqlConnector;

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
            User databaseUser = new User();

            const string sql = "SELECT * FROM `users` WHERE Username=@username";

            MySqlParameter[] sqlParameters = new[] {
                new MySqlParameter("@username", username)
            };

            databaseUser.MapObject(ctx.MySqlQuery(sql, sqlParameters)[0]);
            databaseUser.RefreshStats(ctx);

            return databaseUser;
        }

        public static User FromDatabase(DatabaseContext ctx, long userId) {
            User databaseUser = new User();

            const string sql = "SELECT * FROM `users` WHERE UserId=@userId";

            MySqlParameter[] sqlParameters = new[] {
                new MySqlParameter("@username", userId)
            };

            databaseUser.MapObject(ctx.MySqlQuery(sql, sqlParameters)[0]);
            databaseUser.RefreshStats(ctx);

            return databaseUser;
        }

        public static User CreateUser(DatabaseContext ctx, string username, string email, string plainPassword) {
            const string insertSql = "INSERT INTO `users` (Username, Email, PasswordBcrypt) VALUES (@username, @email, @password)";

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword, 10, true);

            MySqlParameter[] insertSqlParameters = new [] {
                new MySqlParameter("@username", username),
                new MySqlParameter("@email"   , email),
                new MySqlParameter("@password", hashedPassword),
            };

            try {
                ctx.MySqlNonQuery(insertSql, insertSqlParameters);
            }
            catch (MySqlException e) {
                if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry) {
                    LogHelper.Information($"User tried to register twice - Username: {username}");
                }

                return null;
            }

            const string idFindSql = "SELECT UserId FROM `users` WHERE Username=@username";

            MySqlParameter[] idFindParameters = new[] {
                new MySqlParameter("@username", username)
            };

            try {
                IReadOnlyDictionary<string, object>[] results = ctx.MySqlQuery(idFindSql, idFindParameters);

                long userId = (long) results[0].GetValueOrDefault("UserId", -1);

                if (userId != -1) {
                    const string statInsertSql = "INSERT INTO `stats` (UserId, Mode) VALUES (@userid, 0);" +
                                                 "INSERT INTO `stats` (UserId, Mode) VALUES (@userid, 1);" +
                                                 "INSERT INTO `stats` (UserId, Mode) VALUES (@userid, 2);" +
                                                 "INSERT INTO `stats` (UserId, Mode) VALUES (@userid, 3);";

                    MySqlParameter[] statInsertParameters = new[] {
                        new MySqlParameter("@userid", userId)
                    };

                    ctx.MySqlNonQuery(statInsertSql, statInsertParameters);

                    return FromDatabase(ctx, username);
                }
            }
            catch (MySqlException e) {
                if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry) {
                    LogHelper.Warning($"User tried to register twice (they got far though...) - Username: {username}");
                }

                return null;
            }

            return null;
        }

        public void RefreshStats(DatabaseContext ctx) {
            this.StandardStats = UserStats.FromDatabase(ctx, this.UserId, 0);
            this.TaikoStats    = UserStats.FromDatabase(ctx, this.UserId, 1);
            this.CatchStats    = UserStats.FromDatabase(ctx, this.UserId, 2);
            this.ManiaStats    = UserStats.FromDatabase(ctx, this.UserId, 3);
        }
    }
}
