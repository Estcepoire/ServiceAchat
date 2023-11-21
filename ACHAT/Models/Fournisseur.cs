using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Fournisseur
{
    public int id { get; set; }
    public string name { get; set; }
    public string adresse { get; set; }
    public string contact { get; set; }
    public string mail { get; set; }


    public string name_produit { get; set; }
    public string name_fournisseur { get; set; }
    public string name_unite { get; set; }
    public double prix_unitaire { get; set; }
    public DateTime date { get; set; }


    public Fournisseur() { }

    public List<String> getName()
    {
        List<String> nom = new List<String>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT nom FROM fournisseur";
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

    public static List<Fournisseur> getAllFournisseur()
    {
        List<Fournisseur> fournisseurs = new List<Fournisseur>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM fournisseur";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Fournisseur f= new Fournisseur();
                    f.id = reader.GetInt32(0);
                    f.name = reader.GetString(1);
                    f.adresse = reader.GetString(2);
                    f.contact = reader.GetString(3);
                    f.mail = reader.GetString(4);
                    fournisseurs.Add(f);
                }
            }
        }
        connection.Close();
        return fournisseurs;
    }

    public int getIdByName(String nom)
    {
        int id = 0;

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT id FROM fournisseur where nom ='" + nom + "'";
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

    /////////////////////////////////////
    public List<Fournisseur> getAllFournisseur_produit()
    {
        List<Fournisseur> fournisseurs = new List<Fournisseur>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM all_fournisseur_produit";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Fournisseur f = new Fournisseur();
                    f.id = reader.GetInt32(0);
                    f.name_fournisseur = reader.GetString(1);
                    f.name_produit = reader.GetString(2);
                    f.name_unite = reader.GetString(3);
                    f.prix_unitaire = reader.GetDouble(4);
                    f.date = reader.GetDateTime(5);
                    fournisseurs.Add(f);
                }
            }
        }
        connection.Close();
        return fournisseurs;
    }

    public List<String> getNameProduit(String fournisseur)
    {
        List<String> nom = new List<String>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT nom_produit FROM all_fournisseur_produit where nom_fournisseur ='" + fournisseur + "'";
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

    public List<Fournisseur> getAllFournisseur_produit_condition(String fournisseur, String produit, String unite)
    {
        List<Fournisseur> fournisseurs = new List<Fournisseur>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM all_fournisseur_produit where nom_fournisseur ='"+fournisseur+"' AND nom_produit ='"+produit+"' AND nom_unite ='"+unite+"'";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Fournisseur f = new Fournisseur();
                    f.id = reader.GetInt32(0);
                    f.name_fournisseur = reader.GetString(1);
                    f.name_produit = reader.GetString(2);
                    f.name_unite = reader.GetString(3);
                    f.prix_unitaire = reader.GetDouble(4);
                    f.date = reader.GetDateTime(5);
                    fournisseurs.Add(f);
                }
            }
        }
        connection.Close();
        return fournisseurs;
    }

    public double getAllFournisseur_produit_prix(String fournisseur, String produit, String unite)
    {
        double prix = 0.0;
        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT prix FROM all_fournisseur_produit where nom_fournisseur ='" + fournisseur + "' AND nom_produit ='" + produit + "' AND nom_unite ='" + unite + "'";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    prix = reader.GetDouble(0);
                }
            }
        }
        connection.Close();
        return prix;
    }


}