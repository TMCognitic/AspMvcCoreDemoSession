using System.Collections.Generic;

namespace DemoSession.Infrastructure
{
    public interface ISessionManager
    {
        int Id { get; set; }
        byte[] Key { get; set; }
        List<string> Panier { get; }
        string Test { get; set; }

        void AddToPanier(string value);
    }
}