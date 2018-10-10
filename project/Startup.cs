using Owin;
using Microsoft.Owin;

//請注意namespace，複製貼上後請更改為你取的
[assembly: OwinStartup(typeof(SignalRtest.Startup))]
namespace SignalRtest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}