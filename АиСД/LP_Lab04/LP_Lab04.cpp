/*
 * Алгоритм Флойда - Уоршелла
 */

#include <iostream>
#include <windows.h>

#define MAXPOINTS 6 // количество вершин

void OutputArrayAndWay(int(&Array)[MAXPOINTS][MAXPOINTS], int(&Array2)[MAXPOINTS][MAXPOINTS]); // функция вывода матрицы смежности исходного графа(D^0)

using namespace std;

int AdjacencyMatrix[MAXPOINTS][MAXPOINTS] = {  {0, 28, 21, 59, 12, 27}, // матрица смежности графа(D^0)
											   {7, 0, 24, INT32_MAX, 21, 9},
											   {9, 32, 0, 13, 11, INT32_MAX},
											   {8, INT32_MAX, 5, 0, 16, INT32_MAX},
											   {14, 13, 15, 10, 0, 22},
											   {15, 18, INT32_MAX, INT32_MAX, 6, 0}  };
int ShortWay[MAXPOINTS][MAXPOINTS] = { {0, 2, 3, 4, 5, 6}, // матрица кратчайших путей(S^0)
									   {1, 0, 3, 4, 5, 6},
									   {1, 2, 0, 4, 5, 6},
									   {1, 2, 3, 0, 5, 6},
									   {1, 2, 3, 4, 0, 6},
									   {1, 2, 3, 4, 5, 0} };

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	OutputArrayAndWay(AdjacencyMatrix, ShortWay);
	for (int m = 0; m < MAXPOINTS; m++) {
		for (int i = 0; i < MAXPOINTS; i++) {
			for (int j = 0; j < MAXPOINTS; j++) {
				if (AdjacencyMatrix[i][j] > AdjacencyMatrix[i][m] + AdjacencyMatrix[m][j] && i != j && i != m && j != m) {
					AdjacencyMatrix[i][j] = AdjacencyMatrix[i][m] + AdjacencyMatrix[m][j];
					ShortWay[i][j] = ShortWay[i][m];
				}
			}
		}
	}
	OutputArrayAndWay(AdjacencyMatrix, ShortWay);
	system("pause");
	return 0;
}

void OutputArrayAndWay(int (& Array)[MAXPOINTS][MAXPOINTS], int (&Array2)[MAXPOINTS][MAXPOINTS]) {
	cout << "Матрица смежности заданного графа:" << "\n\n\t";
	for (int i = 1; i <= 6; i++) {
		cout << i << "\t";
	}
	cout << endl;
	for (int i = 0; i < MAXPOINTS; i++) {
		cout << endl << i + 1 << "\t";
		for (int j = 0; j < MAXPOINTS; j++) {
			if (Array[i][j] == INT32_MAX) {
				cout << 0 << "\t";
				continue;
			}
			cout << Array[i][j] << "\t";
		}
		cout << endl;
	}
	cout << endl << endl;
	cout << "Матрица короктих путей:" << "\n\n\t";
	for (int i = 1; i <= 6; i++) {
		cout << i << "\t";
	}
	cout << endl;
	for (int i = 0; i < MAXPOINTS; i++) {
		cout << endl << i + 1 << "\t";
		for (int j = 0; j < MAXPOINTS; j++) {
			if (Array2[i][j] == INT32_MAX) {
				cout << 0 << "\t";
				continue;
			}
			cout << Array2[i][j] << "\t";
		}
		cout << endl;
	}
	return;
}