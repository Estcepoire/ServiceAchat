using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Besoin
{
    public int Id { get; set; }
    public int IdDepartement { get; set; }
    public int IdProduit { get; set; }
    public double Quantite { get; set; }
    public string Etat { get; set; }
    public Produit Prod{ get; set;}


    public void save()
    {
        try
        {
            using NpgsqlConnection connection = Connect.GetSqlConnection();
            connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO besoins VALUES (default,@idDepartement, @idProduit, @quantite,default,default)";
                cmd.Parameters.AddWithValue("@idDepartement", this.IdDepartement);
                cmd.Parameters.AddWithValue("@idProduit", this.IdProduit);
                cmd.Parameters.AddWithValue("@quantite", this.Quantite);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        Console.WriteLine("Erreur lors de l'insertion : " + ex.Message);
        }
    }
        public static List<Besoin> getAll(int idDepartement)
    {
        List<Besoin> nom = new List<Besoin>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT * FROM besoins where id_departement = " + idDepartement + " and Etat = '0'";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Besoin p = new Besoin();
                    p.Id = reader.GetInt32(0);
                    p.IdDepartement = reader.GetInt32(1);
                    p.IdProduit = reader.GetInt32(2);
                    p.Quantite = reader.GetDouble(3);
                    p.Etat = reader.GetString(4);
                    p.Prod = Produit.getIdBy(p.IdProduit);
                    nom.Add(p);
                }
            }
        }
        connection.Close();
        return nom;
    }
// public static List<Besoin> getAllValider()
//     {
//         List<Besoin> nom = new List<Besoin>();

//         using NpgsqlConnection connection = Connect.GetSqlConnection();
//         connection.Open();
//         string query = "SELECT * FROM besoins where Etat = '1'";
//         using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
//         {
//             using (NpgsqlDataReader reader = command.ExecuteReader())
//             {
//                 while (reader.Read())
//                 {
//                     Besoin p = new Besoin();
//                     p.Id = reader.GetInt32(0);
//                     p.IdDepartement = reader.GetInt32(1);
//                     p.IdProduit = reader.GetInt32(2);
//                     p.Quantite = reader.GetDouble(3);
//                     p.Etat = reader.GetString(4);
//                     p.Prod = Produit.getIdBy(p.IdProduit);
//                     nom.Add(p);
//                 }
//             }
//         }
//         connection.Close();
//         return nom;
//     }

    public static List<Besoin> getAllValider()
    {
        List<Besoin> nom = new List<Besoin>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "SELECT it_produit,SUM(quantite) FROM besoins where Etat = '1' GROUP BY it_produit";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Besoin p = new Besoin();
                    p.IdProduit = reader.GetInt32(0);
                    p.Quantite = reader.GetDouble(1);
                    p.Prod = Produit.getIdBy(p.IdProduit);
                    nom.Add(p);
                }
            }
        }
        connection.Close();
        return nom;
    }

    public static void valider(int idBesoin){
    {
        try
        {
            using NpgsqlConnection connection = Connect.GetSqlConnection();
            connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE besoins SET Etat = '1' WHERE id = "+ idBesoin;
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        Console.WriteLine("Erreur lors de l'insertion : " + ex.Message);
        }
    }
}
}
