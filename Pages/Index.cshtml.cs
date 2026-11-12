using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace LandPageITCell.Pages;

public class IndexModel : PageModel
{


    public class Email
    {
        public string To_Address;
        public Email(string To_Address)
        {
            this.To_Address = To_Address;
        }


    public void CreateTestMessage2(string server)
    {
        string to = this.To_Address;
        string from = "pedrohenriquecosta.profissional@gmail.com";
        MailMessage message = new MailMessage(from, to);
        message.Subject = "Using the new SMTP client.";
        message.Body = @"Using this new feature, you can send an email message from an application very easily.";
        SmtpClient client = new SmtpClient(server,578);
        client.UseDefaultCredentials = true;

        try
        {
            client.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                ex.ToString());
        }
    }

    }

     public bool IsValidEmailUsingMailAddress(string email)
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

        Email To_Email = new Email($"{Email}");


        if (IsValidEmailUsingMailAddress(To_Email.To_Address)== false)
        {
            ViewData["Response"] = $"Endereço de e-mail errado";    
        }

        

    }
}
