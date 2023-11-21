using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Produit
{
    public int id { get; set; }
    public string name { get; set; }
    public string unite { get; set; }

    public Produit() { }

    public static List<Produit> getAll()
    {
        List<Produit> nom = new List<Produit>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM produit";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Produit p = new Produit();
                    p.id = reader.GetInt32(0);
                    p.name = reader.GetString(1);
                    p.unite = reader.GetString(2);
                    nom.Add(p);
                }
            }
        }
        connection.Close();
        return nom;
    }

    public static Produit getIdBy(int id)
    {
        Produit p = new Produit();
        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM produit where id =" + id + "";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    p.id = reader.GetInt32(0);
                    p.name = reader.GetString(1);
                    p.unite = reader.GetString(2);
                }
            }
        }
        connection.Close();
        return p;
    }

}