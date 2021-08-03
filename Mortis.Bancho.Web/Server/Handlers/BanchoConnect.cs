using System.Net;
using EeveeTools.Extensions;

namespace Mortis.Bancho.Web.Server.Handlers {
    public class BanchoConnect {
        /// <summary>
        /// Handles /web/bancho_connect.php
        /// </summary>
        /// <param name="ctx">HTTP Listener Context</param>
        public static void Handle(HttpListenerContext ctx) {
            string buildName         = ctx.Request.QueryString.Get("v");
            string username          = ctx.Request.QueryString.Get("u");
            string password          = ctx.Request.QueryString.Get("h");
            string activeEndpoint    = ctx.Request.QueryString.Get("fail");
            string frameworkVersions = ctx.Request.QueryString.Get("fx");
            string clientHash        = ctx.Request.QueryString.Get("ch");
            string retrying          = ctx.Request.QueryString.Get("retry");
            string monitorStuff      = ctx.Request.QueryString.Get("x");

            if(clientHash != null)
                if(clientHash != "b7c3bb2040703d81d9b517b9964d8f87")
                    ctx.Response.WriteString("error");

            ctx.Response.WriteString("");
        }
    }
}
