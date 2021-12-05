find_package(igraph REQUIRED)
add_compile_definitions(LIB_COMPILATION)
add_library(NetgraphNative SHARED netgraph.c netgraph.h)

target_link_libraries(NetgraphNative PUBLIC igraph::igraph)
