#include <locale>
#include <cwchar>

#include "stdafx.h"
#include "Error.h"
#include "Parm.h"
#include "In.h"
#include "Log.h"
#include "Out.h"



int _tmain(int argc, _TCHAR* argv[]) {
	setlocale(LC_ALL, "rus");
	Log::LOG log = Log::INITLOG;
	Out::OUT out = Out::INITOUT;
	In::IN in;
	try {
		Parm::PARM parm = Parm::getparm(argc, argv);
		log = Log::getlog(parm.log);
		out = Out::getout(parm.out);
		Log::WriteLine(log, (char*)"Тест:", (char*)" без ошибок", "");
		Log::WriteLine(log, (wchar_t*)L"Тест:", (wchar_t*)L" без ошибок", (wchar_t*)L"");
		Log::WriteLog(log);
		Log::WriteParm(log, parm);
		in = In::getin(parm.in);
		Log::WriteIn(log, in);
		Log::Close(log);
		Out::WriteOut(in, out);
		Out::CloseOut(out);
	}
	catch (Error::ERROR e) {
		Log::WriteError(log, e);
		Out::WriteError(out, e, in.text);
	}
	system("pause");
	return 0;
}