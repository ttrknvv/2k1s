#include <iostream>
#include <Windows.h>
#include <queue>
#include <stack>

/*
    * Графы - алгоритмы
*/
using namespace std;
#define MAXPOINT 15 // максимальное количество вершин
#define MAXEDGE MAXPOINT * (MAXPOINT - 1) / 2 // максимальное количество ребер

int adjacencyArray[MAXPOINT][MAXPOINT]; // матрица смежности

int from[MAXPOINT * 2]; int to[MAXPOINT * 2]; // список ребер от и до

int adjacencyList[MAXPOINT][MAXPOINT]; // список смежности

int visitedPoints[MAXPOINT]; // посещенные вершины
int QUEUE[MAXPOINT]; // массив для вывода очереди

int points; // количество вершин
int count2 = 0;

void addGraph(int max); // реализация матрицы смежности О(Е)
void addGraph2(int max); // реализация списка ребер O(E)
void addGraph3(int max); // реализация списка смежности О(V + E)
void BreadthFirstSearch(); // реализация поиска в ширину
void DepthFirstSearch(); // реализация поиска в глубину
void outPutVisited(); // вывод посещенных вершин
void outputQUEUE(queue<int> visit); // вывод очереди
void outputStack(stack<int> visit); // вывод стека
bool varificationStack(int a, stack<int>pro); // проверка стека
int findUnUse2(); // поиск неиспользованных эелементов в глубине

int main()
{
    int choise;
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    cout << "Введите количество вершин: "; cin >> points;
    cout << "1) Матрица смежности\n2) Список ребер\n3) Список смежности\n";
    cout << "Введите способ представления графа: "; cin >> choise;
    switch (choise) {
        case 1: addGraph(points);
                break;
        case 2: addGraph2(points);
                break;
        case 3: addGraph3(points);
                cout << "\n\n---------------------------------\n\n";
                cout << "Выберите метод обхуда графа:\n1) Поиск в ширину\n2) Поиск в глубину\nВыбор: ";
                cin >> choise;
                switch (choise) {
                    case 1: BreadthFirstSearch();
                            break;
                    case 2: DepthFirstSearch();
                            break;
                    default: cout << "Неправильно введены данные!";
                            break;
                }
                break;
        default: "Неверно введены данные!";
                 break;
    }
    return 0;
}

