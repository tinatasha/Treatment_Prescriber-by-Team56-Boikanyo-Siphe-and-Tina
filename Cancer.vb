' *****************************************************************
' Team Number: 56
' Team Member 1 Details: Mbita, TTN (221141970)
' Team Member 2 Details: Memani, XM (222074392)
' Team Member 3 Details: Ramafalo, B (222102425)
' Team Member 4 Details: Thusini, LS (219053897)
' Practical: Team56Project
' *****************************************************************
Option Strict On
Option Explicit On
Option Infer Off
Public Class Cancer

    Inherits Disease

    'Instance Variables
    Private _CancerType As String
    Private _Stage As Integer

    'Constructors
    Sub New()

    End Sub

    Sub New(TypeD As String, ptpTrans As Boolean, prevention As String)
        _Type = TypeD
        _PtPTrans = ptpTrans
        _Prevention = prevention
    End Sub

    'Property Methods
    Public Property CancerType As String
        Get
            Return _CancerType
        End Get
        Set(value As String)
            _CancerType = value
        End Set
    End Property

    Public Property Stage As Integer
        Get
            Return _Stage
        End Get
        Set(value As Integer)
            _Stage = value
        End Set
    End Property

    'overrides Function
    Public Overrides Function PrescTreatment() As String
        'For different stages of Cancer there is a recommended treatment
        Dim treatment As String
        treatment = " "
        If _Stage = 1 Then
            treatment = "Palliative Treatment"
        End If
        If _Stage = 2 Then
            treatment = "Adjavant Treatment"
        End If
        If _Stage = 3 Then
            treatment = "Primary Treatment"
        End If
        If _Stage = 4 Then
            treatment = "Primary Treatment"
        End If

        Return treatment
    End Function

    Public Function SurvivalLikelyhood() As String
        Dim result As String
        result = " "  'To confirm 
        If _Stage = 1 Then
            result = "High"
        ElseIf _Stage = 2 Then
            result = "Most Likely"
        ElseIf _Stage = 3 Then
            result = "Low"
        ElseIf _Stage = 4 Then
            result = "Very Low"
        End If
        Return result
    End Function

End Class
