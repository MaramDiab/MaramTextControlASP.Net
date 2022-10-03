using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
namespace MaramTX.Hubs
{
    public class CollabHub : Hub
    {
        public async Task SetAnnotationSync(AnnotationSync annotationSync)
        {
            await Clients.All.SendAsync("ReceiveAnnotationSync", annotationSync);
        }
    }

    public class AnnotationSync
    {
        public string User { get; set; }
        public string AnnotationJson { get; set; }
    }
}
