.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib user32.lib

ExitProcess PROTO : DWORD
.STACK 4096

.CONST

.DATA
dataSH0 DW 1
dataUSH0 DW 2
ARRINT DWORD 1, 3
.CODE

main PROC

	push -1
	call ExitProcess

main ENDP
end main