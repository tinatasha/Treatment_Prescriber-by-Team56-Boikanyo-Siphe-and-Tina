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
Public Class HIV
    Inherits Disease

    'Attributes/ Instance variables
    Private _CD4 As Double
    Private _ViralLoad As Double
    Private _numSymptoms As Integer

    'Constructor
    Sub New()

    End Sub
    Sub New(Type As String, ptptrans As Boolean, prevention As String)
        _Type = Type
        _PtPTrans = ptptrans
        _Prevention = prevention
    End Sub

    'Property Methods
    Public Property CD4 As Double
        Get
            Return _CD4
        End Get
        Set(value As Double)
            _CD4 = value
        End Set
    End Property

    Public Property ViralLoad As Double
        Get
            Return _ViralLoad
        End Get
        Set(value As Double)
            _ViralLoad = value
        End Set
    End Property
    Public Property Symptoms As Integer
        Get
            Return _numSymptoms
        End Get
        Set(value As Integer)
            _numSymptoms = value
        End Set
    End Property

    Public Function DetermineStage() As Integer
        Dim Stage As Integer

        If _numSymptoms <= 0 Then
            Stage = 1
        Else
            If _numSymptoms > 0 And _numSymptoms < 3 Then
                Stage = 2
            Else
                If _numSymptoms >= 3 And _numSymptoms < 5 Then
                    Stage = 3
                Else
                    Stage = 4
                End If
            End If
        End If

        Return Stage
    End Function
    Public Overrides Function PrescTreatment() As String
        Dim Treatment As String
        Dim Measure As Integer

        If DetermineStage() = 1 Then
            Measure = 100
        Else
            If DetermineStage() = 2 Then
                Measure = 250
            Else
                If DetermineStage() = 3 Then
                    Measure = 400
                Else
                    If DetermineStage() = 4 Then
                        Measure = 550
                    End If
                End If
            End If
        End If
        Treatment = _Prevention

        Return CStr(Measure) & "g/ daily ARVS"
    End Function

    Public Function VirusDetactablility(ViralLoad As Double) As String
        Dim Undetactable As Double = 200
        Dim Message As String
        If ViralLoad <= Undetactable Then
            Message = "Undetactable"
        Else
            Message = "Detactable"
        End If
        Return Message
    End Function

End Class
