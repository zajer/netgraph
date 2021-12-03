using System;
using System.Runtime.InteropServices;
namespace netgraph.core.library
{
    public class Factory
    {
        public INetgraph GetNetgraphProvider(){
            INativeNetgraph nativeImpl;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && System.Environment.Is64BitOperatingSystem)
                nativeImpl = new Linux64NativeProvider();  
            else
                throw new NotImplementedException();
            
            return new Netgraph(nativeImpl);
        }
    }
}
