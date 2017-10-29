#include "windows.h"
#include <string>
#include "string.h"
#include <iostream>

using namespace std;

void main()
{

	system("chcp 1251");
	cout << "Клиент Named Pipe " << endl << endl;

	

	try
	{
		HANDLE h_NP;

		char rbuf[50];
		char wbuf[50] = "Hello from client ";
		DWORD rb = sizeof(rbuf);
		DWORD wb = sizeof(wbuf);

		for (int i = 0; i<10; i++)
		{
			if ((h_NP = CreateFile(L"\\\\DESKTOP-QN697QT\\pipe\\Tube", GENERIC_WRITE | GENERIC_READ, FILE_SHARE_WRITE | FILE_SHARE_READ, NULL, OPEN_EXISTING, NULL, NULL)) == INVALID_HANDLE_VALUE)
				throw "Error: CreateFile"; 

			char inum[6];
			sprintf(inum, "%d", i + 1);
			char buf[sizeof(wbuf) + sizeof(inum)];
			strcpy(buf, wbuf);
			strcat(buf, inum);
			wb = sizeof(wbuf);

			if (!WriteFile(h_NP, buf, sizeof(wbuf), &wb, NULL))
				throw "Error: WriteFile";
			if (!ReadFile(h_NP, rbuf, sizeof(rbuf), &rb, NULL))
				throw "Error: ReadFile";

			cout << rbuf << endl;

			CloseHandle(h_NP);
		}
}
	catch (string e)
	{
		cout << e << endl;
	}
	catch (...)
	{
		cout << "Error" << endl;
	}
}