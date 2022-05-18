using Microsoft.Extensions.Logging;
using ReverseStringLeapwork.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringLeapwork.Services
{
    public class ReverseStringAppService
    {
        private readonly ILogger<ReverseStringAppService> _logger;
        private readonly IPrintStringEngine _printStringEngine;
        private readonly IReverseAndPrintStringService _reverseAndPrintStringService;
        public ReverseStringAppService(
            ILogger<ReverseStringAppService> logger,
            IPrintStringEngine printStringEngine,
            IReverseAndPrintStringService reverseAndPrintStringService
            )
        {
            _logger = logger;
            _printStringEngine = printStringEngine;
            _reverseAndPrintStringService = reverseAndPrintStringService;
        }

        public void ReverseAndPrintString()
        {
            try
            {
                var isQuit = false;
                while (!isQuit)
                {
                    _printStringEngine.PrintString("Enter a text to be reversed: ");
                    var inputText = Console.ReadLine();
                    if (inputText.Equals("quit"))
                    {
                        isQuit = true;
                        continue;
                    }
                    _reverseAndPrintStringService.ReverseStringAsync(inputText);
                }

                Console.WriteLine("Press Enter to finish...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems reversing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }

        public void ReverseAndPrintText()
        {
            try
            {
                var isQuit = false;
                while (!isQuit)
                {
                    _printStringEngine.PrintString("Enter a text to be reversed: ");
                    var inputText = Console.ReadLine();
                    if (inputText.Equals("quit"))
                    {
                        isQuit = true;
                        continue;
                    }
                    _reverseAndPrintStringService.ReverseTextAsync(inputText);
                }

                Console.WriteLine("Press Enter to finish...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems reversing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }
    }
}
