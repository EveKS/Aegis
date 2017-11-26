using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aegis.Services.Email
{
  public class EmailValidation : IEmailValidation
  {
    bool IEmailValidation.IsValidEmail(string email)
    {
      if (this.IsImagePath(email) || this.IsDigitExtension(email) || !this.IsValid(email)) return false;

      try
      {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
      }
      catch
      {
        return false;
      }
    }

    private bool IsImagePath(string email)
    {
      return email.EndsWith(".bmp") || email.EndsWith(".gif") || email.EndsWith(".png") ||
        email.EndsWith(".tiff") || email.EndsWith(".jpeg") || email.EndsWith(".jpg");
    }

    private bool IsDigitExtension(string email)
    {
      return Path.GetExtension(email).All(char.IsDigit);
    }

    private bool IsValid(string email)
    {
      try
      {
        return Regex.IsMatch(email,
              @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
              RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
      }
      catch (RegexMatchTimeoutException)
      {
        return false;
      }
    }
  }
}
