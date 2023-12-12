Imports System
Imports System.Collections.Generic

Module Module1
    Sub Main()
        Dim elementos As New List(Of Integer) From {3, 4, 1, 9, 2}
        Console.WriteLine("Orden original: " & String.Join(" ", elementos))

        NaturalMergeSort(elementos)
        Console.ReadKey()
    End Sub

    Sub NaturalMergeSort(ByRef arr As List(Of Integer))
        Dim resultadoParcial As List(Of Integer) = Nothing

        While True
            Dim aux1 As New List(Of Integer)()
            Dim aux2 As New List(Of Integer)()
            Dim merged As New List(Of Integer)()

            Dim i As Integer = 0
            While i < arr.Count - 1
                If arr(i) > arr(i + 1) Then
                    Exit While
                End If
                i += 1
            End While

            If i = arr.Count - 1 Then
                resultadoParcial = New List(Of Integer)(arr)
                Exit While
            End If

            aux1 = arr.GetRange(0, i + 1)
            aux2 = arr.GetRange(i + 1, arr.Count - i - 1)

            Console.WriteLine(vbLf & "Auxiliar 1: " & String.Join(" ", aux1))
            Console.WriteLine("Auxiliar 2: " & String.Join(" ", aux2))

            While aux1.Count > 0 AndAlso aux2.Count > 0
                If aux1(0) <= aux2(0) Then
                    merged.Add(aux1(0))
                    aux1.RemoveAt(0)
                Else
                    merged.Add(aux2(0))
                    aux2.RemoveAt(0)
                End If
            End While

            merged.AddRange(aux1)
            merged.AddRange(aux2)
            arr = New List(Of Integer)(merged)

            resultadoParcial = New List(Of Integer)(arr)

            Console.WriteLine("Orden parcial: " & String.Join(" ", arr))
        End While

        ' Imprimir el resultado del último paso parcial como Orden final
        Console.WriteLine(vbLf & "Orden final: " & String.Join(" ", resultadoParcial))
    End Sub
End Module
