using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Proforma
{
    public int id { get; set; }
    public string name_produit { get; set; }
    public string name_fournisseur { get; set; }
    public double quantite { get; set; }
    public string name_unite { get; set; }
    public double prix_total { get; set; }

    public int id_produit {get; set;}
    public int id_fournisseur { get; set; }
    public int id_unite { get; set; }




    public Proforma() { }
    public void insert_proforma(String fournisseur, String produit, double quantite, String unite)
    {
        Fournisseur f = new Fournisseur();
        Produit p = new Produit();
        Unite u = new Unite();
        int id_fournisseur = f.getIdByName(fournisseur);
        int id_produit = p.getIdByName(produit);
        int id_unite = u.getIdByName(unite);
        double prix = f.getAllFournisseur_produit_prix(fournisseur,produit,unite);

        using (NpgsqlConnection connection = Connect.GetSqlConnection())
        {
            connection.Open();

            string query = "INSERT INTO proforma VALUES(default," + id_produit+ "," + id_fournisseur + "," + quantite + ",'" + id_unite + "',"+prix+ ")";

            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }


}