Imports WMPLib
Public Class MenuGame
    'Dim MainMenuAudio As WindowsMediaPlayer = New WindowsMediaPlayer
    Dim TextBox As TextBox
    Dim TriggerRaz As Boolean
    Dim Obj As Object

    'Новая игра
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = True
        Button5.Visible = True
        Button6.Enabled = True
        Button6.Visible = True
        Button7.Enabled = True
        Button7.Visible = True
        Button8.Enabled = True
        Button8.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        Label2.Text = "2"
        Label3.Visible = True
        Label4.Visible = True
        PictureBox1.Visible = True
        PictureBox2.Visible = True
    End Sub

    'Разработчик
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TriggerRaz = True) Then
            For i = 2 To 4
                If (Controls("Button" & i) IsNot Button3) Then
                    Controls("Button" & i).Enabled = True
                End If
            Next
            Label7.Visible = False
            Label7.Location = New Point(Label7.Location.X, 700)
            TriggerRaz = False
            Timer1.Stop()
        Else
            For i = 2 To 4
                If (Controls("Button" & i) IsNot Button3) Then
                    Controls("Button" & i).Enabled = False
                End If
            Next
            Label7.Visible = True
            TriggerRaz = True
            Timer1.Start()
        End If
    End Sub

    'Выход
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    'Изменение количества игроков
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (Label2.Text = "2") Then
            Label2.Text = "4"
            Label5.Visible = True
            PictureBox3.Visible = True
            Label6.Visible = True
            PictureBox4.Visible = True
        ElseIf (Label2.Text = "4") Then
            Label2.Text = "3"
            Label6.Visible = False
            PictureBox4.Visible = False
        ElseIf (Label2.Text = "3") Then
            Label2.Text = "2"
            Label5.Visible = False
            PictureBox3.Visible = False
        End If
    End Sub

    'Изменение количества игроков
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (Label2.Text = "2") Then
            Label2.Text = "3"
            Label5.Visible = True
            PictureBox3.Visible = True
        ElseIf (Label2.Text = "3") Then
            Label2.Text = "4"
            Label6.Visible = True
            PictureBox4.Visible = True
        ElseIf (Label2.Text = "4") Then
            Label2.Text = "2"
            Label5.Visible = False
            PictureBox3.Visible = False
            Label6.Visible = False
            PictureBox4.Visible = False
        End If
    End Sub

    'Изменение имени игрока
    Private Sub Me_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If (Obj IsNot Nothing) Then
            TextBox.Visible = False
            If (TextBox.Text = "") Then
                Obj.Text = ""
            Else
                Obj.Text = TextBox.Text
            End If
            TextBox.Text = ""
        End If
    End Sub

    'Изменение имени игрока
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Obj = sender
        TextBox.Visible = True
        TextBox.Text = ""
        TextBox.Location = Obj.Location + New Point(0, Obj.Size.Height)
    End Sub

    'Изменение имени игрока
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Obj = sender
        TextBox.Visible = True
        TextBox.Text = ""
        TextBox.Location = Obj.Location + New Point(0, Obj.Size.Height)
    End Sub

    'Изменение имени игрока
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Obj = sender
        TextBox.Visible = True
        TextBox.Text = ""
        TextBox.Location = Obj.Location + New Point(0, Obj.Size.Height)
    End Sub

    'Изменение имени игрока
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Obj = sender
        TextBox.Visible = True
        TextBox.Text = ""
        TextBox.Location = Obj.Location + New Point(0, Obj.Size.Height)
    End Sub

    'Начать игру
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        My.Settings.Players = Convert.ToInt32(Label2.Text)
        My.Settings.Player1Name = Label3.Text
        My.Settings.Player2Name = Label4.Text
        If (Label2.Text = "3") Then
            My.Settings.Player3Name = Label5.Text
        ElseIf (Label2.Text = "4") Then
            My.Settings.Player3Name = Label5.Text
            My.Settings.Player4Name = Label6.Text
        End If
        My.Settings.Save()
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        Button3.Enabled = True
        Button4.Enabled = True
        Me.Hide()
        Game.Show()
    End Sub

    'Закрыть выбор игроков
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False
        Button5.Visible = False
        Button6.Enabled = False
        Button6.Visible = False
        Button7.Enabled = False
        Button7.Visible = False
        Button8.Enabled = False
        Button8.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
    End Sub

    'Загрузка данных
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As String
        path = Application.StartupPath
        'MainMenuAudio.currentMedia = MainMenuAudio.newMedia(path & "\Ресурсы\Музыка\Меню\SoundMenu.wav")
        'MainMenuAudio.controls.play()
        'MainMenuAudio.settings.volume = 10
        TextBox = New TextBox With {
            .Location = New Point(0, 0),
            .Size = New Size(115, 29)
            }
        Controls.Add(TextBox)
        TextBox.BringToFront()
        TextBox.Visible = False
    End Sub

    'Разработчик
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (Label7.Location.Y > 0 - Label7.Size.Height) Then
            Label7.Location = New Point(Label7.Location.X, Label7.Location.Y - 1)
        Else
            For i = 1 To 4
                If (Controls("Button" & i) IsNot Button3) Then
                    Controls("Button" & i).Enabled = True
                End If
            Next
            Label7.Visible = False
            Timer1.Stop()
        End If
    End Sub
End Class