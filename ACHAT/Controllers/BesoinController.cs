using Microsoft.AspNetCore.Mvc;
using ACHAT.Models;
using System;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace ACHAT.Controllers;

public class BesoinController : Controller
{
//     public IActionResult Index()
//     {
//         return View("");
//     }

//     public IActionResult page_besoin()
//     {
//         Produit p = new Produit();
//         Departement d = new Departement();
//         Unite u = new Unite();
//         List<String> nom_p = p.getName();
//         List<String> nom_d = d.getName();
//         List<String> nom_u = u.getName();

//         var data = new
//         {
//             Departement = nom_d,
//             Produit = nom_p,
//             Unite = nom_u
//         };
//         return View("",data);
//     }

//     public IActionResult insert_besoin(String departement, String produit, double quantite, String unite)
//     {
//         Besoin b = new Besoin();
//         b.insert_besoin(departement,produit,quantite,unite);
//         return View("");
//     }

//     public IActionResult validation_besoins()
//     {
//         Besoin b = new Besoin();
//         List<Besoin> data = b.getAllBesoin();
//         return View("",data);
//     }

//     public IActionResult besoins_valider()
//     {
//         Besoin b = new Besoin();
//         List<Besoin> data = b.getAllBesoinValider();
//         return View("", data);
//     }


}
