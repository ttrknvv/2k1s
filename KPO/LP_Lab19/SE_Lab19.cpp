#include "stdafx.h"
#include <cstring>

using namespace std;

#define ARRAYSIZE 7

int _tmain(int argc, _TCHAR* argv[]) 
{
	setlocale(LC_ALL, "rus");
	string a[] = { "acbfcdcefcgf\0", 
				 "acbfdcefcgf\0",
				 "accccbfcccdccceeefccgf\0",
				 "abfcdcefcgf\0",
				 "ccaacbfc\0",
				 "acbfdcefcgf\0",
				 "acccccccccbfdccccccefcccgf\0",
				 "acbfcdcefcg\0"};
	for (int i = 0; i < 8; i++) {
		FST::FST fst1((a[i]).c_str(), 12,
			FST::NODE(1, FST::RELATION('a', 1)),
			FST::NODE(2, FST::RELATION('c', 1), FST::RELATION('c', 2)),
			FST::NODE(1, FST::RELATION('b', 3)),
			FST::NODE(1, FST::RELATION('f', 4)),
			FST::NODE(2, FST::RELATION('c', 4), FST::RELATION('d', 5)),
			FST::NODE(2, FST::RELATION('c', 5), FST::RELATION('c', 6)),
			FST::NODE(2, FST::RELATION('e', 6), FST::RELATION('e', 7)),
			FST::NODE(1, FST::RELATION('f', 8)),
			FST::NODE(2, FST::RELATION('c', 8), FST::RELATION('c', 9)),
			FST::NODE(1, FST::RELATION('g', 10)),
			FST::NODE(1, FST::RELATION('f', 11)),
			FST::NODE()); // a  c+ b f c* d c+ e+ f c+ g f
		if (FST::execute(fst1))
		{
			std::cout << "Цепочка " << fst1.string << " распознана" << std::endl;
		}
		else
		{
			std::cout << "Цепочка " << fst1.string << " не распознана" << std::endl;
		}
	}
	
	
	system("pause");
	return 0;
}