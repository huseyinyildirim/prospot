using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net;
using System.Text;
using System.Timers;

namespace IntegrationDelete
{
    internal class Scheduler
    {
        private Timer _oTimer = null;
        //1000 = 1 sn.
        private const double Interval = 14400000;

        public void Start()
        {
            _oTimer = new Timer(Interval)
            {
                AutoReset = true,
                Enabled = true
            };
            _oTimer.Start();

            _oTimer.Elapsed += new ElapsedEventHandler(oTimer_Elapsed);
        }

        private void oTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                const string url = "http://www.prospot.com.tr/integration_delete.php";

                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    readStream = response.CharacterSet == null
                        ? new StreamReader(receiveStream)
                        : new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                    response.Close();
                    readStream.Close();
                }

            }
            catch (Exception ex)
            {
                Log.Add(ex.Message, EventLogEntryType.Error);
            }
        }
    }
}