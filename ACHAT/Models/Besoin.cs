using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Besoin
{
    public int id { get; set; }
    public string name_produit { get; set; }
    public string name_departement { get; set; }
    public double quantite { get; set; }
    public string unite { get; set; }
    public string etat { get; set; }

    public int id_produit { get; set; }
    public int id_departement { get; set; }

    public Besoin() { }

    public void insert_besoin(String departement, String produit, double quantite, String unite)
    {
        Departement d = new Departement();
        Produit p = new Produit();
        int id_departement = d.getIdByName(departement);
        int id_produit = p.getIdByName(produit);

        using (NpgsqlConnection connection = Connect.GetSqlConnection())
        {
            connection.Open();

            string query = "INSERT INTO besoins VALUES(default,"+id_departement+","+id_produit+","+quantite+",'"+unite+"','refuser')";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    /////////////////////////////////////////
    public List<Besoin> getAllBesoin()
    {
        List<Besoin> b = new List<Besoin>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM all_besoins";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Besoin besoin = new Besoin();
                    besoin.id = reader.GetInt32(0);
                    besoin.name_produit= reader.GetString(1);
                    besoin.name_departement = reader.GetString(2);
                    besoin.quantite = reader.GetDouble(3);
                    besoin.unite = reader.GetString(4);
                    besoin.etat = reader.GetString(0);
                    b.Add(besoin);
                }
            }
        }
        connection.Close();
        return b;
    }

    //////////////////////////////////////////////////////
    public List<Besoin> getBesoins()
    {
        List<Besoin> b = new List<Besoin>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM besoins";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Besoin besoin = new Besoin();
                    besoin.id = reader.GetInt32(0);
                    besoin.id_produit = reader.GetInt32(1);
                    besoin.id_departement = reader.GetInt32(2);
                    besoin.quantite = reader.GetDouble(3);
                    besoin.unite = reader.GetString(4);
                    besoin.etat = reader.GetString(0);
                    b.Add(besoin);
                }
            }
        }
        connection.Close();
        return b;
    }

    public Besoin getBesoinbyId(int id)
    {
        Besoin besoin = new Besoin();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM besoins where id ="+id;
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    besoin.id = reader.GetInt32(0);
                    besoin.id_produit = reader.GetInt32(1);
                    besoin.id_departement = reader.GetInt32(2);
                    besoin.quantite = reader.GetDouble(3);
                    besoin.unite = reader.GetString(4);
                    besoin.etat = reader.GetString(0);
                }
            }
        }
        connection.Close();
        return besoin;
    }

    public void insert_besoin_validation(int id, String etat)
    {
        Besoin b = new Besoin();
        Besoin bs = b.getBesoinbyId(id);

        using (NpgsqlConnection connection = Connect.GetSqlConnection())
        {
            connection.Open();
            String query = "";
            if(etat == "VALIDER"){
                query = "INSERT INTO besoins_validation VALUES(default," + bs.id_departement + "," + bs.id_produit + "," + bs.quantite + ",'" + bs.unite + "','"+etat+"')";
            }else if(etat == "REFUSER"){
                query = "INSERT INTO besoins_validation VALUES(default," + bs.id_departement + "," + bs.id_produit + "," + bs.quantite + ",'" + bs.unite + "','" + etat + "')";

            }

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    ////////////////////////////////

    public List<Besoin> getAllBesoinValider()
    {
        List<Besoin> b = new List<Besoin>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM all_besoins_valider where etat ='valider'";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Besoin besoin = new Besoin();
                    besoin.id = reader.GetInt32(0);
                    besoin.name_produit = reader.GetString(1);
                    besoin.name_departement = reader.GetString(2);
                    besoin.quantite = reader.GetDouble(3);
                    besoin.unite = reader.GetString(4);
                    besoin.etat = reader.GetString(0);
                    b.Add(besoin);
                }
            }
        }
        connection.Close();
        return b;
    }
}