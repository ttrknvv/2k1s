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

getmin PROC uses EBX ESI EDI ECX ARR : dword, sizeARR : dword ; ����� ������������
	
	mov EBX, sizeARR
	imul EBX, type DWORD ; ���������� ���� � EBX
	mov ESI, ARR ; ��������� �� ������ �������
	mov EDI, 0 ; ������� �������
	xor EAX, EAX
	mov EAX, [ESI] ; ������ ������ �������
findmin:
	add EDI, 4 ; ��������� 4 �����
	cmp EDI, EBX ; ���������� ���������� ���������� � EBX
	je closePROC
	cmp EAX, [ESI + EDI] ; ���� ����� ������ �������
	jg inputMIN ; ��
	jl findmin ; �����
	

inputMIN:
	mov EAX, [ESI + EDI]
	jmp findmin
closePROC:	
	ret ; ����� �� ���������
getmin ENDP


main PROC
	
	INVOKE getmin, offset ARRAY, sizeARRAY
	
	INVOKE ExitProcess, -1
main ENDP

end main
