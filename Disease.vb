' *****************************************************************
' Team Number: 56
' Team Member 1 Details: Mbita, TTN (221141970)
' Team Member 2 Details: Memani, XM (222074392)
' Team Member 3 Details: Ramafalo, B (222102425)
' Team Member 4 Details: Thusini, LS (219053897)
' Practical: Team56Project
' *****************************************************************
Option Explicit On
Option Strict On
Option Infer Off
Public MustInherit Class Disease
    'Attributes/ instance variables
    Protected _Type As String
    Protected _PtPTrans As Boolean
    Protected _Prevention As String

    'Constuctors
    Sub New()
        'Nothing
    End Sub

    Sub New(Type As String, PtPTrans As Boolean, Prevention As String)
        _Type = Type
        _PtPTrans = PtPTrans
        _Prevention = _Prevention
    End Sub

    'Property Methods
    Public Property Type As String
        Get
            Return _Type
        End Get
        Set(value As String)
            _Type = value
        End Set
    End Property

    Public Property PtPTrans As Boolean
        Get
            Return _PtPTrans
        End Get
        Set(value As Boolean)
            _PtPTrans = value
        End Set
    End Property

    Public Property Prevention As String
        Get
            Return _Prevention
        End Get
        Set(value As String)
            _Prevention = value
        End Set
    End Property


    'Overrides Method
    Public MustOverride Function PrescTreatment() As String

End Class
