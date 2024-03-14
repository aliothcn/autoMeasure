Imports System.ComponentModel
Imports System.IO
Imports Ivi.Visa.Interop
Imports TwinCAT.Ads

Public Class Form1
    Dim smuConfig As New smu
    Dim smu0Config As New smu '模式0
    Dim smu1Config As New smu '模式1
    Dim axisConfig As New axis
    Dim plc As TcAdsClient 'ads client
    Dim iStream As New AdsStream(2 * 2)
    Dim iBinRead As New BinaryReader(iStream)
    Dim power3url, power1url As String
    Dim power3 As FormattedIO488
    Dim power1 As FormattedIO488
    Dim smu As FormattedIO488
    Dim starttime As DateTime
    Dim thismodel As Int16 = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_config()
    End Sub
    Private Sub load_config()
        log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & "加载ini:" & ini.inipath)

        smu0Config.Url = GetStrFromINI("smu", "url", "")
        smu0Config.Mode = GetStrFromINI("smu", "mode", "SWE")
        smu0Config.Remote = GetStrFromINI("smu", "remote", "OFF")
        smu0Config.Shape = GetStrFromINI("smu", "shape", "DC")
        smu0Config.Delay = GetStrFromINI("smu", "delay", "0.01")
        smu0Config.Range = GetStrFromINI("smu", "range", "BEST")
        smu0Config.Start = GetStrFromINI("smu", "start", "-15")
        smu0Config.Stop = GetStrFromINI("smu", "stop", "15")
        smu0Config.Point = GetStrFromINI("smu", "point", "101")
        smu0Config.Aperture = GetStrFromINI("smu", "aperture", "0.03")

        smu1Config.Url = GetStrFromINI("smu", "url", "")
        smu1Config.Mode = GetStrFromINI("smu", "mode1", "SWE")
        smu1Config.Remote = GetStrFromINI("smu", "remote1", "OFF")
        smu1Config.Shape = GetStrFromINI("smu", "shape1", "DC")
        smu1Config.Delay = GetStrFromINI("smu", "delay1", "0.01")
        smu1Config.Range = GetStrFromINI("smu", "range1", "BEST")
        smu1Config.Start = GetStrFromINI("smu", "start1", "-15")
        smu1Config.Stop = GetStrFromINI("smu", "stop1", "15")
        smu1Config.Point = GetStrFromINI("smu", "point1", "101")
        smu1Config.Aperture = GetStrFromINI("smu", "aperture1", "0.03")
        log.Items.Add("模式A:" & smu0Config.Start & "~" & smu0Config.Stop & ":" & smu0Config.Point)
        log.Items.Add("模式B:" & smu1Config.Start & "~" & smu1Config.Stop & ":" & smu1Config.Point)

        axisConfig.Xmin = GetStrFromINI("axis", "xmin", "0")
        axisConfig.Xmax = GetStrFromINI("axis", "xmax", "1")
        axisConfig.Ymin = GetStrFromINI("axis", "ymin", "0")
        axisConfig.Ymax = GetStrFromINI("axis", "ymax", "1")
        axisConfig.Step = GetStrFromINI("axis", "step", "0.1")

        power3url = GetStrFromINI("power3", "url", "")
        power1url = GetStrFromINI("power1", "url", "")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim iok As Integer = 0
        'plc
        Try
            plc = New TcAdsClient
            plc.Connect("10.1.34.184.1.1", 801)
            log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & "连接PLC")
            iok = iok + 1
        Catch ex As Exception
            log.Items.Add("连接PLC出错:" & ex.Message)
            Debug.Print(ex.Message)
        End Try
        'power3
        If power3url <> "" Then
            Dim ioMgr As New Ivi.Visa.Interop.ResourceManager
            power3 = New Ivi.Visa.Interop.FormattedIO488

            Try
                power3.IO = ioMgr.Open(power3url)
                power3.WriteString("*IDN?")
                Dim re As String
                re = power3.ReadString
                log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & "连接阴极电源" & re)
                iok = iok + 1
            Catch ex As Exception
                iok = iok + 1
                log.Items.Add("连接阴极电源出错:" & ex.Message)
                Debug.Print(ex.Message)
            End Try
        Else
            MsgBox("请设置阴极电源接口",, "提示")
        End If
        'power1
        If power1url <> "" Then
            Dim ioMgr As New Ivi.Visa.Interop.ResourceManager
            power1 = New Ivi.Visa.Interop.FormattedIO488
            Try
                power1.IO = ioMgr.Open(power1url)
                power1.WriteString("*IDN?")
                Dim re As String
                re = power1.ReadString
                log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & "连接栅极电源" & re)
                iok = iok + 1
            Catch ex As Exception
                iok = iok + 1
                log.Items.Add("连接栅极电源出错:" & ex.Message)
                Debug.Print(ex.Message)
            End Try
        Else
            MsgBox("请设置栅极电源接口",, "提示")
        End If
        'smu
        smuConfig = smu0Config
        If smuConfig.Url <> "" Then
            Dim ioMgr As New Ivi.Visa.Interop.ResourceManager
            smu = New Ivi.Visa.Interop.FormattedIO488
            Try
                smu.IO = ioMgr.Open(smuConfig.Url)

                smu.WriteString("*RST") '复位
                smu.WriteString("*IDN?")
                Dim re As String
                re = smu.ReadString
                log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & "连接源表" & re)
                iok = iok + 1
            Catch ex As Exception
                iok = iok + 1
                log.Items.Add("连接源表出错:" & ex.Message)
                Debug.Print(ex.Message)
            End Try
        Else
            MsgBox("请设置源表接口",, "提示")
        End If
        If iok > 3 Then
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim path As String
        path = txtpath.Text
        path = Mid(path, path.Length, 1)
        If path <> "\" Then
            txtpath.Text = txtpath.Text & "\"
        End If
        Button4.Enabled = True
        Button2.Enabled = False
        test()
    End Sub
    Private Sub test()
        starttime = Now
        result.Items.Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        result.Items.Add("时间:" & Format(Now, "yyyy-MM-dd HH:mm:ss"))
        readPlc()
        readPower(power3, "阴极电源")
        readPower(power1, "栅极电源")
        Try
            '开始测量
            If modelChange.Checked Then
                If thismodel = 0 Then
                    smuConfig = smu0Config
                    thismodel = 1
                Else
                    smuConfig = smu1Config
                    thismodel = 0
                End If
            End If
            Timer1.Interval = smuConfig.Point * (smuConfig.Aperture + smuConfig.Delay + 0.01) * 1000
            Timer1.Enabled = True
            Debug.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & smuConfig.Start & "-" & smuConfig.Stop & ":" & smuConfig.Point)

            log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & " 开始测量  " & smuConfig.Start & "V ~ " & smuConfig.Stop & "V:" & smuConfig.Point)
            '基本参数
            smu.WriteString("*RST") '复位
            smu.WriteString(":OUTP1:LOW GRO") 'CH1接地
            smu.WriteString(":OUTP2:LOW FLO") 'CH2悬浮
            smu.WriteString(":SENS1:REM " & smuConfig.Remote) 'CH1四线制
            '源设置
            smu.WriteString(":SOUR1:FUNC:MODE VOLT") 'CH1电压源
            smu.WriteString(":SOUR1:VOLT:MODE " & smuConfig.Mode)  'CH1扫描
            If smuConfig.Mode = "SWE" Then
                smu.WriteString(":SOUR1:FUNC:SHAP " & smuConfig.Shape) 'CH1扫描模式DC
                smu.WriteString(":SOUR1:SWE:RANG " & smuConfig.Range) 'CH1量程BEST
                smu.WriteString(":SOUR1:SWE:SPAC LIN") 'CH1扫描线性
                smu.WriteString(":SOUR1:SWE:STA SING") 'CH1扫描单次扫描
                smu.WriteString(":SOUR1:VOLT:STAR " & smuConfig.Start) 'CH1扫描起始值
                smu.WriteString(":SOUR1:VOLT:STOP " & smuConfig.Stop) 'CH1扫描终止值
                smu.WriteString(":SOUR1:SWE:POIN " & smuConfig.Point) 'CH1扫描单次扫描
            End If
            smu.WriteString(":SOUR1:VOLT " & smuConfig.Start) 'CH1扫描起始值

            smu.WriteString(":SOUR2:FUNC:MODE VOLT") 'CH2电压源
            smu.WriteString(":SOUR2:VOLT:MODE FIX") 'CH2恒定
            smu.WriteString(":SOUR2:VOLT 0") 'CH2电压0
            '表设置
            smu.WriteString(":SENS1:FUNC ""CURR""") 'CH1测量电流
            '            smu.WriteString(":SENS1:CURR:NPLC 0.1") '
            smu.WriteString(":SENS1:CURR:PROT 0.1")
            smu.WriteString(":SENS1:CURR:RANG:AUTO OFF") '关闭自动量程
            smu.WriteString(":SENS1:CURR:RANG 1e-1") '0.1A

            smu.WriteString(":SENS2:FUNC ""CURR""") 'CH2测量电流
            smu.WriteString(":SENS2:CURR:PROT 0.1")
            smu.WriteString(":SENS2:CURR:RANG:AUTO OFF") '关闭自动量程
            smu.WriteString(":SENS2:CURR:RANG 1e-1") '0.1A
            '
            smu.WriteString("ARM:ALL:DEL " & smuConfig.Delay)
            smu.WriteString("ARM2:ALL:DEL " & smuConfig.Delay)
            smu.WriteString(":TRIG1:DEL " & smuConfig.Delay)
            smu.WriteString(":TRIG2:DEL " & smuConfig.Delay)
            smu.WriteString(":SENS:CURR:APER:AUTO 0") '积分时间
            smu.WriteString(":SENS:CURR:APER " & smuConfig.Aperture)

            smu.WriteString(":TRIG:SOUR AINT") '
            smu.WriteString(":TRIG:COUN " & smuConfig.Point) '
            smu.WriteString(":TRIG2:SOUR AINT") '
            smu.WriteString(":TRIG2:COUN " & smuConfig.Point) '
            smu.WriteString(":FORM:ELEM:SENS VOLT,CURR,TIME")
            smu.WriteString(":FORM:ELEM:SENS2 VOLT,CURR,TIME")
            smu.WriteString("OUTP1 ON") '
            smu.WriteString("OUTP2 ON") '
            smu.WriteString(":INIT (@1,2)") '
        Catch ex As Exception
            log.Items.Add("开始测量出错:" & ex.Message)
            Timer1.Enabled = False
            Debug.Print(ex.Message)
        End Try

    End Sub

    Private Sub readPlc()
        Try
            log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & " 读取PLC")
            plc.Read(&H4020, 208, iStream)
            iStream.Position = 0
            result.Items.Add("全量程规压力:" & iBinRead.ReadSingle() & "Pa")

            plc.Read(&H4020, 220, iStream)
            iStream.Position = 0
            result.Items.Add("氧气流量:" & iBinRead.ReadSingle().ToString())

            plc.Read(&H4020, 224, iStream)
            iStream.Position = 0
            result.Items.Add("氮气流量:" & iBinRead.ReadSingle().ToString())

            plc.Read(&H4020, 228, iStream)
            iStream.Position = 0
            result.Items.Add("氩气流量:" & iBinRead.ReadSingle().ToString())

            plc.Read(&H4020, 232, iStream)
            iStream.Position = 0
            result.Items.Add("腔体温度:" & iBinRead.ReadSingle().ToString() & "℃")

            'Try
            '    plc.Read(&HF031, 2100, bStream)
            '    bStream.Position = 0
            '    result.Items.Add("插板阀开启指示:" & bBinRead.ReadBoolean())
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try

            plc.Read(&HF030, 2044, iStream)
            iStream.Position = 0
            result.Items.Add("插板阀圈数:" & iBinRead.ReadSingle().ToString())

            plc.Read(&HF030, 2036, iStream)
            iStream.Position = 0
            result.Items.Add("电机1实时位置:" & iBinRead.ReadSingle().ToString())

            plc.Read(&HF030, 2040, iStream)
            iStream.Position = 0
            result.Items.Add("电机2实时位置:" & iBinRead.ReadSingle().ToString())
        Catch ex As Exception
            log.Items.Add("读取PLC出错:" & ex.Message)
        End Try

    End Sub

    Private Sub result_SelectedIndexChanged(sender As Object, e As EventArgs) Handles result.SelectedIndexChanged

        'TextBox1.Text = result.Items(result.SelectedIndex)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & " 读取测量结果")
            '读取结果
            smu.WriteString(":FETC:ARR? (@1)") '
            ' result.Items.Add(smu.ReadString())
            TextBox1.Text = smu.ReadString()
            smu.WriteString(":FETC:ARR? (@2)") '
            ' result.Items.Add(smu.ReadString())
            TextBox2.Text = smu.ReadString()
        Catch ex As Exception
            log.Items.Add("读取结果出错:" & ex.Message)
        End Try
        Try
            '结束测量
            log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & " 结束测量")
            smu.WriteString("OUTP OFF") '
            smu.WriteString("OUTP2 OFF") '
        Catch ex As Exception
            log.Items.Add("结束测量出错:" & ex.Message)
        End Try
        log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & " 保存结果")
        Dim myFile As New IO.FileStream(txtpath.Text & Format(starttime, "yyyyMMddHHmmss") & ".txt", FileMode.OpenOrCreate, FileAccess.Write)
        Dim tw As New StreamWriter(myFile)
        myFile.Seek(0, SeekOrigin.End)
        For i = 0 To result.Items.Count - 1
            tw.WriteLine(result.Items(i))
        Next
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            '保存
            Dim re1() As String
            Dim re2() As String
            re1 = TextBox1.Text.Replace(Chr(13), "").Replace(Chr(10), "").Split(",")
            re2 = TextBox2.Text.Replace(Chr(13), "").Replace(Chr(10), "").Split(",")
            For j = 0 To re1.Length / 3 - 1
                Try
                    tw.WriteLine(re1(j * 3) & "," & re1(j * 3 + 1) & "," & re1(j * 3 + 2) & "," & re2(j * 3) & "," & re2(j * 3 + 1) & "," & re2(j * 3 + 2))
                Catch ex As Exception

                End Try
            Next
        End If
        '关闭流
        tw.Close()

        '关闭文件并保存文件
        myFile.Close()
        If isLoop.Checked Then
            tloop.Interval = loopTimeValue.Value * 1000
            tloop.Enabled = True
        Else

            Button2.Enabled = True
        End If
    End Sub

    Private Sub tloop_Tick(sender As Object, e As EventArgs) Handles tloop.Tick
        tloop.Enabled = False
        test()
    End Sub

    Private Sub readPower(ByRef power As FormattedIO488, name As String)
        Dim re As String
        re = name & "电压:"
        log.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & " 读取 " & name)
        Try
            power.WriteString("MEAS:VOLT?")
            re = re & power.ReadNumber
            power.WriteString("MEAS:curr?")
            re = re & "V 电流:" & power.ReadNumber & "A"
            result.Items.Add(re)
        Catch ex As Exception
            log.Items.Add("读取" & name & "出错:" & ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Timer1.Enabled = False
        tloop.Enabled = False
        isLoop.Checked = False
        Button2.Enabled = True
        Try
            smu.WriteString("*RST") '复位
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        openini.Filter = "配置文件(*.ini;*.txt)|*.ini;*.txt"
        openini.FileName = "config"

        If openini.ShowDialog() = DialogResult.OK Then

            ini.inipath = openini.FileName
            load_config()
        End If

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            plc.Close()
        Catch ex As Exception

        End Try
        Try
            power1.IO.Close()
        Catch ex As Exception

        End Try
        Try
            power3.IO.Close()
        Catch ex As Exception

        End Try
        Try
            smu.IO.Close()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TextBox1.Width = Width / 2 - 20
        TextBox1.Height = Height - 570

        TextBox2.Width = Width / 2 - 20
        TextBox2.Left = Width / 2 - 5
        TextBox2.Height = Height - 570

        log.Width = Width / 2 - 100

        result.Left = Width / 2 - 85
        result.Width = Width / 2 + 60
    End Sub
End Class
