using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace WindowsApplication1
{
    public class clsOleDBReadUpdateDB
    {
        public string stSelect, stInsert, stUpdate, stDelete;
        public OleDbCommand InsertComm, UpdateComm, DeleteComm;
        private ListBox List = new ListBox();
        private OleDbConnection dbConnection;
        private OleDbDataAdapter DA;
        private DataSet DS;
        // Dim Builder As OleDbCommandBuilder
        private string locSQLstring;
        string st;
        public DataRow Record;


        // _______________Создание  DS,DA
        public clsOleDBReadUpdateDB(string ConnString, string SQLstring)
        {
            try
            {
                dbConnection = new OleDbConnection(ConnString);
                dbConnection.Open();
                locSQLstring = SQLstring;
                DA = new OleDbDataAdapter(SQLstring, dbConnection);

                DA.SelectCommand = new OleDbCommand(SQLstring, dbConnection);
                DA.InsertCommand = new OleDbCommand();
                DA.UpdateCommand = new OleDbCommand();

                DA.SelectCommand = new OleDbCommand(SQLstring, dbConnection);
                // DA.InsertCommand = InsertComm
                // DA.UpdateCommand = UpdateComm
                DA.SelectCommand.CommandType = CommandType.Text;
                DA.InsertCommand.CommandType = CommandType.Text;
                DA.UpdateCommand.CommandType = CommandType.Text;

                DA.SelectCommand.Connection = dbConnection;
                DA.InsertCommand.Connection = dbConnection;
                DA.UpdateCommand.Connection = dbConnection;

                DA.SelectCommand.CommandText = SQLstring;
                DS = new DataSet();
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);

            }
        }
        // ______________Вставить ряд. Необходимый параметр command.CommandText = stInsert

        public bool InsertRow()
        {
            bool InsertRowRet = default;
            try
            {
                var command = new OleDbCommand();
                command.Connection = dbConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = stInsert;
                command.ExecuteNonQuery();

                InsertRowRet = true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
                InsertRowRet = false;
            }

            return InsertRowRet;

        }
        // ______________Удалить Необходимый параметр command.CommandText = stDelete

        public bool DeleteRow()
        {
            bool DeleteRowRet = default;
            try
            {
                var command = new OleDbCommand();
                command.Connection = dbConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = stDelete;
                command.ExecuteNonQuery();

                DeleteRowRet = true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
                DeleteRowRet = false;
            }

            return DeleteRowRet;

        }
        // ______________Изменить Необходимый параметр command.CommandText = stUpdate

        public bool UpdateRow()
        {
            bool UpdateRowRet = default;
            try
            {
                var command = new OleDbCommand();
                command.Connection = dbConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = stUpdate;
                command.ExecuteNonQuery();

                UpdateRowRet = true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
                UpdateRowRet = false;
            }

            return UpdateRowRet;

        }
        // ______________Изменить DS. Необходимый параметр command.CommandText = stUpdate
        public bool SaveDS()
        {
            bool SaveDSRet = default;
            var builder = new OleDbCommandBuilder(DA);

            try
            {
                DA.UpdateCommand = new OleDbCommand();
                DA.InsertCommand = InsertComm;
                DA.InsertCommand.Connection = dbConnection;
                DA.Update(DS, DS.Tables[0].TableName);
                DS.AcceptChanges();
                SaveDSRet = true;
            }
            catch (Exception Exc)
            {
                Interaction.MsgBox(Exc.Message);
                SaveDSRet = false;
            }
            finally
            {
            }

            return SaveDSRet;

        }

        // Public Function SaveDS_() As Boolean
        // Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(DA)

        // Try
        // DA.UpdateCommand = New OleDbCommand
        // DA.InsertCommand = InsertComm
        // DA.InsertCommand.Connection = dbConnection
        // DA.Update(DS, DS.Tables(0).TableName)
        // DS.AcceptChanges()
        // SaveDS = True
        // Catch Exc As System.Exception
        // MsgBox(Exc.Message)
        // SaveDS = False
        // Finally
        // End Try

        // End Function



        // ______________Изменить DS. Необходимый параметр command.CommandText = stUpdate
        public bool UpdateDS()
        {
            bool UpdateDSRet = default;
            DA.UpdateCommand = new OleDbCommand();

            var builder = new OleDbCommandBuilder(DA);

            try
            {
                DA.UpdateCommand = UpdateComm;
                DA.UpdateCommand.Connection = dbConnection;
                DA.Update(DS, DS.Tables[0].TableName);
                DS.AcceptChanges();
                UpdateDSRet = true;
            }
            catch (Exception Exc)
            {
                Interaction.MsgBox(Exc.Message);
                UpdateDSRet = false;
            }
            finally
            {
            }

            return UpdateDSRet;

        }


        public DataRow GetNewRow(ref bool ErrCode)
        {
            DataRow GetNewRowRet = default;
            // Try
            DA.Fill(DS);
            // TableName = DS.Tables(0).Namespace
            // Record = DS.Tables(0).NewRow

            // GetNewRow = Record
            // ErrCode = False
            // Catch ex As Exception
            // MsgBox(ex.Message)
            // ErrCode = True
            // Finally
            // End Try

            GetNewRowRet = DS.Tables[0].NewRow();
            return GetNewRowRet;


        }
        public DataRow GetRow(ref bool ErrCode)
        {
            DataRow GetRowRet = default;
            try
            {
                DA.Fill(DS);
                GetRowRet = DS.Tables[0].Rows[0];
                ErrCode = false;
            }
            catch
            {
                ErrCode = true;
                GetRowRet = null;
            }
            finally
            {

            }

            return GetRowRet;
        }
        public DataTable GetTable(ref bool ErrCode)
        {
            DataTable GetTableRet = default;
            try
            {
                DA.Fill(DS);
                // TableName = DS.Tables(0).TableName
                GetTableRet = DS.Tables[0];
                // TableName = DA.SelectCommand.TableMappings(0).ToString
                ErrCode = false;
            }
            catch (Exception ex)
            {
                ErrCode = true;
                Interaction.MsgBox(ex.Message);
                GetTableRet = null;
            }
            finally
            {

            }

            return GetTableRet;
        }
        public bool AddRow()
        {
            bool AddRowRet = default;
            try
            {
                DS.Tables[0].Rows.Add(Record);
                DS.AcceptChanges();
                DA.UpdateCommand = new OleDbCommand();
                // Builder = New OleDbCommandBuilder(DA)

                DA.UpdateCommand.CommandType = CommandType.Text;
                DA.UpdateCommand.CommandText = "Update PathCatL";


                DA.Update(DS, "PathCatL");
                AddRowRet = true;
            }
            catch
            {
                AddRowRet = false;
            }
            finally
            {

            }

            return AddRowRet;

        }


        public bool SaveTable()
        {
            bool SaveTableRet = default;
            try
            {
                DS.AcceptChanges();
                DA.UpdateCommand = new OleDbCommand();
                // Builder = New OleDbCommandBuilder(DA)
                DA.Update(DS);
                SaveTableRet = true;
            }
            catch
            {
                SaveTableRet = false;
            }
            finally
            {
            }

            return SaveTableRet;

        }
        public void Close()
        {
            dbConnection.Close();
            dbConnection = null;

            DA = null;
            DS = null;
            Record = null;
        }
        public void GetTablesName() // As ListBox
        {
            var tabl = dbConnection.GetSchema("Tables");
            // Читаем названия баз данных
            List.Items.Clear();
            foreach (DataRow tablRow in tabl.Rows)
                List.Items.Add(tablRow["TABLE_NAME"]);
            string st = Conversions.ToString(List.Items[4]);
            // GetTablesName = List
        }
        public void SaveField()
        {

            var dbCommand = new OleDbCommand();
            dbCommand.Connection = dbConnection;
            dbCommand.CommandText = stUpdate;

            dbCommand.ExecuteNonQuery();

            dbCommand = null;
        }

        // __________________________чтение в listbox


        // по имени поля в ListBox
        public void ReadFieldToListBox(ref ListBox ListBoxDest, string FieldName)
        {

            var dbCommand = new OleDbCommand();


            try
            {
                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = stSelect;
                dbCommand.CommandType = CommandType.Text;
                ListBoxDest.Items.Clear();
                OleDbDataReader myReader;
                myReader = dbCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (Information.IsNumeric(myReader[FieldName]) == true)
                    {
                        ListBoxDest.Items.Add(myReader[FieldName].ToString());
                    }
                    else
                    {
                        ListBoxDest.Items.Add(myReader[FieldName]);
                    }
                    if (ListBoxDest.Items.Count - 1 > 0)        st = Convert.ToString(ListBoxDest.Items[0]);
                }
                myReader.Close();
                dbCommand = null;
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }


        }
        // по номеру поля в ListBox
        public void ReadFieldToListBox(ref ListBox ListBoxDest, int FieldNumber)
        {

            var dbCommand = new OleDbCommand();
            dbCommand.Connection = dbConnection;
            dbCommand.CommandText = stSelect;

            ListBoxDest.Items.Clear();
            OleDbDataReader myReader;
            myReader = dbCommand.ExecuteReader();
            while (myReader.Read())
                ListBoxDest.Items.Add(myReader.GetString(FieldNumber));
            myReader.Close();
            dbCommand = null;
        }
        // по номеру поля в массив
        public void ReadFieldToArray(ref string[] ArrayDest, int FieldNumber)
        {

            var dbCommand = new OleDbCommand();
            dbCommand.Connection = dbConnection;
            dbCommand.CommandText = stSelect;

            OleDbDataReader myReader;
            int i = 0;
            myReader = dbCommand.ExecuteReader();
            while (myReader.Read())
            {
                ArrayDest[i] = myReader.GetString(FieldNumber);
                i += 1;
            }
            myReader.Close();
            dbCommand = null;
        }


        // по индексу поля в массив Double
        public void ReadFieldToArray(ref double[] ArrayDest, int FieldIndex)
        {
            var dbCommand = new OleDbCommand();
            dbCommand.Connection = dbConnection;
            dbCommand.CommandText = stSelect;

            OleDbDataReader myReader;
            int i = 0;
            myReader = dbCommand.ExecuteReader();
            while (myReader.Read())
            {
                ArrayDest[i] = Conversions.ToDouble(myReader.GetValue(FieldIndex));
                i += 1;
            }
            myReader.Close();
            dbCommand = null;
        }


        public void DisConnect()
        {
            dbConnection.Close();
        }

    }
}