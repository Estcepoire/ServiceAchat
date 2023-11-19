using Microsoft.AspNetCore.Mvc;
using ACHAT.Models;
using System;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace ACHAT.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View("Start");
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



}
