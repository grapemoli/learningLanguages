' journaling applet
' by grace nguyen
' 09.12.22

Public Class Form1
    Dim entry As List(Of List(Of String)) = New List(Of List(Of String))()
    Dim index = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub showButton_Click(sender As Object, e As EventArgs) Handles showButton.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then ' loads picture the user chose
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        PictureBox1.Image = Nothing
        PictureBox1.BackColor = Color.Empty
    End Sub

    Private Sub backgroundButton_Click(sender As Object, e As EventArgs) Handles backgroundButton.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            PictureBox1.SizeMode = PictureBoxSizeMode.Normal
        End If
    End Sub

    Private Sub Calendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles Calendar.DateChanged
        Dim selectedDate As String
        Dim entryDate As String
        selectedDate = Calendar.SelectionRange.Start.Date.ToString("MM/dd/yyyy")
        entryDate = Calendar.SelectionRange.Start.Date.ToString("yyyyMMdd") ' set entryDate global var
        RichTextBox1.Clear()

        ' check if the date exists in the array
        Dim counter = -1
        Dim entryLen = entry.Count
        Dim keepGoing = True

        While keepGoing
            counter = counter + 1
            Dim entryDateCheck = "" ' some default value 

            ' exception handling
            Try
                entryDateCheck = entry(counter)(0)
            Catch
                ' add dummy entry if length is 0
                Dim dummy As List(Of String) = New List(Of String)()
                dummy.Add("")
                dummy.Add("")
                entry.Add(dummy)

                entryDateCheck = entry(counter)(0)

            End Try

            ' if entry exists
            If entryDate = entryDateCheck Then
                label.Text = "~" & selectedDate & "~"
                RichTextBox1.AppendText(entry(counter)(1))

                index = counter ' update global var
                keepGoing = False

            Else
                ' check if at end of list
                ' ONLY append to list after looking through all entries!
                If counter >= entryLen Then
                    keepGoing = False

                    ' create new list and append to entry
                    Dim newEntry As List(Of String) = New List(Of String)()
                    newEntry.Add(entryDate)
                    newEntry.Add("") ' add stored value for later
                    entry.Add(newEntry)

                    index = entry.Count - 1 ' update global var

                    label.Text = "~" & selectedDate & "~"

                End If
            End If

        End While
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' for everytime the user changes the text:
        ' update the associated entry value'
        entry(index)(1) = RichTextBox1.Text
        MsgBox("Succcesfully Saved")
    End Sub
End Class
