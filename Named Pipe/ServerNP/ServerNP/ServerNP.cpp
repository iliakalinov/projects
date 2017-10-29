#include "windows.h"
#include <string>
#include <iostream>

using namespace std;

void main()
	{
		system("chcp 1251");
		cout << "сервер Named Pipe " << endl << endl;

	try
	{
		HANDLE h_NP;

		char rbuf[50];
		char wbuf[50] = "Hello from server";
		DWORD rb = sizeof(rbuf);
		DWORD wb = sizeof(wbuf);

		if ((h_NP = CreateNamedPipe(L"\\\\.\\pipe\\Tube", PIPE_ACCESS_DUPLEX, PIPE_TYPE_MESSAGE | PIPE_WAIT, 1, NULL, NULL, INFINITE, NULL)) == INVALID_HANDLE_VALUE)
			throw "Eroor: CreateNamedPipe";
//PIPE_ACCESS_DUPLEX,           //дуплексный канал 
//PIPE_TYPE_MESSAGE|PIPE_WAIT разрешает 
//       запись данных сообщениями в синхронном режиме
		while (true)
		{
			if (!ConnectNamedPipe(h_NP, NULL))
				throw "Eroor: ConnectNamedPipe";

			if (!ReadFile(h_NP, rbuf, sizeof(rbuf), &rb, NULL))
				throw "Eroor: ReadFile";

			cout << rbuf << endl;

			if (!WriteFile(h_NP, wbuf, sizeof(wbuf), &wb, NULL))
				throw "Eroor: WriteFile";
			if (!DisconnectNamedPipe(h_NP))
				throw "Eroor: DisconnectNamedPipe";
		}
		if (!CloseHandle(h_NP))
			throw "Eroor: CloseHandle";
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