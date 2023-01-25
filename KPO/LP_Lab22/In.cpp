#include "In.h"
#include "Error.h"
#include "stdafx.h"

namespace In
{
	IN getin(wchar_t infile[])
	{
		setlocale(LC_ALL, "rus");
		IN input;
		input.size = 0; input.lines = 0; input.ignor = 0;
		int col = 0;

		unsigned char* text = new unsigned char[IN_MAX_LEN_TEXT] {};


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
		fin.close();
		input.text = text;
		input = changeTextForLexis(input);

		return input;
	}
	IN changeTextForLexis(IN inputData)
	{
		IN outTEXT;
		unsigned char *text = new unsigned char[IN_MAX_LEN_TEXT] {};
		int size = 0;
		int ignore = 0;
		
		for (int i = 0; i < inputData.size; i++)
		{
			switch (inputData.text[i])
			{
				case '\'': text[size++] = inputData.text[i++]; 
						   while(inputData.text[i] != '\'' && i < inputData.size)
						   {
								text[size++] = inputData.text[i++];
						   }
								text[size++] = '\'';
								break;
				case '\n': if(text[size - 1] == ' ')
						   {
								text[size++] = '|';
								text[size++] = IN_CODE_SPACE;
								break;
						   }
						   else
						   {
								text[size++] = IN_CODE_SPACE;
								text[size++] = '|';
								text[size++] = IN_CODE_SPACE;
						   }
						   break;
						   
				case '(':
				case ')':
				case '*':
				case '/':
				case '-':
				case '+':
				case '{':
				case '}':
				case '=':
				case ';':
				case ',': if(text[size - 1] == '|' || text[size - 1] == IN_CODE_SPACE)
						  {
							text[size++] = inputData.text[i];
							text[size++] = IN_CODE_SPACE;
							break;
						  }
						  text[size++] = IN_CODE_SPACE;
						  text[size++] = inputData.text[i];
						  text[size++] = IN_CODE_SPACE;
						  break;
				case IN_CODE_SPACE: if(text[size - 1] == IN_CODE_SPACE || text[size - 1] == '|')
									{
										ignore++;
										break;
									}
								    text[size++] = inputData.text[i];
								    break;
				default: text[size++] = inputData.text[i];
			}
		}
		outTEXT.ignor = inputData.ignor + ignore;
		outTEXT.lines = inputData.lines;
		outTEXT.size = size;
		outTEXT.text = text;
		return outTEXT;
	}
}