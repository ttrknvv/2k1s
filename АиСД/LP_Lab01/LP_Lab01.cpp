#include <iostream>
#include <windows.h>

using namespace std;

#define SIZENUMBER 20

bool verification(char* N, char *K);
void towerOfHanoi(int i, int N, int k);

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	char N[SIZENUMBER] = {}, K[SIZENUMBER] = {};
	int Nsec = 0, ksec = 0;
	char a = 'c';

	cout << "Введите количество дисков (N < 99) : ";
	cin.getline(N, SIZENUMBER);
	cout << "Введите номер стержня, на который надо перенести (K <= 3 и K > 1) : ";
	cin.getline(K, SIZENUMBER);

	if (verification(N, K)) {
		Nsec = atoi(N);
		ksec = atoi(K);
		towerOfHanoi(1, Nsec, ksec);
	}
	else {
		cout << "Неправильно введены данные!";
	}
	return 0;
}

bool verification(char *N, char *K) {
	bool disk = true, sterzh = true;
	for (int i = 0; N[i] != 0; i++) {
		if (N[i] > '9' || N[i] < '0') {
			disk = false;
		}
	}
	if (K[1] != 0 || K[0] < '1' || K[0] > '3') {
		sterzh = false;
	}
	return disk && sterzh;
}
void towerOfHanoi(int i, int N, int k) {
	if (N == 1) {
		cout << "Переместить диск 1 со стержня " << i << " на стержень " << k << ".\n";
		return;
	}
	else {
		int tmp = 6 - i - k; 
		towerOfHanoi(i, N - 1, tmp);
		cout << "Переместить диск " << N << " со стержня " << i << " на стержень " << k << ".\n";
		towerOfHanoi(tmp, N - 1, k);
	}
}

