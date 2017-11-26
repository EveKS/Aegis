using System;
using System.Threading.Tasks;

namespace Aegis.Services.Http
{
    public interface IHttpService
    {
        Task<string> GetAsync(Uri url);
    }
}