using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Produit
{
    public int id { get; set; }
    public string name { get; set; }

    public Produit() { }

    public List<String> getName()
    {
        List<String> nom = new List<String>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT nom FROM produit";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    nom.Add(reader.GetString(0));
                }
            }
        }
        connection.Close();
        return nom;
    }

    public int getIdByName(String nom)
    {
        int id = 0;

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT id FROM produit where nom ='" + nom + "'";
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