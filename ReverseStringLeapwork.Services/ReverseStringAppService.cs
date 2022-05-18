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
                string inputText = string.Empty;
                while (inputText != "quit")
                {
                    _printStringEngine.PrintString("Enter a text to be reversed: ");
                    inputText = Console.ReadLine();
                    _reverseAndPrintStringService.ReverseStringAsync(inputText);
                }
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
                string inputText = string.Empty;
                while (inputText != "quit")
                {
                    _printStringEngine.PrintString("Enter a text to be reversed: ");
                    inputText = Console.ReadLine();
                    _reverseAndPrintStringService.ReverseTextAsync(inputText);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems reversing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }
    }
}
