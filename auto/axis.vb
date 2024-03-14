Public Class axis
#Region "私有成员"
    Private _xmin As Decimal
    Private _xmax As Decimal
    Private _ymin As Decimal
    Private _ymax As Decimal
    Private _step As Decimal
#End Region
#Region "属性"

    Public Property Xmin As Decimal
        Get
            Return _xmin
        End Get
        Set(value As Decimal)
            _xmin = value
        End Set
    End Property

    Public Property Xmax As Decimal
        Get
            Return _xmax
        End Get
        Set(value As Decimal)
            _xmax = value
        End Set
    End Property

    Public Property Ymin As Decimal
        Get
            Return _ymin
        End Get
        Set(value As Decimal)
            _ymin = value
        End Set
    End Property

    Public Property Ymax As Decimal
        Get
            Return _ymax
        End Get
        Set(value As Decimal)
            _ymax = value
        End Set
    End Property

    Public Property [Step] As Decimal
        Get
            Return _step
        End Get
        Set(value As Decimal)
            _step = value
        End Set
    End Property
#End Region
End Class
