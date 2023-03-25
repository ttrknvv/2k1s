/*
* Алгоритм Прима
*/
#include <iostream>
#include <windows.h>

using namespace std;

#define MAXPOINTS 8 // количество вершин

void OutputArray(int(&Array)[MAXPOINTS][MAXPOINTS]); // функция вывода
void PrintFinishTree(); // нарисовать остовное дерево

int AdjacencyMatrix[MAXPOINTS][MAXPOINTS] = { {INT32_MAX, 2, INT32_MAX, 8, 2, INT32_MAX, INT32_MAX, INT32_MAX }, // матрица смежности
											  {2, INT32_MAX, 3, 10, 5, INT32_MAX, INT32_MAX, INT32_MAX},
											  {INT32_MAX, 3, INT32_MAX, INT32_MAX, 12, INT32_MAX, INT32_MAX, 7},
											  {8, 10, INT32_MAX, INT32_MAX, 14, 3, 1, INT32_MAX },
											  {2, 5, 12, 14, INT32_MAX, 11, 4, 8},
											  {INT32_MAX, INT32_MAX, INT32_MAX, 3, 11, INT32_MAX, 6, INT32_MAX},
											  {INT32_MAX, INT32_MAX, INT32_MAX, 1, 4, 6, INT32_MAX, 9},
											  {INT32_MAX, INT32_MAX, 7, INT32_MAX, 8, INT32_MAX, 9, INT32_MAX} };
bool visited[MAXPOINTS] = {};
 
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	OutputArray(AdjacencyMatrix);
	visited[0] = true;
	int sum = 0;
	for (int i = 0; i < MAXPOINTS - 1; i++) {
		int indexX = -1, indexY = -1;
		for (int j = 0; j < MAXPOINTS; j++) {
			if (visited[j]) {
				for (int k = 0; k < MAXPOINTS; k++) {
					if (!visited[k] && AdjacencyMatrix[j][k] > 0 && AdjacencyMatrix[j][k] != INT32_MAX 
						&& (indexY == -1 || AdjacencyMatrix[j][k] < AdjacencyMatrix[indexY][indexX])) {
						indexY = j;
						indexX = k;
					}
				}
			}
		} 
		visited[indexX] = true;
		cout << indexY + 1 << " -> " << indexX + 1 << endl;
		sum += AdjacencyMatrix[indexY][indexX];
	}	
	cout << "\nМинимальный путь: " << sum << endl;
	PrintFinishTree();
	system("pause");
}

void OutputArray(int(&Array)[MAXPOINTS][MAXPOINTS]) {
	cout << "Матрица смежности заданного графа:\n\n";
	for (int i = 1; i <= MAXPOINTS; i++) {
		cout << "v" << i << "\t";
	}
	cout << endl;
	for (int i = 0; i < MAXPOINTS; i++) {
		cout << endl << "v" << i + 1 << "\t";
		for (int j = 0; j < MAXPOINTS; j++) {
			if (Array[i][j] == INT32_MAX) {
				cout << 0 << "\t";
				continue;
			}
			cout << Array[i][j] << "\t";
		}
		cout << endl;
	}
	return;
}
void PrintFinishTree() {
	HANDLE out = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD p = { 9, 28 };
	SetConsoleCursorPosition(out, p);
	cout << "1";
	SetConsoleTextAttribute(out, FOREGROUND_RED);
	p.X = 19;
	SetConsoleCursorPosition(out, p);
	cout << "2";
	SetConsoleTextAttribute(out, 0xf);
	p.Y++;
	p.X = 9;
	SetConsoleCursorPosition(out, p);
	for (int i = 0; i <= 20; i++) {
		cout << "*" << " ";
	}

	p.Y = 28;
	p.X = 30;
	SetConsoleCursorPosition(out, p);
	cout << "2";
	SetConsoleTextAttribute(out, FOREGROUND_RED);
	p.X = 39;
	SetConsoleCursorPosition(out, p);
	cout << "3";
	SetConsoleTextAttribute(out, 0xf);
	p.X = 49;
	SetConsoleCursorPosition(out, p);
	cout << "3";
	p.Y++;
	for (int i = 0; i < 20; i++) {
		p.Y = 30 + i;
		SetConsoleCursorPosition(out, p);
		cout << "*";
	}

	p.X+=2;
	SetConsoleCursorPosition(out, p);
	cout << "8";
	SetConsoleTextAttribute(out, FOREGROUND_RED);
	p.Y = 40;
	SetConsoleCursorPosition(out, p);
	cout << "7";
	SetConsoleTextAttribute(out, 0xf);
	p.X = 10;
	p.Y = 30;
	for (int i = 0; i < 10; i++) {
		p.X = 10 + i * 2;
		p.Y = 30 + i;
		SetConsoleCursorPosition(out, p);
		cout << "*";
	}

	SetConsoleTextAttribute(out, FOREGROUND_RED);
	p.X = 22;
	p.Y = 34;
	SetConsoleCursorPosition(out, p);
	cout << "2";
	SetConsoleTextAttribute(out, 0xf);
	p.X=30;
	p.Y = 39;
	SetConsoleCursorPosition(out, p);
	cout << "5";
	p.X-=2;
	SetConsoleCursorPosition(out, p);
	for (int i = 0; i < 10; i++) {
		SetConsoleCursorPosition(out, p);
		p.Y = 40 + i;
		cout << "*";
	}
	SetConsoleTextAttribute(out, FOREGROUND_RED);
	p.X = 30;
	p.Y = 44;
	SetConsoleCursorPosition(out, p);
	cout << "4";
	SetConsoleTextAttribute(out, 0xf);
	p.Y = 49;
	SetConsoleCursorPosition(out, p);
	cout << "7";
	p.X -= 2;
	SetConsoleCursorPosition(out, p);
	for (int i = 0; i < 10; i++) {
		p.X = 28 - i * 2;
		p.Y = 48 - i;
		SetConsoleCursorPosition(out, p);
		cout << "*";
	}
	SetConsoleTextAttribute(out, FOREGROUND_RED);
	p.X = 20;
	p.Y = 42;
	SetConsoleCursorPosition(out, p);
	cout << "1";
	SetConsoleTextAttribute(out, 0xf);
	p.X = 12;
	p.Y = 38;
	SetConsoleCursorPosition(out, p);
	cout << "4";
	p.X -= 2;
	p.Y += 1;
	SetConsoleCursorPosition(out, p);
	for (int i = 0; i < 9; i++) {
		p.Y = 40 + i;
		SetConsoleCursorPosition(out, p);
		cout << "*";
	}
	p.X += 2;
	SetConsoleCursorPosition(out, p);
	cout << "6\n";
	SetConsoleTextAttribute(out, FOREGROUND_RED);
	p.Y = 44;
	SetConsoleCursorPosition(out, p);
	cout << "3";
	p.Y = 60;
	SetConsoleCursorPosition(out, p);
	SetConsoleTextAttribute(out, 0xf);
}

