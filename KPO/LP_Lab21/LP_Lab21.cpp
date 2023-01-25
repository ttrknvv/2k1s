#include <iostream>
#include "stdafx.h"

#include "LexicalAnalysis.h"
#include "Error.h"
#include "Parm.h"
#include "In.h"
#include "Log.h"
#include "Out.h"
#include "GRB.h"
#include "MFST.h"
#include <stack>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	wchar_t b1[] = L"-in:D:\\2k1s\\КПО\\LP_Lab21\\222.txt";
	wchar_t b2[] = L"-out:D:\\2k1s\\КПО\\LP_Lab21\\out.txt";
	wchar_t b3[] = L"-log:D:\\2k1s\\КПО\\LP_Lab21\\log.txt";
	_TCHAR* a[] = { (wchar_t*)b1, (wchar_t*)b2, (wchar_t*)b3 }; // SE_Lab20 -in:D:\2k1s\КПО\LP_Lab20(1)\222.txt -out:D:\2k1s\КПО\LP_Lab20(1)\out.txt -log:D:\2k1s\КПО\LP_Lab20(1)\log.txt
	Log::LOG log = Log::INITLOG;
	Out::OUT out = Out::INITOUT;
	In::IN in;
	try {
		Parm::PARM parm = Parm::getparm(3, a); // проверка на ошибки
		log = Log::getlog(parm.log);
		out = Out::getout(parm.out);
		Log::WriteLine(log, (char*)"Тест:", (char*)" без ошибок", "");
		Log::WriteLine(log, (wchar_t*)L"Тест:", (wchar_t*)L" без ошибок", (wchar_t*)L"");
		Log::WriteLog(log);
		Log::WriteParm(log, parm);
		in = In::getin(parm.in);
		Log::WriteIn(log, in);
		Out::WriteOut(in, out);

		LexicalAnalysis::TableLaI table = LexicalAnalysis::LexicalAnalys(in, out);
		table.lextable.table[table.lextable.size].lexemaх[0] = '$';
		table.lextable.table[table.lextable.size].sn = table.lextable.table[table.lextable.size - 1].sn;
		table.lextable.size++;

		MFST_TRACE_START
		MFST::Mfst mfst(table, GRB::getGreibach());
		mfst.start();

		mfst.savededucation();
		mfst.printrules();

		Log::Close(log);
		Out::CloseOut(out);
	}
	catch (Error::ERROR e) {
		Log::WriteError(log, e);
		cout << e.message;
		//Out::WriteError(out, e, in.text);
	}
	system("pause");
	return 0;
}

