Imports System
Imports System.IO

' horserace
' by grace nguyen
' 09.16.22
' simulate a horse race :)

Module Program
    Sub Main(args As String())
        ' array of horses
        Dim horses(5) As Horse

        For horseNum As Integer = 0 To 4
            Dim a As Horse = New Horse(horseNum)
            horses(horseNum) = a
        Next

        ' while no horse winner:
        ' print each horses' position as they move
        Dim keepGoing = True
        While keepGoing = True
            Dim winner = ""

            For index As Integer = 0 To 4
                ' each horse: move, print, and check position
                horses(index).willMove()
                Console.Write(horses(index).printPosition & vbCrLf)

                If horses(index).atEnd = True Then
                    keepGoing = False
                    winner = horses(index).name.ToString
                End If
            Next

            Console.Write(vbCrLf & vbCrLf)

            If winner IsNot "" Then
                Console.Write("The winner is Horse #" & winner & "!")
            End If
        End While
    End Sub

End Module


' objects
Public Class Horse
    ' attributes with getters and setters
    ' uses microsoft recommended convention
    Private pos As Integer
    Private horseName As Integer

    Public Property position() As Integer
        Get
            Return pos
        End Get
        Set(ByVal value As Integer)
            pos = value
        End Set
    End Property
    Public Property name() As Integer
        Get
            Return horseName
        End Get
        Set(ByVal value As Integer)
            horseName = value
        End Set
    End Property

    ' null and parameterized constructors
    Public Sub New()
        pos = 0
        name = 0
    End Sub

    Public Sub New(ByVal input As Integer)
        pos = 0
        name = input
    End Sub

    ' methods
    Public Sub moveForward()
        Me.pos = pos + 1
    End Sub

    Public Sub willMove()
        ' generate a random number
        ' if the number is odd, move forward
        Dim randInt As Integer
        randInt = Int((101 * Rnd()))
        randInt = randInt Mod 2

        If randInt = 1 Then
            Me.moveForward()
        End If
    End Sub

    Public Function printPosition()
        ' note- length of the track is 10
        Dim printedHorse As String
        printedHorse = ""

        For posLeft As Integer = 0 To (pos - 1)
            printedHorse = printedHorse + "."
        Next

        printedHorse = printedHorse + Me.horseName.ToString

        For posRight As Integer = 0 To (9 - pos)
            printedHorse = printedHorse + "."
        Next

        Return printedHorse
    End Function

    Public Function atEnd()
        If pos = 10 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
