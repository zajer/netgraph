#ifndef NETGRAPH_NATIVE_LIBRARY_H
#define NETGRAPH_NATIVE_LIBRARY_H
/*
#if defined DLL_EXPORTS
    #if defined WIN32
        #define LIB_API(RetType) extern __declspec(dllexport) RetType
    #else
        #define LIB_API(RetType) extern RetType __attribute__((visibility("default")))
    #endif
#else
    #if defined WIN32
        #define LIB_API(RetType) extern __declspec(dllimport) RetType
    #else
        #define LIB_API(RetType) extern RetType
    #endif
#endif

LIB_API(void) hello();
*/
struct NatGraph {
    int number_of_vertices;
    int* adjacency_data; 
        // Since c# cannot pass array of arrays to native lib this array is "flattened" two dimensional array (second array may vary in lendth).
        // The structure of this array is as follows: each "inner" array begins with the number representing its length.
        // Then the next x number of elements (x is the number defined above) are "regular" content of an inner array.
        // The scheme repeats number_of_vertices times.
    int* vertices_colors;
};
struct FoundIsomorphisms {
    int number_of_isos;
    int** isos;
};
extern int is_igraph_thread_safe();
extern struct FoundIsomorphisms* get_all_subisos(struct NatGraph*,struct NatGraph*,int);
#endif //NETGRAPH_NATIVE_LIBRARY_H