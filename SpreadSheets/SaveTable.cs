using System;
using System.IO;

namespace SpreadSheets_v14
{
    public class SaveTable
    {
        public static void DrawTable(string[][] rows)
        {
            const int COLUMN_LENGTH = 20;
            const int NUMERATION_LENGTH = 30;
            int columns = rows[0].Length;
            // Отримання теки проекту
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(projectDirectory, "table.txt");

            using (StreamWriter writer = new StreamWriter(path))
            {
                // -------
                writer.WriteLine(new String('_', columns * (COLUMN_LENGTH) + NUMERATION_LENGTH + 2));


                // Запис номерів стовпців
                writer.Write("|" + new String(' ', NUMERATION_LENGTH / 2 - 1) + "#" + new String(' ', NUMERATION_LENGTH / 2 - 1));
                for (int i = 1; i <= columns; i++)
                {
                    int divident = i;
                    string columnName = string.Empty;

                    while (divident > 0)
                    {
                        int modulo = (divident - 1) % 26;
                        columnName = Convert.ToChar(65 + modulo) + columnName;
                        divident = (divident - modulo) / 26;
                        writer.Write("|" + new String(' ', COLUMN_LENGTH / 2 - 1) + columnName
                            + new String(' ', COLUMN_LENGTH / 2 - 1));
                    }
                }
                writer.Write("|\n");

                // -------
                writer.WriteLine(new String('-', columns * (COLUMN_LENGTH) + NUMERATION_LENGTH + 2));

                // Запис рядків
                for (int i = 1; i < rows.Length + 1; i++)
                {
                    writer.Write("|" + new String(' ', NUMERATION_LENGTH / 2 - 1) + i
                    + new String(' ', NUMERATION_LENGTH / 2 - 1));
                    foreach (string value in rows[i - 1])
                    {
                        int index = (COLUMN_LENGTH - value.Length) >= 0 ? COLUMN_LENGTH - value.Length : 0;
                        writer.Write("|" + new String(' ', index / 2) + value.Substring(0, value.Length < COLUMN_LENGTH ? value.Length : COLUMN_LENGTH - 1)
                        + new String(' ', index % 2 != 0 || index == 0 ? index / 2 : index / 2 - 1));
                    }
                    writer.Write("|\n");

                    // -------
                    writer.WriteLine(new String('-', columns * (COLUMN_LENGTH) + NUMERATION_LENGTH + 2));
                }
                writer.Close();

            }
        }
    }
}
