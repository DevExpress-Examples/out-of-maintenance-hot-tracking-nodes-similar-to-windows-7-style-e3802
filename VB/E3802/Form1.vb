Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Diagnostics
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList.ViewInfo


Namespace treelistexample
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private dataSource As BindingList(Of Record)
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            dataSource = CreateObjectSource(5, 5)
            treeList1.DataSource = dataSource
            treeList1.ExpandAll()
            Dim helper As New HotTrackHelper(treeList1)
        End Sub



        Private Function CreateObjectSource(ByVal master As Integer, ByVal child As Integer) As BindingList(Of Record)
            Dim count As Integer = 0
            Dim list As New BindingList(Of Record)()
            For i As Integer = 1 To master - 1
                count += 1
                Dim parentId As Integer = count
                list.Add(New Record(count, 0, "root" & i))
                For j As Integer = 1 To child - 1
                    count += 1
                    list.Add(New Record(count, parentId, "Child" & j))
                Next j
            Next i
            count = master
            Return list
        End Function

        Private Class Record
            Private _value As String
            Private _id As Integer
            Private _parentID As Integer
            Public Property Value() As String
                Get
                    Return _value
                End Get
                Set(ByVal value As String)
                    _value = value
                End Set
            End Property
            Public Property ID() As Integer
                Get
                    Return _id
                End Get
                Set(ByVal value As Integer)
                    _id = value
                End Set
            End Property
            Public Property ParentID() As Integer
                Get
                    Return _parentID
                End Get
                Set(ByVal value As Integer)
                    _parentID = value
                End Set
            End Property

            Public Sub New(ByVal id As Integer, ByVal parentId As Integer, ByVal value As String)
                _id = id
                _parentID = parentId
                _value = value
            End Sub
        End Class

    End Class
End Namespace
