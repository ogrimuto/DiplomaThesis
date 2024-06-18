Option Explicit On
Imports System.Data.OleDb
Imports System.Data
Public Class clsOleDBReadUpdateDB
    Public stSelect, stInsert, stUpdate, stDelete As String
    Public InsertComm, UpdateComm, DeleteComm As OleDbCommand
    Dim List As New ListBox
    Dim dbConnection As OleDbConnection
    Dim DA As OleDbDataAdapter
    Dim DS As DataSet
    'Dim Builder As OleDbCommandBuilder
    Dim locSQLstring As String
    Public Record As DataRow

    
    '_______________Создание  DS,DA
    Public Sub New(ByVal ConnString As String, ByVal SQLstring As String)
        Try
            dbConnection = New OleDbConnection(ConnString)
            dbConnection.Open()
            locSQLstring = SQLstring
            DA = New OleDbDataAdapter(SQLstring, dbConnection)

            DA.SelectCommand = New OleDbCommand(SQLstring, dbConnection)
            DA.InsertCommand = New OleDbCommand
            DA.UpdateCommand = New OleDbCommand

            DA.SelectCommand = New OleDbCommand(SQLstring, dbConnection)
            'DA.InsertCommand = InsertComm
            'DA.UpdateCommand = UpdateComm
            DA.SelectCommand.CommandType = CommandType.Text
            DA.InsertCommand.CommandType = CommandType.Text
            DA.UpdateCommand.CommandType = CommandType.Text

            DA.SelectCommand.Connection = dbConnection
            DA.InsertCommand.Connection = dbConnection
            DA.UpdateCommand.Connection = dbConnection

            DA.SelectCommand.CommandText = SQLstring
            DS = New DataSet

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    '______________Вставить ряд. Необходимый параметр command.CommandText = stInsert

    Public Function InsertRow() As Boolean
        Try
            Dim command As New OleDbCommand
            command.Connection = dbConnection
            command.CommandType = CommandType.Text
            command.CommandText = stInsert
            command.ExecuteNonQuery()

            InsertRow = True
        Catch ex As Exception
            MsgBox(ex.Message)
            InsertRow = False
        End Try

    End Function
    '______________Удалить Необходимый параметр command.CommandText = stDelete

    Public Function DeleteRow() As Boolean
        Try
            Dim command As New OleDbCommand
            command.Connection = dbConnection
            command.CommandType = CommandType.Text
            command.CommandText = stDelete
            command.ExecuteNonQuery()

            DeleteRow = True
        Catch ex As Exception
            MsgBox(ex.Message)
            DeleteRow = False
        End Try

    End Function
    '______________Изменить Необходимый параметр command.CommandText = stUpdate

    Public Function UpdateRow() As Boolean
        Try
            Dim command As New OleDbCommand
            command.Connection = dbConnection
            command.CommandType = CommandType.Text
            command.CommandText = stUpdate
            command.ExecuteNonQuery()

            UpdateRow = True
        Catch ex As Exception
            MsgBox(ex.Message)
            UpdateRow = False
        End Try

    End Function
    '______________Изменить DS. Необходимый параметр command.CommandText = stUpdate
    Public Function SaveDS() As Boolean
        Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(DA)

        Try
            DA.UpdateCommand = New OleDbCommand
            DA.InsertCommand = InsertComm
            DA.InsertCommand.Connection = dbConnection
            DA.Update(DS, DS.Tables(0).TableName)
            DS.AcceptChanges()
            SaveDS = True
        Catch Exc As System.Exception
            MsgBox(Exc.Message)
            SaveDS = False
        Finally
        End Try

    End Function

    'Public Function SaveDS_() As Boolean
    '    Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(DA)

    '    Try
    '        DA.UpdateCommand = New OleDbCommand
    '        DA.InsertCommand = InsertComm
    '        DA.InsertCommand.Connection = dbConnection
    '        DA.Update(DS, DS.Tables(0).TableName)
    '        DS.AcceptChanges()
    '        SaveDS = True
    '    Catch Exc As System.Exception
    '        MsgBox(Exc.Message)
    '        SaveDS = False
    '    Finally
    '    End Try

    'End Function



    '______________Изменить DS. Необходимый параметр command.CommandText = stUpdate
    Public Function UpdateDS() As Boolean
        DA.UpdateCommand = New OleDbCommand

        Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(DA)

        Try
            DA.UpdateCommand = UpdateComm
            DA.UpdateCommand.Connection = dbConnection
            DA.Update(DS, DS.Tables(0).TableName)
            DS.AcceptChanges()
            UpdateDS = True
        Catch Exc As System.Exception
            MsgBox(Exc.Message)
            UpdateDS = False
        Finally
        End Try

    End Function


    Public Function GetNewRow(ByRef ErrCode As Boolean) As DataRow
        'Try
        DA.Fill(DS)
        '    TableName = DS.Tables(0).Namespace
        '    Record = DS.Tables(0).NewRow

        '    GetNewRow = Record
        '    ErrCode = False
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    ErrCode = True
        'Finally
        'End Try

        GetNewRow = DS.Tables(0).NewRow


    End Function
    Public Function GetRow(ByRef ErrCode As Boolean) As DataRow
        Try
            DA.Fill(DS)
            GetRow = DS.Tables(0).Rows(0)
            ErrCode = False
        Catch
            ErrCode = True
            GetRow = Nothing
        Finally

        End Try
    End Function
    Public Function GetTable(ByRef ErrCode As Boolean) As System.Data.DataTable
        Try
            DA.Fill(DS)
            'TableName = DS.Tables(0).TableName
            GetTable = DS.Tables(0)
            'TableName = DA.SelectCommand.TableMappings(0).ToString
            ErrCode = False
        Catch ex As Exception
            ErrCode = True
            MsgBox(ex.Message)
            GetTable = Nothing
        Finally

        End Try
    End Function
    Public Function AddRow() As Boolean
        Try
            DS.Tables(0).Rows.Add(Record)
            DS.AcceptChanges()
            DA.UpdateCommand = New OleDbCommand
            'Builder = New OleDbCommandBuilder(DA)

            DA.UpdateCommand.CommandType = CommandType.Text
            DA.UpdateCommand.CommandText = "Update PathCatL"


            DA.Update(DS, "PathCatL")
            AddRow = True
        Catch
            AddRow = False

        Finally

        End Try

    End Function


    Public Function SaveTable() As Boolean
        Try
            DS.AcceptChanges()
            DA.UpdateCommand = New OleDbCommand
            '        Builder = New OleDbCommandBuilder(DA)
            DA.Update(DS)
            SaveTable = True
        Catch
            SaveTable = False
        Finally
        End Try

    End Function
    Public Sub Close()
        dbConnection.Close()
        dbConnection = Nothing

        DA = Nothing
        DS = Nothing
        Record = Nothing
    End Sub
    Public Sub GetTablesName() ' As ListBox
        Dim tabl As System.Data.DataTable = dbConnection.GetSchema("Tables")


        Dim tablRow As DataRow
        'Читаем названия баз данных
        List.Items.Clear()
        For Each tablRow In tabl.Rows
            List.Items.Add(tablRow("TABLE_NAME"))
        Next
        Dim st As String = List.Items(4)
        'GetTablesName = List
    End Sub
    Public Sub SaveField()

        Dim dbCommand = New OleDbCommand
        dbCommand.Connection = dbConnection
        dbCommand.CommandText = stUpdate

        dbCommand.ExecuteNonQuery()
        
        dbCommand = Nothing
    End Sub

    '__________________________чтение в listbox


    'по имени поля в ListBox
    Public Sub ReadFieldToListBox(ByRef ListBoxDest As ListBox, ByVal FieldName As String)

        Dim dbCommand = New OleDbCommand


        Try
            dbCommand.Connection = dbConnection
            dbCommand.CommandText = stSelect
            dbCommand.CommandType = CommandType.Text
            ListBoxDest.Items.Clear()
            Dim myReader As OleDbDataReader
            myReader = dbCommand.ExecuteReader()
            Do While myReader.Read
                If IsNumeric(myReader(FieldName)) = True Then
                    ListBoxDest.Items.Add(myReader(FieldName).ToString)
                Else
                    ListBoxDest.Items.Add(myReader(FieldName))
                End If
                If ListBoxDest.Items.Count - 1 > 0 Then Dim st As String = ListBoxDest.Items(0)
            Loop
            myReader.Close()
            dbCommand = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    'по номеру поля в ListBox
    Public Sub ReadFieldToListBox(ByRef ListBoxDest As ListBox, ByVal FieldNumber As Integer)

        Dim dbCommand = New OleDbCommand
        dbCommand.Connection = dbConnection
        dbCommand.CommandText = stSelect

        ListBoxDest.Items.Clear()
        Dim myReader As OleDbDataReader
        myReader = dbCommand.ExecuteReader()
        Do While myReader.Read
            ListBoxDest.Items.Add(myReader.GetString(FieldNumber))
        Loop
        myReader.Close()
        dbCommand = Nothing
    End Sub
    'по номеру поля в массив
    Public Sub ReadFieldToArray(ByRef ArrayDest() As String, ByVal FieldNumber As Integer)

        Dim dbCommand = New OleDbCommand
        dbCommand.Connection = dbConnection
        dbCommand.CommandText = stSelect

        Dim myReader As OleDbDataReader
        Dim i As Integer = 0
        myReader = dbCommand.ExecuteReader()
        Do While myReader.Read
            ArrayDest(i) = myReader.GetString(FieldNumber)
            i += 1
        Loop
        myReader.Close()
        dbCommand = Nothing
    End Sub


    'по индексу поля в массив Double
    Public Sub ReadFieldToArray(ByRef ArrayDest() As Double, ByVal FieldIndex As Integer)
        Dim dbCommand = New OleDbCommand
        dbCommand.Connection = dbConnection
        dbCommand.CommandText = stSelect

        Dim myReader As OleDbDataReader
        Dim i As Integer = 0
        myReader = dbCommand.ExecuteReader()
        Do While myReader.Read
            ArrayDest(i) = myReader.GetValue(FieldIndex)
            i += 1
        Loop
        myReader.Close()
        dbCommand = Nothing
    End Sub


    Public Sub DisConnect()
        dbConnection.Close()
    End Sub

End Class
