using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAPIForSpeechRecognitionUsingFLAC
{
    public class GoogleSpeechAPI
    {
        public string URL { get; set; }

        public string GetTranscript(string filePath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            System.Net.WebRequest request = System.Net.HttpWebRequest.Create(this.URL);
            request.ContentType = "audio/x-flac; rate=44000";
            request.Method = "POST";
            request.ContentLength = fileBytes.Length;

            System.IO.Stream reqStream = request.GetRequestStream();
            reqStream.Write(fileBytes, 0, fileBytes.Length);
            reqStream.Close();

            System.Net.WebResponse response = request.GetResponse();

            byte[] resBytes = new byte[1000];

            reqStream = response.GetResponseStream();
            reqStream.Read(resBytes, 0, resBytes.Length);
            
            string result = System.Text.ASCIIEncoding.ASCII.GetString(resBytes).TrimEnd();

            var ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            GoogleAPIResult json = ser.Deserialize<GoogleAPIResult>(result.Replace((char)0, (char)32).TrimEnd());

            return result;
        }





    }
}
