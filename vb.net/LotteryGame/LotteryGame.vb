Public Class LotteryGame

    Dim playCount As Integer            'Number of times game was played
    Dim matchTimes As Integer           'Number of times 1,2,3,4 or 5 numbers matched



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub generateButton_Click(sender As Object, e As EventArgs) Handles startButton.Click

        'Clear any items from listboxes
        CheckedListBox.Items.Clear()
        pickedListBox.Items.Clear()
        winningListBox.Items.Clear()
        matchingListBox.Items.Clear()

        'Generate numbers from 1 to 99
        Dim i As Integer
        For i = 1 To 99
            CheckedListBox.Items.Add(i)
        Next

        playButton.Visible = True
        clearButton.Visible = True
        quitButton.Visible = True

    End Sub

    Private Sub generateNumbersButton_Click(sender As Object, e As EventArgs) Handles playButton.Click

        'Clear any previous data in listboxes
        pickedListBox.Items.Clear()
        winningListBox.Items.Clear()
        matchingListBox.Items.Clear()


        Dim rand As New Random              'Random number generator object
        Dim value As Integer                'Stores random numbers
        Dim checkcount As Integer           'Counts checks in checkboxlist
        Dim matchCount As Integer           'Number of picked numbers that match random numbers
        Dim i As Integer                    'Used for counting
        Dim j As Integer                    'Used for counting

        'Nullify variables
        value = 0
        checkcount = 0
        matchCount = 0
        i = 0
        j = 0

        'Generate 5 random numbers and add them to winningListBox
        For i = 1 To 5
            value = rand.Next(1, 99)
            winningListBox.Items.Add(value)
        Next

        'Display the chosen numbers in the pickedListbox
        For i = 0 To CheckedListBox.Items.Count - 1
            If (CheckedListBox.GetItemChecked(i) = True) Then
                checkcount = checkcount + 1
                pickedListBox.Items.Add(CheckedListBox.Items(i))
            End If
        Next

        'Refuse to play if user does not enter 5 numbers
        If (checkcount <> 5) Then
            pickedListBox.Items.Clear()
            winningListBox.Items.Clear()
            matchingListBox.Items.Clear()
            MessageBox.Show("You must pick 5 numbers. You picked " + checkcount.ToString +
                            " numbers. Try again!")

        Else
            'Compare picked numbers with random numbers
            'Add to matchingListBox numbers that match
            For j = 0 To 4
                For i = 0 To 4
                    If pickedListBox.Items(j) = winningListBox.Items(i) Then
                        matchingListBox.Items.Add(pickedListBox.Items(j))
                        matchCount = matchCount + 1
                    End If
                Next
            Next

            'Check if any numbers matched
            If matchCount > 0 Then
                matchTimes = matchTimes + 1
            End If

            'If picked numbers match the random numbers, then you have won!
            If matchCount = 5 Then
                didYouWinLabelOut.ForeColor = Color.Green
                didYouWinLabelOut.Text = "YES!"
            Else
                didYouWinLabelOut.ForeColor = Color.Red
                didYouWinLabelOut.Text = "NO. Try Again"
            End If

            'Increase number of times played
            playCount = playCount + 1
        End If


    End Sub

    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        'Clear all checklist boxes
        CheckedListBox.Items.Clear()
        pickedListBox.Items.Clear()
        winningListBox.Items.Clear()
        matchingListBox.Items.Clear()

        'Make all buttons but START invisible
        playButton.Visible = False
        clearButton.Visible = False
        quitButton.Visible = False
    End Sub

    Private Sub quitButton_Click(sender As Object, e As EventArgs) Handles quitButton.Click
        MessageBox.Show("You played the lottery " + playCount.ToString + " times! You had " +
                        matchTimes.ToString + " matches!")
        Me.Close()
    End Sub

    'If user presses X instead of "QUIT" button. Messages are still displayed
    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        MessageBox.Show("You played the lottery " + playCount.ToString + " times! You had " +
                        matchTimes.ToString + " matches!")
        'Do not cancel the closing
        e.Cancel = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

End Class
