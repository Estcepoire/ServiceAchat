using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Proforma
{
    public int id { get; set; }
    public string name_produit { get; set; }
    public string name_fournisseur { get; set; }
    public double quantite { get; set; }
    public double prix_total { get; set; }
    // public Date date { get; set; }


    public int id_produit {get; set;}
    public int id_fournisseur { get; set; }
    public int id_unite { get; set; }




    public Proforma() { }

    public void insert_proforma(int fournisseur, int id_produit,double prix, String date,double quantite)
    {
        using (NpgsqlConnection connection = Connect.GetSqlConnection())
        {
            connection.Open();
            string query = "INSERT INTO proforma VALUES(default," + id_produit + "," + fournisseur + "," + prix + ",'" + date + "'," + quantite + ")";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

       public static List<Proforma> getAllProforma()
    {
        List<Proforma> dep = new List<Proforma>();

        using NpgsqlConnection connection = Connect.GetSqlConnection();
        connection.Open();
        string query = "select id,nom_produit,nom_fournisseur,quantite, prix_total,date from v_proforma GROUP BY id,nom_produit,nom_fournisseur,quantite,prix_total, date ORDER BY prix_total ASC";
        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Proforma d = new Proforma();
                    d.id=reader.GetInt32(0);
                    d.name_produit = reader.GetString(1);
                    d.name_fournisseur = reader.GetString(2);
                    d.quantite = reader.GetDouble(3);
                    d.prix_total= reader.GetDouble(4);
                    // d.date=reader.GetDate(5);
                    dep.Add(d);
                }
            }
        }
        connection.Close();
        return dep;
    }


}