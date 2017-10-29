
// My_Lab_3_Client.cpp: определяет точку входа для консольного приложения.
//
#include "ErrorCod.h"
#include "stdafx.h"
#include "Winsock2.h"
#pragma comment(lib, "WS2_32.lib")
using namespace std;
#include <iostream>;
#include <time.h>



int main()
{
	string IP = "192.168.43.19";
	//setlocale(LC_ALL, "Russian");
	system("chcp 1251");
	WSADATA ws;
	SOCKET C_sock;

	
		if (WSAStartup(MAKEWORD(2,0), &ws) !=0)
		{
		//	cout<< GetTextError("WSASTARTUP :", WSAGetLastError());
		}
		if((C_sock = socket(AF_INET,SOCK_DGRAM,NULL))==INVALID_SOCKET)
		{
		//	cout<< GetTextError("socket :", GetLastError());
		}

		SOCKADDR_IN S_addr;
		S_addr.sin_family = AF_INET;
		S_addr.sin_port = htons(2000);
	
		S_addr.sin_addr.s_addr = inet_addr(IP.c_str());

	

		int L_S_addr = sizeof(S_addr);
		cout << endl << "IP Servera : " << inet_ntoa(S_addr.sin_addr) << endl;
		
		
		int col;
		cout << "Число сообщений для отправки: " << endl;
		cin >> col;
		cout << endl;
		char obuf[25] = "HelloFromClient ";
		
		for (int i = 0; i < col; i++)
		{

		char inum[6];
		sprintf(inum, "%d", i+1);
		char to[sizeof(obuf) + sizeof(inum)];
		strcpy(to, obuf);
		strcat(to, inum);
		sendto(C_sock, to, sizeof(to), NULL, (sockaddr*)&S_addr, sizeof(S_addr));
		cout << to << endl;
		}

		closesocket(C_sock);
		WSACleanup();





	return 0;
}


