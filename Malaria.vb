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
Public Class Malaria

    Inherits Disease

    'Instance Variables
    Private _Duration As Integer
    Private _MalariaType As String
    Private _Weight As Double
    'Constuctor
    Sub New()

    End Sub

    Sub New(type As String, ptptrans As Boolean, prevention As String)
        _Type = type
        _PtPTrans = ptptrans
        _Prevention = prevention
    End Sub

    'Property Methods
    Public Property Duration As Integer
        Get
            Return _Duration
        End Get
        Set(value As Integer)
            _Duration = value
        End Set
    End Property
    Public Property MalariaType As String
        Get
            Return _MalariaType
        End Get
        Set(value As String)
            _MalariaType = value
        End Set
    End Property

    Public Property Weight As Double
        Get
            Return _Weight
        End Get
        Set(value As Double)
            _Weight = value
        End Set
    End Property


    Public Function isCelebralMalaria() As String
        Dim Damage As String
        Damage = ""
        If _Duration >= 4 Then
            Damage = "Celebral Malaria is possible"
        End If
        If _Duration < 4 Then
            Damage = "No Celebral Malaria"
        End If
        Return Damage
    End Function

    'Utility Method
    Public Function IsUnderWeight() As Boolean
        If _Weight <= 10 Then
            Return True
        Else
            Return False
        End If
    End Function


    'Overrides Function
    Public Overrides Function PrescTreatment() As String
        Dim Treatment As String
        Treatment = " "
        If IsUnderWeight() = True Then
            Treatment = "Atovapoune/Proguanil(3 pediatric tablet daily)"
        Else
            Treatment = "Atovapoune/Proguanil(1 pediatric tablet daily)"
        End If
        Return Treatment
    End Function
End Class
