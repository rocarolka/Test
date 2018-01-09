using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using WebApplication1.DTO;

namespace WebApplication1.Services
{
    public class SimpleSmtp : IMail
    {
        private SmtpClient _client;
        private IConfiguration _configuration;

        public SimpleSmtp(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new SmtpClient(configuration.GetValue<string>("Smpt:Host"), configuration.GetValue<int>("Smpt:Port"))
            {
                Credentials = new NetworkCredential(configuration.GetValue<string>("Smpt:Login"), configuration.GetValue<string>("Smpt:Password")),
                EnableSsl = true
            };
        }

        public void Send(ClientInfo data)
        {
            _client.Send(_configuration.GetValue<string>("Smpt:Login"), _configuration.GetValue<string>("RecipientMail"), $"{data.FirstName} {data.LastName} {data.Email}", "testbody");
        }
    }
}
