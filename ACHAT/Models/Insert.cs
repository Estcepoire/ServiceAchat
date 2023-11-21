using Npgsql;
using Npgsql.Replication;

namespace ACHAT.Models;

public class Insert
{
    public List<Departement> dep { get; set; }
    public List<Produit> prod { get; set; }

    public Insert() {
        this.dep = Departement.getAll();
        this.prod = Produit.getAll();
    }


}