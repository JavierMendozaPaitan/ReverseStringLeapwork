using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringLeapwork.Abstractions
{
    public interface IPrintStringEngine
    {
        void PrintToScreen(string text);
        void PrintString(string text);
    }
}
