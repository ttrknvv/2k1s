.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
SetConsoleTitleA PROTO : DWORD 
GetStdHandle PROTO : DWORD
WriteConsoleA PROTO : DWORD, : DWORD, : DWORD, :DWORD, : DWORD

.code
getmin PROC uses EBX ESI EDI ECX ARR : dword, sizeARR : dword ; поиск минимального
	mov EBX, sizeARR
	imul EBX, type DWORD
	mov ESI, ARR
	mov EDI, 0
	xor EAX, EAX
	mov EAX, [ESI]
findmin:
	add EDI, 4
	cmp EDI, EBX
	je closePROC
	cmp EAX, [ESI + EDI]
	jg inputMIN
	jl findmin
	

inputMIN:
	mov EAX, [ESI + EDI]
	jmp findmin
closePROC:	
	ret 
getmin ENDP

getmax PROC uses EBX ESI EDI ECX ARR : dword, sizeARR : dword ; поиск максимального
	mov EBX, sizeARR ; в EBX количество элементов
	imul EBX, type DWORD ; получаем количество байт
	mov ESI, ARR ; указатель на массив в ESI
	mov EDI, 0 ; 
	xor EAX, EAX
	mov EAX, [ESI] ; первый элемент массива
findmax:
	add EDI, 4 ; сдвиг на 4 байта
	cmp EDI, EBX ; сравниваем с размером байт
	je closePROC
	cmp EAX, [ESI + EDI] ; сравниваем левый и правый
	jl inputMAX
	jg findmax
inputMAX:
	mov EAX, [ESI + EDI] ; записываем максимальный
	jmp findmax
closePROC:	
	ret 
getmax ENDP

NumberInString PROC uses EBX ESI EDI ECX, strNUMBER : dword, number : dword
	mov edi, strNUMBER ; в EDI указатель на строку
	mov esi, 0 ; количество символов
	mov eax, number ; в EAX само число
	cdq ; расширения старшего бита регистра EAX (бита знака) на регистр EDX
	mov ebx, 10 ; делитель в EBX
	idiv ebx ; eax = eax / ebx, остаток в edx
	test eax, 80000000h ; проверка на знак
	jz plus
	neg eax ; смена знака
	neg edx
	mov cl, '-'
	mov [edi], cl ; первый символ -
	inc edi
plus:
	push dx ; остаток в стек
	inc esi ; esi++
	test eax, eax ; проверка на 0
	jz fin
	cdq
	idiv ebx
	jmp plus
fin:
	mov ecx, esi ; количесво символов
write:
	pop bx ; берем остаток из стека
	add bl, '0' ; символ
	mov [edi], bl ; добавили в строку
	inc edi
	loop write

	mov [edi], byte ptr 0

	ret

NumberInString ENDP

PrintConsole PROC uses EAX EBX ESI EDI ECX, strCONSOLE : dword, strTITLE : dword
	INVOKE SetConsoleTitleA, strTITLE
	INVOKE GetStdHandle, -11
	mov esi, strCONSOLE
	mov edi, -1
count:
	inc edi
	cmp byte ptr [esi + edi], 0
	jne count
	INVOKE WriteConsoleA, eax, strCONSOLE, edi, 0, 0

	ret
PrintConsole ENDP

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

end