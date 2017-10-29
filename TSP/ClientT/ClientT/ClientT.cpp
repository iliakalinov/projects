// ����.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include "Winsock2.h"
#include <iostream>
#include <time.h>
#include <string>
using namespace std;
#pragma comment(lib, "WS2_32.lib") 
#include <stdio.h>



string  GetErrorMsgText(int code)    // c����������� ����� ������ 
{
	system("chcp 1252");
	string msgText;
	switch (code)                      // �������� ���� ��������  
	{
	case WSAEINTR: msgText = "������ ������� �������� "; break;
	case WSAEACCES: msgText = "���������� ����������"; break;
	case WSAEFAULT: msgText = "��������� �����"; break;
	case WSAEINVAL: msgText = "������ � ��������� "; break;
	case WSAEMFILE: msgText = "������� ����� ������ �������"; break;
	case WSAEWOULDBLOCK: msgText = "������ �������� ����������"; break;
	case WSAEINPROGRESS: msgText = "�������� � �������� ��������"; break;
	case WSAEALREADY: msgText = "�������� ��� ����������� "; break;
	case WSAENOTSOCK: msgText = "����� ����� �����������   "; break;
	case WSAEDESTADDRREQ: msgText = "��������� ����� ������������ "; break;
	case WSAEMSGSIZE: msgText = "��������� ������� ������� "; break;
	case WSAEPROTOTYPE: msgText = "������������ ��� ��������� ��� ������ "; break;
	case WSAENOPROTOOPT: msgText = "������ � ����� ���������"; break;
	case WSAEPROTONOSUPPORT: msgText = "�������� �� �������������� "; break;
	case WSAESOCKTNOSUPPORT: msgText = "��� ������ �� �������������� "; break;
	case WSAEOPNOTSUPP: msgText = "�������� �� �������������� "; break;
	case WSAEPFNOSUPPORT: msgText = "��� ���������� �� �������������� "; break;
	case WSAEAFNOSUPPORT: msgText = "��� ������� �� �������������� ����������"; break;
	case WSAEADDRINUSE: msgText = "����� ��� ������������ "; break;
	case WSAEADDRNOTAVAIL: msgText = "����������� ����� �� ����� ���� �����������"; break;
	case WSAENETDOWN: msgText = "���� ��������� "; break;
	case WSAENETUNREACH: msgText = "���� �� ���������"; break;
	case WSAENETRESET: msgText = "���� ��������� ����������"; break;
	case WSAECONNABORTED: msgText = "����������� ����� ����� "; break;
	case WSAECONNRESET: msgText = "����� ������������� "; break;
	case WSAENOBUFS: msgText = "�� ������� ������ ��� �������"; break;
	case WSAEISCONN: msgText = "����� ��� ���������"; break;
	case WSAENOTCONN: msgText = "����� �� ���������"; break;
	case WSAESHUTDOWN: msgText = "������ ��������� send: ����� �������� ������"; break;
	case WSAETIMEDOUT: msgText = "���������� ���������� ��������  �������"; break;
	case WSAECONNREFUSED: msgText = "���������� ���������  "; break;
	case WSAEHOSTDOWN: msgText = "���� � ����������������� ���������"; break;
	case WSAEHOSTUNREACH: msgText = "��� �������� ��� ����� "; break;
	case WSAEPROCLIM: msgText = "������� ����� ��������� "; break;
	case WSASYSNOTREADY: msgText = "���� �� �������� "; break;
	case WSAVERNOTSUPPORTED: msgText = "������ ������ ���������� "; break;
	case WSANOTINITIALISED: msgText = "�� ��������� ������������� WS2_32.DLL"; break;
	case WSAEDISCON: msgText = "����������� ����������"; break;
	case WSATYPE_NOT_FOUND: msgText = "����� �� ������ "; break;
	case WSAHOST_NOT_FOUND: msgText = "���� �� ������"; break;
	case WSATRY_AGAIN: msgText = "������������������ ���� �� ������ "; break;
	case WSANO_RECOVERY: msgText = "��������������  ������ "; break;
	case WSANO_DATA: msgText = "��� ������ ������������ ���� "; break;
	case WSA_INVALID_HANDLE: msgText = "��������� ���������� �������  � �������   "; break;
	case WSA_INVALID_PARAMETER: msgText = "���� ��� ����� ���������� � �������   "; break;
	case WSA_IO_INCOMPLETE: msgText = "������ �����-������ �� � ���������� ���������"; break;
	case WSA_IO_PENDING: msgText = "�������� ���������� �����  "; break;
	case WSA_NOT_ENOUGH_MEMORY: msgText = "�� ���������� ������ "; break;
	case WSA_OPERATION_ABORTED: msgText = "�������� ���������� "; break;
	case WSASYSCALLFAILURE: msgText = "��������� ���������� ���������� ������ "; break;
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
									 					  //1-������� domain ������ ������������ ��� �������������� ����� ���������� (��� ���������������� �������), 
														  //��� ����� ���������� TCP/IP �� ������ ����� ���������� �������� AF_INET
														  //2-SOCK_STREAM - � ������������� ����������;
														  //3-������ ���������� �������� ������������� ������ 0-�� ��������� 
		SOCKADDR_IN cerv;
		cerv.sin_family = AF_INET;
		cerv.sin_port = htons(2100);
		cerv.sin_addr.s_addr = inet_addr("192.168.43.67");
		int retVal;
		retVal = connect(clientSock, (LPSOCKADDR)&cerv, sizeof(cerv));
		//bind - ��� ��� ����������� socket'�
		//1-�������� s ������ ���������� ������������ socket'�.
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
		cout << "�����= " << aa<<endl;


		closesocket(clientSock);
		int WSACleanup(sockVer);//�������

								//throw  SetErrorMsgText("socket:", WSAGetLastError());
								//.............................................................
	}
		catch (string errorMsgText)
	{
		cout << endl << "WSAGetLastError: " << errorMsgText;
	}

	return 0;
}

