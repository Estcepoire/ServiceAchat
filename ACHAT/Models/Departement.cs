using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Departement
{
    public int id { get; set; }
    public string name { get; set; }

    public Departement() { }

    public List<String> getName()
    {
        List<String> mail = new List<String>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT nom FROM departement";
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

    public int getIdByName(String nom)
    {
        int id= 0;

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT id FROM departement where nom ='"+nom+"'";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
        }
        connection.Close();
        return id;
    }

}