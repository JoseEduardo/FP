unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    mmo1: TMemo;
    Button1: TButton;
    ProgressBar1: TProgressBar;
    lbl1: TLabel;
    Label1: TLabel;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
 i : Integer;
 Dest, Orig : string;
 TsList : TStringList;
begin
mmo1.Lines.LoadFromFile(Trim(Edit1.Text) );

TsList := TStringList.Create;
ProgressBar1.Max := mmo1.Lines.Count;
Label1.Caption := IntToStr(mmo1.Lines.Count);
for i := 0 to mmo1.Lines.Count-1 do
   begin
   TsList.Delimiter := ';';
   TsList.DelimitedText := mmo1.Lines.Strings[i];

   Dest := 'D:\Google Drive\FanPoke\Assets\Resources\sprites\'+TsList[0]+'.png';
   Orig := 'D:\Google Drive\FanPoke\SpriteDump\SpriteDump\bin\Release\Sprites\'+TsList[0]+'.png';

   if not FileExists(Dest) then
      CopyFile(PChar(Orig), PChar(Dest), False);

   ProgressBar1.Position := ProgressBar1.Position +1;
   lbl1.Caption := IntToStr(ProgressBar1.Position);
   Application.ProcessMessages;
   end;


end;

end.