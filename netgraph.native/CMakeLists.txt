cmake_minimum_required(VERSION 3.14)
project(NetgraphNative)

set(CMAKE_CXX_STANDARD 17)

find_package(igraph REQUIRED)

add_compile_definitions(DLL_EXPORTS)

add_library(NetgraphNative SHARED netgraph.c netgraph.h)

target_link_libraries(NetgraphNative PUBLIC igraph::igraph)

