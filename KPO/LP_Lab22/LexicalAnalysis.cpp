#include "LexicalAnalysis.h"
#include "FST.h"
#include <iomanip>
#include <fstream>

namespace LexicalAnalysis
{
	bool typeInt(char type[])
	{
		FST::FST typeInt(type, 8,
			FST::NODE(1, FST::RELATION('i', 1)),
			FST::NODE(1, FST::RELATION('n', 2)),
			FST::NODE(1, FST::RELATION('t', 3)),
			FST::NODE(1, FST::RELATION('e', 4)),
			FST::NODE(1, FST::RELATION('g', 5)),
			FST::NODE(1, FST::RELATION('e', 6)),
			FST::NODE(1, FST::RELATION('r', 7)),
			FST::NODE()
		);
		return FST::execute(typeInt);
	}
	bool typeStr(char type[])
	{
		FST::FST typeStr(type, 7,
			FST::NODE(1, FST::RELATION('s', 1)),
			FST::NODE(1, FST::RELATION('t', 2)),
			FST::NODE(1, FST::RELATION('r', 3)),
			FST::NODE(1, FST::RELATION('i', 4)),
			FST::NODE(1, FST::RELATION('n', 5)),
			FST::NODE(1, FST::RELATION('g', 6)),
			FST::NODE()
		);
	return FST::execute(typeStr);
	}
	bool typeFunc(char type[])
	{
		FST::FST typeFunc(type, 9,
			FST::NODE(1, FST::RELATION('f', 1)),
			FST::NODE(1, FST::RELATION('u', 2)),
			FST::NODE(1, FST::RELATION('n', 3)),
			FST::NODE(1, FST::RELATION('c', 4)),
			FST::NODE(1, FST::RELATION('t', 5)),
			FST::NODE(1, FST::RELATION('i', 6)),
			FST::NODE(1, FST::RELATION('o', 7)),
			FST::NODE(1, FST::RELATION('n', 8)),
			FST::NODE()
		);
		return FST::execute(typeFunc);
	}
	bool typeDecl(char type[])
	{
		FST::FST typeDecl(type, 8,
			FST::NODE(1, FST::RELATION('d', 1)),
			FST::NODE(1, FST::RELATION('e', 2)),
			FST::NODE(1, FST::RELATION('c', 3)),
			FST::NODE(1, FST::RELATION('l', 4)),
			FST::NODE(1, FST::RELATION('a', 5)),
			FST::NODE(1, FST::RELATION('r', 6)),
			FST::NODE(1, FST::RELATION('e', 7)),
			FST::NODE()
		);
		return FST::execute(typeDecl);
	}
	bool typeRet(char type[])
	{
		FST::FST typeRet(type, 7,
			FST::NODE(1, FST::RELATION('r', 1)),
			FST::NODE(1, FST::RELATION('e', 2)),
			FST::NODE(1, FST::RELATION('t', 3)),
			FST::NODE(1, FST::RELATION('u', 4)),
			FST::NODE(1, FST::RELATION('r', 5)),
			FST::NODE(1, FST::RELATION('n', 6)),
			FST::NODE()
		);
		return FST::execute(typeRet);
	}
	bool typePri(char type[])
	{
		FST::FST typePri(type, 6,
			FST::NODE(1, FST::RELATION('p', 1)),
			FST::NODE(1, FST::RELATION('r', 2)),
			FST::NODE(1, FST::RELATION('i', 3)),
			FST::NODE(1, FST::RELATION('n', 4)),
			FST::NODE(1, FST::RELATION('t', 5)),
			FST::NODE()
		);
		return FST::execute(typePri);
	}
	bool typeMain(char type[])
	{
		FST::FST typeMain(type, 5,
			FST::NODE(1, FST::RELATION('m', 1)),
			FST::NODE(1, FST::RELATION('a', 2)),
			FST::NODE(1, FST::RELATION('i', 3)),
			FST::NODE(1, FST::RELATION('n', 4)),
			FST::NODE()
		);
		return FST::execute(typeMain);
	}
	bool typeLeftFigure(char type[])
	{
		FST::FST typeLeftFigure(type, 2,
			FST::NODE(1, FST::RELATION('{', 1)),
			FST::NODE()
		);
		return FST::execute(typeLeftFigure);
	}
	bool typeRightFigure(char type[])
	{
		FST::FST typeRightFigure(type, 2,
			FST::NODE(1, FST::RELATION('}', 1)),
			FST::NODE()
		);
		return FST::execute(typeRightFigure);
	}
	bool typeLeftCircle(char type[])
	{
		FST::FST typeLeftCircle(type, 2,
			FST::NODE(1, FST::RELATION('(', 1)),
			FST::NODE()
		);
		return FST::execute(typeLeftCircle);
	}
	bool typeRightCircle(char type[])
	{
		FST::FST typeRightCircle(type, 2,
			FST::NODE(1, FST::RELATION(')', 1)),
			FST::NODE()
		);
		return FST::execute(typeRightCircle);
	}
	bool typeSemicolon(char type[])
	{
		FST::FST typeSemicolon(type, 2,
			FST::NODE(1, FST::RELATION(';', 1)),
			FST::NODE()
		);
		return FST::execute(typeSemicolon);
	}
	bool typeComma(char type[])
	{
		FST::FST typeComma(type, 2,
			FST::NODE(1, FST::RELATION(',', 1)),
			FST::NODE()
		);
		return FST::execute(typeComma);
	}
	bool typePlus(char type[])
	{
		FST::FST typePlus(type, 2,
			FST::NODE(1, FST::RELATION('+', 1)),
			FST::NODE()
		);
		return FST::execute(typePlus);
	}
	bool typeMinus(char type[])
	{
		FST::FST typeMinus(type, 2,
			FST::NODE(1, FST::RELATION('-', 1)),
			FST::NODE()
		);
		return FST::execute(typeMinus);
	}
	bool typeStar(char type[])
	{
		FST::FST typeStar(type, 2,
			FST::NODE(1, FST::RELATION('*', 1)),
			FST::NODE()
		);
		return FST::execute(typeStar);
	}
	bool typeDirSlash(char type[])
	{
		FST::FST typeDirSlash(type, 2,
			FST::NODE(1, FST::RELATION('/', 1)),
			FST::NODE()
		);
		return FST::execute(typeDirSlash);
	}
	bool typeEquals(char type[])
	{
		FST::FST typeEquals(type, 2,
			FST::NODE(1, FST::RELATION('=', 1)),
			FST::NODE()
		);
		return FST::execute(typeEquals);
	}
	bool typeStrlen(char type[])
	{
		FST::FST typeStrlen(type, 7,
			FST::NODE(1, FST::RELATION('s', 1)),
			FST::NODE(1, FST::RELATION('t', 2)),
			FST::NODE(1, FST::RELATION('r', 3)),
			FST::NODE(1, FST::RELATION('l', 4)),
			FST::NODE(1, FST::RELATION('e', 5)),
			FST::NODE(1, FST::RELATION('n', 6)),
			FST::NODE()
		);
		return FST::execute(typeStrlen);
	}
	bool typeSubstr(char type[])
	{
		FST::FST typeSubstr(type, 7,
			FST::NODE(1, FST::RELATION('s', 1)),
			FST::NODE(1, FST::RELATION('u', 2)),
			FST::NODE(1, FST::RELATION('b', 3)),
			FST::NODE(1, FST::RELATION('s', 4)),
			FST::NODE(1, FST::RELATION('t', 5)),
			FST::NODE(1, FST::RELATION('r', 6)),
			FST::NODE()
		);
		return FST::execute(typeSubstr);
	}
	bool typeID(char type[])
	{
		FST::FST typeID(type, 2,
			FST::NODE(52, FST::RELATION('a', 0), FST::RELATION('a', 1), FST::RELATION('b', 0), FST::RELATION('b', 1),
				FST::RELATION('c', 0), FST::RELATION('c', 1), FST::RELATION('d', 0), FST::RELATION('d', 1),
				FST::RELATION('e', 0), FST::RELATION('e', 1), FST::RELATION('f', 0), FST::RELATION('f', 1),
				FST::RELATION('g', 0), FST::RELATION('g', 1), FST::RELATION('h', 0), FST::RELATION('h', 1),
				FST::RELATION('i', 0), FST::RELATION('i', 1), FST::RELATION('j', 0), FST::RELATION('j', 1),
				FST::RELATION('k', 0), FST::RELATION('k', 1), FST::RELATION('l', 0), FST::RELATION('l', 1),
				FST::RELATION('m', 0), FST::RELATION('m', 1), FST::RELATION('n', 0), FST::RELATION('n', 1),
				FST::RELATION('o', 0), FST::RELATION('o', 1), FST::RELATION('p', 0), FST::RELATION('p', 1),
				FST::RELATION('q', 0), FST::RELATION('q', 1), FST::RELATION('r', 0), FST::RELATION('r', 1),
				FST::RELATION('s', 0), FST::RELATION('s', 1), FST::RELATION('t', 0), FST::RELATION('t', 1),
				FST::RELATION('u', 0), FST::RELATION('u', 1), FST::RELATION('v', 0), FST::RELATION('v', 1),
				FST::RELATION('w', 0), FST::RELATION('w', 1), FST::RELATION('x', 0), FST::RELATION('x', 1),
				FST::RELATION('y', 0), FST::RELATION('y', 1), FST::RELATION('z', 0), FST::RELATION('z', 1)),
			FST::NODE()
		);
		return FST::execute(typeID);
	}
	bool typeLitInt(char type[])
	{
		FST::FST typeLitInt(type, 2,
			FST::NODE(20, FST::RELATION('1', 0), FST::RELATION('1', 1), FST::RELATION('2', 0), FST::RELATION('2', 1),
				FST::RELATION('3', 0), FST::RELATION('3', 1), FST::RELATION('4', 0), FST::RELATION('4', 1),
				FST::RELATION('5', 0), FST::RELATION('5', 1), FST::RELATION('6', 0), FST::RELATION('6', 1),
				FST::RELATION('7', 0), FST::RELATION('7', 1), FST::RELATION('8', 0), FST::RELATION('8', 1),
				FST::RELATION('9', 0), FST::RELATION('9', 1), FST::RELATION('0', 0), FST::RELATION('0', 1)),
			FST::NODE()
		);
		return FST::execute(typeLitInt);
	}
	bool typeLitStr(char type[])
	{
		FST::FST typeLitStr(type, 4,
			FST::NODE(1, FST::RELATION('\'', 1)),
			FST::NODE(222, FST::RELATION(' ', 1), FST::RELATION(' ', 2), FST::RELATION('1', 1), FST::RELATION('1', 2), FST::RELATION('2', 1), FST::RELATION('2', 2), // 6
				FST::RELATION('3', 1), FST::RELATION('3', 2), FST::RELATION('4', 1), FST::RELATION('4', 2),
				FST::RELATION('5', 1), FST::RELATION('5', 2), FST::RELATION('6', 1), FST::RELATION('6', 2),
				FST::RELATION('7', 1), FST::RELATION('7', 2), FST::RELATION('8', 1), FST::RELATION('8', 2),
				FST::RELATION('9', 1), FST::RELATION('9', 2), FST::RELATION('0', 1), FST::RELATION('0', 2), 
				FST::RELATION('a', 1), FST::RELATION('a', 2), FST::RELATION('b', 1), FST::RELATION('b', 2),
				FST::RELATION('c', 1), FST::RELATION('c', 2), FST::RELATION('d', 1), FST::RELATION('d', 2),
				FST::RELATION('e', 1), FST::RELATION('e', 2), FST::RELATION('f', 1), FST::RELATION('f', 2),
				FST::RELATION('g', 1), FST::RELATION('g', 2), FST::RELATION('h', 1), FST::RELATION('h', 2),
				FST::RELATION('i', 1), FST::RELATION('i', 2), FST::RELATION('j', 1), FST::RELATION('j', 2),
				FST::RELATION('k', 1), FST::RELATION('k', 2), FST::RELATION('l', 1), FST::RELATION('l', 2),
				FST::RELATION('m', 1), FST::RELATION('m', 2), FST::RELATION('n', 1), FST::RELATION('n', 2),
				FST::RELATION('o', 1), FST::RELATION('o', 2), FST::RELATION('p', 1), FST::RELATION('p', 2),
				FST::RELATION('q', 1), FST::RELATION('q', 2), FST::RELATION('r', 1), FST::RELATION('r', 2),
				FST::RELATION('s', 1), FST::RELATION('s', 2), FST::RELATION('t', 1), FST::RELATION('t', 2),
				FST::RELATION('u', 1), FST::RELATION('u', 2), FST::RELATION('v', 1), FST::RELATION('v', 2),
				FST::RELATION('w', 1), FST::RELATION('w', 2), FST::RELATION('x', 1), FST::RELATION('x', 2),
				FST::RELATION('y', 1), FST::RELATION('y', 2), FST::RELATION('z', 1), FST::RELATION('z', 2),
				FST::RELATION('+', 1), FST::RELATION('+', 2), FST::RELATION('-', 1), FST::RELATION('-', 2),
				FST::RELATION(')', 1), FST::RELATION(')', 2), FST::RELATION('(', 1), FST::RELATION('(', 2),
				FST::RELATION('*', 1), FST::RELATION('*', 2), FST::RELATION('&', 1), FST::RELATION('&', 2),
				FST::RELATION('^', 1), FST::RELATION('^', 2), FST::RELATION('%', 1), FST::RELATION('%', 2),
				FST::RELATION('$', 1), FST::RELATION('$', 2), FST::RELATION('#', 1), FST::RELATION('#', 2),
				FST::RELATION('@', 1), FST::RELATION('@', 2), FST::RELATION('!', 1), FST::RELATION('!', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION(';', 1), FST::RELATION(';', 2),
				FST::RELATION('?', 1), FST::RELATION('?', 2), FST::RELATION('A', 1), FST::RELATION('A', 2),
				FST::RELATION('B', 1), FST::RELATION('B', 2), FST::RELATION('C', 1), FST::RELATION('C', 2), // 26 * 4
				FST::RELATION('D', 1), FST::RELATION('D', 2), // 2
				FST::RELATION('E', 1), FST::RELATION('E', 2), FST::RELATION('F', 1), FST::RELATION('F', 2),
				FST::RELATION('G', 1), FST::RELATION('G', 2), FST::RELATION('H', 1), FST::RELATION('H', 2),
				FST::RELATION('I', 1), FST::RELATION('I', 2), FST::RELATION('J', 1), FST::RELATION('J', 2),
				FST::RELATION('K', 1), FST::RELATION('K', 2), FST::RELATION('L', 1), FST::RELATION('L', 2),
				FST::RELATION('M', 1), FST::RELATION('M', 2), FST::RELATION('N', 1), FST::RELATION('N', 2),
				FST::RELATION('O', 1), FST::RELATION('O', 2), FST::RELATION('P', 1), FST::RELATION('P', 2),
				FST::RELATION('Q', 1), FST::RELATION('Q', 2), FST::RELATION('R', 1), FST::RELATION('R', 2),
				FST::RELATION('S', 1), FST::RELATION('S', 2), FST::RELATION('T', 1), FST::RELATION('T', 2),
				FST::RELATION('U', 1), FST::RELATION('U', 2), FST::RELATION('V', 1), FST::RELATION('V', 2),
				FST::RELATION('W', 1), FST::RELATION('W', 2), FST::RELATION('X', 1), FST::RELATION('X', 2),
				FST::RELATION('Y', 1), FST::RELATION('Y', 2), FST::RELATION('Z', 1), FST::RELATION('Z', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2), // 27 * 4
				FST::RELATION('�', 1), FST::RELATION('�', 2), // 2
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2), FST::RELATION('�', 1), FST::RELATION('�', 2),
				FST::RELATION('�', 1), FST::RELATION('�', 2)),
			FST::NODE(1, FST::RELATION('\'', 3)),
			FST::NODE()
		);
		return FST::execute(typeLitStr);
	}
	bool typeLexSepar(char type[])
	{
		FST::FST typeLitSepar(type, 2,
			FST::NODE(20, FST::RELATION('|', 1)),
			FST::NODE()
		);
		return FST::execute(typeLitSepar);
	}

