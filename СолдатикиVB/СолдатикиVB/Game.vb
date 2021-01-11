Public Class Game
    Dim MassCoord(0 To 95, 0 To 48) As Point
    Dim MassCoordTrigger(0 To 95, 0 To 53) As Boolean
    Dim NumRand As Integer = 111
    Dim PanelInfo, Trigger As Boolean
    Dim NumShield As Integer = 1
    Dim UnitsHPInfo(40) As Integer
    Dim UnitsCoord(40, 2) As Integer
    Dim UnitAction, ObjectClick, TurnAction As Object
    Dim ButtonAction(0 To 8) As Button
    Dim PlayerPlay As Color
    Dim OldObj, UnitObj, EnemyUnit As Object
    Dim LengthName As Integer = 0
    Dim Time, CubeNum, Xod As Integer
    Dim AttackTrigger(), TurnTrigger(), ShieldTrigger(), ShieldActivate(40) As Boolean
    Dim NotAction, Active As Boolean
    Dim Panel As Panel
    Dim TextLabel As Label
    Dim Attach, Shield, Turn, Skip As Button
    Dim RedKill(10), OrangeKill(10), YellowKill(10), LimeKill(10) As Boolean
    Dim RedKillT, OrangeKillT, YellowKillT, LimeKillT As Boolean

    'Загрузка данных
    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PrivLocation As Point
        Label101.Text = My.Settings.Player1Name
        Label102.Text = My.Settings.Player2Name
        Label103.Text = My.Settings.Player3Name
        Label104.Text = My.Settings.Player4Name
        Label111.Text = My.Settings.Player1Name
        Label112.Text = My.Settings.Player2Name
        Label113.Text = My.Settings.Player3Name
        Label114.Text = My.Settings.Player4Name
        If (My.Settings.Players = "3") Then
            Label103.Visible = True
            PictureBox104.Visible = True
            Label107.Visible = True
        ElseIf (My.Settings.Players = "4") Then
            Label103.Visible = True
            PictureBox104.Visible = True
            Label107.Visible = True
            Label104.Visible = True
            PictureBox105.Visible = True
            Label108.Visible = True
        End If
        PrivLocation = New Point(11, 7)
        For j = 0 To 48
            For i = 0 To 95
                MassCoord(i, j) = PrivLocation
                PrivLocation += New Point(14, 0)
            Next
            PrivLocation.X = 11
            PrivLocation.Y += 14
        Next
        Rules.Visible = True
        AttachPic.Visible = True
        ShieldPic.Visible = True
        TurnPic.Visible = True
        SkipPic.Visible = True
        RulesCont.Visible = True
    End Sub

    'Выбор объекта и создание меню радом с объектом
    Private Sub Object_MouseClick(sender As Object, e As MouseEventArgs)
        Dim Obj As PictureBox
        Dim Player As String = ""
        If (Active = False) Then
            Obj = sender
            EnemyUnit = Nothing
            TurnAction = Nothing
            UnitAction = sender
            ObjectClick = sender
            UnitObj = sender
            LengthName = 11
            SelectOr()
            If (NotAction = True) Then
                Exit Sub
            End If
            If (ButtonAction(0) IsNot Nothing) Then
                If (Mid(UnitAction.Name, 11) <> Mid(ButtonAction(0).Name, 7)) Then
                    For i = 0 To 7
                        Controls.Remove(ButtonAction(i))
                        ButtonAction(i) = Nothing
                    Next
                End If
            End If
            If (Me.Controls("Label" & Mid(Obj.Name, 11)) IsNot Nothing) Then
                PanelInfo = True
            End If
            If (PanelInfo = True) Then
                Panel = Me.Controls("Panel" & Mid(Obj.Name, 11))
                TextLabel = Me.Controls("Label" & Mid(Obj.Name, 11))
                Attach = Me.Controls("ButtonAttach" & Mid(Obj.Name, 11))
                Shield = Me.Controls("ButtonShield" & Mid(Obj.Name, 11))
                Turn = Me.Controls("ButtonTurn" & Mid(Obj.Name, 11))
                Skip = Me.Controls("ButtonSkip" & Mid(Obj.Name, 11))
                Controls.Remove(Panel)
                Controls.Remove(TextLabel)
                Controls.Remove(Attach)
                Controls.Remove(Shield)
                Controls.Remove(Turn)
                Controls.Remove(Skip)
                PanelInfo = False
            Else
                Controls.Remove(Panel)
                Controls.Remove(TextLabel)
                Controls.Remove(Attach)
                Controls.Remove(Shield)
                Controls.Remove(Turn)
                Controls.Remove(Skip)
                Panel = New Panel With {
                    .Size = New Size(100, 80),
                    .Location = New Point(Obj.Location.X - 40, Obj.Location.Y + 30),
                    .BackColor = Color.Azure,
                    .Name = "Panel" & Mid(Obj.Name, 11),
                    .BorderStyle = BorderStyle.FixedSingle
                }
                If (Panel.Location.Y <= 6) Then
                    Panel.Location = New Point(Panel.Location.X, Panel.Location.Y + Math.Abs(6 - Panel.Location.Y))
                ElseIf (Panel.Location.X <= 10) Then
                    Panel.Location = New Point(Panel.Location.X + Math.Abs(10 - Panel.Location.X), Panel.Location.Y)
                ElseIf (Panel.Location.Y >= 700) Then
                    Panel.Location = New Point(Panel.Location.X, Panel.Location.Y - Math.Abs(700 - Panel.Location.Y))
                ElseIf (Panel.Location.X >= 1260) Then
                    Panel.Location = New Point(Panel.Location.X - Math.Abs(1260 - Panel.Location.X), Panel.Location.Y)
                End If

                If (Obj.BackColor = Color.Red) Then
                    Player = My.Settings.Player1Name
                ElseIf (Obj.BackColor = Color.Orange) Then
                    Player = My.Settings.Player2Name
                ElseIf (Obj.BackColor = Color.Yellow) Then
                    Player = My.Settings.Player3Name
                ElseIf (Obj.BackColor = Color.Lime) Then
                    Player = My.Settings.Player4Name
                End If
                TextLabel = New Label With {
                    .Text = Player & vbLf & "Имя: Солдат " & Mid(Obj.Name, 11) & vbLf & "ОЗ: " & UnitsHPInfo(Mid(Obj.Name, 11)) & "/100",
                    .Font = New Font("Microsoft Sans Serif", 7),
                    .Location = Panel.Location + New Point(5, 5),
                    .BackColor = Color.Azure,
                    .Size = New Size(90, 50),
                    .Name = "Label" & Mid(Obj.Name, 11)
                }
                Controls.Add(Panel)
                Controls.Add(TextLabel)
                Panel.BringToFront()
                TextLabel.BringToFront()
                If (Obj.BackColor = PlayerPlay) Then
                    Attach = New Button With {
                        .Location = TextLabel.Location + New Point(0, 40),
                        .Size = New Size(20, 20),
                        .BackgroundImage = My.Resources.Attach,
                        .BackgroundImageLayout = ImageLayout.Stretch,
                        .FlatStyle = FlatStyle.Flat,
                        .Name = "ButtonAttach" & Mid(Obj.Name, 11)
                     }
                    Attach.FlatAppearance.BorderSize = 0
                    Shield = New Button With {
                        .Location = TextLabel.Location + New Point(20, 40),
                        .Size = New Size(20, 20),
                        .BackgroundImage = My.Resources.Shield,
                        .BackgroundImageLayout = ImageLayout.Stretch,
                        .FlatStyle = FlatStyle.Flat,
                        .Name = "ButtonShield" & Mid(Obj.Name, 11)
                     }
                    Shield.FlatAppearance.BorderSize = 0
                    Turn = New Button With {
                        .Location = TextLabel.Location + New Point(40, 40),
                        .Size = New Size(20, 20),
                        .BackgroundImage = My.Resources.Turn,
                        .BackgroundImageLayout = ImageLayout.Stretch,
                        .FlatStyle = FlatStyle.Flat,
                        .Name = "ButtonTurn" & Mid(Obj.Name, 11)
                     }
                    Turn.FlatAppearance.BorderSize = 0
                    Skip = New Button With {
                        .Location = TextLabel.Location + New Point(60, 40),
                        .Size = New Size(20, 20),
                        .BackgroundImage = My.Resources.Skip,
                        .BackgroundImageLayout = ImageLayout.Stretch,
                        .FlatStyle = FlatStyle.Flat,
                        .Name = "ButtonSkip" & Mid(Obj.Name, 11)
                     }
                    Skip.FlatAppearance.BorderSize = 0
                    If (ButtonAction(0) IsNot Nothing) Then
                        If (Mid(Attach.Name, 13) = Mid(ButtonAction(0).Name, 9)) Then
                            Attach.FlatAppearance.BorderSize = 2
                        ElseIf (Mid(Shield.Name, 13) = Mid(ButtonAction(0).Name, 9)) Then
                            Shield.FlatAppearance.BorderSize = 2
                        End If
                    Else
                        Attach.FlatAppearance.BorderSize = 0
                        Shield.FlatAppearance.BorderSize = 0
                    End If
                    If (AttackTrigger(Mid(Attach.Name, 13)) = True) Then
                        Attach.FlatAppearance.BorderSize = 2
                        Attach.FlatAppearance.BorderColor = Color.Red
                        Turn.FlatAppearance.BorderSize = 2
                        Turn.FlatAppearance.BorderColor = Color.Red
                        Shield.FlatAppearance.BorderSize = 2
                        Shield.FlatAppearance.BorderColor = Color.Red
                    End If
                    If (TurnTrigger(Mid(Turn.Name, 11)) = True) Then
                        Turn.FlatAppearance.BorderSize = 2
                        Turn.FlatAppearance.BorderColor = Color.Red
                    End If
                    If (ShieldTrigger(Mid(Shield.Name, 13)) = True) Then
                        Attach.FlatAppearance.BorderSize = 2
                        Attach.FlatAppearance.BorderColor = Color.Red
                        Turn.FlatAppearance.BorderSize = 2
                        Turn.FlatAppearance.BorderColor = Color.Red
                        Shield.FlatAppearance.BorderSize = 2
                        Shield.FlatAppearance.BorderColor = Color.Red
                    End If
                    Controls.Add(Attach)
                    Attach.BringToFront()
                    Controls.Add(Shield)
                    Shield.BringToFront()
                    Controls.Add(Turn)
                    Turn.BringToFront()
                    Controls.Add(Skip)
                    Skip.BringToFront()
                    AddHandler(Controls("ButtonAttach" & Mid(Obj.Name, 11)).Click), AddressOf AttachButton_MouseClick
                    AddHandler(Controls("ButtonShield" & Mid(Obj.Name, 11)).Click), AddressOf ShieldButton_MouseClick
                    AddHandler(Controls("ButtonTurn" & Mid(Obj.Name, 11)).Click), AddressOf TurnButton_MouseClick
                    AddHandler(Controls("ButtonSkip" & Mid(Obj.Name, 11)).Click), AddressOf SkipButton_MouseClick
                End If
            End If
        End If
    End Sub

    'Кнопка атаки
    Private Sub AttachButton_MouseClick(sender As Object, e As MouseEventArgs)
        UnitObj = sender
        If (AttackTrigger(Mid(UnitObj.Name, 13)) = False) Then
            SelectOr()
            If (EnemyUnit Is Nothing) Then
                Exit Sub
            End If
            If (EnemyUnit.BackColor <> UnitAction.BackColor) Then
                Player_Turn()
                Shield_Sub()
                If (ShieldActivate(Mid(UnitObj.Name, 13)) = True And (CubeNum <> 3)) Then
                    UnitObj.FlatAppearance.BorderSize = 2
                    UnitObj.FlatAppearance.BorderColor = Color.Red
                    Controls.Remove(Controls("Panel" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("Label" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonAttach" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonShield" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonTurn" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonSkip" & Mid(UnitObj.Name, 13)))
                    For i = 0 To 7
                        Controls.Remove(ButtonAction(i))
                        ButtonAction(i) = Nothing
                    Next
                End If
                If (ShieldActivate(Mid(UnitObj.Name, 13)) = False And (CubeNum <> 3)) Then
                    EnemyUnit.Visible = False
                    If (UnitAction.BackColor = Color.Red) Then
                        Label105.Text = Label105.Text + 1
                    ElseIf (UnitAction.BackColor = Color.Orange) Then
                        Label106.Text = Label106.Text + 1
                    ElseIf (UnitAction.BackColor = Color.Yellow) Then
                        Label107.Text = Label107.Text + 1
                    ElseIf (UnitAction.BackColor = Color.Lime) Then
                        Label108.Text = Label108.Text + 1
                    End If
                    UnitObj.FlatAppearance.BorderSize = 2
                    UnitObj.FlatAppearance.BorderColor = Color.Red
                    Controls.Remove(Controls("Panel" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("Label" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonAttach" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonShield" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonTurn" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonSkip" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(EnemyUnit)
                    UnitAction = Nothing
                    For i = 0 To 7
                        Controls.Remove(ButtonAction(i))
                        ButtonAction(i) = Nothing
                    Next
                End If
                If (CubeNum = 3) Then
                    UnitAction.Visible = False
                    If (EnemyUnit.BackColor = Color.Red) Then
                        Label105.Text = Label105.Text + 1
                    ElseIf (EnemyUnit.BackColor = Color.Orange) Then
                        Label106.Text = Label106.Text + 1
                    ElseIf (EnemyUnit.BackColor = Color.Yellow) Then
                        Label107.Text = Label107.Text + 1
                    ElseIf (EnemyUnit.BackColor = Color.Lime) Then
                        Label108.Text = Label108.Text + 1
                    End If
                    UnitObj.FlatAppearance.BorderSize = 2
                    UnitObj.FlatAppearance.BorderColor = Color.Red
                    Controls.Remove(Controls("Panel" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("Label" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonAttach" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonShield" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonTurn" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(Controls("ButtonSkip" & Mid(UnitObj.Name, 13)))
                    Controls.Remove(UnitAction)
                    For i = 0 To 7
                        Controls.Remove(ButtonAction(i))
                        ButtonAction(i) = Nothing
                    Next
                End If
            End If
            OldObj = sender
            EnemyUnit = Nothing
            AttackTrigger(Mid(UnitObj.Name, 13)) = True
            TurnTrigger(Mid(UnitObj.Name, 13)) = True
            ShieldTrigger(Mid(UnitObj.Name, 13)) = True
            Active = False
            GameWin()
        End If
    End Sub

    'Функция атаки
    Private Sub Attach_Sub()
        Dim Butt As Button
        If (TurnTrigger(Mid(UnitAction.Name, 11)) = False) Then
            If (EnemyUnit IsNot Nothing) Then
                If (Controls("ButtonAttach" & Mid(UnitObj.Name, LengthName)) IsNot Nothing) Then
                    Butt = Controls("ButtonAttach" & Mid(UnitObj.Name, LengthName))
                    Butt.FlatAppearance.BorderSize = 1
                End If
                CreateField()
                EnemyUnit.BringToFront()
                If (Controls("Panel" & Mid(UnitObj.Name, 11)) IsNot Nothing) Then
                    Controls("Panel" & Mid(UnitObj.Name, 11)).BringToFront()
                    Controls("Label" & Mid(UnitObj.Name, 11)).BringToFront()
                    If (Controls("ButtonAttach" & Mid(UnitObj.Name, 11)) IsNot Nothing) Then
                        Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).BringToFront()
                        Controls("ButtonShield" & Mid(UnitObj.Name, 11)).BringToFront()
                        Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).BringToFront()
                        Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).BringToFront()
                    End If
                    If (Controls("Cube") IsNot Nothing) Then
                        Controls("Cube").BringToFront()
                    End If
                End If
            End If
            LengthName = 13
        End If
    End Sub

    'Кнопка щита
    Private Sub ShieldButton_MouseClick(sender As Object, e As MouseEventArgs)
        UnitObj = sender
        If (ShieldTrigger(Mid(UnitObj.Name, 13)) = False) Then
            ShieldActivate(Mid(UnitObj.Name, 13)) = True
            UnitObj.FlatAppearance.BorderSize = 2
            UnitObj.FlatAppearance.BorderColor = Color.Red
            Controls.Remove(Controls("Panel" & Mid(UnitObj.Name, 13)))
            Controls.Remove(Controls("Label" & Mid(UnitObj.Name, 13)))
            Controls.Remove(Controls("ButtonAttach" & Mid(UnitObj.Name, 13)))
            Controls.Remove(Controls("ButtonShield" & Mid(UnitObj.Name, 13)))
            Controls.Remove(Controls("ButtonTurn" & Mid(UnitObj.Name, 13)))
            Controls.Remove(Controls("ButtonSkip" & Mid(UnitObj.Name, 13)))
            Controls.Remove(Controls("Cube"))
            For i = 0 To 7
                Controls.Remove(ButtonAction(i))
                ButtonAction(i) = Nothing
            Next
            Player_Turn()
            AttackTrigger(Mid(UnitObj.Name, 13)) = True
            ShieldTrigger(Mid(UnitObj.Name, 13)) = True
            Active = False
            CheckDay()
        End If

    End Sub

    'Кнопка выхода
    Private Sub ExitGame_Click(sender As Object, e As EventArgs) Handles ExitGame.Click
        Me.Close()
        MenuGame.Show()
    End Sub

    'Кнопка закрытия правил
    Private Sub RulesCont_Click(sender As Object, e As EventArgs) Handles RulesCont.Click
        Rules.Visible = False
        AttachPic.Visible = False
        ShieldPic.Visible = False
        TurnPic.Visible = False
        SkipPic.Visible = False
        RulesCont.Visible = False
        RandomMove()
    End Sub

    'Функция щита
    Private Sub Shield_Sub()
        Cube_Throw()
        If (Controls("Cube").Tag = "Resources._1") Then
            CubeNum = 1
        ElseIf (Controls("Cube").Tag = "Resources._2") Then
            CubeNum = 2
        ElseIf (Controls("Cube").Tag = "Resources._3") Then
            CubeNum = 3
        ElseIf (Controls("Cube").Tag = "Resources._4") Then
            CubeNum = 1
        ElseIf (Controls("Cube").Tag = "Resources._5") Then
            CubeNum = 2
        ElseIf (Controls("Cube").Tag = "Resources._6") Then
            CubeNum = 3
        End If
        If (CubeNum = 1) Then
            ShieldActivate(Mid(UnitObj.Name, 13)) = True
        ElseIf (CubeNum = 2) Then
            ShieldActivate(Mid(UnitObj.Name, 13)) = False
        End If
    End Sub

    'Кнопка хода
    Private Sub TurnButton_MouseClick(sender As Object, e As MouseEventArgs)
        UnitObj = sender
        TurnAction = sender
        If (TurnTrigger(Mid(UnitObj.Name, 11)) = False) Then
            EnemyUnit = Nothing
            ObjectClick = Controls("PictureBox" & Mid(sender.Name, 11))
            Cube_Throw()
            Active = True
        End If
        OldObj = sender
    End Sub

    'Функция хода
    Private Sub TurnSub()
        Dim Butt As Button
        Butt = Controls("ButtonAttach" & Mid(UnitObj.Name, 11))
        Butt.FlatAppearance.BorderSize = 0
        Butt = Controls("ButtonTurn" & Mid(UnitObj.Name, 11))
        Butt.FlatAppearance.BorderSize = 1
        If (OldObj IsNot Nothing) Then
            ButtonAction(8) = Controls("Button" & Mid(OldObj.Name, 7))
        End If
        LengthName = 11
        SelectOr()
        CreateField()
        For i = 0 To 7
            If (ButtonAction(i) IsNot Nothing) Then
                ButtonAction(i).Enabled = True
            End If
        Next
        TurnTrigger(Mid(UnitObj.Name, 11)) = True
        Butt.Enabled = False
        Butt.FlatAppearance.BorderSize = 2
        Butt.FlatAppearance.BorderColor = Color.Red
        NotAction = True
    End Sub

    'Кнопка пропуска хода
    Private Sub SkipButton_MouseClick(sender As Object, e As MouseEventArgs)
        UnitObj = sender
        Controls.Remove(Controls("Panel" & Mid(UnitObj.Name, 11)))
        Controls.Remove(Controls("Label" & Mid(UnitObj.Name, 11)))
        Controls.Remove(Controls("ButtonAttach" & Mid(UnitObj.Name, 11)))
        Controls.Remove(Controls("ButtonShield" & Mid(UnitObj.Name, 11)))
        Controls.Remove(Controls("ButtonTurn" & Mid(UnitObj.Name, 11)))
        Controls.Remove(Controls("ButtonSkip" & Mid(UnitObj.Name, 11)))
        Controls.Remove(Controls("Cube"))
        For i = 0 To 7
            Controls.Remove(ButtonAction(i))
            ButtonAction(i) = Nothing
        Next
        Player_Turn()
        AttackTrigger(Mid(UnitObj.Name, 11)) = True
        ShieldTrigger(Mid(UnitObj.Name, 11)) = True
        TurnTrigger(Mid(UnitObj.Name, 11)) = True
        Active = False
        CheckDay()
    End Sub

    'Создание кнопок хода или действия
    Private Sub CreateField()
        Dim Butt As Button
        If (ButtonAction(0) IsNot Nothing) Then
            Trigger = True
        End If
        If (UnitAction Is Nothing) Then
            Exit Sub
        End If
        If (Trigger = True) Then
            If (Controls("ButtonAttach" & Mid(UnitObj.Name, LengthName)) IsNot Nothing) Then
                Butt = Controls("ButtonAttach" & Mid(UnitObj.Name, LengthName))
                Butt.FlatAppearance.BorderSize = 0
                Butt = Controls("ButtonTurn" & Mid(UnitObj.Name, LengthName))
                Butt.FlatAppearance.BorderSize = 0
            End If
            If (ButtonAction(8) IsNot Nothing) Then
                ButtonAction(8).FlatAppearance.BorderSize = 0
            End If
            For i = 0 To 7
                Controls.Remove(ButtonAction(i))
                ButtonAction(i) = Nothing
            Next
            Trigger = False
        Else
            EnemyRoundPlayer()
            LengthName = 11
            For i = 1 To 8
                Butt = New Button With {
                    .Size = New Size(13, 13),
                    .BackColor = Color.Gray,
                    .FlatStyle = FlatStyle.Flat,
                    .Name = "Round" & i & Mid(UnitObj.Name, LengthName)
                }
                If (EnemyUnit IsNot Nothing) Then
                    If (EnemyUnit.BackColor <> UnitAction.BackColor) Then
                        Butt.BackColor = Color.Tomato
                    Else
                        Butt.BackColor = Color.Gray
                    End If
                End If
                Butt.FlatAppearance.BorderSize = 0
                Controls.Add(Butt)
                AddHandler(Butt.Click), AddressOf Action
                Butt.BringToFront()

                If (TurnAction Is Nothing) Then
                    TurnAction = UnitAction
                End If
                If (i = 1) Then
                    Butt.Location = Controls("PictureBox" & Mid(TurnAction.Name, 11)).Location - New Point(14, 14)
                    If (Butt.Location.X < 10 Or Butt.Location.Y < 6) Then
                        Butt.Visible = False
                    End If
                    Butt.Enabled = False
                    ButtonAction(0) = Butt
                ElseIf (i = 2) Then
                    Butt.Location = Controls("PictureBox" & Mid(TurnAction.Name, 11)).Location - New Point(0, 14)
                    If (Butt.Location.Y < 6) Then
                        Butt.Visible = False
                    End If
                    Butt.Enabled = False
                    ButtonAction(1) = Butt
                ElseIf (i = 3) Then
                    Butt.Location = Controls("PictureBox" & Mid(TurnAction.Name, 11)).Location - New Point(-14, 14)
                    If (Butt.Location.X > 1341 Or Butt.Location.Y < 6) Then
                        Butt.Visible = False
                    End If
                    Butt.Enabled = False
                    ButtonAction(2) = Butt
                ElseIf (i = 4) Then
                    Butt.Location = Controls("PictureBox" & Mid(TurnAction.Name, 11)).Location - New Point(-14, 0)
                    If (Butt.Location.X > 1341) Then
                        Butt.Visible = False
                    End If
                    Butt.Enabled = False
                    ButtonAction(3) = Butt
                ElseIf (i = 5) Then
                    Butt.Location = Controls("PictureBox" & Mid(TurnAction.Name, 11)).Location - New Point(-14, -14)
                    If (Butt.Location.X > 1341 Or Butt.Location.Y > 680) Then
                        Butt.Visible = False
                    End If
                    Butt.Enabled = False
                    ButtonAction(4) = Butt
                ElseIf (i = 6) Then
                    Butt.Location = Controls("PictureBox" & Mid(TurnAction.Name, 11)).Location - New Point(0, -14)
                    If (Butt.Location.Y > 680) Then
                        Butt.Visible = False
                    End If
                    Butt.Enabled = False
                    ButtonAction(5) = Butt
                ElseIf (i = 7) Then
                    Butt.Location = Controls("PictureBox" & Mid(TurnAction.Name, 11)).Location - New Point(14, -14)
                    If (Butt.Location.X < 10 Or Butt.Location.Y > 680) Then
                        Butt.Visible = False
                    End If
                    Butt.Enabled = False
                    ButtonAction(6) = Butt
                ElseIf (i = 8) Then
                    Butt.Location = Controls("PictureBox" & Mid(TurnAction.Name, 11)).Location - New Point(14, 0)
                    If (Butt.Location.X < 10) Then
                        Butt.Visible = False
                    End If
                    Butt.Enabled = False
                    ButtonAction(7) = Butt
                End If
            Next
            EnemyRoundPlayer()
            If (Controls("Panel" & Mid(UnitObj.Name, LengthName)) IsNot Nothing) Then
                Controls("Panel" & Mid(UnitObj.Name, LengthName)).BringToFront()
                Controls("Label" & Mid(UnitObj.Name, LengthName)).BringToFront()
                If (Controls("ButtonAttach" & Mid(UnitObj.Name, LengthName)) IsNot Nothing) Then
                    Controls("ButtonAttach" & Mid(UnitObj.Name, LengthName)).BringToFront()
                    Controls("ButtonShield" & Mid(UnitObj.Name, LengthName)).BringToFront()
                    Controls("ButtonTurn" & Mid(UnitObj.Name, LengthName)).BringToFront()
                    Controls("ButtonSkip" & Mid(UnitObj.Name, LengthName)).BringToFront()
                End If
            End If
        End If
    End Sub

    'Функция взаимодействия кнопки хода или дейстия
    Private Sub Action(sender As Object, e As EventArgs)
        Dim Obj As Button
        Obj = sender
        If (Controls("Panel" & Mid(UnitObj.Name, 11)) IsNot Nothing) Then
            If (Obj.Location.X > Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X) Then
                Controls("Panel" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("Panel" & Mid(UnitObj.Name, 11)).Location.X + Math.Abs(Obj.Location.X - Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X), Controls("Panel" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("Label" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("Label" & Mid(UnitObj.Name, 11)).Location.X + Math.Abs(Obj.Location.X - Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X), Controls("Label" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location.X + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location.X + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location.X + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location.X + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location.Y)
            End If
            If (Obj.Location.Y > Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y) Then
                Controls("Panel" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("Panel" & Mid(UnitObj.Name, 11)).Location.X, Controls("Panel" & Mid(UnitObj.Name, 11)).Location.Y + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
                Controls("Label" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("Label" & Mid(UnitObj.Name, 11)).Location.X, Controls("Label" & Mid(UnitObj.Name, 11)).Location.Y + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
                Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location.X, Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location.Y + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
                Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location.X, Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location.Y + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
                Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location.X, Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location.Y + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
                Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location.X, Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location.Y + Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
            End If
            If (Obj.Location.X < Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X) Then
                Controls("Panel" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("Panel" & Mid(UnitObj.Name, 11)).Location.X - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("Panel" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("Label" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("Label" & Mid(UnitObj.Name, 11)).Location.X - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("Label" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location.X - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location.X - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location.X - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location.Y)
                Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location.X - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X - Obj.Location.X), Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location.Y)
            End If
            If (Obj.Location.Y < Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y) Then
                Controls("Panel" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("Panel" & Mid(UnitObj.Name, 11)).Location.X, Controls("Panel" & Mid(UnitObj.Name, 11)).Location.Y - Math.Abs(Obj.Location.Y - Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y))
                Controls("Label" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("Label" & Mid(UnitObj.Name, 11)).Location.X, Controls("Label" & Mid(UnitObj.Name, 11)).Location.Y - Math.Abs(Obj.Location.Y - Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y))
                Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location.X, Controls("ButtonAttach" & Mid(UnitObj.Name, 11)).Location.Y - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
                Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location.X, Controls("ButtonShield" & Mid(UnitObj.Name, 11)).Location.Y - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
                Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location.X, Controls("ButtonTurn" & Mid(UnitObj.Name, 11)).Location.Y - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
                Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location = New Point(Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location.X, Controls("ButtonSkip" & Mid(UnitObj.Name, 11)).Location.Y - Math.Abs(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y - Obj.Location.Y))
            End If
        End If
        If (Xod = 1) Then
            Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location = Obj.Location
            If (EnemyUnit Is Nothing) Then
                Trigger = False
            Else
                Trigger = True
            End If
            ObjectClick = Obj
            UnitObj = Obj
            LengthName = 9
            For i = 0 To 7
                Controls.Remove(ButtonAction(i))
                ButtonAction(i) = Nothing
            Next
            CreateField()
            SelectOr()
            LengthName = 7
            UnitsCoord(Mid(Controls("PictureBox" & Mid(UnitObj.Name, LengthName)).Name, 11), 0) = Controls("PictureBox" & Mid(UnitObj.Name, LengthName)).Location.X
            UnitsCoord(Mid(Controls("PictureBox" & Mid(UnitObj.Name, LengthName)).Name, 11), 1) = Controls("PictureBox" & Mid(UnitObj.Name, LengthName)).Location.Y
            CheckDay()
            EnemyRoundPlayer()
            If (EnemyUnit Is Nothing) Then
                Controls.Remove(Controls("Panel" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("Label" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("ButtonAttach" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("ButtonShield" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("ButtonTurn" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("ButtonSkip" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("Cube"))
                AttackTrigger(Mid(UnitObj.Name, 7)) = True
                ShieldActivate(Mid(UnitObj.Name, 7)) = True
                TurnTrigger(Mid(UnitObj.Name, 7)) = True
                Active = False
                Player_Turn()
            ElseIf (EnemyUnit IsNot Nothing And EnemyUnit.BackColor = UnitAction.BackColor) Then
                Controls.Remove(Controls("Panel" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("Label" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("ButtonAttach" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("ButtonShield" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("ButtonTurn" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("ButtonSkip" & Mid(UnitObj.Name, 7)))
                Controls.Remove(Controls("Cube"))
                AttackTrigger(Mid(UnitObj.Name, 7)) = True
                ShieldActivate(Mid(UnitObj.Name, 7)) = True
                TurnTrigger(Mid(UnitObj.Name, 7)) = True
                Active = False
                Player_Turn()
            End If
            If (EnemyUnit Is Nothing) Then
                For i = 0 To 7
                    Controls.Remove(ButtonAction(i))
                    ButtonAction(i) = Nothing
                Next
            End If
            Trigger = False
        ElseIf (Xod = 2) Then
            Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location = Obj.Location
            EnemyRoundPlayer()
            For i = 0 To 7
                Controls.Remove(ButtonAction(i))
                ButtonAction(i) = Nothing
            Next
            UnitsCoord(Mid(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Name, 11), 0) = Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.X
            UnitsCoord(Mid(Controls("PictureBox" & Mid(UnitObj.Name, 11)).Name, 11), 1) = Controls("PictureBox" & Mid(UnitObj.Name, 11)).Location.Y
            Trigger = False
            CreateField()
            SelectOr()
            For i = 0 To 7
                If (ButtonAction(i) IsNot Nothing) Then
                    ButtonAction(i).Enabled = True
                End If
            Next
        End If
        Xod -= 1
        NotAction = False
    End Sub

    'Функция проверки действия всех солдатов
    Private Sub CheckDay()
        For j = 1 To My.Settings.Players * 10
            If (Controls("PictureBox" & j) Is Nothing) Then
                TurnTrigger(j) = True
            End If
            If (TurnTrigger(j) = True) Then
                Trigger = True
            Else
                Trigger = False
                Exit For
            End If
        Next
        If (Trigger = True) Then
            For j = 1 To My.Settings.Players * 10
                TurnTrigger(j) = False
                ShieldActivate(j) = False
                AttackTrigger(j) = False
                ShieldTrigger(j) = False
            Next
            Trigger = False
            Days.Text = "День " & Mid(Days.Text, 6) + 1
        End If
    End Sub

    'Функия поиска вражеских солдат вокруг объекта и атака на них
    Private Sub SelectOr()
        Dim i As Integer
        For i = 1 To My.Settings.Players * 10
            If (Controls("PictureBox" & i) Is Nothing) Then
                Continue For
            End If
            If (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(14, 14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                If (UnitAction.BackColor <> EnemyUnit.BackColor) Then
                    Attach_Sub()
                    Exit Sub
                End If
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(0, 14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                If (UnitAction.BackColor <> EnemyUnit.BackColor) Then
                    Attach_Sub()
                    Exit Sub
                End If
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(-14, 14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                If (UnitAction.BackColor <> EnemyUnit.BackColor) Then
                    Attach_Sub()
                    Exit Sub
                End If
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(-14, 0)) Then
                EnemyUnit = Controls("PictureBox" & i)
                If (UnitAction.BackColor <> EnemyUnit.BackColor) Then
                    Attach_Sub()
                    Exit Sub
                End If
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(-14, -14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                If (UnitAction.BackColor <> EnemyUnit.BackColor) Then
                    Attach_Sub()
                    Exit Sub
                End If
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(0, -14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                If (UnitAction.BackColor <> EnemyUnit.BackColor) Then
                    Attach_Sub()
                    Exit Sub
                End If
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(14, -14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                If (UnitAction.BackColor <> EnemyUnit.BackColor) Then
                    Attach_Sub()
                    Exit Sub
                End If
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(14, 0)) Then
                EnemyUnit = Controls("PictureBox" & i)
                If (UnitAction.BackColor <> EnemyUnit.BackColor) Then
                    Attach_Sub()
                    Exit Sub
                End If
            End If
        Next
    End Sub

    'Функия поиска вражеских солдат вокруг объекта
    Private Sub EnemyRoundPlayer()
        Dim i As Integer
        EnemyUnit = Nothing
        For i = 1 To My.Settings.Players * 10
            If (Controls("PictureBox" & i) Is Nothing) Then
                Continue For
            End If
            If (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(14, 14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                EnemyUnit.BringToFront
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(0, 14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                EnemyUnit.BringToFront
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(-14, 14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                EnemyUnit.BringToFront
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(-14, 0)) Then
                EnemyUnit = Controls("PictureBox" & i)
                EnemyUnit.BringToFront
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(-14, -14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                EnemyUnit.BringToFront
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(0, -14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                EnemyUnit.BringToFront
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(14, -14)) Then
                EnemyUnit = Controls("PictureBox" & i)
                EnemyUnit.BringToFront
            ElseIf (Controls("PictureBox" & i).Location = ObjectClick.Location - New Point(14, 0)) Then
                EnemyUnit = Controls("PictureBox" & i)
                EnemyUnit.BringToFront
            End If
        Next
    End Sub


    'Отображение игроков
    Private Sub RandomMove()
        PictureBox106.Visible = True
        For i = 110 To 118
            Controls("Label" & i).Visible = True
            Controls("Label" & i).BringToFront()
        Next
        If (My.Settings.Players = "2") Then
            Label113.Visible = False
            Label117.Visible = False
            Label114.Visible = False
            Label118.Visible = False
        ElseIf (My.Settings.Players = "3") Then
            Label114.Visible = False
            Label118.Visible = False
        End If
        Button101.Visible = True
        Button101.BringToFront()
        Label111.BorderStyle = BorderStyle.FixedSingle
    End Sub

    'Бросание кубика
    Private Sub Button101_Click(sender As Object, e As EventArgs) Handles Button101.Click
        UnitObj = sender
        If (NumRand = 111 + My.Settings.Players) Then
            PlayerMove()
            PictureBox106.Visible = False
            For i = 110 To 118
                Controls("Label" & i).Visible = False
            Next
            Button101.Visible = False
            PictureBox101.Visible = True
            CreateUnits()
            Player_Turn()
            Controls.Remove(Controls("Cube"))
        Else
            Cube_Throw()
        End If
    End Sub

    'Переход кубика другому игроку
    Private Sub RandomTurnPlayer()
        Dim lab As Label
        If (NumRand <> 111 + My.Settings.Players) Then
            NumRand += 1
            lab = Controls("Label" & NumRand)
            lab.BorderStyle = BorderStyle.FixedSingle
            If (NumRand = 111 + My.Settings.Players) Then
                lab.BorderStyle = BorderStyle.None
            End If
        End If
        If (Label111.BorderStyle = BorderStyle.FixedSingle) Then
            Label115.Text = CubeNum
            Label111.BorderStyle = BorderStyle.None
        ElseIf (Label112.BorderStyle = BorderStyle.FixedSingle) Then
            Label116.Text = CubeNum
            Label112.BorderStyle = BorderStyle.None
        ElseIf (Label113.BorderStyle = BorderStyle.FixedSingle And (My.Settings.Players = 3 Or My.Settings.Players = 4)) Then
            Label117.Text = CubeNum
            Label113.BorderStyle = BorderStyle.None
        ElseIf (Label114.BorderStyle = BorderStyle.FixedSingle And My.Settings.Players = 4) Then
            Label118.Text = CubeNum
            Label114.BorderStyle = BorderStyle.None
        End If
        If (NumRand = 111 + My.Settings.Players) Then
            Button101.Text = "Начать"
        End If
    End Sub

    'Последовательность хода игроков
    Private Sub PlayerMove()
        Dim max, n, id As Integer
        Dim mass1(0 To 3) As Integer
        Dim mass2(0 To 3) As Integer
        Dim mass3(0 To 3) As Integer
        max = Label115.Text
        n = 115
        For i = 0 To My.Settings.Players - 1
            mass1(i) = Controls("Label" & n).Text
            n += 1
        Next
        For i = 0 To My.Settings.Players - 1
            For j = 0 To My.Settings.Players - 1
                If (max < mass1(j)) Then
                    max = mass1(j)
                    id = j

                End If
            Next
            mass2(i) = max
            mass3(i) = id
            mass1(id) = Nothing
            max = 0
        Next
        n = 1
        For i = 0 To My.Settings.Players - 1
            Controls("Label" & 119 + mass3(i)).Text = n
            Controls("Label" & 119 + mass3(i)).Visible = True
            Controls("Label" & 119 + mass3(i)).BringToFront()
            n += 1
        Next
    End Sub

    'Создание солдат
    Private Sub CreateUnits()
        Dim rand As New Random()
        Dim Pic As PictureBox
        Dim Num As Integer
        Dim x, y As Integer()
        Num = 1
        x = Enumerable.Range(0, 95).OrderBy(Function(n) rand.Next).Take(95).ToArray()
        y = Enumerable.Range(0, 48).OrderBy(Function(n) rand.Next).Take(48).ToArray()
        ReDim AttackTrigger(0 To My.Settings.Players * 10)
        ReDim TurnTrigger(0 To My.Settings.Players * 10)
        ReDim ShieldTrigger(0 To My.Settings.Players * 10)
        For i = 1 To 10
            Pic = New PictureBox With {
                                    .Location = MassCoord(x(i - 1), y(i - 1)),
                                    .Size = New Size(13, 13),
                                    .BackColor = Color.Red,
                                    .Name = "PictureBox" & Num
                                }
            MassCoordTrigger(17, 5) = True
            Controls.Add(Pic)
            Pic.BringToFront()
            AddHandler(Controls("PictureBox" & Num).Click), AddressOf Object_MouseClick
            UnitsHPInfo(Num) = 100
            UnitsCoord(Num, 0) = Pic.Location.X
            UnitsCoord(Num, 1) = Pic.Location.Y
            Num += 1
        Next
        For i = 11 To 20
            Pic = New PictureBox With {
                                    .Location = MassCoord(x(i - 1), y(i - 1)),
                                    .Size = New Size(13, 13),
                                    .BackColor = Color.Orange,
                                    .Name = "PictureBox" & Num
                                }
            MassCoordTrigger(17, 5) = True
            Controls.Add(Pic)
            Pic.BringToFront()
            AddHandler(Controls("PictureBox" & Num).Click), AddressOf Object_MouseClick
            UnitsHPInfo(Num) = 100
            UnitsCoord(Num, 0) = Pic.Location.X
            UnitsCoord(Num, 1) = Pic.Location.Y
            Num += 1
        Next
        If (My.Settings.Players = 3) Then
            For i = 21 To 30
                Pic = New PictureBox With {
                                        .Location = MassCoord(x(i - 1), y(i - 1)),
                                        .Size = New Size(13, 13),
                                        .BackColor = Color.Yellow,
                                        .Name = "PictureBox" & Num
                                    }
                MassCoordTrigger(17, 5) = True
                Controls.Add(Pic)
                Pic.BringToFront()
                AddHandler(Controls("PictureBox" & Num).Click), AddressOf Object_MouseClick
                UnitsHPInfo(Num) = 100
                UnitsCoord(Num, 0) = Pic.Location.X
                UnitsCoord(Num, 1) = Pic.Location.Y
                Num += 1
            Next
        ElseIf (My.Settings.Players = 4) Then
            For i = 21 To 30
                Pic = New PictureBox With {
                                        .Location = MassCoord(x(i - 1), y(i - 1)),
                                        .Size = New Size(13, 13),
                                        .BackColor = Color.Yellow,
                                        .Name = "PictureBox" & Num
                                    }
                MassCoordTrigger(17, 5) = True
                Controls.Add(Pic)
                Pic.BringToFront()
                AddHandler(Controls("PictureBox" & Num).Click), AddressOf Object_MouseClick
                UnitsHPInfo(Num) = 100
                UnitsCoord(Num, 0) = Pic.Location.X
                UnitsCoord(Num, 1) = Pic.Location.Y
                Num += 1
            Next
            For i = 31 To 40
                Pic = New PictureBox With {
                                        .Location = MassCoord(x(i - 1), y(i - 1)),
                                        .Size = New Size(13, 13),
                                        .BackColor = Color.Lime,
                                        .Name = "PictureBox" & Num
                                    }
                MassCoordTrigger(17, 5) = True
                Controls.Add(Pic)
                Pic.BringToFront()
                AddHandler(Controls("PictureBox" & Num).Click), AddressOf Object_MouseClick
                UnitsHPInfo(Num) = 100
                UnitsCoord(Num, 0) = Pic.Location.X
                UnitsCoord(Num, 1) = Pic.Location.Y
                Num += 1
            Next
        End If
        ExitGame.Visible = True
    End Sub

    'Переход хода
    Private Sub Player_Turn()
        If (NumShield > My.Settings.Players) Then
            NumShield = 1
        End If
        If (Label119.Text = NumShield) Then
            Label102.BorderStyle = BorderStyle.None
            Label103.BorderStyle = BorderStyle.None
            Label104.BorderStyle = BorderStyle.None
            Label102.BackColor = Color.Transparent
            Label103.BackColor = Color.Transparent
            Label104.BackColor = Color.Transparent
            Label101.BorderStyle = BorderStyle.FixedSingle
            Label101.BackColor = Color.Red
            PlayerPlay = Color.Red
            NumShield += 1
        ElseIf (Label120.Text = NumShield) Then
            Label101.BorderStyle = BorderStyle.None
            Label103.BorderStyle = BorderStyle.None
            Label104.BorderStyle = BorderStyle.None
            Label101.BackColor = Color.Transparent
            Label103.BackColor = Color.Transparent
            Label104.BackColor = Color.Transparent
            Label102.BorderStyle = BorderStyle.FixedSingle
            Label102.BackColor = Color.Orange
            PlayerPlay = Color.Orange
            NumShield += 1
        ElseIf (Label121.Text = NumShield) Then
            Label101.BorderStyle = BorderStyle.None
            Label102.BorderStyle = BorderStyle.None
            Label104.BorderStyle = BorderStyle.None
            Label101.BackColor = Color.Transparent
            Label102.BackColor = Color.Transparent
            Label104.BackColor = Color.Transparent
            Label103.BorderStyle = BorderStyle.FixedSingle
            Label103.BackColor = Color.Yellow
            PlayerPlay = Color.Yellow
            NumShield += 1
        ElseIf (Label122.Text = NumShield) Then
            Label101.BorderStyle = BorderStyle.None
            Label102.BorderStyle = BorderStyle.None
            Label103.BorderStyle = BorderStyle.None
            Label101.BackColor = Color.Transparent
            Label102.BackColor = Color.Transparent
            Label103.BackColor = Color.Transparent
            Label104.BorderStyle = BorderStyle.FixedSingle
            Label104.BackColor = Color.Lime
            PlayerPlay = Color.Lime
            NumShield += 1
        End If
    End Sub

    'Создание кубика
    Private Sub Cube_Throw()
        Dim Image As PictureBox
        Controls.Remove(Controls("Cube"))
        Image = New PictureBox With {
            .Location = New Point(645, 457),
            .Font = New Font("Microsoft Sans Serif", 56),
            .ForeColor = Color.Black,
            .Size = New Size(100, 100),
            .BackColor = Color.Transparent,
            .BackgroundImage = My.Resources._1,
            .BackgroundImageLayout = ImageLayout.Stretch,
            .Name = "Cube"
        }
        Controls.Add(Image)
        Image.BringToFront()
        Timer1()
    End Sub

    'Бросок кубика
    Private Sub Timer1()
        Dim rand As New Random()
        Dim Num As Integer()
        Dim i, CubeNumXod As Integer
        While Time < 30
            Threading.Thread.Sleep(3)
            Num = Enumerable.Range(1, 6).OrderBy(Function(n) rand.Next).Take(6).ToArray()
            Time += 1
            i += 1
            Controls("Cube").BringToFront()
            If (Num(0) = 1) Then
                Controls("Cube").Tag = "Resources._1"
            ElseIf (Num(0) = 2) Then
                Controls("Cube").Tag = "Resources._2"
            ElseIf (Num(0) = 3) Then
                Controls("Cube").Tag = "Resources._3"
            ElseIf (Num(0) = 4) Then
                Controls("Cube").Tag = "Resources._4"
            ElseIf (Num(0) = 5) Then
                Controls("Cube").Tag = "Resources._5"
            ElseIf (Num(0) = 6) Then
                Controls("Cube").Tag = "Resources._6"
            End If
        End While
        Time = 0
        Controls("Cube").Location = New Point(645, 557)
        If (Controls("Cube").Tag = "Resources._1") Then
            Controls("Cube").BackgroundImage = My.Resources._1
            CubeNum = 1
            CubeNumXod = 1
        ElseIf (Controls("Cube").Tag = "Resources._2") Then
            Controls("Cube").BackgroundImage = My.Resources._2
            CubeNum = 2
            CubeNumXod = 2
        ElseIf (Controls("Cube").Tag = "Resources._3") Then
            Controls("Cube").BackgroundImage = My.Resources._3
            CubeNum = 3
            CubeNumXod = 1
        ElseIf (Controls("Cube").Tag = "Resources._4") Then
            Controls("Cube").BackgroundImage = My.Resources._4
            CubeNum = 4
            CubeNumXod = 2
        ElseIf (Controls("Cube").Tag = "Resources._5") Then
            Controls("Cube").BackgroundImage = My.Resources._5
            CubeNum = 5
            CubeNumXod = 1
        ElseIf (Controls("Cube").Tag = "Resources._6") Then
            Controls("Cube").BackgroundImage = My.Resources._6
            CubeNum = 6
            CubeNumXod = 2
        End If
        If (UnitObj.Name = "Button101") Then
            RandomTurnPlayer()
        End If
        If (UnitObj.Name = "ButtonTurn" & Mid(UnitObj.Name, 11)) Then
            AddHandler(Controls("Cube").Click), AddressOf Cube_Click
            If (CubeNumXod = 1) Then
                Xod = 1
            ElseIf (CubeNumXod = 2) Then
                Xod = 2
            End If
            TurnSub()
        End If
        If (UnitObj.Name = "ButtonShield" & Mid(UnitObj.Name, 11)) Then
        End If
        Controls("Cube").BringToFront()
        Timer2.Start()
    End Sub

    'Удаление кубика
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Time += 1
        If (Time > 20) Then
            Controls.Remove(Controls("Cube"))
            Time = 0
            Timer2.Stop()
        End If
    End Sub

    'Удаление кубика
    Private Sub Cube_Click(sender As Object, e As EventArgs)
        Controls.Remove(sender)
    End Sub

    'Победа
    Private Sub GameWin()
        For i = 1 To 10
            If (Controls("PictureBox" & i) Is Nothing) Then
                RedKill(i - 1) = True
            Else
                RedKill(i - 1) = False
                Continue For
            End If
        Next
        For i = 1 To 10
            If (Controls("PictureBox" & i + 10) Is Nothing) Then
                OrangeKill(i - 1) = True
            Else
                OrangeKill(i - 1) = False
                Continue For
            End If
        Next
        For i = 1 To 10
            If (Controls("PictureBox" & i + 20) Is Nothing) Then
                YellowKill(i - 1) = True
            Else
                YellowKill(i - 1) = False
                Continue For
            End If
        Next
        For i = 1 To 10
            If (Controls("PictureBox" & i + 30) Is Nothing) Then
                LimeKill(i - 1) = True
            Else
                LimeKill(i - 1) = False
                Continue For
            End If
        Next
        For i = 1 To 10
            If (RedKill(i - 1) = True) Then
                RedKillT = True
            Else
                RedKillT = False
                Exit For
            End If
        Next
        For i = 1 To 10
            If (OrangeKill(i - 1) = True) Then
                OrangeKillT = True
            Else
                OrangeKillT = False
                Exit For
            End If
        Next
        For i = 1 To 10
            If (YellowKill(i - 1) = True) Then
                YellowKillT = True
            Else
                YellowKillT = False
                Exit For
            End If
        Next
        For i = 1 To 10
            If (LimeKill(i - 1) = True) Then
                LimeKillT = True
            Else
                LimeKillT = False
                Exit For
            End If
        Next
        If (RedKillT = False And OrangeKillT = True And YellowKillT = True And LimeKillT = True) Then
            Label123.Visible = True
            Label123.Text = "Победил " & My.Settings.Player1Name
            Label123.BackColor = Color.Red
            For i = 1 To 40
                If (Controls("PictureBox" & i) IsNot Nothing) Then
                    Controls("PictureBox" & i).Enabled = False
                End If
            Next
        End If
        If (RedKillT = True And OrangeKillT = False And YellowKillT = True And LimeKillT = True) Then
            Label123.Visible = True
            Label123.Text = "Победил " & My.Settings.Player2Name
            Label123.BackColor = Color.Orange
            For i = 1 To 40
                If (Controls("PictureBox" & i) IsNot Nothing) Then
                    Controls("PictureBox" & i).Enabled = False
                End If
            Next
        End If
        If (RedKillT = True And OrangeKillT = True And YellowKillT = False And LimeKillT = True) Then
            Label123.Visible = True
            Label123.Text = "Победил " & My.Settings.Player3Name
            Label123.BackColor = Color.Yellow
            For i = 1 To 40
                If (Controls("PictureBox" & i) IsNot Nothing) Then
                    Controls("PictureBox" & i).Enabled = False
                End If
            Next
        End If
        If (RedKillT = True And OrangeKillT = True And YellowKillT = True And LimeKillT = False) Then
            Label123.Visible = True
            Label123.Text = "Победил " & My.Settings.Player4Name
            Label123.BackColor = Color.Lime
            For i = 1 To 40
                If (Controls("PictureBox" & i) IsNot Nothing) Then
                    Controls("PictureBox" & i).Enabled = False
                End If
            Next
        End If
    End Sub
End Class