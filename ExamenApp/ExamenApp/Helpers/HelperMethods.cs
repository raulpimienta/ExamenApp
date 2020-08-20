using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace ExamenApp.Helpers
{
    public static class HelperMethods
    {
        public static ImageSource GetImage(string url)
        {

            string base64 = "";
            try
            {
                byte[] ImageData = Helpers.HelperMethods.GetImageByte(url);
                base64 = Convert.ToBase64String(ImageData, 0, ImageData.Length);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64)));
        }

        public static byte[] GetImageByte(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

    }
}
