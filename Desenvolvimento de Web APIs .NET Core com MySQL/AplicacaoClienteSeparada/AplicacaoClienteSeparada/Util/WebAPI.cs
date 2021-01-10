using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoClienteSeparada.Util
{
    public class WebAPI
    {
        public static string URI = "https://localhost:44367/api/cliente";
        public static string TOKEN = "132131sxfvasddbvdwe654cHokage";
        
        public static string RequestGet(string method, string parametro)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"{URI}/{method}/{parametro}");

                request.Method = "GET";
                request.Headers.Add("Token", TOKEN);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static string RequestPost(string method, string jsonData)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"{URI}/{method}");
                var postData = jsonData;
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.Headers.Add("Token", TOKEN);
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static string RequestPut(string method, string jsonData)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"{URI}/{method}");
                var postData = jsonData;
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "PUT";
                request.Headers.Add("Token", TOKEN);
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
