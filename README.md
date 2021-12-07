# netgraph
A C# library providing a subset of igraph functionality.

## Requirements 
The library uses igraph (obivously) as its backbone.
On Linux it is required to either install igraph (https://igraph.org/) via a package manager or build it from source and install it manually.

The native library on Windows requires MSYS2 installed and ``msys64\migw64\bin`` added to PATH. There is no need to install igraph on Windows systems because it is bundled with Netgraph.

The former can be done following the instructions on: https://igraph.org/c/html/latest/igraph-Installation.html#igraph-Installation-general-build-instructions
After initial ``cmake ..`` make sure to set ``BUILD_SHARED_LIBS:BOOL`` to ``ON`` in CMakeCache.txt.
You can additionaly set ``IGRAPH_ENABLE_TLS:BOOL=ON`` if you intend to perform some operations parallely. The rest should be as it has been described in the manual.

If you are using Windows just install MSYS2 from https://www.msys2.org/ and (if you install it on `C:\`) execute ``$env:Path += ";C:\msys64\mingw64\bin"`` in the terminal you are using to launch\compile your programs.

Once the above is done you should be able to use Netgraph without problems.
## Installation
``dotnet add package Netgraph``

## Usage
To be done.

