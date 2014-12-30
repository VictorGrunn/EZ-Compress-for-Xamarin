using System;
using System.IO;

namespace EZCompress1.Plugin.Abstractions
{
  /// <summary>
  /// Interface for EZCompress1
  /// </summary>
  public interface IEZCompress1
  {
      /// <summary>
      /// Compress the provided image with quality between 1 and 100%. Returns a memorystream of the
      /// newly compressed image. Returns in jpeg format.
      /// </summary>
      MemoryStream compressImage(Stream _image, int _compressAmount);
  }
}
