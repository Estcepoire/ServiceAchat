using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Departement
{
    public int id { get; set; }
    public string name { get; set; }

    public Departement() { }

    public static List<Departement> getAll()
    {
        List<Departement> dep = new List<Departement>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM departement";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Departement d = new Departement();
                    d.id=reader.GetInt32(0);
                    d.name=reader.GetString(1);
                    dep.Add(d);
                }
            }
        }
        connection.Close();
        return dep;
    }


}