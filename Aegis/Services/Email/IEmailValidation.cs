namespace Aegis.Services.Email
{
  public interface IEmailValidation
  {
    bool IsValidEmail(string email);
  }
}