using Microsoft.Extensions.Logging;
using ReverseStringLeapwork.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringLeapwork.Engines
{
    public class PrintStringEngine : IPrintStringEngine
    {
        private readonly ILogger<PrintStringEngine> _logger;
        public PrintStringEngine(
            ILogger<PrintStringEngine> logger
            )
        {
            _logger = logger;
        }

        public void PrintToScreen(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    foreach (var charItem in text)
                    {
                        Console.Write(charItem);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems printing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }

        public void PrintString(string text)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {                    
                    Console.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems printing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }
    }
}
