using System;
using System.Net;
using System.Threading.Tasks;
using Android.Graphics;

namespace GameDemoNative.Droid.Classes
{
    public static class DroidHelpers
    {
        private static async Task<Bitmap> GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var uri = new Uri(url);
                var imageBytes = await webClient.DownloadDataTaskAsync(uri);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
        public static Bitmap BytesToBitmap(byte[] imageBytes)
        {
            var bitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
            return bitmap;
        }
    }
}