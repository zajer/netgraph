find_package(igraph REQUIRED)

add_library(NetgraphNative SHARED netgraph.c netgraph.h)

target_link_libraries(NetgraphNative PUBLIC igraph::igraph)
