#pragma once
#define ID_MAXSIZE 5 // максимальное количество символов в идентификаторе
#define TI_MAXSIZE 4096 // максимальное количество строк в таблице идентификаторов
#define  TI_INT_DEFAULT 0x00000000 // значение по умолчанию для типа uint32
#define TI_STR_DEFAULT 0x00 // значение по умолчанию для типа symbol
#define TI_NULLIDX 0Xffffffff // нет элемента таблицы идентификаторов
#define TI_STR_MAXSIZE 255

namespace IT // таблица идентификаторов
{
	enum IDDATATYPE {INT=1, STR=2}; // типы данных идентификаторов
	enum IDTYPE {V=1, F=2, P=3, L=4}; // типы иднтификаторов: переменная, функция, параметр, литерал

	struct Entry // строка таблицы идентификаторов
	{
		int idxfirstLE = 0; // индекс первой строки в таблице лексем
		char id[ID_MAXSIZE]{}; // идентификатор(отсекается до ID_MAXSIZE)
		char nameFunc[ID_MAXSIZE]{}; // имя функции
		IDDATATYPE iddatatype{}; // тип данных
		IDTYPE idtype{}; // тип идентификатораE
		union
		{
			int vint = 0;
			struct
			{
				char len{};
				char str[TI_STR_MAXSIZE - 1]{};
			} vstr[TI_STR_MAXSIZE];
		} value{};
	};
	struct IdTable
	{
		int maxsize;
		int size;
		Entry* table;
	};
	IdTable Create(int size);
	void Add(IdTable& idtable, Entry entry);
	Entry GetEntry(IdTable& idtable, int n);
	int IsId(IdTable& idtable, char id[ID_MAXSIZE]);
	void Delete(IdTable& idtable);
	int findLiteralInt(IdTable& idtable, int value);
	int findLiteralStr(IdTable& idtable, char value[]);
	int findID(IdTable& idtable, char name[], char nameFunc[]);
}