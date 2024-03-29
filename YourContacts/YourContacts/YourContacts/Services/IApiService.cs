﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourContacts.Models;

namespace YourContacts.Services
{
    public interface IApiService
    {
        Task<Contact> GetRandomContacts();

        Task<Result> GetContactsById(int id);
    }
}
