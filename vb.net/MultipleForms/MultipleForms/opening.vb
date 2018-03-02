Public Class opening

    Private Sub breakfast_form_button_Click(sender As Object, e As EventArgs) Handles breakfast_form_button.Click
        Dim breakfast_form As New breakfast
        breakfast_form.ShowDialog()
    End Sub

    Private Sub Lunch_form_button_Click(sender As Object, e As EventArgs) Handles Lunch_form_button.Click
        Dim lunch_form As New lunch
        lunch.ShowDialog()
    End Sub
    Private Sub dinner_form_button_Click(sender As Object, e As EventArgs) Handles dinner_form_button.Click
        Dim dinner_form As New dinner
        dinner_form.ShowDialog()
    End Sub

    Private Sub snack_form_button_Click(sender As Object, e As EventArgs) Handles snack_form_button.Click
        Dim snack_form As New snack
        snack.ShowDialog()
    End Sub

    Private Sub exit_button_Click(sender As Object, e As EventArgs) Handles exit_button.Click
        Me.Close()
    End Sub

    Private Sub opening_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (MessageBox.Show("Are you sure you want to close the diet program?", "Confirm to exit", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub opening_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        MessageBox.Show("Goodbye!")
    End Sub
End Class
