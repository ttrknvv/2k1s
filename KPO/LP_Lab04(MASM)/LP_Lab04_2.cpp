/*
* 13 вариант: Переменная: short;
*             беззнаковый целочисленный литерал (2 байта)
*/
#include <iostream>
#include <fstream>
#include <windows.h>

#define WAYTOBINARYFILE "D:/2k1s/КПО/LP_Lab04/LP_Lab04/LP_Lab04/Serialization.txt"
#define WAYTOASMFILE "D:/2k1s/КПО/LP_Lab04/LP_Lab04/LP_Lab04/Deserialization.asm"
#define HEADOFASMFILE ".586\n.MODEL FLAT, STDCALL\nincludelib kernel32.lib\nincludelib user32.lib\n\nExitProcess PROTO : DWORD\n.STACK 4096\n\n.CONST\n\n.DATA\n"
#define FOOTOFASMFILE "\n.CODE\n\nmain PROC\n\n\tpush -1\n\tcall ExitProcess\n\nmain ENDP\nend main"

const unsigned char TYPESHORT = 1;
const unsigned char TYPEUSHORT = 2;
const unsigned char TYPEARRAYINT = 3;

using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    short dataSH = 0;
    unsigned short dataUSH = 0;
    int dataINT = 0;
    char typeData;
    int iSH = 0, iUSH = 0, countARR = 0;

    ifstream binaryFile(WAYTOBINARYFILE, ios::binary);
    ofstream asmFile(WAYTOASMFILE);

    if (binaryFile.is_open() && asmFile.is_open()) {
        asmFile << HEADOFASMFILE;
        binaryFile.read((char*)&typeData, 1);

        while (!binaryFile.eof()) {
            switch (typeData) {
                case TYPESHORT: asmFile << "dataSH" << iSH++ << " DW ";
                                binaryFile.read((char*)&dataSH, sizeof(short));
                                asmFile << dataSH << "\n";
                                break;

                case TYPEUSHORT: asmFile << "dataUSH" << iUSH++ << " DW ";
                                binaryFile.read((char*)&dataUSH, sizeof(unsigned short));
                                asmFile << dataUSH << "\n";
                                break;

                case TYPEARRAYINT: asmFile << "ARRINT" << " DWORD ";
                                binaryFile.read((char*)&countARR, sizeof(char));
                                for (int i = 0; i < countARR; i++) {
                                    binaryFile.read((char*)&dataINT, sizeof(int));
                                    if (i == countARR - 1) {
                                        asmFile << dataINT;
                                        break;
                                    }
                                    asmFile << dataINT << ", ";
                                }
                                break;
            }
            binaryFile.read((char*)&typeData, 1);
        }

        asmFile << FOOTOFASMFILE;
        binaryFile.close();
        asmFile.close();
        cout << "Десериализация прошла успешно!\n";
    }
    else {
        cout << "Не удалось открыть файл!";
    }


    system("pause");
}