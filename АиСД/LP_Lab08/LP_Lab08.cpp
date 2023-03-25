#include <iostream>
#include <Windows.h>
#include <vector>

using namespace std;

#define SIZESUBJECT 10
#define NAMESIZE 255

struct Subject
{
	char nameSubject[255]{};
	int weight{};
	int price{};
	Subject *a[10]{};
	int size{};
} subjects[SIZESUBJECT]{};

struct Backpack
{
	int maxweight;
	Subject subjects[SIZESUBJECT]{};
} backpack;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int count{};

	cout << "Введите объем рюкзака: "; cin >> backpack.maxweight; 
	cout << "Введите количество предметов: ";
	cin >> count;
	for (int i = 0; i < count; i++)
	{
		cout << "Введите имя " << i + 1 << " предмета: "; cin >> subjects[i].nameSubject;
		cout << "Введите его вес: "; cin >> subjects[i].weight;
		cout << "Введите его цену: "; cin >> subjects[i].price;
	}
	vector<vector<Subject>> Matrix(count + 1, vector<Subject>(backpack.maxweight));
	for (int i = 1; i < count + 1; i++)
	{
		for (int j = 0; j < backpack.maxweight; j++)
		{
			if (j + 1 >= subjects[i - 1].weight)
			{
				if (Matrix[i - 1][j].price < subjects[i - 1].price && j + 1 < subjects[i - 1].weight + Matrix[i - 1][j].weight)
				{
					Matrix[i][j].price = subjects[i - 1].price;
					Matrix[i][j].weight = subjects[i - 1].weight;
					Matrix[i][j].a[Matrix[i][j].size++] = &subjects[i - 1];
				}
				else
				{
					if (j + 1 >= Matrix[i - 1][j].weight + subjects[i - 1].weight)
					{
						Matrix[i][j] = Matrix[i - 1][j];
						Matrix[i][j].price = subjects[i - 1].price + Matrix[i - 1][j].price;
						Matrix[i][j].weight = subjects[i - 1].weight + Matrix[i - 1][j].weight;
						Matrix[i][j].a[Matrix[i][j].size++] = &subjects[i - 1];
					}
					else
					{
						int maxPrice{}, maxWeight{};
						for (int k = 0; k < i - 1; k++)
						{	
							if (j + 1 >= subjects[k].weight + subjects[i - 1].weight && maxPrice <= subjects[k].price + subjects[i - 1].price)
							{
								maxPrice = subjects[k].price + subjects[i - 1].price;
								maxWeight = subjects[k].weight + subjects[i - 1].weight; 
								if (maxWeight != subjects[k].weight)
								{
									Matrix[i][j].size = 0;
									Matrix[i][j].a[Matrix[i][j].size++] = &subjects[k];
									Matrix[i][j].a[Matrix[i][j].size++] = &subjects[i - 1];
								}
							}
							else if (j + 1 >= maxWeight + subjects[k].weight)
							{
								maxPrice += subjects[k].price;
								maxWeight += subjects[k].weight;
								Matrix[i][j].a[Matrix[i][j].size++] = &subjects[k];
							}
						}
						if (maxPrice < Matrix[i - 1][j].price)
						{
							Matrix[i][j] = Matrix[i - 1][j];
						}
						else
						{
							Matrix[i][j].price = maxPrice;
							Matrix[i][j].weight = maxWeight;
						}
					}				
				}
			}
			else
			{
				Matrix[i][j] = Matrix[i - 1][j];
			}
		}
	}
	int maxWeight{}, maxPrice2{};
	cout << "Предметы вошедшие в рюкзак: \n";
	for (int i = 0; i < Matrix[count][backpack.maxweight - 1].size; i++)
	{
		cout << "Название: " << Matrix[count][backpack.maxweight - 1].a[i]->nameSubject << endl;
		cout << "Стоимость: " << Matrix[count][backpack.maxweight - 1].a[i]->price << endl;
		cout << "Вес: " << Matrix[count][backpack.maxweight - 1].a[i]->weight << endl;
		maxWeight += Matrix[count][backpack.maxweight - 1].a[i]->weight;
		maxPrice2 += Matrix[count][backpack.maxweight - 1].a[i]->price;
	}
	cout << "Общий вес: " << maxWeight << endl;
	cout << "Общая стоимость: " << maxPrice2 << endl;
	system("pause");


	return 0;
}