Public Class taxCalculatorForm

    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Me.Close()

    End Sub

    'Calculates single person's taxes before dedictions (tax liability)
    Private Function calcSingleTaxesB4Deduct(myTotalWages As Double) As Double
        Dim myTaxesB4Deduct As Double
        Dim myTaxRate As Double
        If (myTotalWages >= 100000) Then
            myTaxRate = 0.35
        ElseIf (myTotalWages < 100000) Then
            myTaxRate = 0.32
        ElseIf (myTotalWages < 85000) Then
            myTaxRate = 0.28
        ElseIf (myTotalWages < 65000) Then
            myTaxRate = 0.22
        ElseIf (myTotalWages < 45000) Then
            myTaxRate = 0.18
        ElseIf (myTotalWages < 25000) Then
            myTaxRate = 0.15
        End If

        'Calculate Tax Liability
        myTaxesB4Deduct = myTotalWages * myTaxRate

        Return myTaxesB4Deduct

    End Function

    'Calculates married person taxes before deductions (tax liability)
    Private Function calcMarriedTaxesB4Deduct(myTotalWages As Double) As Double
        Dim myTaxesB4Deduct As Double
        Dim myTaxRate As Double
        If (myTotalWages >= 100000) Then
            myTaxRate = 0.24
        ElseIf (myTotalWages < 100000) Then
            myTaxRate = 0.22
        ElseIf (myTotalWages < 85000) Then
            myTaxRate = 0.2
        ElseIf (myTotalWages < 65000) Then
            myTaxRate = 0.18
        ElseIf (myTotalWages < 45000) Then
            myTaxRate = 0.16
        ElseIf (myTotalWages < 25000) Then
            myTaxRate = 0.13
        End If

        'Calculate Tax Liability
        myTaxesB4Deduct = myTotalWages * myTaxRate

        Return myTaxesB4Deduct

    End Function

    'Calculate Federal Tax Due
    Private Function calcFedTaxDue(myTaxesB4Deduct As Double, myTaxWithheld As Double, myNumDeduct As Double, myDeductRate As Double) As Double
        Dim myFedTaxDue As Double
        myFedTaxDue = myTaxesB4Deduct - (myTaxWithheld + (myNumDeduct * myDeductRate))
        Return myFedTaxDue
    End Function

    'Calculate State Tax Due
    Private Function calcStateTaxDue(myTotalWages As Double, myStateTaxRate As Double) As Double
        Dim myStateTaxDue As Double
        myStateTaxDue = myTotalWages * myStateTaxRate
        Return myStateTaxDue
    End Function

    'Calculate Local Tax Due
    Private Function calcLocalTaxDue(myTotalWages As Double, myLocalTaxRate As Double) As Double
        Dim myLocalTaxDue As Double
        myLocalTaxDue = myTotalWages * myLocalTaxRate
        Return myLocalTaxDue
    End Function

    'Display a value in a label
    Private Sub displayInLabel(ByRef myLabel As Label, myValue As Double)
        myLabel.Text = myValue.ToString("c")
    End Sub

    Private Sub calculateButton_Click(sender As Object, e As EventArgs) Handles calculateButton.Click

        If nameTextBox.Text = "" Then
            MsgBox("ERROR: Please enter a name.")
        Else
            Dim totalWages As Double
            Dim taxesWithheld As Double
            Dim numDeduct As Integer

            Dim taxesB4Deduct As Double
            Dim localTaxDue As Double
            Dim localTaxRate As Double
            Dim stateTaxDue As Double
            Dim stateTaxRate As Double
            Dim federalTaxDue As Double
            Dim deductRate As Double

            'Set zero values
            deductRate = 750
            stateTaxRate = 0.06
            localTaxRate = 0.01


            'Collect data from textboxes with exception handler
            Try
                totalWages = CDbl(totalWagesTextBox.Text)
            Catch ex As Exception
                totalWagesTextBox.ForeColor = Color.Red
                MsgBox("Please enter correct data in the Total Wages Textbox")
                totalWagesTextBox.ForeColor = Color.Black

            End Try

            Try
                taxesWithheld = CDbl(taxesWithheldTextBox.Text)
            Catch ex As Exception
                taxesWithheldTextBox.ForeColor = Color.Red
                MsgBox("Please enter correct data in the Taxes Withheld Textbox")
                taxesWithheldTextBox.ForeColor = Color.Black

            End Try

            Try
                numDeduct = CDec(numOfDeductTextBox.Text)
            Catch ex As Exception
                numOfDeductTextBox.ForeColor = Color.Red
                MsgBox("Please enter correct data in the Number of Deductions Textbox")
                numOfDeductTextBox.ForeColor = Color.Black

            End Try



            If (singleRadioButton.Checked) Then
                taxesB4Deduct = calcSingleTaxesB4Deduct(totalWages)
            ElseIf (marriedRadioButton.Checked) Then
                taxesB4Deduct = calcMarriedTaxesB4Deduct(totalWages)
            End If


            'Perform Calculations
            'taxesB4Deduct = totalWages * taxRate
            'federalTaxDue = taxesB4Deduct - (taxesWithheld + (numDeduct * deductRate))
            'stateTaxDue = totalWages * stateTaxRate
            'localTaxDue = totalWages * localTaxRate

            'Use functions to calculate taxes due
            federalTaxDue = calcFedTaxDue(taxesB4Deduct, taxesWithheld, numDeduct, deductRate)
            stateTaxDue = calcStateTaxDue(totalWages, stateTaxRate)
            localTaxDue = calcLocalTaxDue(totalWages, localTaxRate)

            'taxesB4DeductLabelOut.Text = taxesB4Deduct.ToString("c")
            'localTaxDueLabelOut.Text = localTaxDue.ToString("c")
            'stateTaxDueLabelOut.Text = stateTaxDue.ToString("c")
            'federalTaxDueLabelOut.Text = federalTaxDue.ToString("c")

            'Display Calculations
            displayInLabel(taxesB4DeductLabelOut, taxesB4Deduct)
            displayInLabel(localTaxDueLabelOut, localTaxDue)
            displayInLabel(stateTaxDueLabelOut, stateTaxDue)
            displayInLabel(federalTaxDueLabelOut, federalTaxDue)



            If (singleRadioButton.Checked = False) And (marriedRadioButton.Checked = False) Then
                singleRadioButton.ForeColor = Color.Red
                marriedRadioButton.ForeColor = Color.Red
                singleOrMarriedLabel.Visible = True
            Else
                singleRadioButton.ForeColor = Color.Black
                marriedRadioButton.ForeColor = Color.Black
                singleOrMarriedLabel.Visible = False
            End If

            'I changed the logic
            If federalTaxDue < 0 Then
                federalTaxDueLabelOut.ForeColor = Color.Green
                owedMoneyLabel.Visible = True
                oweMoneyLabel.Visible = False
            ElseIf federalTaxDue > 0 Then
                federalTaxDueLabelOut.ForeColor = Color.Red
                oweMoneyLabel.Visible = True
                owedMoneyLabel.Visible = False
            ElseIf federalTaxDue = 0 Then
                federalTaxDueLabelOut.ForeColor = Color.Black
                oweMoneyLabel.Visible = False
                owedMoneyLabel.Visible = False
            End If

        End If


    End Sub

    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        'Clear all fields, send focus back to name textbox
        federalTaxDueLabelOut.Text = ""
        stateTaxDueLabelOut.Text = ""
        localTaxDueLabelOut.Text = ""
        taxesB4DeductLabelOut.Text = ""

        numOfDeductTextBox.Clear()
        marriedRadioButton.Checked = False
        singleRadioButton.Checked = False
        taxesWithheldTextBox.Clear()
        totalWagesTextBox.Clear()
        nameTextBox.Clear()

        nameTextBox.Focus()
    End Sub

    Private Sub nameTextBox_TextChanged(sender As Object, e As EventArgs) Handles nameTextBox.TextChanged

    End Sub
End Class
