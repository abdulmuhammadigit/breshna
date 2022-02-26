﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Services.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
