using Microsoft.Extensions.Logging;
using ReverseStringLeapwork.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringLeapwork.Services
{
    public class ReverseAndPrintStringService : IReverseAndPrintStringService
    {
        private readonly ILogger<ReverseAndPrintStringService> _logger;
        private readonly IPrintStringEngine _printEngine;
        private readonly IReverseStringEngine _reverseStringEngine;
        public ReverseAndPrintStringService(
            ILogger<ReverseAndPrintStringService> logger,
            IPrintStringEngine printEngine,
            IReverseStringEngine reverseStringEngine
            )
        {
            _logger = logger;
            _printEngine = printEngine;
            _reverseStringEngine = reverseStringEngine;
        }
        public Func<string, Task> ReverseStringAsync => ReverseAndPrintStringAsync;

        public Func<string, Task> ReverseTextAsync => ReverseAndPrintTextAsync;

        private async Task ReverseAndPrintStringAsync(string text)
        {
            try
            {
                var task = Task.Run(async () =>
                {
                    var reverseResult = await _reverseStringEngine.ReverseStringAsync(text);
                    _printEngine.PrintString(reverseResult);
                });

                await task;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems reversing and printing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }

        private async Task ReverseAndPrintTextAsync(string text)
        {
            try
            {
                var task = Task.Run(async () =>
                {
                    var reverseResult = await _reverseStringEngine.ReverseTextAsync(text);
                    _printEngine.PrintToScreen(reverseResult);
                });

                await task;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems reversing and printing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }
    }
}
