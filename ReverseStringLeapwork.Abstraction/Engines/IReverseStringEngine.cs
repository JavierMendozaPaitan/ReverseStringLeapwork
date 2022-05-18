using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringLeapwork.Abstractions
{
    public interface IReverseStringEngine
    {
        Task<string> ReverseStringAsync(string text);
        Task<string> ReverseTextAsync(string text);
    }
}
