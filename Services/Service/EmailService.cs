using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using EventRegestration1.Services.Interface;
using EventRegestration.Services.Interface;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace EventRegestration1.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailjetClient _mailjetClient;

        public EmailService(string apiKey, string secretKey)
        {
            _mailjetClient = new MailjetClient(apiKey, secretKey);
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string message)
        {
            var email = new JObject
            {
                { "Messages", new JArray
                    {
                        new JObject
                        {
                            { "From", new JObject { { "Email", "saja_fawaz@yahoo.com" }, { "Name", "Mailjet" } } },
                            { "To", new JArray { new JObject { { "Email", recipientEmail } } } },
                            { "Subject", subject },
                            { "TextPart", message }
                        }
                    }
                }
            };

            var response = await _mailjetClient.SendTransactionalEmailAsync(
                Resources.Email,
                email);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync(); 
                throw new Exception($"Failed to send email. Status code: {response.StatusCode}, Message: {errorMessage}");
            }

        }
    }
    }


