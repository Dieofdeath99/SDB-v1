Module Module1
    Public Enum cellstate
        empty
        miss
        hit
        cmpship
    End Enum
    Public rows As Integer = 4
    Public cols As Integer = 5
    Public board(rows - 1, cols - 1) As cellstate
    Sub Main()
        Dim shotCount As Integer = 0
        Dim gameOver As Boolean = False
        ResetBoard()
        PlaceComputerShip()
        Do
            shotCount += 1
            PrintBoard()
            Dim row As Integer = GetUserInput("Please Enter The Row to Fire On => ", rows - 1)
            Dim col As Integer = GetUserInput("Please Enter The Col to Fire On => ", cols - 1)
            If board(row, col) = cellstate.cmpship Then
                board(row, col) = cellstate.hit
                gameOver = True
            Else
                board(row, col) = cellstate.miss
            End If
        Loop While Not gameOver
        PrintBoard()
        Console.WriteLine("You hit it in {0} shots!", shotCount.ToString)
        Console.ReadKey()
    End Sub
    Sub ResetBoard()
        For i As Integer = 0 To board.GetUpperBound(0)
            For j As Integer = 0 To board.GetUpperBound(1)
                board(i, j) = cellstate.empty
            Next
        Next
    End Sub
    Sub PlaceComputerShip()
        Dim rand As New Random
        Dim row As Integer = rand.Next(0, rows)
        Dim col As Integer = rand.Next(0, cols)
        board(row, col) = cellstate.cmpship
    End Sub
    Sub PrintBoard()
        Console.Write("  ")
        For colNum As Integer = 0 To cols - 1
            Console.Write(colNum & " ")
        Next
        Console.Write(vbNewLine)
        For row As Integer = 0 To board.GetUpperBound(0)
            Console.Write(row & " ")
            For col As Integer = 0 To board.GetUpperBound(1)
                Select Case board(row, col)
                    Case cellstate.empty, cellstate.cmpship
                        Console.Write("- ")
                    Case cellstate.miss
                        Console.ForegroundColor = ConsoleColor.Red
                        Console.Write("x ")
                        Console.ResetColor()
                    Case cellstate.hit
                        Console.ForegroundColor = ConsoleColor.Green
                        Console.Write("H ")
                        Console.ResetColor()
                End Select
            Next
            Console.Write(vbNewLine)
        Next
    End Sub
    Function GetUserInput(prompt As String, max As Integer) As Integer
        Dim valid As Boolean = False
        Dim userInput As Integer
        Dim inputStr As String
        Do
            Console.Write(prompt)
            inputStr = Console.ReadLine
            valid = Integer.TryParse(inputStr, userInput)
            If Not (valid AndAlso userInput >= 0 AndAlso userInput <= max) Then
                valid = False
            End If
        Loop While Not valid
        Return userInput
    End Function
End Module
