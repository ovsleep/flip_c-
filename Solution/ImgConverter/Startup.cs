using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgConverter
{
    public class Startup
    {
        public async Task<object> Invoke(object input)
        {
            string v = (string)input;
            return Helper.Convert(v);
        }

    }

    static class Helper
    {
        //from http://stackoverflow.com/questions/10894836/c-sharp-convert-image-formats-to-jpg
        public static string Convert(string imgPath)
        {
            var imgName = Path.GetFileNameWithoutExtension(imgPath) + "_jpgByDotNet.jpg";
            var path = Path.GetDirectoryName(imgPath);
            var finalFullPath = Path.Combine(path, imgName);

            Bitmap bmp1 = new Bitmap(imgPath);
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            
            // Save the bitmap as a JPG file with zero quality level compression.
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(finalFullPath, jgpEncoder, myEncoderParameters);

            return finalFullPath;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

    }
}
