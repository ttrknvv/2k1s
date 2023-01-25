#include "stdafx.h"
#include "IT.h"
#include "Error.h"

namespace IT
{
	IdTable Create(int size)
	{
		if (size > TI_MAXSIZE)
		{
			throw ERROR_THROW(116) 
		}
		IdTable tableID;
		tableID.table = new Entry[size];
		tableID.maxsize = size;
		tableID.size = NULL;
		return tableID;
	}
	void Add(IdTable& idtable, Entry entry)
	{
		if (idtable.size >= idtable.maxsize)
		{
			throw ERROR_THROW(116)
		}
		idtable.table[idtable.size++] = entry;
	}
	Entry GetEntry(IdTable& idtable, int n)
	{
		if (n >= idtable.maxsize)
		{
			throw ERROR_THROW(116)
		}
		return idtable.table[n];
	}
	int IsId(IdTable& idtable, char id[ID_MAXSIZE])
	{
		for (int i = idtable.size - 1; i >= 0; i--) 
		{
			if (!strcmp(idtable.table[i].id, id))
			{
				return i;
			}
		}
		return TI_NULLIDX;
	}
	void Delete(IdTable& idtable) 
	{
		delete[]idtable.table;
	}
	int findLiteralInt(IdTable& idtable, int value) 
	{
		for(int i = 0; i < idtable.size; i++)
		{
			if (idtable.table[i].idtype == IDTYPE::L && idtable.table[i].value.vint == value)
			{
				return i;
			}
		}
		return TI_NULLIDX;
	}
	int findLiteralStr(IdTable& idtable, char value[])
	{
		for (int i = 0; i < idtable.size; i++)
		{
			if (idtable.table[i].idtype == IDTYPE::L && strcmp(value, idtable.table[i].value.vstr->str) == 0)
			{
				return i;
			}
		}
		return TI_NULLIDX;
	}
	int findID(IdTable& idtable, char name[], char nameFunc[])
	{
		for (int i = 0; i < idtable.size; i++)
		{
			if (strcmp(idtable.table[i].nameFunc, nameFunc) == 0 && strcmp(idtable.table[i].id, name) == 0)
			{
				return i;
			}
			else if (strcmp(idtable.table[i].id, name) == 0 && idtable.table[i].idtype == IT::IDTYPE::F)
			{
				return i;
			}
		}
		return TI_NULLIDX;
	}
}