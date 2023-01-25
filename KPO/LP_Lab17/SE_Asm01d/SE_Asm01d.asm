.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib libucrt.lib
includelib "D:\2k1s\ œŒ\LP_Lab05\SE_Asm01\Debug\SE_Asm01e.lib"

EXTRN getmin : proc
EXTRN getmax : proc

GetStdHandle PROTO : DWORD
WriteConsoleA PROTO : DWORD, : DWORD, : DWORD, : DWORD, : DWORD
ExitProcess PROTO : DWORD

.CONST

.DATA
arr SDWORD 10, 2, 3, 4, 5, 6, 7, 8, 9, -4
str1CONSOLE DB 'getmin + getmax = ', 0
str2CONSOLE DB ?
sum SDWORD ?

.STACK 4096

.CODE

NumberInString PROC uses EBX ESI EDI ECX, strNUMBER : dword, number : dword
	mov edi, strNUMBER
	mov esi, 0
	mov eax, number
	cdq
	mov ebx, 10
	idiv ebx
	test eax, 80000000h
	jz plus
	neg eax
	neg edx
	mov cl, '-'
	mov [edi], cl
	inc edi
plus:
	push dx
	inc esi
	test eax, eax
	jz fin
	cdq
	idiv ebx
	jmp plus
fin:
	mov ecx, esi
write:
	pop bx
	add bl, '0'
	mov [edi], bl
	inc edi
	loop write

	mov [edi], byte ptr 0

	ret

NumberInString ENDP

Print PROC uses EAX EBX ESI EDI ECX, strCONSOLE : dword
	INVOKE GetStdHandle, -11
	mov esi, strCONSOLE
	mov edi, -1
count:
	inc edi
	cmp byte ptr [esi + edi], 0
	jne count
	INVOKE WriteConsoleA, eax, strCONSOLE, edi, 0, 0

	ret
Print ENDP

main PROC
	push lengthof arr
	push offset arr
	call getmin

	mov sum, EAX

	push lengthof arr
	push offset arr
	call getmax

	add sum, eax

	INVOKE Print, offset str1CONSOLE 
	INVOKE NumberInString, offset str2CONSOLE, sum
	INVOKE Print, offset str2CONSOLE

	push -1
	call ExitProcess

main ENDP

end main