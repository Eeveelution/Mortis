using Mortis.Bancho;
using Mortis.Bancho.Bancho;
using Mortis.Common.Objects;

//User.CreateUser(Global.DatabaseContext, "Eevee", "no", "ssh");
User eevee = User.FromDatabase(Global.DatabaseContext, "Eevee");

new BanchoServer("http://127.0.0.1:13382/").Start().BlockThread();