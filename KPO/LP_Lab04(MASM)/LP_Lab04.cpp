/*
* 13 вариант: Переменная: short;
*             беззнаковый целочисленный литерал (2 байта)
*/
#include <iostream>
#include <fstream>
#include <windows.h>

#define NAMEOFFILE "Serialization.txt"

const unsigned char TYPESHORT = 1;
const unsigned char TYPEUSHORT = 2;
const unsigned char TYPEARRAYINT = 3;

using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    int count = 0;
    int ucount = 0;
    short icount = 0;
    short* dataSH;
    unsigned short* dataUSH;
    int* dataINT;

    cout << "Введите количество данных типа short: "; cin >> count;
    dataSH = new short[count];
    for (int i = 0; i < count; i++) {
        cout << "Введите " << i + 1 << "-ый элемент типа short: ";
        cin >> dataSH[i];
    }

    cout << "Введите количество данных типа unsigned short: "; cin >> ucount;
    dataUSH = new unsigned short[ucount];
    for (int i = 0; i < ucount; i++) {
        cout << "Введите " << i + 1 << "-ый элемент типа unsigned short: ";
        cin >> dataUSH[i];
    }

    cout << "Введите количество элементов массива типа int: "; cin >> icount;
    dataINT = new int[icount];
    for (int i = 0; i < icount; i++) {
        cout << "Введите " << i << "-ый элемент массива типа int: ";
        cin >> dataINT[i];
    }

    ofstream binaryFile(NAMEOFFILE, ios::binary);

    if (binaryFile.is_open()) {
        for (int i = 0; i < count; i++) {
            binaryFile.write((char*)&TYPESHORT, sizeof(char));
            binaryFile.write((char*)&dataSH[i], sizeof(short));
        }

        for (int i = 0; i < ucount; i++) {
            binaryFile.write((char*)&TYPEUSHORT, sizeof(char));
            binaryFile.write((char*)&dataUSH[i], sizeof(unsigned short));
        }

        if (icount) {
            binaryFile.write((char*)&TYPEARRAYINT, sizeof(char));
            binaryFile.write((char*)&icount, sizeof(char));
        }
        for (int i = 0; i < icount; i++) {
            binaryFile.write((char*)&dataINT[i], sizeof(int));
        }

        binaryFile.close();
        cout << "Сериализация прошла успешно!\n";
    }
    else {
        cout << "Неудалось открыть файл!";
    }

    delete[]dataSH;
    delete[]dataUSH;
    delete[]dataINT;


    system("pause");

    return 0;
}

