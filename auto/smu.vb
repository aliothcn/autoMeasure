Public Class smu
#Region "私有成员"
    Private _url As String
    Private _mode As String '模式:swe
    Private _shape As String '形状:DC\Puls
    Private _delay As Decimal
    Private _start As Decimal
    Private _stop As Decimal
    Private _range As String
    Private _point As Integer
    Private _aperture As Decimal
    Private _remote As String
#End Region
#Region "属性"
    Public Property Url As String
        Get
            Return _url
        End Get
        Set(value As String)
            _url = value
        End Set
    End Property
    Public Property Mode As String
        Get
            Return _mode
        End Get
        Set(value As String)
            _mode = value
        End Set
    End Property

    Public Property Shape As String
        Get
            Return _shape
        End Get
        Set(value As String)
            _shape = value
        End Set
    End Property

    Public Property Delay As Decimal
        Get
            Return _delay
        End Get
        Set(value As Decimal)
            _delay = value
        End Set
    End Property

    Public Property Start As Decimal
        Get
            Return _start
        End Get
        Set(value As Decimal)
            _start = value
        End Set
    End Property

    Public Property [Stop] As Decimal
        Get
            Return _stop
        End Get
        Set(value As Decimal)
            _stop = value
        End Set
    End Property

    Public Property Range As String
        Get
            Return _range
        End Get
        Set(value As String)
            _range = value
        End Set
    End Property

    Public Property Point As Integer
        Get
            Return _point
        End Get
        Set(value As Integer)
            _point = value
        End Set
    End Property

    Public Property Aperture As Decimal
        Get
            Return _aperture
        End Get
        Set(value As Decimal)
            _aperture = value
        End Set
    End Property

    Public Property Remote As String
        Get
            Return _remote
        End Get
        Set(value As String)
            _remote = value
        End Set
    End Property


#End Region
#Region "方法"
    Public Sub New(_mode As String, _shape As String, _delay As Decimal, _start As Decimal, _stop As Decimal, _range As String, _point As Integer, _aperture As Decimal, _remote As String)
        Me._mode = _mode
        Me._shape = _shape
        Me._delay = _delay
        Me._start = _start
        Me._stop = _stop
        Me._range = _range
        Me._point = _point
        Me._aperture = _aperture
        Me._remote = _remote
    End Sub
    Public Sub New()

    End Sub
#End Region
End Class
