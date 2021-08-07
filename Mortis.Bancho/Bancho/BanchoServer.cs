using System.Net;
using System.Threading;
using EeveeTools.Helpers;
using EeveeTools.Servers.HTTP;

namespace Mortis.Bancho.Bancho {
    public class BanchoServer {
        private HttpServer _server;

        public BanchoServer(string location) {
            this._server = new HttpServer(location, this.RequestHandler);
        }

        private void RequestHandler(string url, HttpListenerContext ctx) {
            LogHelper.Information($"Got Request on {url}");

            if (ctx.Request.Headers.Get("osu-token") == null)
                new ClientOsu(ctx);
        }

        public BanchoServer Start() {
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
