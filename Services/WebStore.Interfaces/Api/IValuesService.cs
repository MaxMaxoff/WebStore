﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WebStore.Interfaces.Api
{
    /// <summary>
    /// Value Service Interface
    /// </summary>
    public interface IValuesService
    {
        IEnumerable<string> Get();

        Task<IEnumerable<string>> GetAsync();

        string Get(int id);

        Task<string> GetAsync(int id);

        Uri Post(string value);

        Task<Uri> PostAsync(string value);

        HttpStatusCode Put(int id, string value);

        Task<HttpStatusCode> PutAsync(int id, string value);

        HttpStatusCode Delete(int id);

        Task<HttpStatusCode> DeleteAsync(int id);
    }
}
