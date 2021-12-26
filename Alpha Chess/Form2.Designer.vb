<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.StartGame = New System.Windows.Forms.Button()
        Me.QueensAdvantage = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.Timer = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PiecesStyleCB = New System.Windows.Forms.ComboBox()
        Me.QueensAdCB = New System.Windows.Forms.ComboBox()
        Me.PlayerTimerCB = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Sample = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BoardCB = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.Sample, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StartGame
        '
        Me.StartGame.Location = New System.Drawing.Point(343, 647)
        Me.StartGame.Name = "StartGame"
        Me.StartGame.Size = New System.Drawing.Size(75, 23)
        Me.StartGame.TabIndex = 0
        Me.StartGame.Text = "Start"
        Me.StartGame.UseVisualStyleBackColor = True
        '
        'QueensAdvantage
        '
        Me.QueensAdvantage.AutoSize = True
        Me.QueensAdvantage.BackColor = System.Drawing.Color.Transparent
        Me.QueensAdvantage.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QueensAdvantage.Location = New System.Drawing.Point(22, 53)
        Me.QueensAdvantage.Name = "QueensAdvantage"
        Me.QueensAdvantage.Size = New System.Drawing.Size(185, 22)
        Me.QueensAdvantage.TabIndex = 2
        Me.QueensAdvantage.Text = "Queen's Ad. Timer:"
        '
        'Version
        '
        Me.Version.AutoSize = True
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Location = New System.Drawing.Point(22, 652)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(84, 13)
        Me.Version.TabIndex = 4
        Me.Version.Text = "Version 2.6.4.39"
        '
        'Timer
        '
        Me.Timer.AutoSize = True
        Me.Timer.BackColor = System.Drawing.Color.Transparent
        Me.Timer.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Timer.Location = New System.Drawing.Point(22, 19)
        Me.Timer.Name = "Timer"
        Me.Timer.Size = New System.Drawing.Size(132, 22)
        Me.Timer.TabIndex = 5
        Me.Timer.Text = "Player Timer:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 22)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Pieces Style:"
        '
        'PiecesStyleCB
        '
        Me.PiecesStyleCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PiecesStyleCB.FormattingEnabled = True
        Me.PiecesStyleCB.Items.AddRange(New Object() {"Neo-Wood", "Neo", "Classic"})
        Me.PiecesStyleCB.Location = New System.Drawing.Point(209, 88)
        Me.PiecesStyleCB.Name = "PiecesStyleCB"
        Me.PiecesStyleCB.Size = New System.Drawing.Size(133, 21)
        Me.PiecesStyleCB.TabIndex = 13
        '
        'QueensAdCB
        '
        Me.QueensAdCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.QueensAdCB.FormattingEnabled = True
        Me.QueensAdCB.Items.AddRange(New Object() {"20 Seconds", "30 Seconds", "40 Seconds", "1 Minute"})
        Me.QueensAdCB.Location = New System.Drawing.Point(209, 54)
        Me.QueensAdCB.Name = "QueensAdCB"
        Me.QueensAdCB.Size = New System.Drawing.Size(133, 21)
        Me.QueensAdCB.TabIndex = 16
        '
        'PlayerTimerCB
        '
        Me.PlayerTimerCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayerTimerCB.FormattingEnabled = True
        Me.PlayerTimerCB.Items.AddRange(New Object() {"1 Minute ", "5 Minutes", "10 Minutes", "15 Minutes", "20 Minutes", "30 Minutes", "No Time"})
        Me.PlayerTimerCB.Location = New System.Drawing.Point(209, 18)
        Me.PlayerTimerCB.Name = "PlayerTimerCB"
        Me.PlayerTimerCB.Size = New System.Drawing.Size(133, 21)
        Me.PlayerTimerCB.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 612)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 22)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Right click to use abilities"
        '
        'Sample
        '
        Me.Sample.BackColor = System.Drawing.Color.Black
        Me.Sample.BackgroundImage = CType(resources.GetObject("Sample.BackgroundImage"), System.Drawing.Image)
        Me.Sample.Location = New System.Drawing.Point(20, 193)
        Me.Sample.Name = "Sample"
        Me.Sample.Size = New System.Drawing.Size(400, 400)
        Me.Sample.TabIndex = 15
        Me.Sample.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 22)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Board:"
        '
        'BoardCB
        '
        Me.BoardCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BoardCB.FormattingEnabled = True
        Me.BoardCB.Items.AddRange(New Object() {"Default", "Blue", "Brown", "Orange", "Purple", "Pink", "Red", "Grey", "Metal", "Newspaper", "Walnut", "Blurred Wood"})
        Me.BoardCB.Location = New System.Drawing.Point(209, 122)
        Me.BoardCB.Name = "BoardCB"
        Me.BoardCB.Size = New System.Drawing.Size(133, 21)
        Me.BoardCB.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 22)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Preview"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.Alpha_Chess.My.Resources.Resources.Form_2_Background1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(440, 692)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Sample)
        Me.Controls.Add(Me.BoardCB)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PlayerTimerCB)
        Me.Controls.Add(Me.QueensAdCB)
        Me.Controls.Add(Me.PiecesStyleCB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Timer)
        Me.Controls.Add(Me.QueensAdvantage)
        Me.Controls.Add(Me.StartGame)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(456, 731)
        Me.MinimumSize = New System.Drawing.Size(456, 731)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alpha Chess"
        CType(Me.Sample, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StartGame As Button
    Friend WithEvents QueensAdvantage As Label
    Friend WithEvents Version As Label
    Friend WithEvents Timer As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PiecesStyleCB As ComboBox
    Friend WithEvents QueensAdCB As ComboBox
    Friend WithEvents PlayerTimerCB As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Sample As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BoardCB As ComboBox
    Friend WithEvents Label3 As Label
End Class
