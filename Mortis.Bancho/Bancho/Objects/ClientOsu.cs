using System.IO;

namespace Mortis.Bancho.Bancho.Objects {
    public class ClientOsu {
        public ClientOsu(Stream inputStream) {
            string[] loginData = new StreamReader(inputStream).ReadToEnd().Split("\n");

            string username = loginData[0];
            string password = loginData[1];


        }
    }
}
