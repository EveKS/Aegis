using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aegis.Services.GoogleSearch
{
  public interface IGoogleSearchService
  {
    Task<IEnumerable<string>> CustomSearchAsync(string query, int count);
  }
}
