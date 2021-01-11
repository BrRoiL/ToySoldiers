<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Game
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Game))
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.Button101 = New System.Windows.Forms.Button()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.PictureBox105 = New System.Windows.Forms.PictureBox()
        Me.PictureBox104 = New System.Windows.Forms.PictureBox()
        Me.PictureBox103 = New System.Windows.Forms.PictureBox()
        Me.PictureBox102 = New System.Windows.Forms.PictureBox()
        Me.PictureBox106 = New System.Windows.Forms.PictureBox()
        Me.PictureBox101 = New System.Windows.Forms.PictureBox()
        Me.Days = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label123 = New System.Windows.Forms.Label()
        Me.ExitGame = New System.Windows.Forms.Button()
        Me.Rules = New System.Windows.Forms.Label()
        Me.RulesCont = New System.Windows.Forms.Button()
        Me.Test = New System.Windows.Forms.PictureBox()
        Me.AttachPic = New System.Windows.Forms.PictureBox()
        Me.ShieldPic = New System.Windows.Forms.PictureBox()
        Me.TurnPic = New System.Windows.Forms.PictureBox()
        Me.SkipPic = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox105, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox104, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox103, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox102, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox101, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Test, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttachPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShieldPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TurnPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SkipPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label101
        '
        Me.Label101.BackColor = System.Drawing.Color.Transparent
        Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.Black
        Me.Label101.Location = New System.Drawing.Point(12, 704)
        Me.Label101.Name = "Label101"
        Me.Label101.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label101.Size = New System.Drawing.Size(115, 29)
        Me.Label101.TabIndex = 11
        Me.Label101.Text = "Игрок 1:"
        Me.Label101.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label102
        '
        Me.Label102.BackColor = System.Drawing.Color.Transparent
        Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label102.ForeColor = System.Drawing.Color.Black
        Me.Label102.Location = New System.Drawing.Point(169, 704)
        Me.Label102.Name = "Label102"
        Me.Label102.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label102.Size = New System.Drawing.Size(115, 29)
        Me.Label102.TabIndex = 13
        Me.Label102.Text = "Игрок 2:"
        Me.Label102.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.Transparent
        Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.Black
        Me.Label103.Location = New System.Drawing.Point(326, 704)
        Me.Label103.Name = "Label103"
        Me.Label103.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label103.Size = New System.Drawing.Size(115, 29)
        Me.Label103.TabIndex = 15
        Me.Label103.Text = "Игрок 3:"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label103.Visible = False
        '
        'Label104
        '
        Me.Label104.BackColor = System.Drawing.Color.Transparent
        Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.Black
        Me.Label104.Location = New System.Drawing.Point(483, 704)
        Me.Label104.Name = "Label104"
        Me.Label104.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label104.Size = New System.Drawing.Size(115, 29)
        Me.Label104.TabIndex = 17
        Me.Label104.Text = "Игрок 4:"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label104.Visible = False
        '
        'Label105
        '
        Me.Label105.BackColor = System.Drawing.Color.Transparent
        Me.Label105.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label105.ForeColor = System.Drawing.Color.Black
        Me.Label105.Location = New System.Drawing.Point(12, 733)
        Me.Label105.Name = "Label105"
        Me.Label105.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label105.Size = New System.Drawing.Size(115, 29)
        Me.Label105.TabIndex = 11
        Me.Label105.Text = "0"
        Me.Label105.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label106
        '
        Me.Label106.BackColor = System.Drawing.Color.Transparent
        Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label106.ForeColor = System.Drawing.Color.Black
        Me.Label106.Location = New System.Drawing.Point(169, 733)
        Me.Label106.Name = "Label106"
        Me.Label106.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label106.Size = New System.Drawing.Size(115, 29)
        Me.Label106.TabIndex = 11
        Me.Label106.Text = "0"
        Me.Label106.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label107
        '
        Me.Label107.BackColor = System.Drawing.Color.Transparent
        Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.Black
        Me.Label107.Location = New System.Drawing.Point(326, 733)
        Me.Label107.Name = "Label107"
        Me.Label107.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label107.Size = New System.Drawing.Size(115, 29)
        Me.Label107.TabIndex = 11
        Me.Label107.Text = "0"
        Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label107.Visible = False
        '
        'Label108
        '
        Me.Label108.BackColor = System.Drawing.Color.Transparent
        Me.Label108.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.Black
        Me.Label108.Location = New System.Drawing.Point(483, 733)
        Me.Label108.Name = "Label108"
        Me.Label108.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label108.Size = New System.Drawing.Size(115, 29)
        Me.Label108.TabIndex = 11
        Me.Label108.Text = "0"
        Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label108.Visible = False
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label110.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label110.Location = New System.Drawing.Point(619, 94)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(162, 25)
        Me.Label110.TabIndex = 19
        Me.Label110.Text = "Порядок хода"
        Me.Label110.Visible = False
        '
        'Label111
        '
        Me.Label111.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label111.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.Black
        Me.Label111.Location = New System.Drawing.Point(434, 133)
        Me.Label111.Name = "Label111"
        Me.Label111.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label111.Size = New System.Drawing.Size(115, 29)
        Me.Label111.TabIndex = 20
        Me.Label111.Text = "Игрок 1:"
        Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label111.Visible = False
        '
        'Label112
        '
        Me.Label112.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label112.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.Black
        Me.Label112.Location = New System.Drawing.Point(434, 162)
        Me.Label112.Name = "Label112"
        Me.Label112.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label112.Size = New System.Drawing.Size(115, 29)
        Me.Label112.TabIndex = 21
        Me.Label112.Text = "Игрок 2:"
        Me.Label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label112.Visible = False
        '
        'Label113
        '
        Me.Label113.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label113.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label113.ForeColor = System.Drawing.Color.Black
        Me.Label113.Location = New System.Drawing.Point(434, 191)
        Me.Label113.Name = "Label113"
        Me.Label113.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label113.Size = New System.Drawing.Size(115, 29)
        Me.Label113.TabIndex = 22
        Me.Label113.Text = "Игрок 3:"
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label113.Visible = False
        '
        'Label114
        '
        Me.Label114.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label114.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.Black
        Me.Label114.Location = New System.Drawing.Point(434, 220)
        Me.Label114.Name = "Label114"
        Me.Label114.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label114.Size = New System.Drawing.Size(115, 29)
        Me.Label114.TabIndex = 23
        Me.Label114.Text = "Игрок 4:"
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label114.Visible = False
        '
        'Label115
        '
        Me.Label115.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label115.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label115.ForeColor = System.Drawing.Color.Black
        Me.Label115.Location = New System.Drawing.Point(555, 133)
        Me.Label115.Name = "Label115"
        Me.Label115.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label115.Size = New System.Drawing.Size(30, 29)
        Me.Label115.TabIndex = 20
        Me.Label115.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label115.Visible = False
        '
        'Label116
        '
        Me.Label116.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label116.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label116.ForeColor = System.Drawing.Color.Black
        Me.Label116.Location = New System.Drawing.Point(555, 162)
        Me.Label116.Name = "Label116"
        Me.Label116.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label116.Size = New System.Drawing.Size(30, 29)
        Me.Label116.TabIndex = 20
        Me.Label116.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label116.Visible = False
        '
        'Label117
        '
        Me.Label117.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label117.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label117.ForeColor = System.Drawing.Color.Black
        Me.Label117.Location = New System.Drawing.Point(555, 191)
        Me.Label117.Name = "Label117"
        Me.Label117.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label117.Size = New System.Drawing.Size(30, 29)
        Me.Label117.TabIndex = 20
        Me.Label117.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label117.Visible = False
        '
        'Label118
        '
        Me.Label118.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label118.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label118.ForeColor = System.Drawing.Color.Black
        Me.Label118.Location = New System.Drawing.Point(555, 220)
        Me.Label118.Name = "Label118"
        Me.Label118.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label118.Size = New System.Drawing.Size(30, 29)
        Me.Label118.TabIndex = 20
        Me.Label118.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label118.Visible = False
        '
        'Button101
        '
        Me.Button101.AutoSize = True
        Me.Button101.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Button101.FlatAppearance.BorderSize = 0
        Me.Button101.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button101.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button101.Location = New System.Drawing.Point(652, 387)
        Me.Button101.Name = "Button101"
        Me.Button101.Size = New System.Drawing.Size(106, 35)
        Me.Button101.TabIndex = 24
        Me.Button101.Text = "Выбить"
        Me.Button101.UseVisualStyleBackColor = False
        Me.Button101.Visible = False
        '
        'Label119
        '
        Me.Label119.AutoSize = True
        Me.Label119.BackColor = System.Drawing.Color.Red
        Me.Label119.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label119.ForeColor = System.Drawing.Color.Black
        Me.Label119.Location = New System.Drawing.Point(140, 710)
        Me.Label119.Name = "Label119"
        Me.Label119.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label119.Size = New System.Drawing.Size(17, 18)
        Me.Label119.TabIndex = 25
        Me.Label119.Text = "0"
        Me.Label119.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label119.Visible = False
        '
        'Label120
        '
        Me.Label120.AutoSize = True
        Me.Label120.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label120.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label120.ForeColor = System.Drawing.Color.Black
        Me.Label120.Location = New System.Drawing.Point(296, 709)
        Me.Label120.Name = "Label120"
        Me.Label120.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label120.Size = New System.Drawing.Size(17, 18)
        Me.Label120.TabIndex = 25
        Me.Label120.Text = "0"
        Me.Label120.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label120.Visible = False
        '
        'Label121
        '
        Me.Label121.AutoSize = True
        Me.Label121.BackColor = System.Drawing.Color.Yellow
        Me.Label121.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label121.ForeColor = System.Drawing.Color.Black
        Me.Label121.Location = New System.Drawing.Point(454, 710)
        Me.Label121.Name = "Label121"
        Me.Label121.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label121.Size = New System.Drawing.Size(17, 18)
        Me.Label121.TabIndex = 26
        Me.Label121.Text = "0"
        Me.Label121.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label121.Visible = False
        '
        'Label122
        '
        Me.Label122.AutoSize = True
        Me.Label122.BackColor = System.Drawing.Color.Lime
        Me.Label122.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label122.ForeColor = System.Drawing.Color.Black
        Me.Label122.Location = New System.Drawing.Point(610, 710)
        Me.Label122.Name = "Label122"
        Me.Label122.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label122.Size = New System.Drawing.Size(17, 18)
        Me.Label122.TabIndex = 27
        Me.Label122.Text = "0"
        Me.Label122.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label122.Visible = False
        '
        'PictureBox105
        '
        Me.PictureBox105.BackColor = System.Drawing.Color.Lime
        Me.PictureBox105.Location = New System.Drawing.Point(604, 703)
        Me.PictureBox105.Name = "PictureBox105"
        Me.PictureBox105.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox105.TabIndex = 16
        Me.PictureBox105.TabStop = False
        Me.PictureBox105.Visible = False
        '
        'PictureBox104
        '
        Me.PictureBox104.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox104.Location = New System.Drawing.Point(447, 703)
        Me.PictureBox104.Name = "PictureBox104"
        Me.PictureBox104.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox104.TabIndex = 14
        Me.PictureBox104.TabStop = False
        Me.PictureBox104.Visible = False
        '
        'PictureBox103
        '
        Me.PictureBox103.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox103.Location = New System.Drawing.Point(290, 703)
        Me.PictureBox103.Name = "PictureBox103"
        Me.PictureBox103.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox103.TabIndex = 12
        Me.PictureBox103.TabStop = False
        '
        'PictureBox102
        '
        Me.PictureBox102.BackColor = System.Drawing.Color.Red
        Me.PictureBox102.Location = New System.Drawing.Point(133, 703)
        Me.PictureBox102.Name = "PictureBox102"
        Me.PictureBox102.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox102.TabIndex = 10
        Me.PictureBox102.TabStop = False
        '
        'PictureBox106
        '
        Me.PictureBox106.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PictureBox106.Location = New System.Drawing.Point(424, 85)
        Me.PictureBox106.Name = "PictureBox106"
        Me.PictureBox106.Size = New System.Drawing.Size(550, 350)
        Me.PictureBox106.TabIndex = 18
        Me.PictureBox106.TabStop = False
        Me.PictureBox106.Visible = False
        '
        'PictureBox101
        '
        Me.PictureBox101.BackgroundImage = Global.СолдатикиVB.My.Resources.Resources.Сетка
        Me.PictureBox101.Enabled = False
        Me.PictureBox101.Location = New System.Drawing.Point(10, 6)
        Me.PictureBox101.Name = "PictureBox101"
        Me.PictureBox101.Size = New System.Drawing.Size(1345, 757)
        Me.PictureBox101.TabIndex = 0
        Me.PictureBox101.TabStop = False
        Me.PictureBox101.Visible = False
        '
        'Days
        '
        Me.Days.AutoSize = True
        Me.Days.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Days.Location = New System.Drawing.Point(1248, 710)
        Me.Days.Name = "Days"
        Me.Days.Size = New System.Drawing.Size(107, 31)
        Me.Days.TabIndex = 28
        Me.Days.Text = "День 1"
        '
        'Timer2
        '
        Me.Timer2.Interval = 30
        '
        'Label123
        '
        Me.Label123.AutoSize = True
        Me.Label123.BackColor = System.Drawing.Color.Brown
        Me.Label123.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label123.Location = New System.Drawing.Point(444, 248)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(322, 73)
        Me.Label123.TabIndex = 30
        Me.Label123.Text = "Победил "
        Me.Label123.Visible = False
        '
        'ExitGame
        '
        Me.ExitGame.FlatAppearance.BorderSize = 0
        Me.ExitGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitGame.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ExitGame.ForeColor = System.Drawing.Color.Black
        Me.ExitGame.Location = New System.Drawing.Point(640, 729)
        Me.ExitGame.Name = "ExitGame"
        Me.ExitGame.Size = New System.Drawing.Size(181, 33)
        Me.ExitGame.TabIndex = 31
        Me.ExitGame.Text = "Выход из игры"
        Me.ExitGame.UseVisualStyleBackColor = True
        Me.ExitGame.Visible = False
        '
        'Rules
        '
        Me.Rules.AutoSize = True
        Me.Rules.BackColor = System.Drawing.Color.White
        Me.Rules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Rules.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Rules.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Rules.Location = New System.Drawing.Point(84, 6)
        Me.Rules.Name = "Rules"
        Me.Rules.Size = New System.Drawing.Size(1193, 639)
        Me.Rules.TabIndex = 32
        Me.Rules.Text = resources.GetString("Rules.Text")
        Me.Rules.Visible = False
        '
        'RulesCont
        '
        Me.RulesCont.AutoSize = True
        Me.RulesCont.BackColor = System.Drawing.Color.Transparent
        Me.RulesCont.FlatAppearance.BorderSize = 0
        Me.RulesCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RulesCont.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RulesCont.Location = New System.Drawing.Point(626, 652)
        Me.RulesCont.Name = "RulesCont"
        Me.RulesCont.Size = New System.Drawing.Size(155, 35)
        Me.RulesCont.TabIndex = 24
        Me.RulesCont.Text = "Продолжить"
        Me.RulesCont.UseVisualStyleBackColor = False
        Me.RulesCont.Visible = False
        '
        'Test
        '
        Me.Test.Location = New System.Drawing.Point(3, 693)
        Me.Test.Name = "Test"
        Me.Test.Size = New System.Drawing.Size(1362, 70)
        Me.Test.TabIndex = 33
        Me.Test.TabStop = False
        '
        'AttachPic
        '
        Me.AttachPic.BackgroundImage = Global.СолдатикиVB.My.Resources.Resources.Attach
        Me.AttachPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.AttachPic.Location = New System.Drawing.Point(123, 495)
        Me.AttachPic.Name = "AttachPic"
        Me.AttachPic.Size = New System.Drawing.Size(23, 21)
        Me.AttachPic.TabIndex = 34
        Me.AttachPic.TabStop = False
        Me.AttachPic.Visible = False
        '
        'ShieldPic
        '
        Me.ShieldPic.BackgroundImage = Global.СолдатикиVB.My.Resources.Resources.Shield
        Me.ShieldPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ShieldPic.Location = New System.Drawing.Point(132, 536)
        Me.ShieldPic.Name = "ShieldPic"
        Me.ShieldPic.Size = New System.Drawing.Size(23, 21)
        Me.ShieldPic.TabIndex = 35
        Me.ShieldPic.TabStop = False
        Me.ShieldPic.Visible = False
        '
        'TurnPic
        '
        Me.TurnPic.BackgroundImage = Global.СолдатикиVB.My.Resources.Resources.Turn
        Me.TurnPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TurnPic.Location = New System.Drawing.Point(144, 574)
        Me.TurnPic.Name = "TurnPic"
        Me.TurnPic.Size = New System.Drawing.Size(23, 21)
        Me.TurnPic.TabIndex = 36
        Me.TurnPic.TabStop = False
        Me.TurnPic.Visible = False
        '
        'SkipPic
        '
        Me.SkipPic.BackgroundImage = Global.СолдатикиVB.My.Resources.Resources.Skip
        Me.SkipPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.SkipPic.Location = New System.Drawing.Point(144, 613)
        Me.SkipPic.Name = "SkipPic"
        Me.SkipPic.Size = New System.Drawing.Size(23, 21)
        Me.SkipPic.TabIndex = 37
        Me.SkipPic.TabStop = False
        Me.SkipPic.Visible = False
        '
        'Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.SkipPic)
        Me.Controls.Add(Me.TurnPic)
        Me.Controls.Add(Me.ShieldPic)
        Me.Controls.Add(Me.AttachPic)
        Me.Controls.Add(Me.ExitGame)
        Me.Controls.Add(Me.Days)
        Me.Controls.Add(Me.Label122)
        Me.Controls.Add(Me.Label121)
        Me.Controls.Add(Me.Label120)
        Me.Controls.Add(Me.Label119)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.PictureBox105)
        Me.Controls.Add(Me.Label103)
        Me.Controls.Add(Me.PictureBox104)
        Me.Controls.Add(Me.Label102)
        Me.Controls.Add(Me.PictureBox103)
        Me.Controls.Add(Me.Label108)
        Me.Controls.Add(Me.Label107)
        Me.Controls.Add(Me.Label106)
        Me.Controls.Add(Me.Label105)
        Me.Controls.Add(Me.Label101)
        Me.Controls.Add(Me.PictureBox102)
        Me.Controls.Add(Me.Test)
        Me.Controls.Add(Me.RulesCont)
        Me.Controls.Add(Me.Button101)
        Me.Controls.Add(Me.Label114)
        Me.Controls.Add(Me.Label113)
        Me.Controls.Add(Me.Label112)
        Me.Controls.Add(Me.Label118)
        Me.Controls.Add(Me.Label117)
        Me.Controls.Add(Me.Label116)
        Me.Controls.Add(Me.Label115)
        Me.Controls.Add(Me.Label111)
        Me.Controls.Add(Me.Label110)
        Me.Controls.Add(Me.PictureBox106)
        Me.Controls.Add(Me.Rules)
        Me.Controls.Add(Me.Label123)
        Me.Controls.Add(Me.PictureBox101)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Game"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game"
        CType(Me.PictureBox105, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox104, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox103, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox102, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox101, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Test, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttachPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShieldPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TurnPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SkipPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label101 As Label
    Friend WithEvents PictureBox102 As PictureBox
    Friend WithEvents Label102 As Label
    Friend WithEvents PictureBox103 As PictureBox
    Friend WithEvents Label103 As Label
    Friend WithEvents PictureBox104 As PictureBox
    Friend WithEvents Label104 As Label
    Friend WithEvents PictureBox105 As PictureBox
    Friend WithEvents Label105 As Label
    Friend WithEvents Label106 As Label
    Friend WithEvents Label107 As Label
    Friend WithEvents Label108 As Label
    Friend WithEvents PictureBox106 As PictureBox
    Friend WithEvents Label110 As Label
    Friend WithEvents Label111 As Label
    Friend WithEvents Label112 As Label
    Friend WithEvents Label113 As Label
    Friend WithEvents Label114 As Label
    Friend WithEvents Label115 As Label
    Friend WithEvents Label116 As Label
    Friend WithEvents Label117 As Label
    Friend WithEvents Label118 As Label
    Friend WithEvents Button101 As Button
    Friend WithEvents PictureBox101 As PictureBox
    Friend WithEvents Label119 As Label
    Friend WithEvents Label120 As Label
    Friend WithEvents Label121 As Label
    Friend WithEvents Label122 As Label
    Friend WithEvents Days As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Label123 As Label
    Friend WithEvents ExitGame As Button
    Friend WithEvents Rules As Label
    Friend WithEvents RulesCont As Button
    Friend WithEvents Test As PictureBox
    Friend WithEvents AttachPic As PictureBox
    Friend WithEvents ShieldPic As PictureBox
    Friend WithEvents TurnPic As PictureBox
    Friend WithEvents SkipPic As PictureBox
End Class
