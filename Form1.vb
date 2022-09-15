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

Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Public Class FrmDisease
    'Variables
    Private Diseases() As Disease
    Private nDiseases As Integer
    'Files Variables
    Private FS As FileStream
    Private BF As BinaryFormatter
    Private Const FileName As String = "IFM_T56.ifm"
    'Enumeration for Disease choice
    Enum Choose
        HIV = 1
        Malaria = 2
        Cancer = 3
    End Enum
    Private Sub btnInit_Click(sender As Object, e As EventArgs) Handles BtnInit.Click
        nDiseases = CInt(InputBox("Enter the number of patients: "))
        ReDim Diseases(nDiseases)  'Resize the Array according to Number of Diseases

        For D As Integer = 1 To nDiseases
            Dim choice As Integer
            choice = CInt(InputBox("What disease does Patient " & CStr(D) & " have? :" & Environment.NewLine & "1.) HIV, 2.) Malaria, 3.) Cancer : ")) 'Choose which Disease you want to capture
            Select Case choice

                Case Choose.HIV
                    Dim HIVs As HIV
                    HIVs = New HIV()
                    HIVs.Type = InputBox("What type of disease is HIV:")
                    HIVs.Prevention = InputBox("How to prevent HIV?")
                    Dim PtP As String
                    PtP = InputBox("Is HIV person to person transmitted? y-yes, n-no")

                    Select Case PtP
                        Case "y"
                            HIVs.PtPTrans = True
                        Case "n"
                            HIVs.PtPTrans = False
                    End Select

                    HIVs.Symptoms = CInt(InputBox("How many Symptoms does Patient" & CStr(D) & " have?"))
                    HIVs.CD4 = CDbl(InputBox("What is the CD4 count of a patient?"))
                    HIVs.ViralLoad = CDbl(InputBox("What is the viral Load?"))
                    Diseases(D) = HIVs

                Case Choose.Malaria
                    Dim Malarias As Malaria
                    Malarias = New Malaria()
                    Malarias.Type = InputBox("What type of disease is Malaria?")
                    Malarias.Prevention = InputBox("How to prevent Malaria?")
                    Dim PtP As String
                    PtP = InputBox("Is it person to person transmitted? y-yes, n-no")
                    Select Case PtP
                        Case "y"
                            Malarias.PtPTrans = True
                        Case "n"
                            Malarias.PtPTrans = False
                    End Select


                    Malarias.Weight = CDbl(InputBox("What's the weight of the patient?"))
                    Malarias.MalariaType = InputBox("What type of Malaria?")
                    Malarias.Duration = CInt(InputBox("How long as the patient been diagnosed"))
                    Diseases(D) = Malarias

                Case Choose.Cancer
                    Dim Cancers As Cancer
                    Cancers = New Cancer()
                    Cancers.Type = InputBox("What type of disease is Cancer?")
                    Cancers.Prevention = InputBox("How to prevent Cancer?")
                    Dim PtP As String
                    PtP = InputBox("Is Canccer person to person transmitted? y-yes, n-no")
                    Select Case PtP
                        Case "y"
                            Cancers.PtPTrans = True
                        Case "n"
                            Cancers.PtPTrans = False
                    End Select

                    Cancers.CancerType = InputBox("What type of Cancer")
                    Cancers.Stage = CInt(InputBox("What stage is the cancer?"))
                    Diseases(D) = Cancers

            End Select
        Next D

    End Sub

    Public Sub PT(r As Integer, c As Integer, t As String)
        grdDiseases.Row = r
        grdDiseases.Col = c
        grdDiseases.Text = t
    End Sub


    Private Sub BtnHiv_Click(sender As Object, e As EventArgs) Handles BtnHiv.Click

        'Grid setup
        grdDiseases.Cols = 8
        grdDiseases.Rows = nDiseases + 1

        'Labelling grid
        PT(0, 1, "Type")
        PT(0, 2, "Prevention")
        PT(0, 3, "Transmittable")
        PT(0, 4, "CD4")
        PT(0, 5, "Viral Load")
        PT(0, 6, "Detactability")
        PT(0, 7, "Treatment")

        Dim counter As Integer = 0

        For i As Integer = 1 To nDiseases
            Dim HIvs As HIV
            HIvs = TryCast(Diseases(i), HIV) 'Downcasting
            If Not (HIvs Is Nothing) Then
                counter += 1
                'Displaying in grid
                PT(counter, 0, "HIV #" & CStr(counter))
                PT(counter, 1, HIvs.Type)
                PT(counter, 2, HIvs.Prevention)
                PT(counter, 3, CStr(HIvs.PtPTrans))
                PT(counter, 4, CStr(HIvs.CD4))
                PT(counter, 5, CStr(HIvs.ViralLoad))
                PT(counter, 6, HIvs.VirusDetactablility(HIvs.ViralLoad))
                PT(counter, 7, HIvs.PrescTreatment)
            End If

        Next i
    End Sub

    Private Sub BtnCancer_Click(sender As Object, e As EventArgs) Handles BtnCancer.Click
        'clear the grid
        For r As Integer = 0 To nDiseases
            For c As Integer = 0 To 6
                PT(r, c, " ")
            Next
        Next

        'Grid setup
        grdDiseases.Cols = 8
        grdDiseases.Rows = nDiseases + 1


        'Labelling grid
        PT(0, 1, "Type")
        PT(0, 2, "Prevention")
        PT(0, 3, "Transmittable")
        PT(0, 4, "Cancer Type")
        PT(0, 5, "Stage")
        PT(0, 6, "Survival Likelihood")
        PT(0, 7, "Treatment")

        Dim counter As Integer = 0

        For i As Integer = 1 To nDiseases

            'Downcasting
            Dim Cancers As Cancer
            Cancers = TryCast(Diseases(i), Cancer)
            If Not (Cancers Is Nothing) Then
                counter += 1
                'Displaying in grid
                PT(counter, 0, "Cancer #" & CStr(counter))
                PT(counter, 1, Cancers.Type)
                PT(counter, 2, Cancers.Prevention)
                PT(counter, 3, CStr(Cancers.PtPTrans))
                PT(counter, 4, Cancers.CancerType)
                PT(counter, 5, CStr(Cancers.Stage))
                PT(counter, 6, Cancers.SurvivalLikelyhood)
                PT(counter, 7, Cancers.PrescTreatment)
            End If
        Next i
    End Sub

    Private Sub BtnMalaria_Click(sender As Object, e As EventArgs) Handles BtnMalaria.Click

        'Clear the grid
        For r As Integer = 0 To nDiseases
            For c As Integer = 0 To 7
                PT(r, c, " ")
            Next
        Next

        'Grid setup
        grdDiseases.Cols = 8
        grdDiseases.Rows = nDiseases + 1


        'Labelling grid
        PT(0, 1, "Type")
        PT(0, 2, "Prevention")
        PT(0, 3, "Transmittable")
        PT(0, 4, "Malaria Type")
        PT(0, 5, "Duration")
        PT(0, 6, "Treatment")

        Dim counter As Integer = 0


        For i As Integer = 1 To nDiseases
            Dim Malarias As Malaria
            Malarias = TryCast(Diseases(i), Malaria) 'Downcasting
            If Not (Malarias Is Nothing) Then
                counter += 1
                'Displaying in grid
                PT(counter, 0, "Malaria #" & CStr(counter))
                PT(counter, 1, Malarias.Type)
                PT(counter, 2, Malarias.Prevention)
                PT(counter, 3, CStr(Malarias.PtPTrans))
                PT(counter, 4, Malarias.MalariaType)
                PT(counter, 5, CStr(Malarias.Duration))
                PT(counter, 6, Malarias.isCelebralMalaria)
                PT(counter, 7, Malarias.PrescTreatment)
            End If

        Next i
    End Sub
    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        grdDiseases.Cols = 3
        grdDiseases.Rows = nDiseases + 1

        PT(0, 0, "Patient#")
        PT(0, 1, "Disease")
        PT(0, 2, "Treatment")
        'label the grid
        For i As Integer = 1 To nDiseases
            PT(i, 0, "Patient" & CStr(i))
            PT(i, 1, Diseases(i).GetType.Name)
            PT(i, 2, Diseases(i).PrescTreatment)
        Next
    End Sub
    Private Sub btnSaveProgress_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        FS = New FileStream(FileName, FileMode.Create, FileAccess.Write)
        BF = New BinaryFormatter()

        For i As Integer = 1 To nDiseases
            Try
                BF.Serialize(FS, nDiseases)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next i
        FS.Close()
        MsgBox("Your File Is Saved!")

    End Sub

End Class
