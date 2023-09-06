Namespace BookmarkInsertLR

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.richEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
            Me.panel1 = New System.Windows.Forms.Panel()
            Me.btnBetween = New System.Windows.Forms.Button()
            Me.btnRight = New System.Windows.Forms.Button()
            Me.btnLeft = New System.Windows.Forms.Button()
            Me.cbBookmarks = New System.Windows.Forms.ComboBox()
            Me.panel1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' richEditControl1
            ' 
            Me.richEditControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.richEditControl1.Location = New System.Drawing.Point(0, 0)
            Me.richEditControl1.Name = "richEditControl1"
            Me.richEditControl1.Options.MailMerge.KeepLastParagraph = False
            Me.richEditControl1.Size = New System.Drawing.Size(581, 440)
            Me.richEditControl1.TabIndex = 0
            Me.richEditControl1.Text = "richEditControl1"
            ' 
            ' panel1
            ' 
            Me.panel1.Controls.Add(Me.cbBookmarks)
            Me.panel1.Controls.Add(Me.btnBetween)
            Me.panel1.Controls.Add(Me.btnRight)
            Me.panel1.Controls.Add(Me.btnLeft)
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.panel1.Location = New System.Drawing.Point(0, 440)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(581, 36)
            Me.panel1.TabIndex = 1
            ' 
            ' btnBetween
            ' 
            Me.btnBetween.Location = New System.Drawing.Point(167, 7)
            Me.btnBetween.Name = "btnBetween"
            Me.btnBetween.Size = New System.Drawing.Size(75, 23)
            Me.btnBetween.TabIndex = 2
            Me.btnBetween.Text = "Between"
            Me.btnBetween.UseVisualStyleBackColor = True
            AddHandler Me.btnBetween.Click, New System.EventHandler(AddressOf Me.btnBetween_Click)
            ' 
            ' btnRight
            ' 
            Me.btnRight.Location = New System.Drawing.Point(86, 7)
            Me.btnRight.Name = "btnRight"
            Me.btnRight.Size = New System.Drawing.Size(75, 23)
            Me.btnRight.TabIndex = 1
            Me.btnRight.Text = "Right"
            Me.btnRight.UseVisualStyleBackColor = True
            AddHandler Me.btnRight.Click, New System.EventHandler(AddressOf Me.btnRight_Click)
            ' 
            ' btnLeft
            ' 
            Me.btnLeft.Location = New System.Drawing.Point(5, 7)
            Me.btnLeft.Name = "btnLeft"
            Me.btnLeft.Size = New System.Drawing.Size(75, 23)
            Me.btnLeft.TabIndex = 0
            Me.btnLeft.Text = "Left"
            Me.btnLeft.UseVisualStyleBackColor = True
            AddHandler Me.btnLeft.Click, New System.EventHandler(AddressOf Me.btnLeft_Click)
            ' 
            ' cbBookmarks
            ' 
            Me.cbBookmarks.FormattingEnabled = True
            Me.cbBookmarks.Location = New System.Drawing.Point(249, 7)
            Me.cbBookmarks.Name = "cbBookmarks"
            Me.cbBookmarks.Size = New System.Drawing.Size(121, 21)
            Me.cbBookmarks.TabIndex = 3
            AddHandler Me.cbBookmarks.SelectedValueChanged, New System.EventHandler(AddressOf Me.cbBookmarks_SelectedValueChanged)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(581, 476)
            Me.Controls.Add(Me.richEditControl1)
            Me.Controls.Add(Me.panel1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            Me.panel1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private richEditControl1 As DevExpress.XtraRichEdit.RichEditControl

        Private panel1 As System.Windows.Forms.Panel

        Private btnBetween As System.Windows.Forms.Button

        Private btnRight As System.Windows.Forms.Button

        Private btnLeft As System.Windows.Forms.Button

        Private cbBookmarks As System.Windows.Forms.ComboBox
    End Class
End Namespace
