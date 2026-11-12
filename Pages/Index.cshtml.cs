using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace LandPageITCell.Pages;

public class IndexModel : PageModel
{

    public static bool IsValidEmailUsingMailAddress(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public void OnPost()
    {
        var Name = Request.Form["name"];
        var Email = Request.Form["email"];
        var Fone = Request.Form["fone"];
        var IsWhats = Request.Form["IsWhats"];
        var Doubt = Request.Form["doubt"];
        Console.WriteLine($"{IsWhats}");

        if (IsValidEmailUsingMailAddress(Email)== false)
        {
            ViewData["Response"] = $"Endereço de e-mail errado";    
        }

    }
}
