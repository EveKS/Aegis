using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using System;

namespace Aegis.Services.Telegram
{
  public interface ITelegramService
  {
    Task SendMessage(string message);
    Task SendMessageExceptionAsync(Exception ex);
  }
}
