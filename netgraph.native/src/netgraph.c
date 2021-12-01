#include "netgraph.h"
#include "misc.c"
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
int** unflatten_array(int* flattened_array,int size_of_root_array){
    int i,j;
    int** result = malloc(size_of_root_array * (sizeof(int*)));

    for(i=0,j=0;i<size_of_root_array;i++){
        result[i] = &flattened_array[j];
        j=flattened_array[j]+1;
    }

    return result;
}
*/
struct FoundIsomorphisms* get_all_subisos(
        struct NatGraph target,
        struct NatGraph pattern,
        int are_graphs_directed
        /*
        int** target_adjacency, //first element of each inner array is its size
        int ta_size,
        int* target_vertices_colors,
        int** pattern_adjacency,
        int pa_size,
        int* pattern_vertices_colors,
        int are_graphs_directed
        */
    ){
    igraph_t target_graph;
    igraph_vector_int_t target_colors;
    igraph_t pattern_graph;
    igraph_vector_int_t pattern_colors;
    igraph_vector_ptr_t iso_maps;
    igraph_vector_t *single_iso;
    igraph_vector_ptr_t *map;
    igraph_vector_t *pair;
    int i,j;
    int **target_adjacency,**pattern_adjacency;

    target_adjacency = unflatten_array(target.adjacency_data,target.number_of_vertices);
    pattern_adjacency = unflatten_array(pattern.adjacency_data,pattern.number_of_vertices);
    igraph_empty(&pattern_graph, pattern.number_of_vertices, are_graphs_directed);
    for (i=0;i<pattern.number_of_vertices;i++){        
        for(j=0;j<pattern_adjacency[i][0];j++)
            igraph_add_edge(&pattern_graph, i, pattern_adjacency[i][j+1]);
    }
    igraph_empty(&target_graph, target.number_of_vertices, are_graphs_directed);
    for (i=0;i<target.number_of_vertices;i++){        
        for(j=0;j<target_adjacency[i][0];j++)
            igraph_add_edge(&pattern_graph, i, target_adjacency[i][j+1]);
    }
    igraph_vector_int_init(&target_colors,0);
    for(i=0;i<target.number_of_vertices;i++){
        VECTOR(target_colors)[i] = target.vertices_colors[i];
    }
    igraph_vector_int_init(&pattern_colors,0);
    for(i=0;i<pattern.number_of_vertices;i++){
        VECTOR(pattern_colors)[i] = pattern.vertices_colors[i];
    }
    igraph_vector_ptr_init(&iso_maps,0);
    int ec = igraph_get_subisomorphisms_vf2(
  	            &target_graph,
  	            &pattern_graph,
                &target_colors,
                &pattern_colors,
                NULL,NULL,
                &iso_maps,
                NULL,
                NULL,
                NULL);
    long int number_of_isos = igraph_vector_ptr_size(&iso_maps);
    int** isos_result = malloc(number_of_isos * sizeof(int*));
    //result[0] = malloc(sizeof(long int));
    //*result[0] = number_of_isos;
    for (i=0; i < number_of_isos; i++) {
        single_iso = igraph_vector_ptr_e(&iso_maps,i);
        isos_result[i] = malloc(pattern.number_of_vertices * sizeof(int));
        for(j=0; j< igraph_vector_size(single_iso);j++)
        {
            isos_result[i][j]=VECTOR(*single_iso)[j];
            //printf("%g|",VECTOR(*single_iso)[j]);
        }
        //printf("\n");
    }
    struct FoundIsomorphisms *result = malloc(sizeof( struct FoundIsomorphisms ));
    result->number_of_isos = number_of_isos;
    result->isos=isos_result;
    return result;
}

