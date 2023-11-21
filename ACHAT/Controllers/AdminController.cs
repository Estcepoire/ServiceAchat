using Microsoft.AspNetCore.Mvc;
using ACHAT.Models;
using System;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace ACHAT.Controllers;

public class AdminController : Controller
{
    public IActionResult Dev()
    {
        Insert i = new Insert();
        var data = i;
        return View("Dev",data);
    }
    public IActionResult Login()
    {
        var data = Departement.getAll();
        return View("Login",data);
    }
    public IActionResult valider(int id)
    {
        Besoin.valider(id);
        return RedirectToAction("getValidation");
    }
    public IActionResult Pro(int id,double qtt)
    {
        var data = new Tuple<List<Fournisseur>,int,double>(Fournisseur.getAllFournisseur(),id,qtt);
        return View("Proforma",data);
    }

    public IActionResult getValidation(int departement)
    {
        var data = Besoin.getAll(departement);
        return View("Product",data);
    }
    public IActionResult saveBesoin(int departement, List<int> produits, List<int> quantites)
    {
        Console.WriteLine(produits.Count);
        Console.WriteLine(quantites.Count);
        for (int i = 0; i < produits.Count; i++)
        {
            Besoin b = new Besoin();
            b.IdDepartement = departement;
            b.IdProduit = produits[i];
            b.Quantite = quantites[i];
            b.save();
        }
        return RedirectToAction("Login");
    }
    
    public IActionResult admin_login()
    {
        return View("Admin_login");
    }

    public IActionResult check_login(String mail, String password)
    {
        Admin admin = new Admin();
        List<String> email = admin.Mail();
        List<String> pass = admin.Password();

        for (int i = 0; i < pass.Count; i++)
        {
            if (mail == email[i] && password == pass[i])
            {
                return View("");
            }
        }

        return View("Admin_login");
    }

    public IActionResult insert_proforma(int fournisseur,double prix, int idProduit, double qtt , String date)
    {
        Proforma p = new Proforma();
        p.insert_proforma(fournisseur,idProduit,prix,date, qtt);
        return RedirectToAction("Login");
    }


    public IActionResult liste_proforma()
    {
        //  p = new Proforma();
        var data = Proforma.getAllProforma();
        return View("ListProforma",data);
    }


}
