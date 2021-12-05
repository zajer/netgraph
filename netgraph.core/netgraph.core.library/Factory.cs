using System;
using System.Runtime.InteropServices;
namespace Netgraph.Core.Library
{
    public class Factory
    {
        public INetgraph GetNetgraphProvider(){
            INativeNetgraph nativeImpl;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && System.Environment.Is64BitOperatingSystem)
                nativeImpl = new Linux64NativeProvider();  
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && System.Environment.Is64BitOperatingSystem)
                nativeImpl = new Windows64NativeProvider();  
            else
                throw new NotImplementedException();
            
            return new Netgraph(nativeImpl);
        }
    }
}
