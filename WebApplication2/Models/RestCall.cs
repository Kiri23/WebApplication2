using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication2.Models
{
    public class RestCall
    {
      
            public string id;
            public string type;

            protected string api = "https://api.stackexchange.com/2.2/";
            protected string options = "?order=desc&sort=name&site=stackoverflow";

            public string request()
            {
                string totalUrl = this.join(id);

                return this.HttpGet(totalUrl);
            }

            protected string join(string s)
            {
                return api + type + "/" + s + options;
            }

            protected string get(string url)
            {
                try
                {
                    string rt;

                    WebRequest request = WebRequest.Create(url);

                    WebResponse response = request.GetResponse();

                    Stream dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);

                    rt = reader.ReadToEnd();

                    Console.WriteLine(rt);

                    reader.Close();
                    response.Close();

                    return rt;
                }

                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
            public string HttpGet(string URI)
            {
                WebClient client = new WebClient();

                // Add a user agent header in case the 
                // requested URI contains a query.

                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                Stream data = client.OpenRead(URI);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();

                return s;
            }
        }
    }
