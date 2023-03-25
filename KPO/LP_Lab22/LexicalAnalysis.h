#pragma once

#include "In.h"
#include "Error.h"
#include "LT.h"
#include "IT.h"
#include "Parm.h"
#include "Log.h"
#include "Out.h"


namespace LexicalAnalysis
{
	struct TableLaI
	{
		LT::LexTable lextable;
		IT::IdTable idtable;
	};

	struct UsingType
	{
		bool UseInt = false;
		bool UseStr = false;
		bool UseLeftFigure = false;
		bool UseFunc = false;
		bool UseLeftCircle = false;
		bool UseRightFigure = false;
	};

	bool typeInt(char type[]);
	bool typeStr(char type[]);
	bool typeFunc(char type[]);
	bool typeDecl(char type[]);
	bool typeRet(char type[]);
	bool typePri(char type[]);
	bool typeMain(char type[]);
	bool typeLeftFigure(char type[]);
	bool typeRightFigure(char type[]);
	bool typeLeftCircle(char type[]);
	bool typeRightCircle(char type[]);
	bool typeSemicolon(char type[]);
	bool typeComma(char type[]);
	bool typePlus(char type[]);
	bool typeMinus(char type[]);
	bool typeStar(char type[]);
	bool typeDirSlash(char type[]);
	bool typeEquals(char type[]);
	bool typeStrlen(char type[]);
	bool typeSubstr(char type[]);
	bool typeLexSepar(char type[]);

	TableLaI LexicalAnalys(In::IN inputData, Out::OUT out);
	void inputLexema(int line, char lett);
	void inputLexemaForLiteral(int line, char lett, int liti, char lits[]);
	void inputLexemaForIDCopy(int line, char lett, char name[]);
	void printLT(LT::LexTable lextable, Out::OUT out);
	void printIT(IT::IdTable idtable, Out::OUT out);
}