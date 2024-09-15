using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace Unity_Game_StringToCSV
{
    public class StringProcessor
    {
        public void ExtractStrings(string inputFile, string outputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException($"Input file not found: {inputFile}");
            }

            using (StreamReader reader = new StreamReader(inputFile, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
            {
                writer.WriteLine("m_Id,m_Localized");

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim().StartsWith("0 SInt64 m_Id"))
                    {
                        string id = Regex.Match(line, @"= (\d+)").Groups[1].Value;
                        string localizedString = "";

                        string nextLine = reader.ReadLine();
                        if (nextLine != null && nextLine.Trim().StartsWith("1 string m_Localized"))
                        {
                            localizedString = Regex.Match(nextLine, @"= ""(.*)""", RegexOptions.Singleline).Groups[1].Value;
                        }

                        writer.WriteLine($"\"{id}\",\"{localizedString.Replace("\"", "\"\"")}\"");
                    }
                }
            }
        }

        public void ImportCsv(string inputFile, string outputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException($"CSV file not found: {inputFile}");
            }

            if (!File.Exists(outputFile))
            {
                throw new FileNotFoundException($"Original Unity string file not found: {outputFile}");
            }

            Dictionary<string, string> translations = new Dictionary<string, string>();
            using (TextFieldParser parser = new TextFieldParser(inputFile, Encoding.UTF8))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                string header = parser.ReadLine();
                if (header == null || !header.Equals("m_Id,m_Localized"))
                {
                    throw new InvalidDataException("Invalid CSV header. Expected 'm_Id,m_Localized'.");
                }

                int lineNumber = 2;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length != 2)
                    {
                        throw new InvalidDataException($"Invalid CSV format at line {lineNumber}. Expected 2 fields, found {fields.Length}.");
                    }

                    translations.Add(fields[0].Replace("\"", ""), fields[1].Replace("\"\"", "\""));
                    lineNumber++;
                }
            }

            List<string> newLines = new List<string>();
            using (StreamReader reader = new StreamReader(outputFile, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim().StartsWith("0 SInt64 m_Id"))
                    {
                        string id = Regex.Match(line, @"= (\d+)").Groups[1].Value;
                        newLines.Add(line);

                        string nextLine = reader.ReadLine();
                        if (nextLine != null && nextLine.Trim().StartsWith("1 string m_Localized"))
                        {
                            if (translations.ContainsKey(id))
                            {
                                newLines.Add($"\t1 string m_Localized = \"{translations[id]}\"");
                            }
                            else
                            {
                                newLines.Add(nextLine);
                            }
                        }
                        else
                        {
                            newLines.Add(nextLine);
                        }
                    }
                    else
                    {
                        newLines.Add(line);
                    }
                }
            }

            File.WriteAllLines(outputFile, newLines, Encoding.UTF8);
        }
    }
}