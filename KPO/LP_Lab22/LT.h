#pragma once
#include <iostream>

#define LEXEMA_FIXSIZE 1 // фиксированный размер лексемы
#define LT_MAXSIZE 4096 // маскимальное количество строк в таблице лексем
#define LI_TI_NULLIDX 0xffffffff // нет элемента таблицы идентификаторов
#define LEX_INTEGER 't'
#define LEX_STRING 't'
#define LEX_ID 'i'
#define LEX_LITERAL 'l'
#define LEX_FUNCTION 'f'
#define LEX_DECLARE 'd'
#define LEX_RETURN 'r'
#define LEX_PRINT 'p'
#define LEX_SEMICOLON ';'
#define LEX_COMMA ','
#define LEX_LEFTBRACE '{'
#define LEX_BRACELET '}'
#define LEX_LEFTTHESIS '('
#define LEX_RIGHTTHESIS ')'
#define LEX_PLUS 'v'
#define LEX_MINUS 'v'
#define LEX_STAR 'v'
#define LEX_DIRSLASH 'v'
#define LEX_MAIN 'm'
#define LEX_EQUALS '='
#define LEX_SEPARATOR '\n'
#define LEX_MAIN 'm'

namespace LT
{
	struct Entry // строка таблицы лексем
	{
		char lexemaх[LEXEMA_FIXSIZE]{}; // лексема
		int sn = 0; // номер строки в исходном тексте
		int idxTI = 0; // индекс в таблице идентефикаторов или LT_TI_NULLIDX
	};

	struct LexTable // экземпл€р таблицы лексем
	{
		int maxsize = 0; // емкость таблицы лексем < LT_MAXSIZE
		int size = 0; // текущий размер таблицы лексем < maxsize
		Entry* table = NULL; // массив строк таблицы лексем
	};
	LexTable Create(int size); // создать таблицы лексем

	void Add(LexTable& lextable, Entry entry); // добавить строку в таблицу лексем
	
	Entry GetEntry(LexTable& lextable, int n); // получить строку из таблицы лексем

	void Delete(LexTable& lextable); // удалить таблицу лексем(освободить пам€ть)

}