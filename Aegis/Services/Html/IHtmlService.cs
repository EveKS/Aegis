using Aegis.Datas;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aegis.Services.Html
{
  public interface IHtmlService
  {
    void CreateHtmlNotification(IHtmlNotification htmlNotification);
    Task DeepAdd(string userId, string id, Uri uri, Uri mainUri, int deepCount, CancellationToken token);
  }
}
