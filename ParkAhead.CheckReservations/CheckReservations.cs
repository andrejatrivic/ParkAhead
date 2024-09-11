using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ParkAhead.Business.Interfaces;

namespace ParkAhead.CheckReservations
{
    public class CheckReservations
    {
        private readonly ILogger _logger;
		private readonly HttpClient _httpClient;

		public CheckReservations(ILoggerFactory loggerFactory,
			 IHttpClientFactory httpClientFactory)
        {
            _logger = loggerFactory.CreateLogger<CheckReservations>();
			_httpClient = httpClientFactory.CreateClient();
		}

        [Function("CheckReservations")]
        public async Task Run([TimerTrigger("* * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

			var url = "https://localhost:7204/api/CheckReservation/check-reservations";
			var response = await _httpClient.PutAsync(url, null);
			response.EnsureSuccessStatusCode();
		}
    }
}
