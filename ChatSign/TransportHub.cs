using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatSign
{
    public class TransportHub:Hub
    {
        public async Task EnviarMessage(int orden,double latitude,double longitude)
        {
            await Clients.All.SendAsync("locationMessage", orden, latitude,longitude);
        }
    }

}
