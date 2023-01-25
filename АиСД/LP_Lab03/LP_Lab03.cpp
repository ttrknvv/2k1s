#include <iostream>
#include <windows.h>

void PrintGraph(); // функция вывода графа
int LetterInNumber(char a); // преобразование в число
char NumberInLetter(int a); // преобразование в символ
void AhloritmDeikstra(char choise); // алгоритм Дейсктры

using namespace std;

#define MAX INT32_MAX
 
int Graph[9][9] = { {0, 7, 10, 0, 0 , 0 , 0, 0, 0 }, // сам граф
                    {7, 0, 0, 0, 0, 9, 27, 0, 0},
                    {10, 0, 0, 0, 31, 8, 0, 0, 0},
                    {0, 0, 0, 0, 32, 0, 0, 17, 21},
                    {0, 0, 31, 32, 0, 0, 0, 0, 0},
                    {0, 9, 8, 0, 0, 0, 0, 11, 0},
                    {0, 27, 0, 0, 0, 0, 0, 0, 15},
                    {0, 0, 0, 17, 0, 11, 0, 0, 15},
                    {0, 0, 0, 21, 0, 0, 15, 15, 0} };
int ShortWay[9]; // массив короткий путей
int PassedWay[9]; // массив посещенных вершин

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    char choise = ' ';
    cout << "Граф заполнен в соответствии с 3 лабораторной работой.\n";
    PrintGraph();

    cout << "Алгоритм Дейкстры: Введите с какой вершины искать короткие пути: "; cin >> choise;
    AhloritmDeikstra(choise);
    cout << "Кратчайшие пути до вершин: \n";
    for (int i = 0; i < 9; i++) {
        if (LetterInNumber(choise) == i) { continue; }
        cout << NumberInLetter(i) << " -> " << ShortWay[i] << endl;
    }
    system("pause");
}

void PrintGraph() {
    cout << "\t";
    for (int i = 0; i < 9; i++) cout << NumberInLetter(i) << "\t";
    cout << endl << endl;
    for (int i = 0; i < 9; i++) {
        for (int j = 0; j < 9; j++) {
            if (!j) cout << NumberInLetter(i) << "\t";
            if (Graph[i][j] == MAX) {
                cout << 0 << "\t";
                continue;
            }
            cout << Graph[i][j] << "\t";
        }
        cout << endl << endl;
    }
}
int LetterInNumber(char a) {
    switch (a) {
    case 'A': return 0;
    case 'B': return 1;
    case 'C': return 2;
    case 'D': return 3;
    case 'E': return 4;
    case 'F': return 5;
    case 'G': return 6;
    case 'H': return 7;
    case 'I': return 8;
    default: return -1;
    }
}
char NumberInLetter(int a) {
    switch (a) {
    case 0: return 'A';
    case 1: return 'B';
    case 2: return 'C';
    case 3: return 'D';
    case 4: return 'E';
    case 5: return 'F';
    case 6: return 'G';
    case 7: return 'H';
    case 8: return 'I';
    default: return ' ';
    }
}
void AhloritmDeikstra(char choise) {
    for (int i = 0; i < 9; i++) { // заполняем путь к вершине бесконечностью и пройденные вершины 0
        ShortWay[i] = MAX;
        PassedWay[i] = 0;
    }

    ShortWay[LetterInNumber(choise)] = 0; // узел для начала алгоритма
    int minValue;
    int index;
    int temp;
    do {
        index = MAX;
        minValue = MAX;
        for (int i = 0; i < 9; i++) {
            if (!PassedWay[i] && ShortWay[i] < minValue) { // установка непосещенных вершин
                minValue = ShortWay[i]; 
                index = i;
            }
        }

        if (index != MAX) {
            for (int i = 0; i < 9; i++) {
                if (Graph[index][i] > 0) {
                    temp = minValue + Graph[index][i]; // поиск наименьшего пути
                    if (temp < ShortWay[i]) {
                        ShortWay[i] = temp;
                    }
                }
            }
            PassedWay[index] = 1;
        }
    } while (index < MAX);
}
