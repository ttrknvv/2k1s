#include <stack>
#include <iostream>
#include <string>

using namespace std;

string PolishNotation(string expression); // обратная польская нотация
int Priority(char data); // приоритет символов
bool VerificationExpression(string expression); // проверка корректности

int main()
{
    setlocale(LC_ALL, "rus");
    string data; // исходная строка(инфиксная форма)
    string finishData; // результирующая строка(обратная польская запись)
    getline(cin, data);
    data += '\0';
    if (VerificationExpression(data)) {
        finishData = PolishNotation(data);
        cout << finishData;
    }
    else {
        cout << "Выражение заданно некорректно";
    }
    
}

string PolishNotation(string expression) {
    string PolishLine; // результирующая строка(обратная польская запись)
    stack <char> operation; // стек
    for (int i = 0; i < expression.length() && expression[i] != '='; i++) {
        if (expression[i] < '(' || expression[i] > '/') {
            PolishLine += expression[i];
        }
        else if (expression[i] == ')') {
            while (operation.top() != '(') {
                PolishLine += operation.top();
                operation.pop();
            }
            operation.pop();
        }
        else if (operation.empty() || (operation.top() == '(' || expression[i] == '(')) {
            operation.push(expression[i]);
        }
        else if(Priority(expression[i]) <= Priority(operation.top())) {
            while (!operation.empty() && Priority(expression[i]) <= Priority(operation.top())) {
                PolishLine += operation.top();
                operation.pop();
            }
            operation.push(expression[i]);
        }
        else {
            operation.push(expression[i]);
        }
    }
    while (!operation.empty()) {
        PolishLine += operation.top();
        operation.pop();
    }
    return PolishLine;
}
int Priority(char data) {
    switch (data) {
        case '(':
        case ')': return 1;
        case '+':
        case '-': return 2;
        case '*':
        case '/': return 3;
    }
}
bool VerificationExpression(string expression) {
    stack<char> operation;
    for (int i = 0; i < expression.length(); i++) {
        switch (expression[i]) {
            case '(': operation.push(expression[i]);
                      break;
            case ')': if (!operation.empty() && operation.top() == '(') { 
                            operation.pop(); 
                        }
                      else {
                            return false;
                        }
                      break;
            case '+':
            case '-':
            case '/':
            case '*': switch (expression[i + 1]) {
                            case '+':
                            case '-':
                            case '/':
                            case '*':
                            case ')':
                            case '\0': return false;

                             
            }
                            
                      
            default: continue;
        }
    }
    if (operation.empty()) {
        return true;
    }
    return false;
}