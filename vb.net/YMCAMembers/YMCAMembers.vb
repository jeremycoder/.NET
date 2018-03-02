Imports System.IO

Public Class Form1
    'File variables
    Dim file_reader As StreamReader
    Dim data As String

    'Parallel Arrays
    'Member arrays
    Public memberCode(100) As Integer
    Public married(100) As String
    Public firstName(100) As String
    Public lastName(100) As String
    Public age(100) As Integer
    Public gender(100) As String

    'Classes arrays
    Public classCode(100) As Integer
    Public className(100) As String
    Public beginningDate(100) As String

    'Registration arrays
    Public regMemberCode(100) As Integer
    Public regClassCode(100) As Integer

    'Array counts
    Public memberArraysCount As Integer = -1
    Public classesArraysCount As Integer = -1
    Public regArraysCount As Integer = -1

    'Character delimiter
    Dim chrDelimiter As Char = ","c
    Dim strFields() As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Read in member data and store each field in the particular members array
        Try
            file_reader = File.OpenText("membervb.dat")
            Do Until file_reader.EndOfStream
                data = file_reader.ReadLine()
                membersListBox.Items.Add(data)
                memberArraysCount = memberArraysCount + 1
                strFields = data.Split(chrDelimiter)
                memberCode(memberArraysCount) = CInt(strFields(0))
                married(memberArraysCount) = strFields(1)
                firstName(memberArraysCount) = strFields(2)
                lastName(memberArraysCount) = strFields(3)
                age(memberArraysCount) = strFields(4)
                gender(memberArraysCount) = strFields(5)
            Loop

        Catch ex As Exception
            MsgBox("ERROR, cannot read membervb.dat. Program cannot continue. Program will close.")
            Me.Close()
        End Try

        'Clear the string
        data = ""

        Try
            'Read in classes data and store each field in the particular classess array
            file_reader = File.OpenText("classvb.dat")
            Do Until file_reader.EndOfStream
                data = file_reader.ReadLine()
                classesListBox.Items.Add(data)
                classesArraysCount = classesArraysCount + 1
                strFields = data.Split(chrDelimiter)
                classCode(classesArraysCount) = CInt(strFields(0))
                className(classesArraysCount) = strFields(1)
                beginningDate(classesArraysCount) = strFields(2)
            Loop

        Catch ex As Exception
            MsgBox("ERROR, cannot read classvb.dat. Program cannot continue. Program will close.")
            Me.Close()
        End Try

        'Clear the string
        data = ""

        Try
            'Read in registration data and store each field in the particular classess array
            file_reader = File.OpenText("registervb.dat")
            Do Until file_reader.EndOfStream
                data = file_reader.ReadLine()
                regArraysCount = regArraysCount + 1
                strFields = data.Split(chrDelimiter)
                regMemberCode(regArraysCount) = CInt(strFields(0))
                regClassCode(regArraysCount) = CInt(strFields(1))
            Loop

        Catch ex As Exception
            MsgBox("ERROR, cannot read registervb.dat. Program cannot continue. Program will close.")
            Me.Close()
        End Try


        'Clear the string
        data = ""

        file_reader.Close()

        'Read from the arrays
        rereadArrays()

    End Sub

    'Reloads arrays
    Public Sub rereadArrays()
        membersListBox.Items.Clear()
        classesListBox.Items.Clear()
        Dim i As Integer = 0

        'Read the members arrays and load them into members list box
        For i = 0 To memberArraysCount
            membersListBox.Items.Add(memberCode(i).ToString + ",  " + married(i) + ",  " + firstName(i) + ",  " + lastName(i) + ",  " + age(i).ToString + ",  " + gender(i))
        Next

        'Read the classes arrays and load them into members list box
        For i = 0 To classesArraysCount
            classesListBox.Items.Add(classCode(i).ToString + ",  " + className(i) + ",  " + beginningDate(i))
        Next

    End Sub



    Private Sub exitButton_Click(sender As Object, e As EventArgs) Handles exitButton.Click
        Me.Close()
    End Sub

    Private Sub clearResultsButton_Click(sender As Object, e As EventArgs) Handles clearResultsButton.Click
        resultsListBox.Items.Clear()
    End Sub

    'Display Basic Member Info
    Private Sub basicMemberInfoButton_Click(sender As Object, e As EventArgs) Handles basicMemberInfoButton.Click
        resultsListBox.Items.Clear()
        Dim i As Integer
        For i = 0 To memberArraysCount
            resultsListBox.Items.Add(firstName(i) + "     " + lastName(i) + ",     " + age(i).ToString + "     " + gender(i))
        Next

    End Sub

    'Display Basic Class Info
    Private Sub basicClassButton_Click(sender As Object, e As EventArgs) Handles basicClassButton.Click
        resultsListBox.Items.Clear()
        Dim i As Integer
        For i = 0 To classesArraysCount
            resultsListBox.Items.Add(classCode(i).ToString + "      " + className(i))
        Next
    End Sub

    'Display Basic Registration Info
    Private Sub basicRegButton_Click(sender As Object, e As EventArgs) Handles basicRegButton.Click
        Dim j As Integer
        Dim fname As String = ""
        Dim lname As String = ""
        Dim cname As String = ""            'Class name

        resultsListBox.Items.Clear()
        For i = 0 To regArraysCount

            'Search the members
            For j = 0 To memberArraysCount
                If (regMemberCode(i) = memberCode(j)) Then
                    fname = firstName(j)
                    lname = lastName(j)
                End If
            Next

            'Search the classes
            For j = 0 To classesArraysCount
                If (regClassCode(i) = classCode(j)) Then
                    cname = className(j)
                End If
            Next

            resultsListBox.Items.Add(regMemberCode(i).ToString + "    " + fname + "    " + lname + "    " + regClassCode(i).ToString + "    " + cname)
        Next

    End Sub

    'Display Class by Member Info
    Private Sub classMemberButton_Click(sender As Object, e As EventArgs) Handles classMemberButton.Click
        Dim memCode As Integer = 0
        Dim i As Integer
        Dim j As Integer
        Dim cname As String = ""
        Dim fname As String = ""
        Dim lname As String = ""
        Dim found As Integer = 0
        resultsListBox.Items.Clear()

        Try
            memCode = InputBox("Please enter member code")
        Catch ex As Exception
            MsgBox("Invalid Entry!")
        End Try

        For i = 0 To regArraysCount

            If (memCode = regMemberCode(i)) Then

                found = 1

                'Find first and last names
                For j = 0 To memberArraysCount
                    If regMemberCode(i) = memberCode(j) Then
                        fname = firstName(j)
                        lname = lastName(j)
                    End If
                Next


                'Find class name
                For j = 0 To classesArraysCount
                    If regClassCode(i) = classCode(j) Then
                        cname = className(j)
                    End If
                Next

            End If

            If (found = 1) Then
                resultsListBox.Items.Add(memCode.ToString + "   " + fname + "   " + lname + "   " + cname)
            End If

            found = 0

        Next

    End Sub

    'Display Class by Gender Info
    Private Sub membersGenderButton_Click(sender As Object, e As EventArgs) Handles membersGenderButton.Click
        Dim gend As String = ""
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim cname As String = ""
        Dim fname As String = ""
        Dim lname As String = ""
        Dim found As Integer = 0
        resultsListBox.Items.Clear()

        Try
            gend = InputBox("Please enter gender [Case sensitive]:")
        Catch ex As Exception
            MsgBox("Invalid Entry!")
        End Try

        For i = 0 To memberArraysCount


            If (gend = gender(i)) Then

                found = 1
                fname = firstName(i)
                lname = lastName(i)

            End If

            If (found = 1) Then
                resultsListBox.Items.Add(gend.ToString + "   " + fname + "   " + lname)
            End If

            found = 0

        Next

    End Sub

    'Display Members by Age Range
    Private Sub membersAgeButton_Click(sender As Object, e As EventArgs) Handles membersAgeButton.Click
        Dim ageMin As Integer = 0
        Dim ageMax As Integer = 0
        Dim i As Integer
        Dim fname As String = ""
        Dim lname As String = ""
        resultsListBox.Items.Clear()

        Try

            ageMin = InputBox("Please enter minimum age")
            ageMax = InputBox("Please enter maximum age")

        Catch ex As Exception
            MsgBox("Invalid Entry")
        End Try

        If (ageMin > ageMax) Then
            MsgBox("Invalid Age Range")
        Else

            For i = 0 To memberArraysCount
                If age(i) >= ageMin And age(i) <= ageMax Then
                    fname = firstName(i)
                    lname = lastName(i)
                    resultsListBox.Items.Add(age(i).ToString + "   " + fname + "   " + lname)
                End If
            Next


        End If

    End Sub

    'Display members with no class
    Private Sub membersNotClassButton_Click(sender As Object, e As EventArgs) Handles membersNotClassButton.Click
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim memCode As Integer = 0
        Dim found As Integer = -1
        resultsListBox.Items.Clear()

        For i = 0 To memberArraysCount
            found = 0

            For k = 0 To regArraysCount
                If memberCode(i) = regMemberCode(k) Then
                    found = 1
                End If
            Next

            If found = 0 Then
                resultsListBox.Items.Add(memberCode(i).ToString + "   " + firstName(i) + "   " + lastName(i))
            End If

        Next

    End Sub

    'Display all members by class code
    Private Sub membersByClassButton_Click(sender As Object, e As EventArgs) Handles membersByClassButton.Click
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim cCode As Integer = 0
        Dim mCode As Integer = 0
        Dim cName As String = ""
        resultsListBox.Items.Clear()

        Try
            cCode = InputBox("Please enter class code")

            For i = 0 To regArraysCount

                If cCode = regClassCode(i) Then

                    mCode = regMemberCode(i)

                    For k = 0 To classesArraysCount
                        If regClassCode(i) = classCode(k) Then
                            cName = className(k)
                        End If
                    Next


                    For k = 0 To memberArraysCount

                        If mCode = memberCode(k) Then

                            resultsListBox.Items.Add(cCode.ToString + "  " + cName + "   " + firstName(k) + "  " + lastName(k))

                        End If

                    Next



                End If

            Next



        Catch ex As Exception
            MsgBox("ERROR " + ex.Message)
        End Try


    End Sub

    'Display all members with classes
    Private Sub allMembersAllClassesButton_Click(sender As Object, e As EventArgs) Handles allMembersAllClassesButton.Click
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim cCode As Integer = 0
        Dim mCode As Integer = 0
        Dim cName As String = ""
        resultsListBox.Items.Clear()

        For i = 0 To regArraysCount

            mCode = regMemberCode(i)
            cCode = regClassCode(i)

            For k = 0 To classesArraysCount

                If cCode = classCode(k) Then
                    cName = className(k)
                End If
            Next


            For k = 0 To memberArraysCount
                If mCode = memberCode(k) Then
                    resultsListBox.Items.Add(mCode.ToString + "  " + firstName(k) + "  " + lastName(k) + "  " + cCode.ToString + "   " + cName)
                End If
            Next

        Next


    End Sub

    Private Sub classesFormButton_Click(sender As Object, e As EventArgs) Handles classesFormButton.Click
        Classes.ShowDialog()
    End Sub
End Class
