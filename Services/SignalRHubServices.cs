using Microsoft.AspNetCore.SignalR.Client;

namespace AceMicEV.Services
{
    public static class SignalRHubServices //:Signalrepository
    {
        public static HubConnection hubConnection;
        public static bool IsConnected =>
           hubConnection?.State == HubConnectionState.Connected;
        //readonly ISignalRepository _signalRepository = new SIgnalRServices();s
        public static async Task OpenConnectionAsync(ISignalRepository _signalRepository)
        {
            ConcurrentDicSignalR._dictionary.TryGetValue("signalRConnection", out object signalRConn);

            if (signalRConn != null)
            {
                hubConnection = (HubConnection)signalRConn;
            }

            if (IsConnected)
                return;

            if (hubConnection is null)
            {
                var baseUrl = "https://acemicapi.azurewebsites.net/";
                hubConnection = new HubConnectionBuilder()
                .WithUrl($"{baseUrl}/chatHub")
                 .WithAutomaticReconnect()
                 .Build();
                //var hubConnectionID;
                await hubConnection.StartAsync().ConfigureAwait(false);
                var hubConnectionID = hubConnection.ConnectionId;

                ConcurrentDicSignalR._dictionary.TryAdd("signalRConnection", hubConnection);
                Preferences.Set("ConnectionKey", hubConnectionID);

                string userid = Preferences.Get("DidKey", null);
                var SignalInfo = _signalRepository.Signaldata(hubConnectionID, userid);


                //hubConnection.On<string, string>("ReceiveMessageconectionid", (connectionid, message) =>
                //    {
                //        //lblChat.Text += $"<b>: {connectionid}</b>: {message}<br/>";
                //    });


            }
        }
        //public async Task SendMessage()
        //{



        //    //  hubConnection.SendAsync("ReceiveMessageconectionid", message).ConfigureAwait(false);
        //    hubConnection.On<string, string>("ReceiveMessageconectionid", (connectionid, message) =>
        //    {
        //        //    //lblChat.Text += $"<b>: {connectionid}</b>: {message}<br/>";


        //    });


        //}

    }

}