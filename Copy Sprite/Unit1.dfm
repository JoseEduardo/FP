object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 320
  ClientWidth = 418
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object lbl1: TLabel
    Left = 16
    Top = 272
    Width = 16
    Height = 13
    Caption = 'lbl1'
  end
  object Label1: TLabel
    Left = 200
    Top = 272
    Width = 16
    Height = 13
    Caption = 'lbl1'
  end
  object Edit1: TEdit
    Left = 0
    Top = 0
    Width = 418
    Height = 21
    Align = alTop
    TabOrder = 0
    Text = 'Edit1'
    ExplicitLeft = 56
    ExplicitTop = 48
    ExplicitWidth = 121
  end
  object mmo1: TMemo
    Left = 8
    Top = 27
    Width = 402
    Height = 222
    Lines.Strings = (
      'mmo1')
    TabOrder = 1
  end
  object Button1: TButton
    Left = 335
    Top = 264
    Width = 75
    Height = 25
    Caption = 'Button1'
    TabOrder = 2
    OnClick = Button1Click
  end
  object ProgressBar1: TProgressBar
    Left = 0
    Top = 303
    Width = 418
    Height = 17
    Align = alBottom
    TabOrder = 3
    ExplicitLeft = 112
    ExplicitTop = 360
    ExplicitWidth = 150
  end
end
