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
extern int is_igraph_thread_safe();

#endif //NETGRAPH_NATIVE_LIBRARY_H