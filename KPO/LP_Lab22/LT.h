#pragma once
#include <iostream>

#define LEXEMA_FIXSIZE 1 // ������������� ������ �������
#define LT_MAXSIZE 4096 // ������������ ���������� ����� � ������� ������
#define LI_TI_NULLIDX 0xffffffff // ��� �������� ������� ���������������
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
	struct Entry // ������ ������� ������
	{
		char lexema�[LEXEMA_FIXSIZE]{}; // �������
		int sn = 0; // ����� ������ � �������� ������
		int idxTI = 0; // ������ � ������� ��������������� ��� LT_TI_NULLIDX
	};

	struct LexTable // ��������� ������� ������
	{
		int maxsize = 0; // ������� ������� ������ < LT_MAXSIZE
		int size = 0; // ������� ������ ������� ������ < maxsize
		Entry* table = NULL; // ������ ����� ������� ������
	};
	LexTable Create(int size); // ������� ������� ������

	void Add(LexTable& lextable, Entry entry); // �������� ������ � ������� ������
	
	Entry GetEntry(LexTable& lextable, int n); // �������� ������ �� ������� ������

	void Delete(LexTable& lextable); // ������� ������� ������(���������� ������)

}