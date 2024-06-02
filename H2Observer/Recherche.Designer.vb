<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Recherche
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend6 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Recherche))
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.critere_recherche = New System.Windows.Forms.GroupBox()
        Me.CheckBox29 = New System.Windows.Forms.CheckBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.MaskedTextBox4 = New System.Windows.Forms.MaskedTextBox()
        Me.MaskedTextBox3 = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox28 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sonde_temperature = New System.Windows.Forms.GroupBox()
        Me.CheckBox27 = New System.Windows.Forms.CheckBox()
        Me.CheckBox26 = New System.Windows.Forms.CheckBox()
        Me.CheckBox25 = New System.Windows.Forms.CheckBox()
        Me.CheckBox24 = New System.Windows.Forms.CheckBox()
        Me.CheckBox23 = New System.Windows.Forms.CheckBox()
        Me.CheckBox22 = New System.Windows.Forms.CheckBox()
        Me.CheckBox21 = New System.Windows.Forms.CheckBox()
        Me.CheckBox20 = New System.Windows.Forms.CheckBox()
        Me.CheckBox19 = New System.Windows.Forms.CheckBox()
        Me.CheckBox18 = New System.Windows.Forms.CheckBox()
        Me.CheckBox17 = New System.Windows.Forms.CheckBox()
        Me.sonde_conductivite = New System.Windows.Forms.GroupBox()
        Me.CheckBox16 = New System.Windows.Forms.CheckBox()
        Me.CheckBox15 = New System.Windows.Forms.CheckBox()
        Me.CheckBox14 = New System.Windows.Forms.CheckBox()
        Me.capteur_pression = New System.Windows.Forms.GroupBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.CheckBox13 = New System.Windows.Forms.CheckBox()
        Me.CheckBox8 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.CheckBox9 = New System.Windows.Forms.CheckBox()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox10 = New System.Windows.Forms.CheckBox()
        Me.capteur_debit = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.capteur_pretraitement = New System.Windows.Forms.GroupBox()
        Me.CheckBox30 = New System.Windows.Forms.CheckBox()
        Me.CheckBox31 = New System.Windows.Forms.CheckBox()
        Me.CheckBox35 = New System.Windows.Forms.CheckBox()
        Me.CheckBox36 = New System.Windows.Forms.CheckBox()
        Me.CheckBox37 = New System.Windows.Forms.CheckBox()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.critere_recherche.SuspendLayout()
        Me.sonde_temperature.SuspendLayout()
        Me.sonde_conductivite.SuspendLayout()
        Me.capteur_pression.SuspendLayout()
        Me.capteur_debit.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.capteur_pretraitement.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea6.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea6)
        Legend6.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend6)
        Me.Chart1.Location = New System.Drawing.Point(349, 12)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel
        Series6.ChartArea = "ChartArea1"
        Series6.Legend = "Legend1"
        Series6.Name = "Series1"
        Me.Chart1.Series.Add(Series6)
        Me.Chart1.Size = New System.Drawing.Size(921, 486)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'critere_recherche
        '
        Me.critere_recherche.BackColor = System.Drawing.Color.White
        Me.critere_recherche.Controls.Add(Me.CheckBox29)
        Me.critere_recherche.Controls.Add(Me.DateTimePicker2)
        Me.critere_recherche.Controls.Add(Me.DateTimePicker1)
        Me.critere_recherche.Controls.Add(Me.MaskedTextBox4)
        Me.critere_recherche.Controls.Add(Me.MaskedTextBox3)
        Me.critere_recherche.Controls.Add(Me.Label4)
        Me.critere_recherche.Controls.Add(Me.CheckBox28)
        Me.critere_recherche.Controls.Add(Me.Label3)
        Me.critere_recherche.Controls.Add(Me.Label2)
        Me.critere_recherche.Controls.Add(Me.Label1)
        Me.critere_recherche.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.critere_recherche.Location = New System.Drawing.Point(111, 161)
        Me.critere_recherche.Name = "critere_recherche"
        Me.critere_recherche.Size = New System.Drawing.Size(248, 202)
        Me.critere_recherche.TabIndex = 18
        Me.critere_recherche.TabStop = False
        Me.critere_recherche.Text = "CRITERE DE RECHERCHE"
        '
        'CheckBox29
        '
        Me.CheckBox29.AutoSize = True
        Me.CheckBox29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox29.Location = New System.Drawing.Point(183, 28)
        Me.CheckBox29.Name = "CheckBox29"
        Me.CheckBox29.Size = New System.Drawing.Size(60, 20)
        Me.CheckBox29.TabIndex = 29
        Me.CheckBox29.Text = "Excel"
        Me.CheckBox29.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.CustomFormat = "yyyyMMdd"
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(135, 101)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(108, 22)
        Me.DateTimePicker2.TabIndex = 28
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.CustomFormat = "yyyyMMdd"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(135, 68)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(108, 22)
        Me.DateTimePicker1.TabIndex = 26
        '
        'MaskedTextBox4
        '
        Me.MaskedTextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox4.Location = New System.Drawing.Point(183, 170)
        Me.MaskedTextBox4.Mask = "00:00"
        Me.MaskedTextBox4.Name = "MaskedTextBox4"
        Me.MaskedTextBox4.Size = New System.Drawing.Size(49, 22)
        Me.MaskedTextBox4.TabIndex = 27
        Me.MaskedTextBox4.Text = "2359"
        Me.MaskedTextBox4.ValidatingType = GetType(Date)
        '
        'MaskedTextBox3
        '
        Me.MaskedTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox3.Location = New System.Drawing.Point(183, 139)
        Me.MaskedTextBox3.Mask = "00:00"
        Me.MaskedTextBox3.Name = "MaskedTextBox3"
        Me.MaskedTextBox3.Size = New System.Drawing.Size(49, 22)
        Me.MaskedTextBox3.TabIndex = 26
        Me.MaskedTextBox3.Text = "0000"
        Me.MaskedTextBox3.ValidatingType = GetType(Date)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "HEURE  FIN"
        '
        'CheckBox28
        '
        Me.CheckBox28.AutoSize = True
        Me.CheckBox28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox28.Location = New System.Drawing.Point(6, 31)
        Me.CheckBox28.Name = "CheckBox28"
        Me.CheckBox28.Size = New System.Drawing.Size(170, 17)
        Me.CheckBox28.TabIndex = 23
        Me.CheckBox28.Text = "RECHERCHE SUR UN JOUR"
        Me.CheckBox28.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "DATE FIN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "DATE DEBUT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "HEURE DU JOUR"
        '
        'sonde_temperature
        '
        Me.sonde_temperature.BackColor = System.Drawing.Color.White
        Me.sonde_temperature.Controls.Add(Me.CheckBox27)
        Me.sonde_temperature.Controls.Add(Me.CheckBox26)
        Me.sonde_temperature.Controls.Add(Me.CheckBox25)
        Me.sonde_temperature.Controls.Add(Me.CheckBox24)
        Me.sonde_temperature.Controls.Add(Me.CheckBox23)
        Me.sonde_temperature.Controls.Add(Me.CheckBox22)
        Me.sonde_temperature.Controls.Add(Me.CheckBox21)
        Me.sonde_temperature.Controls.Add(Me.CheckBox20)
        Me.sonde_temperature.Controls.Add(Me.CheckBox19)
        Me.sonde_temperature.Controls.Add(Me.CheckBox18)
        Me.sonde_temperature.Controls.Add(Me.CheckBox17)
        Me.sonde_temperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sonde_temperature.Location = New System.Drawing.Point(568, 552)
        Me.sonde_temperature.Name = "sonde_temperature"
        Me.sonde_temperature.Size = New System.Drawing.Size(248, 109)
        Me.sonde_temperature.TabIndex = 16
        Me.sonde_temperature.TabStop = False
        Me.sonde_temperature.Text = " SONDES DE TEMPERATURE"
        '
        'CheckBox27
        '
        Me.CheckBox27.AutoSize = True
        Me.CheckBox27.Location = New System.Drawing.Point(187, 65)
        Me.CheckBox27.Name = "CheckBox27"
        Me.CheckBox27.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox27.TabIndex = 21
        Me.CheckBox27.Text = "T12"
        Me.CheckBox27.UseVisualStyleBackColor = True
        '
        'CheckBox26
        '
        Me.CheckBox26.AutoSize = True
        Me.CheckBox26.Location = New System.Drawing.Point(187, 42)
        Me.CheckBox26.Name = "CheckBox26"
        Me.CheckBox26.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox26.TabIndex = 20
        Me.CheckBox26.Text = "T11"
        Me.CheckBox26.UseVisualStyleBackColor = True
        '
        'CheckBox25
        '
        Me.CheckBox25.AutoSize = True
        Me.CheckBox25.Location = New System.Drawing.Point(187, 19)
        Me.CheckBox25.Name = "CheckBox25"
        Me.CheckBox25.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox25.TabIndex = 19
        Me.CheckBox25.Text = "T09"
        Me.CheckBox25.UseVisualStyleBackColor = True
        '
        'CheckBox24
        '
        Me.CheckBox24.AutoSize = True
        Me.CheckBox24.Location = New System.Drawing.Point(94, 88)
        Me.CheckBox24.Name = "CheckBox24"
        Me.CheckBox24.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox24.TabIndex = 18
        Me.CheckBox24.Text = "T08"
        Me.CheckBox24.UseVisualStyleBackColor = True
        '
        'CheckBox23
        '
        Me.CheckBox23.AutoSize = True
        Me.CheckBox23.Location = New System.Drawing.Point(94, 65)
        Me.CheckBox23.Name = "CheckBox23"
        Me.CheckBox23.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox23.TabIndex = 17
        Me.CheckBox23.Text = "T07"
        Me.CheckBox23.UseVisualStyleBackColor = True
        '
        'CheckBox22
        '
        Me.CheckBox22.AutoSize = True
        Me.CheckBox22.Location = New System.Drawing.Point(94, 42)
        Me.CheckBox22.Name = "CheckBox22"
        Me.CheckBox22.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox22.TabIndex = 16
        Me.CheckBox22.Text = "T06"
        Me.CheckBox22.UseVisualStyleBackColor = True
        '
        'CheckBox21
        '
        Me.CheckBox21.AutoSize = True
        Me.CheckBox21.Location = New System.Drawing.Point(94, 19)
        Me.CheckBox21.Name = "CheckBox21"
        Me.CheckBox21.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox21.TabIndex = 15
        Me.CheckBox21.Text = "T05"
        Me.CheckBox21.UseVisualStyleBackColor = True
        '
        'CheckBox20
        '
        Me.CheckBox20.AutoSize = True
        Me.CheckBox20.Location = New System.Drawing.Point(6, 88)
        Me.CheckBox20.Name = "CheckBox20"
        Me.CheckBox20.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox20.TabIndex = 14
        Me.CheckBox20.Text = "T04"
        Me.CheckBox20.UseVisualStyleBackColor = True
        '
        'CheckBox19
        '
        Me.CheckBox19.AutoSize = True
        Me.CheckBox19.Location = New System.Drawing.Point(6, 65)
        Me.CheckBox19.Name = "CheckBox19"
        Me.CheckBox19.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox19.TabIndex = 13
        Me.CheckBox19.Text = "T03"
        Me.CheckBox19.UseVisualStyleBackColor = True
        '
        'CheckBox18
        '
        Me.CheckBox18.AutoSize = True
        Me.CheckBox18.Location = New System.Drawing.Point(6, 42)
        Me.CheckBox18.Name = "CheckBox18"
        Me.CheckBox18.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox18.TabIndex = 12
        Me.CheckBox18.Text = "T02"
        Me.CheckBox18.UseVisualStyleBackColor = True
        '
        'CheckBox17
        '
        Me.CheckBox17.AutoSize = True
        Me.CheckBox17.Location = New System.Drawing.Point(6, 19)
        Me.CheckBox17.Name = "CheckBox17"
        Me.CheckBox17.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox17.TabIndex = 11
        Me.CheckBox17.Text = "T01"
        Me.CheckBox17.UseVisualStyleBackColor = True
        '
        'sonde_conductivite
        '
        Me.sonde_conductivite.BackColor = System.Drawing.Color.White
        Me.sonde_conductivite.Controls.Add(Me.CheckBox16)
        Me.sonde_conductivite.Controls.Add(Me.CheckBox15)
        Me.sonde_conductivite.Controls.Add(Me.CheckBox14)
        Me.sonde_conductivite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sonde_conductivite.Location = New System.Drawing.Point(1070, 534)
        Me.sonde_conductivite.Name = "sonde_conductivite"
        Me.sonde_conductivite.Size = New System.Drawing.Size(248, 59)
        Me.sonde_conductivite.TabIndex = 15
        Me.sonde_conductivite.TabStop = False
        Me.sonde_conductivite.Text = "SONDES DE CONDUCTIVITE"
        '
        'CheckBox16
        '
        Me.CheckBox16.AutoSize = True
        Me.CheckBox16.Location = New System.Drawing.Point(192, 23)
        Me.CheckBox16.Name = "CheckBox16"
        Me.CheckBox16.Size = New System.Drawing.Size(54, 20)
        Me.CheckBox16.TabIndex = 12
        Me.CheckBox16.Text = "Q03"
        Me.CheckBox16.UseVisualStyleBackColor = True
        '
        'CheckBox15
        '
        Me.CheckBox15.AutoSize = True
        Me.CheckBox15.Location = New System.Drawing.Point(93, 23)
        Me.CheckBox15.Name = "CheckBox15"
        Me.CheckBox15.Size = New System.Drawing.Size(54, 20)
        Me.CheckBox15.TabIndex = 11
        Me.CheckBox15.Text = "Q02"
        Me.CheckBox15.UseVisualStyleBackColor = True
        '
        'CheckBox14
        '
        Me.CheckBox14.AutoSize = True
        Me.CheckBox14.Location = New System.Drawing.Point(6, 23)
        Me.CheckBox14.Name = "CheckBox14"
        Me.CheckBox14.Size = New System.Drawing.Size(54, 20)
        Me.CheckBox14.TabIndex = 10
        Me.CheckBox14.Text = "Q01"
        Me.CheckBox14.UseVisualStyleBackColor = True
        '
        'capteur_pression
        '
        Me.capteur_pression.BackColor = System.Drawing.Color.White
        Me.capteur_pression.Controls.Add(Me.CheckBox6)
        Me.capteur_pression.Controls.Add(Me.CheckBox7)
        Me.capteur_pression.Controls.Add(Me.CheckBox13)
        Me.capteur_pression.Controls.Add(Me.CheckBox8)
        Me.capteur_pression.Controls.Add(Me.CheckBox12)
        Me.capteur_pression.Controls.Add(Me.CheckBox9)
        Me.capteur_pression.Controls.Add(Me.CheckBox11)
        Me.capteur_pression.Controls.Add(Me.CheckBox10)
        Me.capteur_pression.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capteur_pression.Location = New System.Drawing.Point(740, 534)
        Me.capteur_pression.Name = "capteur_pression"
        Me.capteur_pression.Size = New System.Drawing.Size(248, 103)
        Me.capteur_pression.TabIndex = 14
        Me.capteur_pression.TabStop = False
        Me.capteur_pression.Text = "CAPTEURS DE PRESSION"
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(6, 32)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox6.TabIndex = 5
        Me.CheckBox6.Text = "PR01"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(6, 55)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox7.TabIndex = 6
        Me.CheckBox7.Text = "PR04"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'CheckBox13
        '
        Me.CheckBox13.AutoSize = True
        Me.CheckBox13.Location = New System.Drawing.Point(188, 55)
        Me.CheckBox13.Name = "CheckBox13"
        Me.CheckBox13.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox13.TabIndex = 12
        Me.CheckBox13.Text = "PR10"
        Me.CheckBox13.UseVisualStyleBackColor = True
        '
        'CheckBox8
        '
        Me.CheckBox8.AutoSize = True
        Me.CheckBox8.Location = New System.Drawing.Point(6, 78)
        Me.CheckBox8.Name = "CheckBox8"
        Me.CheckBox8.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox8.TabIndex = 7
        Me.CheckBox8.Text = "PR05"
        Me.CheckBox8.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Location = New System.Drawing.Point(188, 32)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox12.TabIndex = 11
        Me.CheckBox12.Text = "PR09"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'CheckBox9
        '
        Me.CheckBox9.AutoSize = True
        Me.CheckBox9.Location = New System.Drawing.Point(97, 32)
        Me.CheckBox9.Name = "CheckBox9"
        Me.CheckBox9.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox9.TabIndex = 8
        Me.CheckBox9.Text = "PR06"
        Me.CheckBox9.UseVisualStyleBackColor = True
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Location = New System.Drawing.Point(97, 78)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox11.TabIndex = 10
        Me.CheckBox11.Text = "PR08"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox10
        '
        Me.CheckBox10.AutoSize = True
        Me.CheckBox10.Location = New System.Drawing.Point(97, 55)
        Me.CheckBox10.Name = "CheckBox10"
        Me.CheckBox10.Size = New System.Drawing.Size(64, 20)
        Me.CheckBox10.TabIndex = 9
        Me.CheckBox10.Text = "PR07"
        Me.CheckBox10.UseVisualStyleBackColor = True
        '
        'capteur_debit
        '
        Me.capteur_debit.BackColor = System.Drawing.Color.White
        Me.capteur_debit.Controls.Add(Me.CheckBox1)
        Me.capteur_debit.Controls.Add(Me.CheckBox2)
        Me.capteur_debit.Controls.Add(Me.CheckBox3)
        Me.capteur_debit.Controls.Add(Me.CheckBox4)
        Me.capteur_debit.Controls.Add(Me.CheckBox5)
        Me.capteur_debit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capteur_debit.ForeColor = System.Drawing.Color.Black
        Me.capteur_debit.Location = New System.Drawing.Point(111, 390)
        Me.capteur_debit.Name = "capteur_debit"
        Me.capteur_debit.Size = New System.Drawing.Size(248, 108)
        Me.capteur_debit.TabIndex = 13
        Me.capteur_debit.TabStop = False
        Me.capteur_debit.Text = "CAPTEURS DE DEBIT"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 32)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 20)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "FL01"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(12, 55)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(60, 20)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "FL02"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CheckBox3.Location = New System.Drawing.Point(12, 78)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(60, 20)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "FL03"
        Me.CheckBox3.UseVisualStyleBackColor = False
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(167, 32)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(60, 20)
        Me.CheckBox4.TabIndex = 3
        Me.CheckBox4.Text = "FL04"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(167, 55)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(60, 20)
        Me.CheckBox5.TabIndex = 4
        Me.CheckBox5.Text = "FL05"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.White
        Me.GroupBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox7.Controls.Add(Me.RadioButton6)
        Me.GroupBox7.Controls.Add(Me.RadioButton5)
        Me.GroupBox7.Controls.Add(Me.RadioButton1)
        Me.GroupBox7.Controls.Add(Me.RadioButton2)
        Me.GroupBox7.Controls.Add(Me.RadioButton3)
        Me.GroupBox7.Controls.Add(Me.RadioButton4)
        Me.GroupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox7.Location = New System.Drawing.Point(111, 1)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(248, 154)
        Me.GroupBox7.TabIndex = 3
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "RECHERCHE"
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton6.Location = New System.Drawing.Point(15, 128)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(130, 20)
        Me.RadioButton6.TabIndex = 5
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "ECO VANNE V09"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton5.Location = New System.Drawing.Point(15, 106)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(226, 20)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "CAPTEURS PRE -TRAITEMENT"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(15, 18)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(208, 20)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "SONDES DE CONDUCTIVITE"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(15, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(212, 20)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "SONDES DE TEMPERATURE"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(15, 61)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(165, 20)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "CAPTEURS DE DEBIT"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.Location = New System.Drawing.Point(15, 83)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(194, 20)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "CAPTEURS DE PRESSION"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button2.Location = New System.Drawing.Point(15, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 90)
        Me.Button2.TabIndex = 23
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button3.Location = New System.Drawing.Point(12, 300)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 90)
        Me.Button3.TabIndex = 24
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button4.Location = New System.Drawing.Point(15, 150)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(90, 90)
        Me.Button4.TabIndex = 25
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.Location = New System.Drawing.Point(188, 69)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 53)
        Me.Button1.TabIndex = 24
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Sélection mail"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(6, 41)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(235, 24)
        Me.ComboBox2.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(111, 369)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 131)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Envoie de fichier par mail"
        '
        'capteur_pretraitement
        '
        Me.capteur_pretraitement.BackColor = System.Drawing.Color.White
        Me.capteur_pretraitement.Controls.Add(Me.CheckBox30)
        Me.capteur_pretraitement.Controls.Add(Me.CheckBox31)
        Me.capteur_pretraitement.Controls.Add(Me.CheckBox35)
        Me.capteur_pretraitement.Controls.Add(Me.CheckBox36)
        Me.capteur_pretraitement.Controls.Add(Me.CheckBox37)
        Me.capteur_pretraitement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capteur_pretraitement.Location = New System.Drawing.Point(998, 575)
        Me.capteur_pretraitement.Name = "capteur_pretraitement"
        Me.capteur_pretraitement.Size = New System.Drawing.Size(272, 124)
        Me.capteur_pretraitement.TabIndex = 28
        Me.capteur_pretraitement.TabStop = False
        Me.capteur_pretraitement.Text = "CAPTEURS PRE-TRAITEMENT"
        '
        'CheckBox30
        '
        Me.CheckBox30.AutoSize = True
        Me.CheckBox30.Location = New System.Drawing.Point(6, 93)
        Me.CheckBox30.Name = "CheckBox30"
        Me.CheckBox30.Size = New System.Drawing.Size(53, 20)
        Me.CheckBox30.TabIndex = 5
        Me.CheckBox30.Text = "T30"
        Me.CheckBox30.UseVisualStyleBackColor = True
        '
        'CheckBox31
        '
        Me.CheckBox31.AutoSize = True
        Me.CheckBox31.Location = New System.Drawing.Point(143, 93)
        Me.CheckBox31.Name = "CheckBox31"
        Me.CheckBox31.Size = New System.Drawing.Size(54, 20)
        Me.CheckBox31.TabIndex = 6
        Me.CheckBox31.Text = "Q30"
        Me.CheckBox31.UseVisualStyleBackColor = True
        '
        'CheckBox35
        '
        Me.CheckBox35.AutoSize = True
        Me.CheckBox35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox35.Location = New System.Drawing.Point(6, 23)
        Me.CheckBox35.Name = "CheckBox35"
        Me.CheckBox35.Size = New System.Drawing.Size(211, 17)
        Me.CheckBox35.TabIndex = 8
        Me.CheckBox35.Text = "Colmatage 1er étage de filtration"
        Me.CheckBox35.UseVisualStyleBackColor = True
        '
        'CheckBox36
        '
        Me.CheckBox36.AutoSize = True
        Me.CheckBox36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox36.Location = New System.Drawing.Point(6, 65)
        Me.CheckBox36.Name = "CheckBox36"
        Me.CheckBox36.Size = New System.Drawing.Size(223, 17)
        Me.CheckBox36.TabIndex = 10
        Me.CheckBox36.Text = "Colmatage 3éme étage de filtration"
        Me.CheckBox36.UseVisualStyleBackColor = True
        '
        'CheckBox37
        '
        Me.CheckBox37.AutoSize = True
        Me.CheckBox37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox37.Location = New System.Drawing.Point(6, 44)
        Me.CheckBox37.Name = "CheckBox37"
        Me.CheckBox37.Size = New System.Drawing.Size(223, 17)
        Me.CheckBox37.TabIndex = 9
        Me.CheckBox37.Text = "Colmatage 2éme étage de filtration"
        Me.CheckBox37.UseVisualStyleBackColor = True
        '
        'Recherche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1339, 711)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.capteur_debit)
        Me.Controls.Add(Me.capteur_pression)
        Me.Controls.Add(Me.sonde_temperature)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.sonde_conductivite)
        Me.Controls.Add(Me.critere_recherche)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.capteur_pretraitement)
        Me.Name = "Recherche"
        Me.Text = "Recherche"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.critere_recherche.ResumeLayout(False)
        Me.critere_recherche.PerformLayout()
        Me.sonde_temperature.ResumeLayout(False)
        Me.sonde_temperature.PerformLayout()
        Me.sonde_conductivite.ResumeLayout(False)
        Me.sonde_conductivite.PerformLayout()
        Me.capteur_pression.ResumeLayout(False)
        Me.capteur_pression.PerformLayout()
        Me.capteur_debit.ResumeLayout(False)
        Me.capteur_debit.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.capteur_pretraitement.ResumeLayout(False)
        Me.capteur_pretraitement.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents sonde_conductivite As GroupBox
    Friend WithEvents capteur_pression As GroupBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox13 As CheckBox
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox12 As CheckBox
    Friend WithEvents CheckBox9 As CheckBox
    Friend WithEvents CheckBox11 As CheckBox
    Friend WithEvents CheckBox10 As CheckBox
    Friend WithEvents capteur_debit As GroupBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents critere_recherche As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents sonde_temperature As GroupBox
    Friend WithEvents CheckBox27 As CheckBox
    Friend WithEvents CheckBox26 As CheckBox
    Friend WithEvents CheckBox25 As CheckBox
    Friend WithEvents CheckBox24 As CheckBox
    Friend WithEvents CheckBox23 As CheckBox
    Friend WithEvents CheckBox22 As CheckBox
    Friend WithEvents CheckBox21 As CheckBox
    Friend WithEvents CheckBox20 As CheckBox
    Friend WithEvents CheckBox19 As CheckBox
    Friend WithEvents CheckBox18 As CheckBox
    Friend WithEvents CheckBox17 As CheckBox
    Friend WithEvents CheckBox16 As CheckBox
    Friend WithEvents CheckBox15 As CheckBox
    Friend WithEvents CheckBox14 As CheckBox
    Friend WithEvents CheckBox28 As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents MaskedTextBox4 As MaskedTextBox
    Friend WithEvents MaskedTextBox3 As MaskedTextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBox29 As CheckBox
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents capteur_pretraitement As GroupBox
    Friend WithEvents CheckBox30 As CheckBox
    Friend WithEvents CheckBox31 As CheckBox
    Friend WithEvents CheckBox35 As CheckBox
    Friend WithEvents CheckBox36 As CheckBox
    Friend WithEvents CheckBox37 As CheckBox
    Friend WithEvents RadioButton6 As RadioButton
End Class
