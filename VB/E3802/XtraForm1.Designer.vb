Namespace E3802
    Partial Friend Class XtraForm1
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
            DirectCast(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' treeList1
            ' 
            Me.treeList1.Location = New System.Drawing.Point(242, 113)
            Me.treeList1.Name = "treeList1"
            Me.treeList1.Size = New System.Drawing.Size(400, 200)
            Me.treeList1.TabIndex = 0
            ' 
            ' XtraForm1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(284, 262)
            Me.Controls.Add(Me.treeList1)
            Me.Name = "XtraForm1"
            Me.Text = "XtraForm1"
            DirectCast(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private treeList1 As DevExpress.XtraTreeList.TreeList
    End Class
End Namespace