unit Warhouses;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, DBCtrls, Grids, DBGrids, Db, DBTables;

type
  TForm_Warhouses = class(TForm)
    Table_Warhouses: TTable;
    DataSource_Warhouses: TDataSource;
    DBGrid1: TDBGrid;
    DBNavigator1: TDBNavigator;
    Button_Close: TButton;
    Query_Delete: TQuery;
    procedure Button_CloseClick(Sender: TObject);
    procedure Table_WarhousesBeforeDelete(DataSet: TDataSet);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form_Warhouses: TForm_Warhouses;

implementation

uses Presences, Sales;

{$R *.DFM}

procedure TForm_Warhouses.Button_CloseClick(Sender: TObject);
begin
     Close;
end;

procedure TForm_Warhouses.Table_WarhousesBeforeDelete(DataSet: TDataSet);
var
   id: string;

begin
     //������������� �������� ������
     if MessageDlg('������� ������ � ��� ��������� � ��� ������ ����� �������.'
        +#13+'����������?',
        mtConfirmation,[mbOK,mbCancel],0)=mrCancel then begin
        Abort;
     end;

     //�������� ������� �� ��������
     Query_Delete.Close;
     //��������� ����� ��������� ������
     id:=Table_Warhouses.FieldByName('id').AsString;

     //�������� SQL-�������
     Query_Delete.SQL.Clear;
     //���������� ������ SQL-�������
     Query_Delete.SQL.Add('DELETE FROM presences');
     Query_Delete.SQL.Add('WHERE presences.id_warhouse='+id);
     //���������� �������
     Query_Delete.ExecSQL;

     Query_Delete.SQL.Clear;
     Query_Delete.SQL.Add('DELETE FROM sales');
     Query_Delete.SQL.Add('WHERE sales.id_warhouse='+id);
     Query_Delete.ExecSQL;

     //���������� ������ � ����� ���������
     Form_Presences.Table_Presences.Close;
     Form_Presences.Table_Presences.Open;
     Form_Sales.Table_Sales.Close;
     Form_Sales.Table_Sales.Open;
end;

end.
