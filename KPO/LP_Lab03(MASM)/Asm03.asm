.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib user32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA
myBytes BYTE 10h, 20h, 30h, 40h
myWords WORD 8Ah, 3Bh, 44h, 5Fh, 99h
myDoubles DWORD 1, 2, 3, 4, 5, 6
myPointer DWORD myDoubles
myNumbers BYTE 2, 9, 2, 1, 10, 6, 0 ; массив 7-ми элементов
STR1 DB "Тараканов Никита Сергеевич, 2 курс, 4 группа", 0
STR2 DB "В массиве есть 0 элемент...", 0
STR3 DB "В массиве 0 элемента нет...", 0

.CODE

main PROC

ab:
	mov ESI, 0 ; 0
	mov EAX, [myDoubles + 1] ; 02000000
	mov EDX, [myDoubles + ESI] ; 00000001

cZad:
	xor EAX, EAX
	mov al, [myNumbers]
	add al, [myNumbers + 1]
	add al, [myNumbers + 2]
	add al, [myNumbers + 3]
	add al, [myNumbers + 4]
	add al, [myNumbers + 5]
	add al, [myNumbers + 6]

c2Zad:
	mov ECX, lengthof myNumbers ; начиная с последнего элемента
	mov EBX, 1

CYCLE:
	cmp [myNumbers + ECX - 1], 0
	je TRUE
	jne FALSE

TRUE:
	invoke MessageBoxA, 0, OFFSET STR2, OFFSET STR1, 20
	jmp ENDPROCESS

FALSE:
	loop CYCLE

FINISH:
	invoke MessageBoxA, 0, OFFSET STR3, OFFSET STR1, 20	

ENDPROCESS:
	push -1
	call ExitProcess

main ENDP
end main