namespace _04.String_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringEditor
    {
        private static EditorEngine textEngine = new EditorEngine();

        public static void Main()
        {
            string commandText = Console.ReadLine();

            while (commandText != string.Empty)
            {
                try
                {
                    var commandParameters = ParseCommand(commandText);
                    Console.WriteLine(ExecuteCommand(commandParameters));
                    commandText = Console.ReadLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error.");
                    commandText = Console.ReadLine();
                }
            }
        }

        private static string ExecuteCommand(List<string> commandParameters)
        {
            try
            {
                string name = commandParameters[0];
                switch (name)
                {
                    case "APPEND":
                        {
                            string text = commandParameters[1];
                            textEngine.Append(text);
                            return "Text appended.";
                        }

                    case "INSERT":
                        {
                            string text = commandParameters[1];
                            int index = int.Parse(commandParameters[2]);
                            textEngine.Insert(text, index);
                            return "Text inserted.";
                        }
                    case "DELETE":
                        {
                            int index = int.Parse(commandParameters[1]);
                            int count = int.Parse(commandParameters[2]);
                            textEngine.Delete(index, count);
                            return "Text deleted.";
                        }
                    case "REPLACE":
                        {
                            int index = int.Parse(commandParameters[1]);
                            int count = int.Parse(commandParameters[2]);
                            string replacement = commandParameters[3];
                            textEngine.Replace(index, count, replacement);
                            return "Text replaced.";
                        }
                    case "PRINT":
                        {
                            return textEngine.Print();
                        }
                    default:
                        return "Unrecognised command.";
                }
            }
            catch (Exception ex)
            {

                return "Error.";
            }
        }

        private static List<string> ParseCommand(string commandText)
        {
            List<string> parameters = new List<string>();
            string[] tokens = commandText.Split(new char[] { ' ' });
            string name = tokens.ToList().Take(1).FirstOrDefault();
            parameters.Add(name);

            switch (name)
            {
                case "APPEND":
                    {
                        string text = commandText.Substring(name.Length + 1);
                        parameters.Add(text);
                        break;
                    }
                case "INSERT":
                    {
                        int textStart = commandText.IndexOf(" ");
                        int textEnd = commandText.LastIndexOf(" ");
                        string text = commandText.Substring(textStart + 1, textEnd - textStart - 1);
                        string index = commandText.Substring(textEnd, commandText.Length - textEnd);
                        parameters.Add(text);
                        parameters.Add(index);
                        break;
                    }
                case "DELETE":
                    {
                        parameters.Add(tokens[1].Trim());
                        parameters.Add(tokens[2].Trim());
                        break;
                    }
                case "REPLACE":
                    {
                        parameters.Add(tokens[1].Trim());
                        parameters.Add(tokens[2].Trim());
                        int textStart = commandText.IndexOf(" ");
                        textStart = commandText.IndexOf(" ", textStart + 1);
                        textStart = commandText.IndexOf(" ", textStart + 1);
                        parameters.Add(commandText.Substring(textStart + 1));
                        break;
                    }
                case "PRINT":
                    {
                        break;
                    }
                default:
                    break;
            }

            return parameters;
        }
    }
}
