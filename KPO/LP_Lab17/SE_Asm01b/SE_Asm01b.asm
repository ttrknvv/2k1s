.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib "D:\2k1s\КПО\LP_Lab05\SE_Asm01\Debug\SE_Asm01_a.lib"

getmin PROTO : DWORD, : DWORD ; функции из статической библиотеки
getmax PROTO : DWORD, : DWORD
PrintConsole PROTO : DWORD, : DWORD
NumberInString PROTO : DWORD, : DWORD
Print PROTO : DWORD

ExitProcess PROTO : DWORD

.STACK 4096

.CONST

.DATA
ARRAY SDWORD 12, 2, 8, 1, 4, 2, 6, 1, 1, -2
sizeARRAY DWORD 10
strCONSOLE db 'getmax + getmin = ' , 0
strCONSOLE2 db ?
strTITLE db 'STATIC LIBRARY', 0
consoleHANDLE DD ?
sumMINandMAX SDWORD ?

.CODE

main PROC
	INVOKE getmin, offset ARRAY, sizeARRAY
	mov sumMINandMAX, eax
	INVOKE getmax, offset ARRAY, sizeARRAY
	add sumMINandMAX, eax
	INVOKE PrintConsole, offset strCONSOLE, offset strTITLE
	INVOKE NumberInString, offset strCONSOLE2, sumMINandMAX
	INVOKE Print, offset strCONSOLE2
	INVOKE ExitProcess, -1
main ENDP

end main
