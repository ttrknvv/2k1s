#include <iostream>
#include <iomanip>
#include <string>
#include <Windows.h>
#include <cstring>

using namespace std;

bool CheckAddress(char* ip_); // функция проверки валидности айпи адреса
unsigned long CharToLong(char* ip_); // функция перевода из char в long
bool CheckMask(char* mask_);// функция проверки валидности маски
string LongInChar(unsigned long data); // функция перевода из long в string

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	unsigned long ip{}; // айпи адрес long
	unsigned long mask{}; // маска long
	unsigned long subnet{}; // network ID подсети long
	unsigned long host{}; // network ID хоста long
	unsigned long broadcast{}; // широковещательный адрес long
	char* ip_{}, * mask_{}; // айпи и маска char
	bool flag = true;
	ip_ = new char[16];
	mask_ = new char[16];

	do
	{
		if (!flag) // цикл проверки на валидность айпи адреса
		{
			cout << "Неверно введён адрес\n";
		}
		cout << "IP: ";
		cin >> ip_;
	} while (!(flag = CheckAddress(ip_)));

	flag = true;

	do
	{
		if (!flag) // цикл проверки на валидность маски
		{
			cout << "Неправильная маска!\n";
		}
		flag = true;
		do
		{
			if (!flag)
			{
				cout << "Неверно введена маска!\n";
			}
			cout << "Маска: ";
			cin >> mask_;
		} while (!(flag = CheckAddress(mask_)));
		mask = CharToLong(mask_);
	} while (!(flag = CheckMask(mask_)));

	ip = CharToLong(ip_); // получить айпи адрес в формате long
	mask = CharToLong(mask_); // получить маску в формате long

	subnet = ip & mask; // расчет ID подсети
	host = ip & ~mask; // ID хоста
	broadcast = subnet | ~mask; // широковещательный адрес

	// вывод вычисленных данных
	cout << setw(20) << "Исходный IP адрес" << setw(30) << "Новая маска подсети" << setw(24) << "ID подсети" 
		 << setw(20) << "ID хоста" << setw(30) << "Широковещательный адрес" << endl;
	cout << setw(17) << ip_ << setw(30) << mask_ << setw(28) << LongInChar(subnet) << setw(20) << LongInChar(host)
		 << setw(24) << LongInChar(broadcast) << endl;
	system("pause");
	return false;
}

string LongInChar(unsigned long data)
{
	unsigned long octet = data;
	string strOctet;
	bool check = true;
	char number[4]{};
	for (int i = 24; i >= 0; i-=8)
	{
		octet >>= i;
		_itoa_s(octet, number, 10);
		string strNumber = number;
		strOctet += strNumber;
		if (i) strOctet += '.';
		octet <<= i;
		data -= octet;
		octet = data;
	}
	return strOctet;
}
bool CheckMask(char *mask_)
{
	int points = -1; // количество точек
	int numbers = 0; // значение октета
	char* buff{}; // буфер для одного октета
	bool flag = true;
	buff = new char[3];
	for (int i = 0; mask_[i - 1] != '\0'; i++)
	{
		if (mask_[i] <= '9' && mask_[i] >= '0' && mask_[i] != '\0')
		{
			if (numbers > 3)
			{
				return false;
			}
			buff[numbers++] = mask_[i];
		}
		else
		{
			if (mask_[i] == '.' || i == strlen(mask_))
			{
				if (points == 0 && atoi(buff) == 0) return false;
				switch (atoi(buff))
				{
					case 255: if(!flag) return false;
							  break;
					case 254:
					case 252:
					case 248:
					case 240:
					case 224:
					case 192:
					case 128: if (!flag) return false;
							  flag = false;
							  break;
					case 0:   flag = false;
							  break;
					default: return false;
							 break;
				}
				numbers = 0;
				points++;
				delete[]buff;
				buff = new char[3];
			}
			else
			{
				return false;
			}
		}
	}
	if (points != 3)
	{
		return false;
	}
	return true;
};
unsigned long CharToLong(char* ip_)
{
	unsigned long out = 0;
	char* buff;
	buff = new char[3] {};
	for (int i = 0, j = 0, k = 0; ip_[i] != '\0'; i++, j++)
	{
		if (ip_[i] != '.')
		{
			buff[j] = ip_[i];
		}
		if (ip_[i] == '.' || ip_[i + 1] == '\0')
		{
			out <<= 8;
			if (atoi(buff) > 255)
			{
				return NULL;
			}
			out += (unsigned long)atoi(buff);
			k++;
			j = -1;
			delete[]buff;
			buff = new char[3]{};
		}
	}
	return out;
}
bool CheckAddress(char* ip_)
{
	int points = 0; // количество точек
	int numbers = 0; // значение октета
	char* buff{}; // буфер для одного октета
	buff = new char[3];
	for (int i = 0; ip_[i] != '\0'; i++)
	{
		if (ip_[i] <= '9' && ip_[i] >= '0')
		{
			if (numbers > 3)
			{
				return false;
			}
			buff[numbers++] = ip_[i];
		}
		else
		{
			if (ip_[i] == '.')
			{
				if (atoi(buff) > 255 || numbers == 0)
				{
					return false;
				}
				numbers = 0;
				points++;
				delete[]buff;
				buff = new char[3];
			}
			else
			{
				return false;
			}
		}
	}
	if (points != 3 || numbers == 0 || numbers > 3)
	{
		return false;
	}
	return true;
}