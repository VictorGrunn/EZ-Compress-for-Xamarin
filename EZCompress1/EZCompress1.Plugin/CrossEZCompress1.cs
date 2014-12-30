using EZCompress1.Plugin.Abstractions;
using System;

namespace EZCompress1.Plugin
{
  /// <summary>
  /// Cross platform EZCompress1 implemenations
  /// </summary>
  public class CrossEZCompress1
  {
    static Lazy<IEZCompress1> Implementation = new Lazy<IEZCompress1>(() => CreateEZCompress1(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IEZCompress1 Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IEZCompress1 CreateEZCompress1()
    {
#if PORTABLE
        return null;
#else
        return new EZCompress1Implementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
