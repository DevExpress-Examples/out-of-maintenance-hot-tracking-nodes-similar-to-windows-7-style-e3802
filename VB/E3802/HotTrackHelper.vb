Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports System.Text
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo

Namespace treelistexample
    Friend Class HotTrackHelper
        Private Tree As DevExpress.XtraTreeList.TreeList
        Private hotNode As TreeListNode


        Public Sub New(ByVal treeList As DevExpress.XtraTreeList.TreeList)

            Attach(treeList)
        End Sub
        Public Sub Attach(ByVal treeList As DevExpress.XtraTreeList.TreeList)
            Tree = treeList
            AddHandler Tree.CustomDrawNodeIndent, AddressOf Tree_CustomDrawNodeIndent
            AddHandler Tree.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            AddHandler Tree.MouseMove, AddressOf Tree_MouseMove

            Tree.OptionsSelection.EnableAppearanceFocusedCell = False

        End Sub

        Private Sub Tree_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim hi As TreeListHitTest = Tree.ViewInfo.GetHitTest(e.Location)
            If hotNode IsNot hi.Node Then
                Tree.RefreshNode(hotNode)
                hotNode = hi.Node
                Tree.RefreshNode(hotNode)

            End If
        End Sub

        Private Sub Tree_CustomDrawNodeCell(ByVal sender As Object, ByVal e As CustomDrawNodeCellEventArgs)
            DrawBackGround(e.Node, e)
        End Sub

        Private Sub Tree_CustomDrawNodeIndent(ByVal sender As Object, ByVal e As CustomDrawNodeIndentEventArgs)
            DrawBackGround(e.Node, e)
            e.Handled = True
        End Sub

        Private Sub DrawBackGround(ByVal node As TreeListNode, ByVal e As CustomDrawEventArgs)
            If hotNode IsNot node AndAlso (Not node.Focused) Then
                Return
            End If
            Dim backButton As New SimpleButton()
            Tree.FindForm().Controls.Add(backButton)

            Dim ri As RowInfo = Tree.ViewInfo.RowsInfo(node)
            backButton.Bounds = ri.Bounds
            Dim bm As New Bitmap(backButton.Width, backButton.Height)
            backButton.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
            Dim rec As Rectangle = Rectangle.Intersect(ri.Bounds, e.Bounds)
            rec.Offset(-ri.Bounds.X, -ri.Bounds.Y)
            e.Graphics.DrawImage(bm, e.Bounds, rec, GraphicsUnit.Pixel)
            Tree.FindForm().Controls.Remove(backButton)
        End Sub
        Public Sub Detach()
            AddHandler Tree.CustomDrawNodeIndent, AddressOf Tree_CustomDrawNodeIndent
            AddHandler Tree.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            AddHandler Tree.MouseMove, AddressOf Tree_MouseMove
            Tree.OptionsSelection.EnableAppearanceFocusedCell = True

        End Sub

    End Class
End Namespace
