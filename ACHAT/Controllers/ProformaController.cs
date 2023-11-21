// using Microsoft.AspNetCore.Mvc;
// using ACHAT.Models;
// using System;
// using System.IO;
// using System.Net.Mail;
// using System.Net;


// namespace ACHAT.Controllers;

// public class ProformaController : Controller
// {
//     public IActionResult Index()
//     {
//         return View("");
//     }

//     public IActionResult send_fournisseur_page_proforma(String nom_fournisseur){
//         return RedirectToAction("page_proforma", "Proforma", new { nom_fournisseur});

//     }

//     public IActionResult page_proforma(String nom_fournisseur)
//     {
//         Produit p = new Produit();
//         Fournisseur f = new Fournisseur();
//         Unite u = new Unite();
//         List<String> nom_p = f.getNameProduit(nom_fournisseur);
//         List<String> nom_f = f.getName();
//         List<String> nom_u = u.getName();

//         var data = new
//         {
//             Fournisseur = nom_f,
//             Produit = nom_p,
//             Unite = nom_u
//         };
//         return View("", data);
//     }

//     public IActionResult insert_proforma(String fournisseur, String produit, double quantite, String unite)
//     {
//         Proforma pr = new Proforma();
//         pr.insert_proforma(fournisseur,produit,quantite,unite);
//         return View("");
//     }

//     public IActionResult validation_besoins()
//     {
//         Besoin b = new Besoin();
//         List<Besoin> data = b.getAllBesoin();
//         return View("", data);
//     }

//     public IActionResult besoins_valider()
//     {
//         Besoin b = new Besoin();
//         List<Besoin> data = b.getAllBesoinValider();
//         return View("", data);
//     }


// }
