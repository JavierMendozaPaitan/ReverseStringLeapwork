using Microsoft.Extensions.Logging;
using ReverseStringLeapwork.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringLeapwork.Engines
{
    public class ReverseStringEngine : IReverseStringEngine
    {
        private readonly ILogger<ReverseStringEngine> _logger;
        public ReverseStringEngine(
            ILogger<ReverseStringEngine> logger
            )
        {
            _logger = logger;
        }

        public async Task<string> ReverseStringAsync(string text)
        {
            try
            {
                var task = Task.Run(() =>
                {
                    var reverseResult = string.Empty;

                    if (string.IsNullOrEmpty(text))
                    {
                        char[] chars = text.ToCharArray();
                        Array.Reverse(chars);

                        reverseResult = chars.ToString();
                    }

                    return reverseResult;
                });

                return await task;                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems reversing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }

        public async Task<string> ReverseTextAsync(string text)
        {
            try
            {
                var task = Task.Run(() =>
                {
                    var reverseResult = string.Empty;

                    if (!string.IsNullOrEmpty(text))
                    {
                        reverseResult = text[text.Length - 1].ToString();
                        int index = 1;
                        while (reverseResult.Length < text.Length)
                        {
                            index = index + 1;
                            reverseResult = reverseResult + text[text.Length - index];
                        }
                    }

                    return reverseResult;
                });

                return await task;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Problems reversing string: {ex.Message}", ex.StackTrace);
                throw;
            }
        }
    }
}
