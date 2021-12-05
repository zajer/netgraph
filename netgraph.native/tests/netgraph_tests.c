#include "../src/netgraph.h"

#define CTEST_MAIN
#ifndef WIN32 //there is no signal.h with kill(pid_t,int) on Windows :(
    #define CTEST_SEGFAULT
#endif
#define CTEST_COLOR_OK
#include "ctest.h"

int main(int argc, const char *argv[])
{
    int result = ctest_main(argc, argv);
    return result;
}

void construct_target_graph_for_test1(struct NatGraph *graph){
    //structure:
    //  0
    // 1 2
    //3
    // 0 -> 2
    // 1 -> 0,3
    // 2 ->
    // 3 ->
    int ref_adj[] = { 1,2,2,0,3,0,0};
    int ref_adj_length = sizeof(ref_adj)/sizeof(int);
    int *adjacency = malloc(sizeof(int)*ref_adj_length);
    for(int i=0;i<ref_adj_length;i++)
        adjacency[i] = ref_adj[i];
    graph->number_of_vertices = 4;
    graph->vertices_colors=NULL;
    graph->adjacency_data=adjacency;
}
void construct_pattern_graph_for_test1(struct NatGraph *graph){
    //structure:
    //  0
    // 1 2
    // 0 -> 1, 2
    // 1 ->
    // 2 ->
    int ref_adj[] = { 2,1,2,0,0};
    int ref_adj_length = sizeof(ref_adj)/sizeof(int);
    int *adjacency = malloc(sizeof(int)*ref_adj_length);
    for(int i=0;i<ref_adj_length;i++)
        adjacency[i] = ref_adj[i];
    graph->number_of_vertices = 3;
    graph->vertices_colors=NULL;
    graph->adjacency_data=adjacency;
}

CTEST(all_subiso_suite,no_colors_not_directed){
    struct FoundIsomorphisms result;
    struct NatGraph *target = malloc (sizeof( struct NatGraph ));
    struct NatGraph *pattern = malloc (sizeof( struct NatGraph ));
    int expected_number_of_isos = 4;
    construct_target_graph_for_test1(target);
    construct_pattern_graph_for_test1(pattern);
    result = get_all_subisos(*target,*pattern,0);
    ASSERT_EQUAL(expected_number_of_isos,result.number_of_isos);
    free(target->adjacency_data);
    free(pattern->adjacency_data);
    for(int i=0;i<expected_number_of_isos;i++)
        free(result.isos[i]);
    free(result.isos);
    //free(result);
}
CTEST(all_subiso_suite,no_colors_directed){
    struct FoundIsomorphisms result;
    struct NatGraph *target = malloc (sizeof( struct NatGraph ));
    struct NatGraph *pattern = malloc (sizeof( struct NatGraph ));
    int expected_number_of_isos = 2;
    construct_target_graph_for_test1(target);
    construct_pattern_graph_for_test1(pattern);
    result = get_all_subisos(*target,*pattern,1);
    ASSERT_EQUAL(expected_number_of_isos,result.number_of_isos);
    free(target->adjacency_data);
    free(pattern->adjacency_data);
    for(int i=0;i<expected_number_of_isos;i++)
        free(result.isos[i]);
    free(result.isos);
    //free(result);
}

void color_target_graph_for_test3(struct NatGraph *graph){
    int ref_colors[] = {0,0,2,2};
    int ref_colors_length = sizeof(ref_colors)/sizeof(int);
    int *colors = malloc (sizeof(int)*ref_colors_length);
    for(int i=0;i<ref_colors_length;i++)
        colors[i]=ref_colors[i];
    graph->vertices_colors=colors;
}
void color_pattern_graph_for_test3(struct NatGraph *graph){
    int ref_colors[] = {0,0,2};
    int ref_colors_length = sizeof(ref_colors)/sizeof(int);
    int *colors = malloc (sizeof(int)*ref_colors_length);
    for(int i=0;i<ref_colors_length;i++)
        colors[i]=ref_colors[i];
    graph->vertices_colors=colors;
}

CTEST(all_subiso_suite,colors_not_directed){
    struct FoundIsomorphisms result;
    struct NatGraph *target = malloc (sizeof( struct NatGraph ));
    struct NatGraph *pattern = malloc (sizeof( struct NatGraph ));
    int expected_number_of_isos = 2;
    construct_target_graph_for_test1(target);
    construct_pattern_graph_for_test1(pattern);
    color_target_graph_for_test3(target);
    color_pattern_graph_for_test3(pattern);
    result = get_all_subisos(*target,*pattern,0);
    ASSERT_EQUAL(expected_number_of_isos,result.number_of_isos);
    free(target->adjacency_data);
    free(target->vertices_colors);
    free(pattern->adjacency_data);
    free(pattern->vertices_colors);
    for(int i=0;i<expected_number_of_isos;i++)
        free(result.isos[i]);
    free(result.isos);
    //free(result);
}
CTEST(all_subiso_suite,colors_directed){
    struct FoundIsomorphisms result;
    struct NatGraph *target = malloc (sizeof( struct NatGraph ));
    struct NatGraph *pattern = malloc (sizeof( struct NatGraph ));
    int expected_number_of_isos = 1;
    construct_target_graph_for_test1(target);
    construct_pattern_graph_for_test1(pattern);
    color_target_graph_for_test3(target);
    color_pattern_graph_for_test3(pattern);
    result = get_all_subisos(*target,*pattern,1);
    ASSERT_EQUAL(expected_number_of_isos,result.number_of_isos);
    free(target->adjacency_data);
    free(target->vertices_colors);
    free(pattern->adjacency_data);
    free(pattern->vertices_colors);
    for(int i=0;i<expected_number_of_isos;i++)
        free(result.isos[i]);
    free(result.isos);
    //free(result);
}