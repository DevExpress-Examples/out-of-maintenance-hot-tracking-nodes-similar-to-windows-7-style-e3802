Imports System
Imports System.Collections.Generic

Imports System.Text
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing

Namespace treelist
    Friend Class HotTrackHelper
        Private fTreeList As DevExpress.XtraTreeList.TreeList
        Private hotNode As TreeListNode
        Private customButtonPainter As SkinEditorButtonPainter
        Private args As EditorButtonObjectInfoArgs

        Public Sub New(ByVal treeList As DevExpress.XtraTreeList.TreeList)
            Attach(treeList)
        End Sub
        Public Sub Attach(ByVal treeList As DevExpress.XtraTreeList.TreeList)
            fTreeList = treeList
            AddHandler fTreeList.CustomDrawNodeIndent, AddressOf Tree_CustomDrawNodeIndent
            AddHandler fTreeList.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            AddHandler fTreeList.MouseMove, AddressOf Tree_MouseMove

            fTreeList.OptionsSelection.EnableAppearanceFocusedCell = False
            CreateButtonInfoArgs()
            CreateButtonPainter()
        End Sub

        Private Sub CreateButtonInfoArgs()
            Dim btn As New EditorButton(ButtonPredefines.Glyph)

            args = New EditorButtonObjectInfoArgs(btn, New DevExpress.Utils.AppearanceObject())
            args.Transparent = True
        End Sub
        Private Sub CreateButtonPainter()
            customButtonPainter = New SkinEditorButtonPainter(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel)
        End Sub
        Private Sub Tree_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim hi As TreeListHitTest = fTreeList.ViewInfo.GetHitTest(e.Location)
            If True Then
                If hotNode IsNot hi.Node Then
                    fTreeList.RefreshNode(hotNode)
                    hotNode = hi.Node
                    fTreeList.RefreshNode(hotNode)
                End If
            End If
        End Sub
        Private Sub Tree_CustomDrawNodeCell(ByVal sender As Object, ByVal e As CustomDrawNodeCellEventArgs)
            DrawBackground(e.Node, e)
        End Sub
        Private Sub Tree_CustomDrawNodeIndent(ByVal sender As Object, ByVal e As CustomDrawNodeIndentEventArgs)
            DrawBackground(e.Node, e)
            e.Handled = True
        End Sub
        Private Sub DrawBackground(ByVal node As TreeListNode, ByVal e As CustomDrawEventArgs)
            If hotNode IsNot node AndAlso Not node.Focused Then
                Return
            End If
            SetUpButtonInfoArgs(e)
            customButtonPainter.DrawObject(args)
        End Sub
        Private Sub SetUpButtonInfoArgs(ByVal e As CustomDrawEventArgs)
            args.Cache = e.Cache
            args.Bounds = e.Bounds
            args.State = DevExpress.Utils.Drawing.ObjectState.Hot
        End Sub
        Public Sub Detach()
            RemoveHandler fTreeList.CustomDrawNodeIndent, AddressOf Tree_CustomDrawNodeIndent
            RemoveHandler fTreeList.CustomDrawNodeCell, AddressOf Tree_CustomDrawNodeCell
            RemoveHandler fTreeList.MouseMove, AddressOf Tree_MouseMove
            fTreeList.OptionsSelection.EnableAppearanceFocusedCell = True
            fTreeList = Nothing
        End Sub
    End Class
End Namespace
