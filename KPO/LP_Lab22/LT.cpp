#include "LT.h"
#include "Error.h"
#include "stdafx.h"

namespace LT
{
	LexTable Create(int size)
	{
		if (size > LT_MAXSIZE)
		{
			throw ERROR_THROW(115) // название?
		}
		LexTable tableLex;
		tableLex.table = new Entry[size];
		tableLex.maxsize = size;
		tableLex.size = NULL;
		return tableLex;
	}
	Entry GetEntry(LexTable& lextable, int n)
	{
		if (n > lextable.maxsize)
		{
			throw ERROR_THROW(115)
		}
		return lextable.table[n];
	}
	void Add(LexTable& lextable, Entry entry)
	{
		if (lextable.size >= lextable.maxsize)
		{
			throw ERROR_THROW(115)
		}
		lextable.table[lextable.size++] = entry;
	}
	void Delete(LexTable& lextable)
	{
		delete[]lextable.table;
	}
}