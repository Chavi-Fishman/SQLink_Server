using LoginServer.BL.Services;
using LoginServer.BL.ServicesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace LoginServer.BL.Cache
{
    public class SessionMemoryCache
    {
        MemoryCache _memoryCache = new MemoryCache("SESSION");
        IConfiguration _configuration;
        public SessionMemoryCache(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public SessionData Get(string token)
        {
            if (_memoryCache.Contains(token))
            {
                return (SessionData)_memoryCache.Get(token);
            }
            else
            {
                return null;
            }
        }

        public IList<KeyValuePair<string, object>> GetAll()
        {
            return _memoryCache.AsEnumerable().ToList();
        }
        public void Add(string token, SessionData session)
        {
            _memoryCache.Add(token, session, DateTime.Now.AddMinutes(double.Parse(_configuration.GetSection("SessionData:DateTimeOffset").Value)));
        }
        public void Refresh(string token, SessionData session)
        {
            Delete(token);
            Add(token, session);
        }
        public void Delete(string token)
        {
            if (_memoryCache.Contains(token))
            {
                _memoryCache.Remove(token);
            }
        }

    }
}
