using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab4_Phedun.Classes
{
    internal class Event
    {
        //[JsonIgnore]
        //[JsonPropertyName("Name")]

        public Event(List<string> workerData)
        {
            Title = workerData[0] + "";
            PIP = workerData[1] + "";
            FacultyTitle = workerData[2] + "";
            Cathedra = workerData[3] + "";
            ResponsibleRole = workerData[4] + "";
            HelperRole1 = workerData[5] + "";
            HelperRole2 = workerData[6] + "";
            PreparationInfo =
                new PreparationInfo
                (
                    workerData[7] + "",
                    workerData[8] + ""
                );
            Time = workerData[9] + "";
            Place = workerData[10] + "";
            Characteristics = workerData[11] + "";
        }

        public Event(DataGridViewRow row)
        {
            Title = row.Cells[0].Value + "";
            PIP = row.Cells[1].Value + "";
            FacultyTitle = row.Cells[2].Value + "";
            Cathedra = row.Cells[3].Value + "";
            ResponsibleRole = row.Cells[4].Value + "";
            HelperRole1 = row.Cells[5].Value + "";
            HelperRole2 = row.Cells[6].Value + "";
            PreparationInfo = 
                new PreparationInfo
                (
                    row.Cells[7].Value + "",
                    row.Cells[8].Value + ""
                );
            Time = row.Cells[9].Value + "";
            Place = row.Cells[10].Value + "";
            Characteristics = row.Cells[11].Value + "";
        }

        public Event()
        {
            Title = "";
            PIP = "";
            FacultyTitle = "";
            Cathedra = "";
            ResponsibleRole = "";
            HelperRole1 = "";
            HelperRole2 = "";
            PreparationInfo = new PreparationInfo("", "");
            Time = "";
            Place = "";
            Characteristics = "";
        }

        public Event(string title, string pIP, string facultyTitle, string cathedra, string responsibleRole, string helperRole1, string helperRole2, PreparationInfo preparationInfo, string time, string place, string characteristics)
        {
            Title = title;
            PIP = pIP;
            FacultyTitle = facultyTitle;
            Cathedra = cathedra;
            ResponsibleRole = responsibleRole;
            HelperRole1 = helperRole1;
            HelperRole2 = helperRole2;
            PreparationInfo = preparationInfo;
            Time = time;
            Place = place;
            Characteristics = characteristics;
        }

        public string Title { get; set; }
        public string PIP { get; set; }
        public string FacultyTitle { get; set; }
        public string Cathedra { get; set; }
        public string ResponsibleRole { get; set; }
        public string HelperRole1 { get; set; }
        public string HelperRole2 { get; set; }
        public PreparationInfo PreparationInfo { get; set; }
        public string Time { get; set; }
        public string Place { get; set; }
        public string Characteristics { get; set; }
        public string[] GetData()
        {
            string[] row = {
                Title, 
                PIP, 
                FacultyTitle,
                Cathedra,
                ResponsibleRole,
                HelperRole1, 
                HelperRole2,
                PreparationInfo.StartDate,
                PreparationInfo.EndDate,
                Time, 
                Place,
                Characteristics
        };

            return row;
        }
    }
}
