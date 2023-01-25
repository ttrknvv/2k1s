#include <iostream>
//#include "D:\2k1s\КПО\LP_Lab05\SE_Asm01\Debug\SE_Asm01_a.lib"
#pragma comment(lib, "..\\Debug\\SE_Asm01_a.lib")
using namespace std;

extern "C"
{
    int __stdcall getmin(int *arr, int size);
    int __stdcall getmax(int* arr, int size);
}

int main()
{
    int iARR[10] = { 17, 2, 3, 4, 5, 6, 7, 8, 9, -1 };
    int sum = getmin(iARR, (sizeof(iARR)) / sizeof(int)) + getmax(iARR, (sizeof(iARR)) / sizeof(int));
    cout << "getmin + getmax = " << sum;
}

