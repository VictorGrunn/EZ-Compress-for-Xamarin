using EZCompress1.Plugin.Abstractions;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.IO;


namespace EZCompress1.Plugin
{
  /// <summary>
  /// Implementation for EZCompress1
  /// </summary>
  public class EZCompress1Implementation : IEZCompress1
  {
      /// <summary>
      /// Compress the provided image with quality between 1 and 100%. Returns a memorystream of the
      /// newly compressed image. Returns in jpeg format. 
      ///also added option to scale the image based on the size, it will divide the image proportionally by that facter to make a smaller
      ///or larger image. Useful when uploading to the web or creating thumbnails
      /// </summary>
      public	Stream compressImage(Stream image, int compressAmount, int scaleFactor)
		{
			if (compressAmount < 1 || compressAmount > 100)
			{
				System.Diagnostics.Debug.WriteLine("Compress amount must be between 1 and 100! Compression failed.");
				return null;
			}

			image.Position = 0;



			using (var data = NSData.FromStream(image))
			{
				
					
				float _compressAmount = (float)(compressAmount * .01);

				var _image = UIImage.LoadFromData(data);

				var scaledImage = scaleToSize (_image, scaleFactor);

				var newResult = scaledImage.AsPNG ();

				var finalStream = newResult.AsStream();

				finalStream.Position = 0;

				System.Diagnostics.Debug.WriteLine("Compression succeeded!");
				return finalStream;
			}

		}

		public UIImage scaleToSize(UIImage src, int scaleFactor)
		{

			CGRect rect = new CGRect(0.0, 0.0, src.Size.Width/scaleFactor, src.Size.Height/scaleFactor);

			UIGraphics.BeginImageContext (rect.Size);
			UIGraphics.GetCurrentContext ();

			src.Draw (rect);
			src = UIGraphics.GetImageFromCurrentImageContext();

			UIGraphics.EndImageContext ();


			return src;
			
		}
  }
}
