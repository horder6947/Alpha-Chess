Public Class Form2

    Public PlayerTimer As Integer
    Public QAT As Integer

    Private Sub StartGame_Click(sender As Object, e As EventArgs) Handles StartGame.Click

        If PiecesStyleCB.SelectedItem = "" Then

            Label4.ForeColor = Color.Red

        End If

        If QueensAdCB.SelectedItem = "" Then

            QueensAdvantage.ForeColor = Color.Red

        End If

        If PlayerTimerCB.SelectedItem = "" Then

            Timer.ForeColor = Color.Red

        End If

        If BoardCB.SelectedItem = "" Then

            Label5.ForeColor = Color.Red

        End If

        If PiecesStyleCB.SelectedItem <> "" And QueensAdCB.SelectedItem <> "" And PlayerTimerCB.SelectedItem <> "" And BoardCB.SelectedItem <> "" Then

            If QueensAdCB.SelectedItem <> "1 Minute" Then

                QAT = CInt(Microsoft.VisualBasic.Left(QueensAdCB.SelectedItem, 2))

            Else

                QAT = CInt(Microsoft.VisualBasic.Left(QueensAdCB.SelectedItem, 1)) * 60

            End If

            If PlayerTimerCB.SelectedItem <> "No Time" Then

                PlayerTimer = CInt(Microsoft.VisualBasic.Left(PlayerTimerCB.SelectedItem, Len(PlayerTimerCB.SelectedItem) - 8))

            End If

            Form1.Show()

        End If

    End Sub

    Private Sub PlayerTimerCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PlayerTimerCB.SelectedIndexChanged

        Timer.ForeColor = Color.Black

    End Sub

    Private Sub QueensAdCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QueensAdCB.SelectedIndexChanged

        QueensAdvantage.ForeColor = Color.Black

    End Sub

    Private Sub BoardCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BoardCB.SelectedIndexChanged

        Label5.ForeColor = Color.Black

        Select Case BoardCB.SelectedItem

            Case "Default"

                Sample.BackgroundImage = My.Resources._Default

            Case "Blue"

                Sample.BackgroundImage = My.Resources.Blue

            Case "Brown"

                Sample.BackgroundImage = My.Resources.Brown

            Case "Orange"

                Sample.BackgroundImage = My.Resources.Orange

            Case "Purple"

                Sample.BackgroundImage = My.Resources.Purple

            Case "Pink"

                Sample.BackgroundImage = My.Resources.Pink

            Case "Red"

                Sample.BackgroundImage = My.Resources.Red

            Case "Grey"

                Sample.BackgroundImage = My.Resources.Grey

            Case "Metal"

                Sample.BackgroundImage = My.Resources.Metal

            Case "Newspaper"

                Sample.BackgroundImage = My.Resources.Newspaper

            Case "Walnut"

                Sample.BackgroundImage = My.Resources.Walnut

            Case "Blurred Wood"

                Sample.BackgroundImage = My.Resources.Blurred_Wood

        End Select

    End Sub

    Private Sub PiecesStyleCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PiecesStyleCB.SelectedIndexChanged

        Label4.ForeColor = Color.Black

        Select Case PiecesStyleCB.SelectedItem

            Case "Neo-Wood"

                Sample.Image = My.Resources.Neo_Wood_Sample

            Case "Classic"

                Sample.Image = My.Resources.Classic_Pieces_Sample

            Case "Neo"

                Sample.Image = My.Resources.Neo_Sample

        End Select

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BoardCB.SelectedIndex = 0
        PiecesStyleCB.SelectedIndex = 0

    End Sub

    Private Sub Version_Click(sender As Object, e As EventArgs) Handles Version.Click

    End Sub
End Class