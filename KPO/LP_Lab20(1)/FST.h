#pragma once
#include "stdafx.h"
namespace FST
{
	struct RELATION // ребро : символ -> вершина графа переходов КА
	{
		char symbol; // символ перехода
		short nnode; // номер смежной вершины
		RELATION(const char c = 0x00, short ns = NULL);
	};
	struct NODE // вершина графов переходов
	{
		short n_relation; // количество инцидентных вершин
		RELATION* relations; // инцидентные ребра
		NODE();
		NODE(short n, RELATION rel, ...);
	};
	struct FST // недетерминированный конечный автомат
	{
		const char* string; // цепочка( в конце 0х00)
		short position; // текущая позиция в цепочке
		short nstates; // количество состояний автомата
		NODE* nodes; // граф переходов 0 - начальное, nstates - 1 - конечное
		short* rstates; // возможные состояния автомата на данной позиции
		FST(const char* s, short ns, NODE n, ...);
	};
	bool step(FST& fst, short*& rstates);
	bool execute(FST& fst); // выполнить распознавание цепочки
}