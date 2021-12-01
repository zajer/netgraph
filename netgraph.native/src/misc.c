#include <stdlib.h>
//the result outer array needs to be freed
int** unflatten_array(int* flattened_array,int size_of_root_array){
    int i,j; //i - index in the result array, j index in the flattened array poining at the begining of the next "inner" array
    int **result = malloc(size_of_root_array * (sizeof(int*)));

    for(i=0,j=0;i<size_of_root_array;i++){
        result[i] = &flattened_array[j];
        j=j+flattened_array[j]+1;
    }
    return result;
}
