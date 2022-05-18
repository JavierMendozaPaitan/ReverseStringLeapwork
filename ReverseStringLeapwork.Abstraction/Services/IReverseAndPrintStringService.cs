using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringLeapwork.Abstractions
{
    public interface IReverseAndPrintStringService
    {
        Func<string, Task> ReverseStringAsync { get; }
        Func<string, Task> ReverseTextAsync { get; }
    }
}
