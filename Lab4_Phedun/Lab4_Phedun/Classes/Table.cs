using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab4_Phedun.Classes
{
    internal static class Table
    {
        public static void FilterByCell(string searchCriteria, int cellNumber)
        {
            filteredTableData = (
                from eventData in tableData
                where eventData[cellNumber] == searchCriteria
                select eventData
                ).ToList();
        }

        public static void PrintTable()
        {
            dataGridView.Rows.Clear();

            foreach (List<string> eventData in tableData)
            {
                Event @event = new Event(eventData.ToList());
                dataGridView.Rows.Add(@event.GetData());
            }
        }
        public static void PrintTableFiltered()
        {
            dataGridView.Rows.Clear();

            foreach (List<string> eventData in filteredTableData)
            {
                Event @event = new Event(eventData.ToList());
                dataGridView.Rows.Add(@event.GetData());
            }
        }
        public static void Import() {
            foreach (string line in File.ReadLines(IMPORT_PATH))
            {
                string[] eventData = line.Split(TXT_SPLIT_SYMBOL);
                if (eventData.Length != dataGridView.ColumnCount)
                {
                    throw new ArgumentOutOfRangeException(eventData.Length.ToString());
                }
                tableData.Add(eventData.ToList());
                Event @event = new Event(eventData.ToList());
                dataGridView.Rows.Add(@event.GetData());
            }
            UserMessager.SuccessMessage();
        }

        public static async void Export()
        {
            List<string> strings = new List<string>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool rowIsEmpty = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        rowIsEmpty = true;
                        break;
                    }
                }
                if (!rowIsEmpty)
                {
                    var eventData =
                        row.Cells[0].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[1].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[2].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[3].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[4].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[5].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[6].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[7].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[8].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[9].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[10].Value + TXT_SPLIT_SYMBOL +
                        row.Cells[11].Value;
                    strings.Add(eventData);
                }
            }
            await File.WriteAllLinesAsync(EXPORT_PATH, strings);
            UserMessager.SuccessMessage();
        }

        public static async void ImportFromJson()
        {
            var events = await Helper.Deserialize(DESERIALIZE_PATH);
            if (events != null)
            {
                foreach (var @event in events)
                {
                    dataGridView.Rows.Add(@event.GetData());
                    Table.tableData.Add(@event.GetData().ToList());
                }
                UserMessager.SuccessMessage();
            }
            else
            {
                UserMessager.NotFoundMessage();
            }
        }

        public static async void ExportToJson()
        {
            List<string> jsonEvents = new List<string>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool rowIsEmpty = true;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        rowIsEmpty = false;
                        break;
                    }
                }

                if (!rowIsEmpty)
                {
                    Event @event = new Event(row);

                    string jsonWorker = Helper.Serialize(@event);
                    jsonEvents.Add(jsonWorker);
                }
            }

            await File.WriteAllLinesAsync(SERIALIZE_PATH, jsonEvents, Encoding.UTF8);
            UserMessager.SuccessMessage();
        }
        public static void AddRow(string[] row)
        {
            dataGridView.Rows.Add(row);
            tableData.Add(row.ToList());
        }

        public static void SetupDataGridView(DataGridView dataGW)
        {
            dataGridView = dataGW;
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = 12;
            dataGridView.Columns[0].Name = "Назва події";
            dataGridView.Columns[1].Name = "ПІП";
            dataGridView.Columns[2].Name = "Назва факультету";
            dataGridView.Columns[3].Name = "Кафедра";
            dataGridView.Columns[4].Name = "Посада відповідального";
            dataGridView.Columns[5].Name = "Посада першого помічника";
            dataGridView.Columns[6].Name = "Посада другого помічника";
            dataGridView.Columns[7].Name = "Початок підготовки";
            dataGridView.Columns[8].Name = "Кінець підготовки";
            dataGridView.Columns[9].Name = "Час";
            dataGridView.Columns[10].Name = "Місце";
            dataGridView.Columns[11].Name = "Характеристика";
        }

        public static List<List<string>> tableData = new List<List<string>>();
        public static List<List<string>> filteredTableData = new List<List<string>>();
        private static DataGridView dataGridView = new DataGridView();

        private const string DESERIALIZE_PATH = @".\input.json";
        private const string SERIALIZE_PATH = @".\output.json";
        private const string IMPORT_PATH = @".\input.txt";
        private const string EXPORT_PATH = @".\output.txt";
        public const string TXT_SPLIT_SYMBOL = ",";
    }
}
