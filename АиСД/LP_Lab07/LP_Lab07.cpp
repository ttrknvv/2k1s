#include <iostream>
#include <Windows.h>

using namespace std;

#define MAXSIZE 255

int baseArray[MAXSIZE]; // последовательноть
int indexArray[MAXSIZE]; // индексы подпоследовательностей
int index[MAXSIZE]; // восстановленная подпоследовательность


int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int count = 0;
	cout << "Введите длину исходной последовательности: ";
	cin >> count;
	cout << "Введите исходную последовательность: ";
	for (int i = 0; i < count; i++) // ввод последовательности
	{
		cin >> baseArray[i];
		indexArray[i] = 1;
	}
	for (int i = 1; i < count; i++) // разбиение на подпоследовательности
	{
		for (int j = 0; j < i; j++)
		{
			if (baseArray[i] > baseArray[j])
			{
				if (indexArray[i] <= indexArray[j])
				{
					indexArray[i] = indexArray[j] + 1;
				}
			}
		}
	}
	int mid = 0;
	int size = 0;
	for (int i = 0; i < count; i++) // восстановление одной из подпоследовательностей
	{
		if (indexArray[i] > mid)
		{
			mid = indexArray[i];
			index[size++] = i;
		}
	}


	cout << "Количество чисел в наибольшей подпоследовательности: " << mid;
	cout << "\nПодпоследовательность наибольшей длины: ";
	for (int i = 0; i < mid; i++) // вывод
	{
		cout << baseArray[index[i]] << ' ';
	}
	cout << endl;
	system("pause");
	return 0;
}