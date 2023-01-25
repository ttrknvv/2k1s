#include "Parm.h"
#include "TCHAR.h"
#include "Error.h"

namespace Parm {
	PARM getparm(int argc, _TCHAR* argv[]) {
		PARM argument;
		bool in = false, log = false, out = false;
		for (int i = 0; i < argc; i++)
		{
			if (wcslen(argv[i]) > PARM_MAX_SIZE) {
				throw ERROR_THROW(104);
			}
			if (wcsstr(argv[i], PARM_IN)) // ищет вхождение -in в текущей строке
			{
				wcscpy_s(argument.in, argv[i] + wcslen(PARM_IN)); // копирует параметры после -in
				in = true; // найдено -in
			}
			if (wcsstr(argv[i], PARM_OUT))
			{
				wcscpy_s(argument.out, argv[i] + wcslen(PARM_OUT));
				out = true;
			}
			if (wcsstr(argv[i], PARM_LOG))
			{
				wcscpy_s(argument.log, argv[i] + wcslen(PARM_LOG));
				log = true;
			}
		}
		if (!in) {
			throw ERROR_THROW(100) //если не найдено параметра -in
		};
		if (!out)
		{
			wcscpy_s(argument.out, argument.in);
			wcscat_s(argument.out, PARM_OUT_DEFAULT_EXIT);
		}
		if (!log)
		{
			wcscpy_s(argument.log, argument.in);
			wcscat_s(argument.log, PARM_LOG_DEFAULT_EXIT);
		}
		return argument;
	}
}