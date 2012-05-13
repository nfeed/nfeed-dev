using System.Collections;
using MySql.Data.MySqlClient;

namespace MCMS
{
    public class user
    {
        //Felder
        private string host;
        private string username;
        private string password;
        private string database;

        public user(string t_host, string t_user, string t_password, string t_database)
        {
            this.host = t_host;
            this.username = t_user;
            this.password = t_password;
            this.database = t_database;
        }

        public ArrayList get_all_user()
        {
            ArrayList usr = new ArrayList();

            string myConnectionString = "SERVER=" + this.host + ";" +
                            "DATABASE=" + this.database + ";" +
                            "UID=" + this.username + ";" +
                            "PASSWORD=" + this.password + ";";

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM user";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                    row += Reader.GetValue(i).ToString() + ", ";
                //usr.Add(row.ToString()); > Komplette Zeile
                usr.Add(Reader.GetValue(1).ToString()); // 1 = Zweites Felder, username!
            }
            connection.Close();
            return usr;
        }

        public int get_user_by_id(string t_username)
        {
            string myConnectionString = "SERVER=" + this.host + ";" +
                            "DATABASE=" + this.database + ";" +
                            "UID=" + this.username + ";" +
                            "PASSWORD=" + this.password + ";";

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id FROM user WHERE username = '" + t_username + "'";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            Reader.Read();
            string row = Reader.GetValue(0).ToString();
            connection.Close();
            return int.Parse(row);
        }

        public int getlastid()
        {
            string myConnectionString = "SERVER=" + this.host + ";" +
                            "DATABASE=" + this.database + ";" +
                            "UID=" + this.username + ";" +
                            "PASSWORD=" + this.password + ";";

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(id) FROM user ";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            Reader.Read();
            string row = Reader.GetValue(0).ToString();
            connection.Close();
            return int.Parse(row);
        }

        public bool adduser(string t_username, string t_password, string t_mail, int t_level)
        {
            string lastlogin = "-";
            string ip = "-";
            string avatar = "no_avatar.jpg";
            string block = "0";

            string myConnectionString = "SERVER=" + this.host + ";" +
                            "DATABASE=" + this.database + ";" +
                            "UID=" + this.username + ";" +
                            "PASSWORD=" + this.password + ";";

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            string InsertQuery = "INSERT INTO user (id, username, password, lastlogin, ip, level, mail, avatar, block)" +
                                 "Values('" + (this.getlastid() + 1) + "', '" + t_username + "', '" + t_password + "', '" + lastlogin + "', '" + ip + "', '" + t_level + "', '" + t_mail + "', '" + avatar + "', '" + block + "')";

            MySqlCommand Command = new MySqlCommand(InsertQuery);
            Command.Connection = connection;
            connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
            return true;
        }

        public bool delete_user_by_id(int id)
        {
            string myConnectionString = "SERVER=" + this.host + ";" +
                            "DATABASE=" + this.database + ";" +
                            "UID=" + this.username + ";" +
                            "PASSWORD=" + this.password + ";";

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            string InsertQuery = "Delete FROM User WHERE id = '" + id + "'";

            MySqlCommand Command = new MySqlCommand(InsertQuery);
            Command.Connection = connection;
            connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();
            return true;
        }
    }
}