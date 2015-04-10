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
      /// </summary>
      public MemoryStream compressImage(Stream _image, int _compressAmount)
      {
          if (_compressAmount < 1 || _compressAmount > 100)
          {
              System.Diagnostics.Debug.WriteLine("Compress amount must be between 1 and 100! Compression failed.");
              return null;
          }

          _image.Position = 0;

          using (var data = NSData.FromStream(_image))
          {
              float compressAmount = (float)(_compressAmount * .01);

              var image = UIImage.LoadFromData(data);

              var newResult = image.AsJPEG(compressAmount);
              var finalStream = newResult.AsStream();

              finalStream.Position = 0;
              
              System.Diagnostics.Debug.WriteLine("Compression succeeded!");
              return (MemoryStream)finalStream;
          }
      }
  }
}
