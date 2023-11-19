using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Admin
{
    public int id { get; set; }
    public string name { get; set; }
    public string mail { get; set; }
    public string password { get; set; }



    public Admin() { }

    public List<String> Mail()
    {
        List<String> mail = new List<String>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT mail FROM admin";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    mail.Add(reader.GetString(0));
                }
            }
        }
        connection.Close();
        return mail;
    }

    public List<String> Password()
    {
        List<String> mail = new List<String>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT password FROM admin";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    mail.Add(reader.GetString(0));
                }
            }
        }
        connection.Close();
        return mail;
    }

}