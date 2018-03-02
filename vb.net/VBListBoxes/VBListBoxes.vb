Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Displaybutton.Click
        Dim i As Integer
        For i = 0 To 98
            CheckedListBox1.Items.Add(i + 1)
        Next

    End Sub

    Private Sub exitbutton_Click(sender As Object, e As EventArgs) Handles exitbutton.Click
        Me.Close()
    End Sub

    Private Sub checkbutton_Click(sender As Object, e As EventArgs) Handles checkbutton.Click
        Dim checkcount As Integer = 0
        Dim i As Integer
        For i = 0 To CheckedListBox1.Items.Count - 1
            If (CheckedListBox1.GetItemChecked(i) = True) Then
                checkcount = checkcount + 1
                ListBox3.Items.Add(CheckedListBox1.Items(i))
            End If
        Next
        MessageBox.Show(checkcount.ToString + " numbers were checked")
    End Sub

    Private Sub clearbutton_Click(sender As Object, e As EventArgs) Handles clearbutton.Click
        ListBox3.Items.Clear()
        CheckedListBox1.Items.Clear()
    End Sub

    Private Sub RandomNumber_Click(sender As Object, e As EventArgs) Handles RandomNumber.Click
        Dim rand As New Random
        Dim value As Integer
        value = rand.Next(100)
        random_num.Text = value.ToString()
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged

    End Sub
End Class
