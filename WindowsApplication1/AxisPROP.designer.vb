<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Axis
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Pic = New System.Windows.Forms.PictureBox()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pic
        '
        Me.Pic.BackColor = System.Drawing.Color.White
        Me.Pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pic.Location = New System.Drawing.Point(0, 0)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New System.Drawing.Size(150, 150)
        Me.Pic.TabIndex = 0
        Me.Pic.TabStop = False
        '
        'Axis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Pic)
        Me.Name = "Axis"
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pic As System.Windows.Forms.PictureBox

End Class
