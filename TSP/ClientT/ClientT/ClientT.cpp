// серв.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "Winsock2.h"
#include <iostream>
#include <time.h>
#include <string>
using namespace std;
#pragma comment(lib, "WS2_32.lib") 
#include <stdio.h>



string  GetErrorMsgText(int code)    // cформировать текст ошибки 
{
	system("chcp 1252");
	string msgText;
	switch (code)                      // проверка кода возврата  
	{
	case WSAEINTR: msgText = "Работа функции прервана "; break;
	case WSAEACCES: msgText = "Разрешение отвергнуто"; break;
	case WSAEFAULT: msgText = "Ошибочный адрес"; break;
	case WSAEINVAL: msgText = "Ошибка в аргументе "; break;
	case WSAEMFILE: msgText = "Слишком много файлов открыто"; break;
	case WSAEWOULDBLOCK: msgText = "Ресурс временно недоступен"; break;
	case WSAEINPROGRESS: msgText = "Операция в процессе развития"; break;
	case WSAEALREADY: msgText = "Операция уже выполняется "; break;
	case WSAENOTSOCK: msgText = "Сокет задан неправильно   "; break;
	case WSAEDESTADDRREQ: msgText = "Требуется адрес расположения "; break;
	case WSAEMSGSIZE: msgText = "Сообщение слишком длинное "; break;
	case WSAEPROTOTYPE: msgText = "Неправильный тип протокола для сокета "; break;
	case WSAENOPROTOOPT: msgText = "Ошибка в опции протокола"; break;
	case WSAEPROTONOSUPPORT: msgText = "Протокол не поддерживается "; break;
	case WSAESOCKTNOSUPPORT: msgText = "Тип сокета не поддерживается "; break;
	case WSAEOPNOTSUPP: msgText = "Операция не поддерживается "; break;
	case WSAEPFNOSUPPORT: msgText = "Тип протоколов не поддерживается "; break;
	case WSAEAFNOSUPPORT: msgText = "Тип адресов не поддерживается протоколом"; break;
	case WSAEADDRINUSE: msgText = "Адрес уже используется "; break;
	case WSAEADDRNOTAVAIL: msgText = "Запрошенный адрес не может быть использован"; break;
	case WSAENETDOWN: msgText = "Сеть отключена "; break;
	case WSAENETUNREACH: msgText = "Сеть не достижима"; break;
	case WSAENETRESET: msgText = "Сеть разорвала соединение"; break;
	case WSAECONNABORTED: msgText = "Программный отказ связи "; break;
	case WSAECONNRESET: msgText = "Связь восстановлена "; break;
	case WSAENOBUFS: msgText = "Не хватает памяти для буферов"; break;
	case WSAEISCONN: msgText = "Сокет уже подключен"; break;
	case WSAENOTCONN: msgText = "Сокет не подключен"; break;
	case WSAESHUTDOWN: msgText = "Нельзя выполнить send: сокет завершил работу"; break;
	case WSAETIMEDOUT: msgText = "Закончился отведенный интервал  времени"; break;
	case WSAECONNREFUSED: msgText = "Соединение отклонено  "; break;
	case WSAEHOSTDOWN: msgText = "Хост в неработоспособном состоянии"; break;
	case WSAEHOSTUNREACH: msgText = "Нет маршрута для хоста "; break;
	case WSAEPROCLIM: msgText = "Слишком много процессов "; break;
	case WSASYSNOTREADY: msgText = "Сеть не доступна "; break;
	case WSAVERNOTSUPPORTED: msgText = "Данная версия недоступна "; break;
	case WSANOTINITIALISED: msgText = "Не выполнена инициализация WS2_32.DLL"; break;
	case WSAEDISCON: msgText = "Выполняется отключение"; break;
	case WSATYPE_NOT_FOUND: msgText = "Класс не найден "; break;
	case WSAHOST_NOT_FOUND: msgText = "Хост не найден"; break;
	case WSATRY_AGAIN: msgText = "Неавторизированный хост не найден "; break;
	case WSANO_RECOVERY: msgText = "Неопределенная  ошибка "; break;
	case WSANO_DATA: msgText = "Нет записи запрошенного типа "; break;
	case WSA_INVALID_HANDLE: msgText = "Указанный дескриптор события  с ошибкой   "; break;
	case WSA_INVALID_PARAMETER: msgText = "Один или более параметров с ошибкой   "; break;
	case WSA_IO_INCOMPLETE: msgText = "Объект ввода-вывода не в сигнальном состоянии"; break;
	case WSA_IO_PENDING: msgText = "Операция завершится позже  "; break;
	case WSA_NOT_ENOUGH_MEMORY: msgText = "Не достаточно памяти "; break;
	case WSA_OPERATION_ABORTED: msgText = "Операция отвергнута "; break;
	case WSASYSCALLFAILURE: msgText = "Аварийное завершение системного вызова "; break;
	default:                msgText = "***ERROR***";      break;
	};
	return msgText;
};
string  SetErrorMsgText(string msgText, int code)
{
	return  msgText + GetErrorMsgText(code);
};



int main()
{
	try
	{
		system("chcp 1251");
		//............................................................
		WORD sockVer;
		WSADATA wsaData;
		sockVer = MAKEWORD(2, 2);
		WSAStartup(sockVer, &wsaData);	
		SOCKET clientSock = socket(AF_INET, SOCK_STREAM, 0);// IPPROTO_TCP
									 					  //1-ргумент domain задает используемый для взаимодействия набор протоколов (вид коммуникационной области), 
														  //для стека протоколов TCP/IP он должен иметь символьное значение AF_INET
														  //2-SOCK_STREAM - с установлением соединения;
														  //3-задает конкретный протокол транспортного уровня 0-по умолчанию 
		SOCKADDR_IN cerv;
		cerv.sin_family = AF_INET;
		cerv.sin_port = htons(2100);
		cerv.sin_addr.s_addr = inet_addr("192.168.43.67");
		int retVal;
		retVal = connect(clientSock, (LPSOCKADDR)&cerv, sizeof(cerv));
		//bind - для Для подключения socket'а
		//1-Аргумент s задает дескриптор связываемого socket'а.
		//2

		int n;
		cin >> n;
		clock_t t1, t2;

		if (retVal == 0) {
			char *bfrom = new char;
			t1 = clock();

			for (int i = 1; i <= n; i++) {
			
			//	delete(bfrom);	
				itoa(i, bfrom, 10);
				cout <<  "Hello from Client   ";
			
				retVal = send(clientSock, bfrom, 20, 0);

				retVal = recv(clientSock, bfrom, 20, 0);
				cout << bfrom<<"\n";




			}
			t2 = clock();
		}
		double aa =(double)(t2 - t1) / 1000;
		cout << "время= " << aa<<endl;


		closesocket(clientSock);
		int WSACleanup(sockVer);//закрыть

								//throw  SetErrorMsgText("socket:", WSAGetLastError());
								//.............................................................
	}
		catch (string errorMsgText)
	{
		cout << endl << "WSAGetLastError: " << errorMsgText;
	}

	return 0;
}

