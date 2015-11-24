Public Class CustomTreeview
    Inherits System.Windows.Forms.TreeView

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H203 Then
            ' identified double click
            Dim localPos = PointToClient(Cursor.Position)
            Dim hitTestInfo = HitTest(localPos)
            If hitTestInfo.Location = TreeViewHitTestLocations.StateImage Then
                m.Result = IntPtr.Zero
            Else
                MyBase.WndProc(m)
            End If
        Else
            MyBase.WndProc(m)
        End If
    End Sub

End Class
