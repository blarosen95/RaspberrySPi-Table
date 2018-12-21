using System;
using System.Threading;
using Windows.Storage;
using Windows.Web.Http;
using RaspBrarySPi;

namespace RaspberrySPi
{
    class StartUp
    {
        private readonly ApplicationDataContainer _localSet = ApplicationData.Current.LocalSettings;

        public StartUp()
        {
            FetchIp();
        }

        private async void FetchIp()
        {
            var uri = new Uri("https://api.ipify.org");
            var httpClient = new HttpClient();
            var cts = new CancellationTokenSource();

            var response = await httpClient.GetAsync(uri).AsTask(cts.Token);

            try
            {
                //If the local setting value for IP is not equal to the IP fetched
                if (!_localSet.Values["IP"].ToString().Equals(await response.Content.ReadAsStringAsync().AsTask(cts.Token)))
                {
                    _localSet.Values["IP"] = await response.Content.ReadAsStringAsync().AsTask(cts.Token);
                    //Call the GeoLocator method
                    FetchLocation(_localSet.Values["IP"].ToString());
                }
            }
            //If the key "IP" does not exist within local settings (such as when first running this application)
            catch (NullReferenceException)
            {
                _localSet.Values["IP"] = await response.Content.ReadAsStringAsync().AsTask(cts.Token);
            }
        }

        private async void FetchLocation(string Ip)
        {
            var backStack = new IpStackBackEnd();
            string[] latLon = await backStack.GetLatLon(Ip);
            _localSet.Values["Latitude"] = latLon[0];
            _localSet.Values["Longitude"] = latLon[1];
        }
    }
}
