#include <iostream>
#include <map>
#include <queue>
#include <vector>
#include <Windows.h>
#include <string>

using namespace std;

struct TreeHaffman // дерево хаффмана
{
	char symbol;
	int frequence;
	TreeHaffman* left;
	TreeHaffman* right;
};

struct LowestPriority // приоритет для очереди
{
	bool operator ()(const TreeHaffman* l,const TreeHaffman* r) const {
		return l->frequence > r->frequence;
	}
};


TreeHaffman* GetCompleteNode(char symbol, int frequence, TreeHaffman* left, TreeHaffman* right); // получить структуру с символов и приоритетом
map <char, string> buildTree(string data); // построить дерево и получить значения битов
void encodeSymbol(TreeHaffman* base, string str, map<char, string>& huffmancode); // кодирование символов
void PrintTable(map <char, int>data, string base); // вывести таблицу встречаемости
void PrintCodes(map<char, string> base, string str); // вывести битовые последовательности
void PrintBaseInCodes(string base, map<char, string> codes); // вывести строку в формате битовой последовательности

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	string inputData; // исходнаяя строка
	getline(cin, inputData);

	map<char, string> codeSymbols = buildTree(inputData); // получение таблицы кодировок

	PrintCodes(codeSymbols, inputData); // вывести коды символов
	
	PrintBaseInCodes(inputData, codeSymbols); // вывести битовую последовательность строки

	system("pause");
	return 0;
}

map <char, string> buildTree(string data)
{
	map<char, int> frequence;
	for (int i = 0; i < data.length(); i++)
	{
		frequence[data[i]]++;
	}

	PrintTable(frequence, data);

	priority_queue<TreeHaffman*, vector<TreeHaffman*>, LowestPriority> queue; // очередь с приоритетом

	bool *check = new bool[255]; // исключение повторений
	for (int i = 0; i < data.size(); i++)
	{
		if (check[(unsigned char)data[i]]) 
		{
			queue.push(GetCompleteNode(data[i], frequence[data[i]], nullptr, nullptr));
		}
		check[(unsigned char)data[i]] = false;
	}
	delete[]check;

	while (queue.size() != 1) // до последнего элемента, который будет являться вершиной
	{
		TreeHaffman* left = queue.top();
		queue.pop();
		TreeHaffman* right = queue.top();
		queue.pop();
		int sum = left->frequence + right->frequence;
		queue.push(GetCompleteNode('\0', sum, left, right));
	}

	TreeHaffman* base = queue.top();
	queue.pop();

	map<char, string> code; // карта, которая будет хранить коды символов
	encodeSymbol(base, "", code);

	return code;
}
TreeHaffman* GetCompleteNode(char symbol, int frequence, TreeHaffman* left, TreeHaffman* right)
{
	TreeHaffman* tree = new TreeHaffman();

	tree->symbol = symbol;
	tree->frequence = frequence;
	tree->left = left;
	tree->right = right;

	return tree;
}
void encodeSymbol(TreeHaffman* base, string str, map<char, string>& huffmancode)
{
	if (base == nullptr)
	{
		return;
	}
	if (!base->left && !base->right)
	{
		huffmancode[base->symbol] = str;
	}
	encodeSymbol(base->left, str + "0", huffmancode);
	encodeSymbol(base->right, str + "1", huffmancode);
}
void PrintTable(map <char, int>data, string base)
{
	bool check[255];
	cout << "\nИсходное количество символов: " << base.length() << endl;
	for (int i = 0; i < base.length(); i++)
	{
		if (check[(unsigned char)base[i]]) {
			float procent = ((float)data[base[i]] / (float)base.length()) * 100.1;
			cout << "\'" << base[i] << "\'" << " : " << "Количество вхождений: " << data[base[i]]
				<< " ; Процент вхождений: " << procent << "%" << endl;
		}
		check[(unsigned char)base[i]] = false;
	}
}
void PrintCodes(map<char, string> base, string str)
{
	bool check[255];
	cout << "\nКоды символов: \n";
	for (int i = 0; i < str.length(); i++)
	{
		if (check[(unsigned char)str[i]]) {
			cout << "\'" << str[i] << "\'" << " : " << "" << base[str[i]] << endl;
		}
		check[(unsigned char)str[i]] = false;
	}
}
void PrintBaseInCodes(string base, map<char, string> codes)
{
	cout << "\nИсходная строка: " << base << endl << "Битовая последовательность: \n";
	for (int i = 0; i < base.length(); i++)
	{
		cout << codes[base[i]];
	}
	cout << endl;
}