using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Phedun.Classes
{
    internal static class UserMessager
    {
        public static void SuccessMessage()
        {
            MessageBox.Show("Операція успішна", "Успіх");
        }
        public static void SuccessAdditionMessage()
        {
            MessageBox.Show("Додано успішно", "Успіх");
        }
        public static void NotFoundMessage()
        {
            MessageBox.Show("Не знайдено дані", "Помилка");
        }
        public static void NumberOutOfRangeMessage()
        {
            MessageBox.Show("Число має бути у проміжку від 1 до номера останнього рядка");
        }
        public static void FileFormatMessage()
        {
            MessageBox.Show("Текстовий файл повинен мати в собі дані у форматі по 12 частин, розділених комою у кожному рядку");
        }
        public static void GeneralErrorMessage(Exception exception)
        {
            MessageBox.Show(exception.Message, "Помилка");
        }
        public static void InputErrorMessage(Exception exception)
        {
            MessageBox.Show(exception.Message, "Помилка вводу");
        }
        public static void InputEventMessage()
        {
            MessageBox.Show("Введіть назву події для пошуку");
        }
        public static void InputFacultyMessage()
        {
            MessageBox.Show("Введіть назву факультету для пошуку");
        }
        public static void InputPipMessage()
        {
            MessageBox.Show("Введіть ПІП для пошуку");
        }
    }
}
