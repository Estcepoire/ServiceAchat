using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Unite
{
    public int id { get; set; }
    public string name { get; set; }

    public Unite() { }

    public List<String> getName()
    {
        List<String> unite = new List<String>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT nom FROM unite";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    unite.Add(reader.GetString(0));
                }
            }
        }
        connection.Close();
        return unite;
    }

    public int getIdByName(String nom)
    {
        int id = 0;

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT id FROM unite where nom ='" + nom + "'";
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