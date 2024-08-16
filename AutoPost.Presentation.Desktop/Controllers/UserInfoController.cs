using Microsoft.Data.Sqlite;
using AutoPost.Presentation.Desktop.Models;

namespace AutoPost.Presentation.Desktop.Controllers
{
    public class UserInfoController
    {
        private readonly string _connectionString;

        public UserInfoController(string databasePath)
        {

            _connectionString = $"Data Source={databasePath};";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var query = @"
                CREATE TABLE IF NOT EXISTS UserInfo (
                    UserId TEXT PRIMARY KEY,
                    Likes INTEGER,
                    IsSubscribed INTEGER,
                    IsActive INTEGER,
                    LastColor TEXT,
                    Shares INTEGER,
                    Follows INTEGER,
                    Gifts INTEGER,
                    Comments INTEGER,
                    Emotes INTEGER
                )";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SaveUserInfo(UserInfo userInfo)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var query = @"
                INSERT INTO UserInfo (UserId, Likes, IsSubscribed, IsActive, LastColor, Shares, Follows, Gifts, Comments, Emotes)
                VALUES (@UserId, @Likes, @IsSubscribed, @IsActive, @LastColor, @Shares, @Follows, @Gifts, @Comments, @Emotes)
                ON CONFLICT(UserId) DO UPDATE SET 
                    Likes = excluded.Likes,
                    IsSubscribed = excluded.IsSubscribed,
                    IsActive = excluded.IsActive,
                    LastColor = excluded.LastColor,
                    Shares = excluded.Shares,
                    Follows = excluded.Follows,
                    Gifts = excluded.Gifts,
                    Comments = excluded.Comments,
                    Emotes = excluded.Emotes";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userInfo.UserId);
                    command.Parameters.AddWithValue("@Likes", userInfo.Likes);
                    command.Parameters.AddWithValue("@IsSubscribed", userInfo.IsSubscribed ? 1 : 0);
                    command.Parameters.AddWithValue("@IsActive", userInfo.IsActive ? 1 : 0);
                    command.Parameters.AddWithValue("@LastColor", userInfo.LastColor);
                    command.Parameters.AddWithValue("@Shares", userInfo.Shares);
                    command.Parameters.AddWithValue("@Follows", userInfo.Follows);
                    command.Parameters.AddWithValue("@Gifts", userInfo.Gifts);
                    command.Parameters.AddWithValue("@Comments", userInfo.Comments);
                    command.Parameters.AddWithValue("@Emotes", userInfo.Emotes);

                    command.ExecuteNonQuery();
                }
            }
        }

        public UserInfo? LoadUserInfo(string userId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM UserInfo WHERE UserId = @UserId";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserInfo
                            {
                                UserId = reader.GetString(reader.GetOrdinal("UserId")),
                                Likes = reader.GetInt64(reader.GetOrdinal("Likes")),
                                IsSubscribed = reader.GetInt64(reader.GetOrdinal("IsSubscribed")) == 1,
                                IsActive = reader.GetInt64(reader.GetOrdinal("IsActive")) == 1,
                                LastColor = reader.GetString(reader.GetOrdinal("LastColor")),
                                Shares = reader.GetInt32(reader.GetOrdinal("Shares")),
                                Follows = reader.GetInt32(reader.GetOrdinal("Follows")),
                                Gifts = reader.GetInt32(reader.GetOrdinal("Gifts")),
                                Comments = reader.GetInt32(reader.GetOrdinal("Comments")),
                                Emotes = reader.GetInt32(reader.GetOrdinal("Emotes"))
                            };
                        }
                    }
                }
            }

            return null;
        }
    }

}
