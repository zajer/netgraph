#include "netgraph.h"
#include <igraph.h>
#include <stdio.h>

#if defined(_WIN32)
    #define OS "Windows"
#elif defined(__linux__)
    #define OS "Linux"
#elif defined(__APPLE__)
    #define OS "MacOS"
#else
    #define OS "Unknown OS"
#endif

int is_igraph_thread_safe(){
    return IGRAPH_THREAD_SAFE ;   
}

/*
int** get_all_subisos(int** target_adjacency,int ta_size,int* target_vertex_color,int tvc_size,int** pattern_adjacency,int pa_size,int* pattern_vertex_color,int pvc_size){
    igraph_t small_graph;
    igraph_t big_graph;
    igraph_t triangle_graph;
    igraph_vector_ptr_t iso_maps;
    igraph_vector_t *single_iso;
    igraph_vector_ptr_t *map;
    igraph_vector_t *pair;

    igraph_vector_ptr_init(&iso_maps,0);
}
*/