using Common.ViewModel;
using DataInfastructure.Model;
using DataInfastructure.Responsitory;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageSchoolApi.Realtime
{
    public class ClassHub : Hub
    {
        public async Task NewClassCreated(ResponseItems<Class> finalClassesAndPage)
        {
            await Clients.All.SendAsync("ReceiveNewClass", finalClassesAndPage);
        }
    }
}
