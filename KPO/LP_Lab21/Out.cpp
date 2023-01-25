#include "Out.h"
#include "stdafx.h"

using namespace std;

namespace Out {
	OUT getout(wchar_t outfile[]) {
		OUT outf;
		outf.stream = new std::ofstream;
		outf.stream->open(outfile);
		if (outf.stream->fail())
			throw ERROR_THROW(113);
		wcscpy_s(outf.outfile, outfile);
		return outf;
	}
	void WriteOut(In::IN inf, OUT outf) {
		*outf.stream << inf.text;
	}
	void WriteError(OUT outf, Error::ERROR error, unsigned char* text) {
		if (outf.stream) {
			*outf.stream << text << " Строка: " << error.inext.line + 1 << " позиция: " << error.inext.col + 1;
		}
	}
	void CloseOut(OUT outf) {
		outf.stream->close();
		delete outf.stream;
	}

}