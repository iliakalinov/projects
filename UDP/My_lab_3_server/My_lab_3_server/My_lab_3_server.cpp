// My_lab_3_server.cpp: определяет точку входа для консольного приложения.
//
#include "Winsock2.h"
#include "stdafx.h"
#include "WinSock2.h"
#include <iostream>
#include <string>
#include "ErrorCod.h"
#pragma comment (lib, "WS2_32.lib")


int main()
{
	setlocale(LC_ALL, "Russian");
	//{Обьявление
	try {
		cout << endl << "***UDP***" << endl;
		WSADATA swd;
		SOCKET S_sock;
		//Обьявление}

		if (WSAStartup(MAKEWORD(2,0), &swd) == SOCKET_ERROR)
		{
			throw GetTextError("WSAStartup : ",WSAGetLastError());
		}
		
		if ((S_sock = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
		{
			throw GetTextError("Socket : ", GetLastError());
		}
		
		
			SOCKADDR_IN S_addr;
			S_addr.sin_family = AF_INET;
			S_addr.sin_port = htons(2000);

			S_addr.sin_addr.S_un.S_addr = inet_addr("192.168.43.67");
		

		if ((bind(S_sock, (sockaddr*)&S_addr, sizeof(S_addr))) == SOCKET_ERROR)
		{
			throw GetTextError("Bind : ", GetLastError());
		}

		cout << endl << "IP Servera : " << inet_ntoa(S_addr.sin_addr) <<endl;

		SOCKADDR_IN from;
		int lfrom = sizeof(from);

		char dfrom[50];
		int ldfrom = sizeof(dfrom);
		int lb = 0;
		int i = 0;
		
		for (;;) {
		Sleep(10);
		
			if ((lb = recvfrom(S_sock, dfrom, ldfrom, 0, (sockaddr*)&from, (int*)&lfrom)) == SOCKET_ERROR)
			{
				throw GetTextError("recvfrom : ", GetLastError());
			}
			if (!strcmp(dfrom,"---"))break;
		
			i++;
			cout<<"   " << i << " "<< dfrom <<endl;
		}



		closesocket(S_sock);
		WSACleanup();

	}
	catch (string s)
	{
		s = GetTextError("код ошибки : ", GetLastError());
		cout << endl << s <<endl;
	}
    return 0;
}
