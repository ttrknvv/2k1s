#include <iostream>
#include <windows.h>

using namespace std;

#define MAXPOINTS 8 // количество вершин
#define COUNTOFEDGE 16 // количество ребер графа

struct Graph{
    int point1 = 0;
    int point2 = 0;
    int weight = 0;
};

bool FindCycle(Graph a); // поиск цикла
void PrintFinishTree(); // нарисовать остовное дерево

Graph Array[COUNTOFEDGE] = { {1, 2, 2},{1, 4, 8}, {1, 5, 2}, // структура ребер графа
                                 {2, 3, 3}, {2, 5, 5}, {2, 4, 10},
                                 {3, 5, 12}, {3, 8, 7},
                                 {4, 5, 14}, {4, 7, 1}, {4, 6, 3},
                                 {5, 6, 11}, {5, 7, 4}, {5, 8, 8},
                                 {6, 7, 6}, {7, 8, 9} };
Graph Finish[MAXPOINTS - 1] = {}; // конечный результат

int main()
{
	int sum = 0;
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
    for (int i = 0; i < COUNTOFEDGE - 1; i++) { // сортировка ребер по возрастанию
        for (int j = 0; j < COUNTOFEDGE; j++) {
            if (Array[i].weight < Array[j].weight) {
                swap(Array[i], Array[j]);
            }
        }
    }
    Finish[0] = Array[0]; // наименьшее ребро в первое ребро ответа
	sum += Array[0].weight;
    int count = 1;

    for (int j = 1; j < COUNTOFEDGE; j++) {
        if (FindCycle(Array[j])) {
            continue;
        }
        Finish[count++] = Array[j];
	    sum += Array[j].weight;
		if (count >= MAXPOINTS - 1) break;
    }

	cout << "Список смежности: \n";
	for (int i = 0; i < MAXPOINTS - 1; i++) {
		cout << endl << Finish[i].point1 << " -> " << Finish[i].point2 << " Вес: " << Finish[i].weight;
	}
	cout << "\nНаименьший путь: " << sum;
	PrintFinishTree();
    system("pause");
}

bool FindCycle(Graph a) {
    for (int i = 0; Finish[i].weight; i++) {
        if (a.point1 == Finish[i].point1) {
            for (int j = 0; Finish[j].weight; j++) {
                if (Finish[j].point2 == a.point2) {
                    if (Finish[j].point1 == Finish[i].point2) return true;
                }
                if (Finish[j].point1 == a.point2) {
                    if (Finish[j].point2 == Finish[i].point2) return true;
                }
            }
        }
        if(a.point1 == Finish[i].point2) {
            for (int j = 0; Finish[j].weight; j++) {
                if (Finish[j].point2 == a.point2) {
                    if (Finish[j].point1 == Finish[i].point1) return true;
                }
                if (Finish[j].point1 == a.point2) {
                    if (Finish[j].point2 == Finish[i].point1) return true;
                }
            }
        }
    }
    return false;
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

	p.X += 2;
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
	p.X = 30;
	p.Y = 39;
	SetConsoleCursorPosition(out, p);
	cout << "5";
	p.X -= 2;
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