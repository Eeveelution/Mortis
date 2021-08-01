using System.Net;
using System.Threading;
using EeveeTools.Extensions;
using EeveeTools.Helpers;
using EeveeTools.Servers.HTTP;

namespace Mortis.Bancho.Web.Server {
    public class Router {
        private HttpServer _server;

        public Router(string location) {
            this._server = new HttpServer(location, this.RequestHandler);
        }

        private void RequestHandler(string url, HttpListenerContext ctx) {
            LogHelper.Information($"Got Request on {url}");
            
            LogHelper.Information($"Host: {ctx.Request.Headers.Get("Host")}");
            LogHelper.Information($"X-Forwarded-For: {ctx.Request.Headers.Get("X-Forwarded-For")}");
            LogHelper.Information($"X-Real-IP: {ctx.Request.Headers.Get("X-Real-IP")}");

            switch (ctx.Request.Headers.Get("Host")) {
                case "c.ppy.sh":
                case "c1.ppy.sh":

            }

            ctx.Response.WriteString("wack");
        }

        public Router Start() {
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
