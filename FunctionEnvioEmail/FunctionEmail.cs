using System;
using FunctionEnvioEmail.Dominio;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionEnvioEmail
{
    public static class FunctionEmail
    {
        [FunctionName("FunctionEmail")]
        public static void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Ultima execução da FunctionEmail: {DateTime.Now}");
            using (var filaEmail = new LeituraFilaEmail())
            {
                filaEmail.EnvioEmails();
            }
        }
    }
}