	LT::LexTable lextable = LT::Create(LT_MAXSIZE - 1);
	IT::IdTable idtable = IT::Create(TI_MAXSIZE - 1);

	void LexicalAnalysis(In::IN inputData, Out::OUT out)
	{
		UsingType type;
		char *pickWord = new char[255]{};
		char id[5];
		char nameFunc[ID_MAXSIZE]{};
		int line = 0;
		int size = 0;
		int col = 0;
		int litCount = 0;

		for (int i = 0; i < inputData.size; i++)
		{
			switch (inputData.text[i])
			{
				case '\'': pickWord[size++] = inputData.text[i++]; 
						   while(inputData.text[i] != '\'')
						   {
								pickWord[size++] = inputData.text[i++];
						   }
						   pickWord[size++] = '\''; i++;
						   if (typeLitStr(pickWord))
						   {
							   char str[255];
							   strcpy_s(str, &pickWord[1]);
							   str[size - 2] = '\0';
							   if (IT::findLiteralStr(idtable, str) == TI_NULLIDX)
							   {
								   IT::Entry stroke;
								   char a[3]{};
								   char b[5] = "L";
								   inputLexema(line, LEX_LITERAL);
								   _itoa_s(litCount++, a, 10);
								   strcat_s(b, a);
								   strcpy_s(stroke.id, b);
								   strcpy_s(stroke.nameFunc, nameFunc);
								   stroke.idxfirstLE = lextable.size - 1;
								   stroke.idtype = IT::IDTYPE::L;
								   stroke.iddatatype = IT::IDDATATYPE::STR;
								   strcpy_s(stroke.value.vstr->str, str);
								   stroke.value.vstr->len = size - 2;
								   IT::Add(idtable, stroke);
							   }
							   else
							   {
								   inputLexemaForLiteral(line, LEX_LITERAL, 0, str);
							   }							   
						   }
						   else
						   {
							   throw ERROR_THROW_IN(117, line, col + 1);;
						   }
						   memset(pickWord, '\0', strlen(pickWord));
						   size = 0;
						   break;
				case ' ': if (pickWord == "") break;
						  if(typeInt(pickWord))
						  {
							  inputLexema(line, LEX_INTEGER);
							  type.UseInt = true;
							  type.UseStr = false;
						  }
						  else if (typeMain(pickWord))
						  {
							  inputLexema(line, LEX_MAIN);
							  strcpy_s(nameFunc, pickWord);
							  type.UseFunc = true;
						  }
						  else if (typeStr(pickWord))
						  {
							  inputLexema(line, LEX_STRING);
							  type.UseStr = true;
							  type.UseInt = false;
						  }
						  else if (typeFunc(pickWord))
						  {
							  inputLexema(line, LEX_FUNCTION);
							  type.UseFunc = true;
						  }
						  else if (typeDecl(pickWord))
						  {
							  inputLexema(line, LEX_DECLARE);
						  }
						  else if (typeRet(pickWord))
						  {
							  inputLexema(line, LEX_RETURN);
						  }
						  else if (typePri(pickWord))
						  {
							  inputLexema(line, LEX_PRINT);
						  }
						  else if (typeMain(pickWord))
						  {
							  inputLexema(line, LEX_MAIN);
						  }
						  else if (typeLeftFigure(pickWord))
						  {
							  inputLexema(line, LEX_LEFTBRACE);
							  type.UseLeftFigure = true;
							  type.UseRightFigure = false;
							  type.UseInt = false;
							  type.UseStr = false;
							  type.UseFunc = false;
						  }
						  else if (typeRightFigure(pickWord))
						  {
							  inputLexema(line, LEX_BRACELET);
							  type.UseRightFigure = true;
							  type.UseLeftFigure = false;
							  type.UseInt = false;
							  type.UseStr = false;
							  type.UseFunc = false;
						  }
						  else if (typeLeftCircle(pickWord))
						  {
							  inputLexema(line, LEX_LEFTTHESIS);
							  type.UseLeftCircle = true;
							  type.UseInt = false;
							  type.UseStr = false;
							  type.UseFunc = false;
						  }
						  else if (typeRightCircle(pickWord))
						  {
							  inputLexema(line, LEX_RIGHTTHESIS);
							  type.UseLeftCircle = false;
							  type.UseInt = false;
							  type.UseStr = false;
							  type.UseFunc = false;
						  }
						  else if (typeSemicolon(pickWord))
						  {
							  inputLexema(line, LEX_SEMICOLON);
							  type.UseStr = false;
							  type.UseInt = false;
						  }
						  else if (typeComma(pickWord))
						  {
							  inputLexema(line, LEX_COMMA);
						  }
						  else if (typePlus(pickWord))
						  {
							  inputLexema(line, LEX_PLUS);
						  }
						  else if (typeMinus(pickWord))
						  {
							  inputLexema(line, LEX_MINUS);
						  }
						  else if (typeStar(pickWord))
						  {
							  inputLexema(line, LEX_STAR);
						  }
						  else if (typeDirSlash(pickWord))
						  {
							  inputLexema(line, LEX_DIRSLASH);
						  }
						  else if (typeEquals(pickWord))
						  {
							  inputLexema(line, LEX_EQUALS);
						  }
						  else if (typeStrlen(pickWord))
						  {
							  inputLexema(line, LEX_FUNCTION);
						  }
						  else if (typeSubstr(pickWord))
						  {
							  inputLexema(line, LEX_FUNCTION);
						  }
						  else if (typeLitInt(pickWord))
						  {
							  if (IT::findLiteralInt(idtable, atoi(pickWord)) == TI_NULLIDX)
							  {
								  inputLexema(line, LEX_LITERAL);
								  IT::Entry stroke;
								  char a[3]{};
								  char b[4] = "L";
								  _itoa_s(litCount++, a, 10);
								  strcat_s(b, a);
								  strcpy_s(stroke.id, b);
								  strcpy_s(stroke.nameFunc, nameFunc);
								  stroke.idxfirstLE = lextable.size - 1;
								  stroke.idtype = IT::IDTYPE::L;
								  stroke.iddatatype = IT::IDDATATYPE::INT;
								  stroke.value.vint = atoi(pickWord);
								  IT::Add(idtable, stroke);
							  }
							  else
							  {
								  inputLexemaForLiteral(line, LEX_LITERAL, atoi(pickWord), NULL);
							  }
						  }
						  else if (typeID(pickWord))
						  {
							  IT::Entry stroke;
							  strcpy_s(stroke.id, pickWord);
							  stroke.idxfirstLE = lextable.size;
							  if (type.UseFunc && type.UseInt && !type.UseLeftCircle)
							  {
								  stroke.idtype = IT::IDTYPE::F;
								  stroke.iddatatype = IT::IDDATATYPE::INT;		  
								  strcpy_s(nameFunc, pickWord);
							  }
							  else if (type.UseFunc && type.UseStr && !type.UseLeftCircle)
							  {
								  stroke.idtype = IT::IDTYPE::F;
								  stroke.iddatatype = IT::IDDATATYPE::STR;
								  strcpy_s(nameFunc, pickWord);
							  }
							  else if (type.UseLeftCircle && type.UseStr && !type.UseFunc)
							  {
								  stroke.idtype = IT::IDTYPE::P;
								  stroke.iddatatype = IT::IDDATATYPE::STR;
								  strcpy_s(stroke.nameFunc, nameFunc);
							  }
							  else if (type.UseLeftCircle && type.UseInt && !type.UseFunc)
							  {
								  stroke.idtype = IT::IDTYPE::P;
								  stroke.iddatatype = IT::IDDATATYPE::INT;
								  strcpy_s(stroke.nameFunc, nameFunc);
							  }
							  else if (type.UseStr && !type.UseFunc && !type.UseLeftCircle)
							  {
								  stroke.idtype = IT::IDTYPE::V;
								  stroke.iddatatype = IT::IDDATATYPE::STR;
							  }
							  else if (type.UseInt && !type.UseFunc && !type.UseLeftCircle)
							  {
								  stroke.idtype = IT::IDTYPE::V;
								  stroke.iddatatype = IT::IDDATATYPE::INT;
							  }
							  else if (type.UseLeftFigure && !type.UseRightFigure)
							  {
								  int id = IT::IsId(idtable, pickWord);
								  if (id != TI_NULLIDX)
								  {
									  stroke.idtype = idtable.table[id].idtype;
									  stroke.iddatatype = idtable.table[id].iddatatype;
								  }
							  }
							  strcpy_s(stroke.nameFunc, nameFunc);
							  if (IT::findID(idtable, pickWord, nameFunc) == TI_NULLIDX)
							  {
								  IT::Add(idtable, stroke);
							  }
							  inputLexemaForIDCopy(line, LEX_ID, pickWord);
						  }
						  else if(typeLexSepar(pickWord))
						  {
								inputLexema(line, LEX_SEPARATOR);
								col = 0;
								line++;
						  }
						  else
						  {
								throw ERROR_THROW_IN(117, line, col + 1);
						  }
						  memset(pickWord, '\0', strlen(pickWord));
						  size = 0;

						  break;
				default: pickWord[size++] = inputData.text[i];
						 col++;
						 break;
			}
		}
		if (!out.stream)
		{
			throw ERROR_THROW(113)
		}
		*out.stream << "\n\n";
		for (int i = 0; i < lextable.size; i++)
		{
			*out.stream << lextable.table[i].lexema�;
		}
		*out.stream << "\n\n�������" << " ------ " << "����� ������" << " ------ " << "������\n";
		for (int i = 0; i < lextable.size; i++)
		{
			if (lextable.table[i].lexema�[0] == '\n')
			{
				*out.stream << std::setw(5) << '|' << std::setw(15) << lextable.table[i].sn
					<< std::setw(15) << lextable.table[i].idxTI << "\n";
				continue;
			}
			*out.stream << std::setw(5) << lextable.table[i].lexema� << std::setw(15) << lextable.table[i].sn
				<< std::setw(15) << lextable.table[i].idxTI << "\n";
		}
		*out.stream << "�������������" << " ------ " << " ��� ������ " << " ------ "
			<< "��� �������." << " ------ " << "��������" << " ------ " << "������ � ������� ������" << " ------ ��� �������\n";
		for (int i = 0; i < idtable.size; i++)
		{
			if (idtable.table[i].iddatatype == IT::IDDATATYPE::INT)
			{
				if (idtable.table[i].idtype == IT::IDTYPE::F)
				{
					*out.stream << std::setw(8) << idtable.table[i].id << std::setw(20) << "INT"
						<< std::setw(23) << "FUNCTION" << std::setw(15) << 0
						<< std::setw(18) << idtable.table[i].idxfirstLE << std::setw(30) << idtable.table[i].nameFunc << "\n";
				}
				else if(idtable.table[i].idtype == IT::IDTYPE::L)
				{
					*out.stream << std::setw(8) << idtable.table[i].id << std::setw(20) << "INT"
						<< std::setw(23) << "LITERAL" << std::setw(15) << idtable.table[i].value.vint
						<< std::setw(18) << idtable.table[i].idxfirstLE << "\n";
				}
				else if(idtable.table[i].idtype == IT::IDTYPE::P)
				{
					*out.stream << std::setw(8) << idtable.table[i].id << std::setw(20) << "INT"
						<< std::setw(23) << "PARAMETR" << std::setw(15) << 0
						<< std::setw(18) << idtable.table[i].idxfirstLE << std::setw(30) << idtable.table[i].nameFunc << "\n";
				}
				else if (idtable.table[i].idtype == IT::IDTYPE::V)
				{
					*out.stream << std::setw(8) << idtable.table[i].id << std::setw(20) << "INT"
						<< std::setw(23) << "VARIABLE" << std::setw(15) << 0
						<< std::setw(18) << idtable.table[i].idxfirstLE << std::setw(30) << idtable.table[i].nameFunc << "\n";
				}
			}
			else if (idtable.table[i].iddatatype == IT::IDDATATYPE::STR)
			{
				if (idtable.table[i].idtype == IT::IDTYPE::F)
				{
					*out.stream << std::setw(8) << idtable.table[i].id << std::setw(20) << "STR"
						<< std::setw(23) << "FUNCTION" << std::setw(15) << 0
						<< std::setw(18) << idtable.table[i].idxfirstLE << std::setw(30) << idtable.table[i].nameFunc << "\n";
				}
				else if (idtable.table[i].idtype == IT::IDTYPE::L)
				{
					*out.stream << std::setw(8) << idtable.table[i].id << std::setw(20) << "STR"
						<< std::setw(23) << "LITERAL" << std::setw(20) << idtable.table[i].value.vstr->str
						<< std::setw(13) << idtable.table[i].idxfirstLE << "\n";
				}
				else if (idtable.table[i].idtype == IT::IDTYPE::P)
				{
					*out.stream << std::setw(8) << idtable.table[i].id << std::setw(20) << "STR"
						<< std::setw(23) << "PARAMETR" << std::setw(15) << 0
						<< std::setw(18) << idtable.table[i].idxfirstLE << std::setw(30) << idtable.table[i].nameFunc << "\n";
				}
				else if (idtable.table[i].idtype == IT::IDTYPE::V)
				{
					*out.stream << std::setw(8) << idtable.table[i].id << std::setw(20) << "STR"
						<< std::setw(23) << "VARIABLE" << std::setw(15) << 0
						<< std::setw(18) << idtable.table[i].idxfirstLE << std::setw(30) << idtable.table[i].nameFunc << "\n";
				}
			}
				
			
		}
		delete[]pickWord;
	}
	void inputLexema(int line, char lett)
	{
		LT::Entry stroke;
		memset(stroke.lexema�, '\0', sizeof(stroke.lexema�));
		stroke.sn = line;
		stroke.lexema�[0] = lett;
		stroke.lexema�[1] = '\0';
		if (lett != LEX_ID && lett != LEX_LITERAL)
		{
			stroke.idxTI = LI_TI_NULLIDX;
		}
		else
		{
			stroke.idxTI = idtable.size;
		}
		LT::Add(lextable, stroke);
	}
	void inputLexemaForLiteral(int line, char lett, int liti, char lits[])
	{
		LT::Entry stroke;
		memset(stroke.lexema�, '\0', sizeof(stroke.lexema�));
		stroke.sn = line;
		stroke.lexema�[0] = lett;
		stroke.lexema�[1] = '\0';
		if (lett != LEX_ID && lett != LEX_LITERAL)
		{
			stroke.idxTI = LI_TI_NULLIDX;
		}
		else
		{
			if (lits == NULL)
			{
				stroke.idxTI = IT::findLiteralInt(idtable, liti);
			}
			else
			{
				stroke.idxTI = IT::findLiteralStr(idtable, lits);
			}
		}
		LT::Add(lextable, stroke);
	}
	void inputLexemaForIDCopy(int line, char lett, char name[])
	{
		LT::Entry stroke;
		memset(stroke.lexema�, '\0', sizeof(stroke.lexema�));
		stroke.sn = line;
		stroke.lexema�[0] = lett;
		stroke.lexema�[1] = '\0';

		stroke.idxTI = IT::IsId(idtable, name);
		LT::Add(lextable, stroke);
	}
}