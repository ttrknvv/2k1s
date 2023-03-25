.586
.MODEL FLAT, STDCALL
includelib kernel32.lib
SetConsoleTitleA PROTO : DWORD 
GetStdHandle PROTO : DWORD
WriteConsoleA PROTO : DWORD, : DWORD, : DWORD, :DWORD, : DWORD

.code
getmin PROC uses EBX ESI EDI ECX ARR : dword, sizeARR : dword ; ����� ������������
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

getmax PROC uses EBX ESI EDI ECX ARR : dword, sizeARR : dword ; ����� �������������
	mov EBX, sizeARR ; � EBX ���������� ���������
	imul EBX, type DWORD ; �������� ���������� ����
	mov ESI, ARR ; ��������� �� ������ � ESI
	mov EDI, 0 ; 
	xor EAX, EAX
	mov EAX, [ESI] ; ������ ������� �������
findmax:
	add EDI, 4 ; ����� �� 4 �����
	cmp EDI, EBX ; ���������� � �������� ����
	je closePROC
	cmp EAX, [ESI + EDI] ; ���������� ����� � ������
	jl inputMAX
	jg findmax
inputMAX:
	mov EAX, [ESI + EDI] ; ���������� ������������
	jmp findmax
closePROC:	
	ret 
getmax ENDP

NumberInString PROC uses EBX ESI EDI ECX, strNUMBER : dword, number : dword
	mov edi, strNUMBER ; � EDI ��������� �� ������
	mov esi, 0 ; ���������� ��������
	mov eax, number ; � EAX ���� �����
	cdq ; ���������� �������� ���� �������� EAX (���� �����) �� ������� EDX
	mov ebx, 10 ; �������� � EBX
	idiv ebx ; eax = eax / ebx, ������� � edx
	test eax, 80000000h ; �������� �� ����
	jz plus
	neg eax ; ����� �����
	neg edx
	mov cl, '-'
	mov [edi], cl ; ������ ������ -
	inc edi
plus:
	push dx ; ������� � ����
	inc esi ; esi++
	test eax, eax ; �������� �� 0
	jz fin
	cdq
	idiv ebx
	jmp plus
fin:
	mov ecx, esi ; ��������� ��������
write:
	pop bx ; ����� ������� �� �����
	add bl, '0' ; ������
	mov [edi], bl ; �������� � ������
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