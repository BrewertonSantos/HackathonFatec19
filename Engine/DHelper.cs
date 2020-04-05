using System;
using System.Data;
using System.Data.SQLite;

namespace Engine
{
    public class DHelper
    {
        private static SQLiteConnection sqliteConn;
        private static SQLiteDataAdapter da = null;
        private static DataTable dt = new DataTable();

        public DHelper()
        { }

        private static SQLiteConnection DbConn()
        {
            sqliteConn = new SQLiteConnection(@"Data Source=C:\IRC\teste.sqlite;Version=3;");
            sqliteConn.Open();
            return sqliteConn;
        }

        // Creates a database on at the specified path if it doesn't exist.
        public static void CreateDb(string dbName)
        {
            /*var directory = @"C:\Users\BREWERTONTHIAGOOLIVE\Desktop";
            var filename = "dbfile.sqlite";
            var query = directory + filename;*/
            try
            {
                SQLiteConnection.CreateFile(@"C:\IRC\teste.sqlite");
            }
            catch
            {
                throw;
            }
        }

        // Creates a table on the specified database with fields(id, name, email).
        public static void CreateTable()
        {
            try
            {
                using (var cmd = DbConn().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Tab1 (id int, name VarChar(50), email VarChar(80))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region CRUD
        public static void Add(int id, string name, string serial)
        {
            try
            {
                using (var cmd = DbConn().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Tab1(id, name, email) values (@id, @name, @email)";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", serial);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // Geting content in a specific table, (*) to get all the content. 
        public static DataTable GetTab1()
        {
            try
            {
                using (var cmd = DbConn().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Tab1";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConn());
                    // Inputing query data in data adapter.
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetById(int id)
        {
            try
            {
                using (var cmd = DbConn().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Tab1 Where id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConn());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(int? id, string name, string serial)
        {
            try
            {
                using(var cmd = new SQLiteCommand(DbConn()))
                {
                    if(id != null)
                    {
                        cmd.CommandText = "Update Tab1 SET Nome=@Nome, Email=@Email WHERE Id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Nome", name);
                        cmd.Parameters.AddWithValue("@Email", serial);
                        // Executing command.
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void Delete(int Id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConn()))
                {
                    cmd.CommandText = "DELETE FROM Tab1 Where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
