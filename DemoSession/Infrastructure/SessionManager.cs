using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSession.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private ISession Session { get; }

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            Session = httpContextAccessor.HttpContext.Session;
        }

        public int Id
        {
            get { return (Session.GetInt32(nameof(Id)).HasValue) ? Session.GetInt32(nameof(Id)).Value : -1; }
            set { Session.SetInt32(nameof(Id), value); }
        }

        public string Test
        {
            get { return Session.GetString(nameof(Test)); }
            set { Session.SetString(nameof(Test), value); }
        }

        public byte[] Key
        {
            get { return Session.Get(nameof(Key)); }
            set { Session.Set(nameof(Key), value); }
        }

        public List<string> Panier
        {
            get
            {
                if (Session.GetString(nameof(Panier)) is null)
                    Panier = new List<string>();

                return JsonConvert.DeserializeObject<List<string>>(Session.GetString(nameof(Panier)));
            }

            private set
            {
                Session.SetString(nameof(Panier), JsonConvert.SerializeObject(value));
            }
        }

        public void AddToPanier(string value)
        {
            List<string> panier = Panier;
            panier.Add(value);
            Panier = panier;
        }

        public void Abandon()
        {
            Session.Clear();            
        }
    }
}
