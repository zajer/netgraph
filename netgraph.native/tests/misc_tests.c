#include "../src/misc.c"

#define CTEST_MAIN
#define CTEST_SEGFAULT
#define CTEST_COLOR_OK
#include "ctest.h"

int main(int argc, const char *argv[])
{
    int result = ctest_main(argc, argv);
    return result;
}

CTEST(unflatten_array, test1){
    int f_array[] = {2,96,44,2,75,92};
    int expected_array[2][3] = { {2,96,44},{2,75,92} };
    int i,j;
    int **uf_array = unflatten_array(f_array,2);
    for(i=0;i<2;i++)
        for(j=0;j<3;j++)
            ASSERT_EQUAL(expected_array[i][j], uf_array[i][j]);
    free(uf_array);
}

CTEST(unflatten_array, test2){
    int f_array[] = {2,96,44,2,75,92};
    int expected_array[2][3] = { {2,97,44},{2,75,92} }; //the difference is intended, this test is expected to fail
    int i,j;
    int **uf_array = unflatten_array(f_array,2);
    for(i=0;i<2;i++)
        for(j=0;j<3;j++)
            if (i==0 && j==1)
                ASSERT_NOT_EQUAL(expected_array[i][j], uf_array[i][j]);
            else    
                ASSERT_EQUAL(expected_array[i][j], uf_array[i][j]);
    free(uf_array);
}

CTEST(unflatten_array, test3){
    int f_array[] = {3,333,444,11,2,71,95};
    
    int **expected_array = malloc (2 * sizeof(int*));
    expected_array[0] = malloc(4*sizeof(int));
    expected_array[0][0] = 3;
    expected_array[0][1] = 333;
    expected_array[0][2] = 444;
    expected_array[0][3] = 11;
    expected_array[1] = malloc(3*sizeof(int));
    expected_array[1][0] = 2;
    expected_array[1][1] = 71;
    expected_array[1][2] = 95;

    int i,j,k;
    int **uf_array = unflatten_array(f_array,2);
    for(i=0;i<2;i++)
    {
        switch(i)
        {
            case 0:
                k=4;
                break;
            case 1:
                k=3;
                break;
        }
        for(j=0;j<k;j++)
            ASSERT_EQUAL(expected_array[i][j], uf_array[i][j]);
    }
    free(expected_array[0]);
    free(expected_array[1]);
    free(expected_array);
}

CTEST(unflatten_array, test4){
    int f_array[] = {3,35,42,11,0,2,71,92};
    
    int **expected_array = malloc (3 * sizeof(int*));
    expected_array[0] = malloc(4*sizeof(int));
    expected_array[0][0] = 3;
    expected_array[0][1] = 35;
    expected_array[0][2] = 42;
    expected_array[0][3] = 11;
    expected_array[1] = malloc(1*sizeof(int));
    expected_array[1][0] = 0;
    expected_array[2] = malloc(3*sizeof(int));
    expected_array[2][0] = 2;
    expected_array[2][1] = 71;
    expected_array[2][2] = 92;

    int i,j,k;
    int **uf_array = unflatten_array(f_array,3);
    
    for(i=0;i<3;i++)
    {
        switch(i)
        {
            case 0:
                k=4;
                break;
            case 1:
                k=1;
                break;
            case 2:
                k=3;
                break;
        }
        for(j=0;j<k;j++){
            ASSERT_EQUAL(expected_array[i][j], uf_array[i][j]);
        }
    }
    
    free(expected_array[0]);
    free(expected_array[1]);
    free(expected_array[2]);
    free(expected_array);
}

CTEST(unflatten_array, test5){
    int f_array[] = {3,35,42,11,1,15,2,71,92};
    
    int **expected_array = malloc (3 * sizeof(int*));
    expected_array[0] = malloc(4*sizeof(int));
    expected_array[0][0] = 3;
    expected_array[0][1] = 35;
    expected_array[0][2] = 42;
    expected_array[0][3] = 11;
    expected_array[1] = malloc(2*sizeof(int));
    expected_array[1][0] = 1;
    expected_array[1][1] = 15;
    expected_array[2] = malloc(3*sizeof(int));
    expected_array[2][0] = 2;
    expected_array[2][1] = 71;
    expected_array[2][2] = 92;

    int i,j,k;
    int **uf_array = unflatten_array(f_array,3);
    
    for(i=0;i<3;i++)
    {
        switch(i)
        {
            case 0:
                k=4;
                break;
            case 1:
                k=2;
                break;
            case 2:
                k=3;
                break;
        }
        for(j=0;j<k;j++){
            ASSERT_EQUAL(expected_array[i][j], uf_array[i][j]);
        }
    }
    
    free(expected_array[0]);
    free(expected_array[1]);
    free(expected_array[2]);
    free(expected_array);
}