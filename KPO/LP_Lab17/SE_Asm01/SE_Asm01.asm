.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib user32.lib

ExitProcess PROTO : DWORD

.STACK 4096

.CONST

.DATA
ARRAY SDWORD -3, 2, 8, 1, 4, 2, 6, 1, 1, 1
sizeARRAY DWORD 10

.CODE

getmin PROC uses EBX ESI EDI ECX ARR : dword, sizeARR : dword ; поиск минимального
	
	mov EBX, sizeARR
	imul EBX, type DWORD ; количество байт в EBX
	mov ESI, ARR ; указатель на начало массива
	mov EDI, 0 ; текущий элемент
	xor EAX, EAX
	mov EAX, [ESI] ; кладем первый элемент
findmin:
	add EDI, 4 ; добавляем 4 байта
	cmp EDI, EBX ; сравниваем количество пройденных с EBX
	je closePROC
	cmp EAX, [ESI + EDI] ; если левый больше правого
	jg inputMIN ; то
	jl findmin ; иначе
	

inputMIN:
	mov EAX, [ESI + EDI]
	jmp findmin
closePROC:	
	ret ; выход из процедуры
getmin ENDP


main PROC
	
	INVOKE getmin, offset ARRAY, sizeARRAY
	
	INVOKE ExitProcess, -1
main ENDP

end main
