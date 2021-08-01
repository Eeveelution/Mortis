using System.Net;
using System.Threading;
using EeveeTools.Helpers;
using EeveeTools.Servers.HTTP;

namespace Mortis.Bancho.Web.Server {
    public class ScoreServer {
        private HttpServer _server;

        public ScoreServer(string location) {
            this._server = new HttpServer(location, this.RequestHandler);
        }

        private void RequestHandler(string url, HttpListenerContext ctx) {
            LogHelper.Information($"Got Request on {url}");
            
            
        }

        public ScoreServer Start() {
            this._server.Start();

            return this;
        }
        public void BlockThread() {
            while (this._server.IsRunning) {
                Thread.Sleep(2500);
            }
        }
    }
}
