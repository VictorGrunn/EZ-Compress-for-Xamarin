using EZCompress1.Plugin.Abstractions;
using System;
using System.IO;
using Android.Graphics;


namespace EZCompress1.Plugin
{
  /// <summary>
  /// Implementation for Feature
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
          var bitmap = BitmapFactory.DecodeStream(_image);

          var finalStream = new MemoryStream();

          bitmap.Compress(Bitmap.CompressFormat.Jpeg, _compressAmount, finalStream);
          bitmap = null;

          finalStream.Position = 0;

          return finalStream;
      }
  }
}