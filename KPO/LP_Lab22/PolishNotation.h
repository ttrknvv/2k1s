#pragma once
#include "stdafx.h"
#include "LexicalAnalysis.h"
#include "LT.h"
#include "IT.h"

#define EXP1 28
#define EXP1 28
#define EXP1 28


namespace POL
{
	bool PolishNotation(int& lextable_pos, LT::LexTable& lextable, IT::IdTable& idtable);
	bool PolishStart(LT::LexTable& lextable, IT::IdTable& idtable);
}