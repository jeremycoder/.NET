Public Class feesCalc

    Private Sub studentNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles studentNameTextBox.TextChanged

    End Sub

    Private Sub creditsTextBox_TextChanged(sender As Object, e As EventArgs) Handles creditsTextBox.TextChanged

    End Sub

    Private Sub studentNameLabel_Click(sender As Object, e As EventArgs) Handles studentNameLabel.Click

    End Sub

    Private Sub creditsLabel_Click(sender As Object, e As EventArgs) Handles creditsLabel.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        MessageBox.Show("Thank You For Your Interest in Carnegie Mellon University")
        Me.Close()

    End Sub

    Private Sub calcButton_Click(sender As Object, e As EventArgs) Handles calcButton.Click
        'Assign variables
        Dim credits As Integer
        Dim mealPlan As Double
        Dim roomAmount As Double
        Dim scholarship As Double
        Dim tuition As Double
        Dim roomBoard As Double
        Dim techFee As Double
        techFee = 150.0
        Dim final As Double

        'Convert numerical input
        credits = Convert.ToInt32(creditsTextBox.Text)
        mealPlan = CDbl(mealPlanTextBox.Text)
        roomAmount = CDbl(roomAmountTextBox.Text)
        scholarship = CDbl(scholarshipTextBox.Text)

        'Perform Calculations
        tuition = credits * 750.0
        roomBoard = (mealPlan + roomAmount) * 0.9 'Adding 10% discount
        final = tuition + techFee + roomBoard - scholarship

        'Display Calculations
        tuitionOutLabel.Text = tuition.ToString("c")
        roomBoardOutLabel.Text = roomBoard.ToString("c")
        techFeeOutLabel.Text = techFee.ToString("c")
        finalOutLabel.Text = final.ToString("c")

        'Display Invisible Labels
        creditsTimesLabel.Visible = True
        tenPercentLabel.Visible = True
        feesMinusLabel.Visible = True


    End Sub

    Private Sub tuitionTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub calcAnotherButton1_Click(sender As Object, e As EventArgs)
        









    End Sub

    Private Sub calcAnotherButton1_Click_1(sender As Object, e As EventArgs) Handles calcAnotherButton1.Click
        'Change invisible labels back to invisible
        feesMinusLabel.Visible = False
        tenPercentLabel.Visible = False
        creditsTimesLabel.Visible = False

        'Clear the text labels
        finalOutLabel.Text = ""
        techFeeOutLabel.Text = ""
        roomBoardOutLabel.Text = ""
        tuitionOutLabel.Text = ""

        'Clear the text boxes
        scholarshipTextBox.Text = ""
        roomAmountTextBox.Text = ""
        mealPlanTextBox.Text = ""
        creditsTextBox.Text = ""
        studentNameTextBox.Text = ""

        'Place focus back to student name textbox
        studentNameTextBox.Focus()
    End Sub
End Class
