#ifndef NETGRAPH_NATIVE_LIBRARY_H
#define NETGRAPH_NATIVE_LIBRARY_H

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
#define LIB_API_PREFIX_win_export() extern __declspec(dllexport)
#define LIB_API_PREFIX_win_import() extern __declspec(dllimport)
#define LIB_API_PREFIX_win(export_import) LIB_API_PREFIX_win_##export_import()
#define LIB_API_PREFIX_unix(export_import) extern

#define LIB_API_SUFFIX_win() 
#define LIB_API_SUFFIX_unix() __attribute__((visibility("default")))

#define LIB_API(platform,export_import) \
	LIB_API_PREFIX_##platform(export_import) int LIB_API_SUFFIX_##platform() is_igraph_thread_safe(); \
    LIB_API_PREFIX_##platform(export_import) struct FoundIsomorphisms LIB_API_SUFFIX_##platform() get_all_subisos(struct NatGraph,struct NatGraph,int); 


#if defined LIB_COMPILATION
    #if defined WIN32
        LIB_API(win,export)       
        //extern __declspec(dllexport) int is_igraph_thread_safe();
        //extern __declspec(dllexport) struct FoundIsomorphisms get_all_subisos(struct NatGraph,struct NatGraph,int);
    #else
        LIB_API(unix,export)
        //extern int __attrubte__((visibility("default"))) is_igraph_thread_safe();
        //extern  struct FoundIsomorphisms __attrubte__((visibility("default"))) get_all_subisos(struct NatGraph,struct NatGraph,int);
    #endif
#else
    #if defined WIN32
        LIB_API(win,import)
        //extern __declspec(dllimport) int is_igraph_thread_safe();
        //extern __declspec(dllimport) struct FoundIsomorphisms get_all_subisos(struct NatGraph,struct NatGraph,int);
    #else
        LIB_API(unix,import)
        //extern int is_igraph_thread_safe();
        //extern struct FoundIsomorphisms get_all_subisos(struct NatGraph,struct NatGraph,int);
    #endif
#endif

#endif