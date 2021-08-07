using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Mortis.Bancho.Bancho.Managers {
    public class ClientManager {
        public static ConcurrentDictionary<string, ClientOsu> ClientsByToken    = new();
        public static ConcurrentDictionary<string, ClientOsu> ClientsByUsername = new();
        public static ConcurrentDictionary<int   , ClientOsu> ClientsByUserId   = new();
    }
}
