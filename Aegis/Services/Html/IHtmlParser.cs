using System;
using System.Collections.Generic;

namespace Aegis.Services.Html
{
    public interface IHtmlParser
    {
        IEnumerable<string> Aegis(string html);
        IEnumerable<string> GetLinks(string html, Uri uri);
    }
}