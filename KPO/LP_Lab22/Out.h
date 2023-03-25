#pragma once
#include "stdafx.h"
#include "Parm.h"
#include "Error.h"
#include "In.h"

namespace Out
{
	struct OUT
	{
		wchar_t outfile[PARM_MAX_SIZE];
		std::ofstream* stream;
	};

	static const OUT INITOUT = { L"", NULL };
	Out::OUT getout(wchar_t outfile[]);
	void WriteOut(In::IN inf, OUT outf);
	void WriteError(OUT outf, Error::ERROR error, unsigned char* text);
	void CloseOut(OUT outf);
};