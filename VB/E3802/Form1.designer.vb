Namespace treelist
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
            Me.treeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.treeListColumn2 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' treeList1
            ' 
            Me.treeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() { Me.treeListColumn1, Me.treeListColumn2})
            Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.treeList1.Location = New System.Drawing.Point(0, 0)
            Me.treeList1.Name = "treeList1"
            Me.treeList1.OptionsView.ShowFocusedFrame = False
            Me.treeList1.OptionsView.ShowHorzLines = False
            Me.treeList1.OptionsView.ShowIndicator = False
            Me.treeList1.OptionsView.ShowVertLines = False
            Me.treeList1.Size = New System.Drawing.Size(352, 410)
            Me.treeList1.TabIndex = 0
            ' 
            ' treeListColumn1
            ' 
            Me.treeListColumn1.Caption = "Value"
            Me.treeListColumn1.FieldName = "Value"
            Me.treeListColumn1.Name = "treeListColumn1"
            Me.treeListColumn1.Visible = True
            Me.treeListColumn1.VisibleIndex = 0
            ' 
            ' treeListColumn2
            ' 
            Me.treeListColumn2.Caption = "treeListColumn2"
            Me.treeListColumn2.FieldName = "treeListColumn2"
            Me.treeListColumn2.Name = "treeListColumn2"
            Me.treeListColumn2.Visible = True
            Me.treeListColumn2.VisibleIndex = 1
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(352, 410)
            Me.Controls.Add(Me.treeList1)
            Me.Name = "Form1"
            CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private treeList1 As DevExpress.XtraTreeList.TreeList
        Private treeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
        Private treeListColumn2 As DevExpress.XtraTreeList.Columns.TreeListColumn

    End Class
End Namespace