using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace NJTDVAPI.Models
{
    public class DV
    {
        public string GetDVByStationID(string stationID)
        {
            HttpWebResponse response;
            string dv=string.Empty;

            if (Request_dv_njtransit_com(out response,stationID ))
            {
                Stream st = response.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                dv = sr.ReadToEnd();
                response.Close();
            }
            return dv;
        }

        private bool Request_dv_njtransit_com(out HttpWebResponse response,string stationID)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dv.njtransit.com/mobile/tid-mobile.aspx?sid=" + stationID );

                request.UserAgent = "Fiddler";

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }
    }
}