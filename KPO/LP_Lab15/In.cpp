#include "In.h"
#include "Error.h"
#include "stdafx.h"

namespace In
{
	IN getin(wchar_t infile[])
	{
		IN input;
		input.size = 0; input.lines = 0; input.ignor = 0;
		int col = 0;

		unsigned char* text = new unsigned char[IN_MAX_LEN_TEXT]{};


		std::ifstream fin;
		fin.open(infile);
		if (fin.fail()) throw ERROR_THROW(110); // неуспешное открытие

		while (input.size < IN_MAX_LEN_TEXT)
		{
			char symb; fin.get(symb);//считываем символ из файла
			unsigned char x = symb;

			if (fin.eof())
			{
				text[input.size] = 0;
				break;
			}
			switch (input.code[x]) {
				case input.F: input.text = text;
							  throw ERROR_THROW_IN(111, input.lines, col);// запрещенный
							  break;
				case input.T: text[input.size] = x; // проверяем кодировку
							  input.size++;
							  col++;
							  break;
				case input.I: input.ignor++; // ignore
							  break;
				default: text[input.size] = input.code[x];
						 input.size++;
						 col++;
						 break;
			}
			if (x == IN_CODE_ENDL) // переход на новую строку
			{
				input.lines++;
				col = 0;
			}
		}
		if (!fin.eof())
			throw ERROR_THROW_IN(114, input.lines, col)
		input.text = text;
		
		return input;
	}
}