void addGraph(int max) {
    int choise;
    for (int i = 1; i <= max; i++) {
        for (int j = 1; j <= points; j++) {
            cout << "Есть такое ребро from: " << i << " to: " << j << "?(Введите 1, если да, 0, если нет): ";
            cin >> choise;
            if (choise) { adjacencyArray[i][j] = 1; }
        }
    }
    cout << "\n\n-------------------------------\n\n";
    cout << "Ваша матрица смежности:\n\n";
    cout << "\t";
    for (int i = 1; i <= max; i++) {
        cout << i << "\t";
    }
    cout << " - Вершины\n\n";
    for (int i = 1; i <= max; i++) {
        cout << i << "\t";
        for (int j = 1; j <= max; j++) {
            cout << adjacencyArray[i][j] << "\t";
        }
        cout << endl << endl;
    }
    cout << "|\nВершины";
}
void addGraph2(int max) {
    int from2, to2;
    for (int i = 0; i < max * 2; i = i + 2) {
        cout << "Введите ребро\nfrom: "; cin >> from2;
        from[i] = from2; to[i + 1] = from2;
        cout << "to: "; cin >> to2;
        to[i] = to2; from[i + 1] = to2;
    }
    cout << "\n\n-------------------------------\n\n";
    cout << "Ваш список ребер:\n";
    for (int i = 0; from[i]; i = i + 2) {
        cout << "{ " << from[i] << ", " << to[i] << "}, ";
        cout << "{ " << from[i + 1] << ", " << to[i + 1] << "}\n";
    }
}
void addGraph3(int max) {
    int point = 0, to = 0, k = 0;
    for (int i = 0; i < max; i++) {
        to = 1, k = 0;
        cout << "Введите вершину: "; cin >> point;
        while (to) {
            cout << "Введите смежную вершину(закончите ввод 0): ";
            cin >> to;
            if (to) { 
                adjacencyList[point][k] = to;
                k++;
            }
        }
        }
    cout << "\n\n-------------------------------\n\n";
    cout << "Ваш список смежности:\n";
    for (int i = 1; i <= max; i++) {
        cout << i << " => { ";
        for (int j = 0; adjacencyList[i][j]; j++) {
            cout << adjacencyList[i][j];
            if (adjacencyList[i][j + 1]) { cout << " , "; }
        }
        cout << " }\n";
        
    }
    
}
void BreadthFirstSearch() {
    queue<int> visit;
    int currentPoint = 1, i = 0, j = 0;
    bool visitedPoint = false;
    visit.push(currentPoint);
    visitedPoints[j] = visit.front();
    j++;
    cout << endl << endl;
    while (!visit.empty()) {
        outPutVisited();
        outputQUEUE(visit);
        for (int k = 0; adjacencyList[visit.front()][k]; k++) {
            for (int g = 0; visitedPoints[g]; g++) {
                if (visitedPoints[g] == adjacencyList[visit.front()][k]) { visitedPoint = true; break; }
            }
            if (!visitedPoint) {
                visit.push(adjacencyList[visit.front()][k]);
                visitedPoints[j] = visit.back();
                j++;
                outPutVisited();
                outputQUEUE(visit);
            }
            visitedPoint = false;
        }
        visit.pop();
        if (visit.empty() && j != points) { 
            visit.push(++j); 
            visitedPoints[j-1] = visit.back();
        }
    }

    outPutVisited();
    outputQUEUE(visit);
}
void DepthFirstSearch() {
    stack<int> points2;
    int currentPoint = 1, i = 0, j = 0;
    bool repeat = false;
    int variable = 1;
    points2.push(currentPoint);
    outPutVisited();
    outputStack(points2);
    cout << endl << endl;
    while (!points2.empty()) {
        outPutVisited();
        outputStack(points2);
        for (int k = 0; adjacencyList[variable][k]; k++) {
            for (int g = 0; visitedPoints[g]; g++) {
                if (visitedPoints[g] == adjacencyList[variable][k] || varificationStack(adjacencyList[variable][k], points2)) {
                    repeat = true; break;
                }
            }
                if (!k) {
                    visitedPoints[j] = points2.top();
                    j++;
                    points2.pop();
                }
                if (!repeat) {
                    points2.push(adjacencyList[variable][k]);
                    outPutVisited();
                    outputStack(points2);
                }
                repeat = false;
            }
        if(j != points) {
            if(points2.empty()) 
                points2.push(findUnUse2());
            variable = points2.top();
            }
    }
    outPutVisited();
    outputStack(points2);
}
void outPutVisited() {
    cout << "Посещенные вершины: ";
    for (int i = 0; visitedPoints[i]; i++) {
        cout << visitedPoints[i] << " ";
    }
    cout << endl;
}
void outputQUEUE(queue<int> visit) {
    queue<int> secondvisit = visit;
    cout << "Очередь: ";
    while (!secondvisit.empty()) {
        cout << secondvisit.front() << " ";
        secondvisit.pop();
    }
    cout << endl << endl << "---------------------------" << endl << endl;
}
void outputStack(stack<int> visit) {
    stack<int> secondvisit = visit;
    cout << "Стек: ";
    while (!secondvisit.empty()) {
        cout << secondvisit.top() << " ";
        secondvisit.pop();
    }
    cout << endl << endl << "---------------------------" << endl << endl;
}
bool varificationStack(int a, stack<int>pro) {
    stack<int>sec = pro;
    while (!pro.empty()) {
        if (a == pro.top()) return true;
        pro.pop();
    }
    return false;
}
int findUnUse2() {
    bool unuse = true;
    int un = 1;
    while(unuse) {
        for (int j = 0; visitedPoints[j] ; j++) {
            if (un == visitedPoints[j]) { unuse = false; break; };
        }
        if (unuse) return un;
        else unuse = true;
        un++;
    }
}

