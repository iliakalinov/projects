// My_Lab_3_exit.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "Winsock2.h"
#pragma comment(lib, "WS2_32.lib")
using namespace std;
#include <iostream>;


int main()
{
	string IP = "192.168.43.132";
	setlocale(LC_ALL, "Russian");
	WSADATA ws;
	SOCKET C_sock;
	WSAStartup(MAKEWORD(2, 0), &ws);
	C_sock = socket(AF_INET, SOCK_DGRAM, NULL);
	
	SOCKADDR_IN S_addr;
	S_addr.sin_family = AF_INET;
	S_addr.sin_port = htons(2000);
	S_addr.sin_addr.s_addr = inet_addr(IP.c_str());

	sendto(C_sock, "EXIT", sizeof("EXIT"), 0, (sockaddr*)&S_addr, sizeof(S_addr));
	closesocket(C_sock);
	WSACleanup();

	return 0;
}