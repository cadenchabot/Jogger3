using System;
using Collections;
using System.IO;

namespace PermanentStorage
{
    /// <summary>
    /// Handles saving and opening of files
    /// </summary>
    public class FileHandler 
    {
        /// <summary>
        /// Saves text to a file with a specified file name.
        /// </summary>
        /// <param name="text"></param> The text to save.
        /// <param name="fileName"></param> The file name.
        /// <returns></returns> true or false indicating success.
        public bool Save(string text, string fileName)
        {
            try
            {
                FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter file = new StreamWriter(writer);
                file.WriteLine(text);
                file.Close();
                return true;
            }
            catch(NullReferenceException)
            {
                return false;
            }
            catch(IOException)
            {
                return false;
            }
        }


        /// <summary>
        /// Saves an array of text to a file with a specified file name.
        /// </summary>
        /// <param name="lines"></param> the array to save.
        /// <param name="fileName"></param> the file name.
        /// <returns></returns> true or false indicating success.
        public bool Save(string[] lines, string fileName)
        {
            try
            {
                FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter file = new StreamWriter(writer);
                foreach (string line in lines) file.WriteLine(line);
                file.Close();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (ArrayTypeMismatchException)
            {
                return false;
            }
        }

        /// <summary>
        /// Saves an array of numbers to a file with a specified file name.
        /// </summary>
        /// <param name="numbers"></param> the array to save.
        /// <param name="fileName"></param> the file name.
        /// <returns></returns> true or false indicating success.
        public bool Save(int[]numbers, string fileName)
        {
            try
            {
                FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter file = new StreamWriter(writer);
                foreach (int number in numbers) file.WriteLine(numbers);
                file.Close();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (ArrayTypeMismatchException)
            {
                return false;
            }
        }

        /// <summary>
        /// Saves a LinkedList of numbers to a file with a specified file name.
        /// </summary>
        /// <param name="data"></param> the LinkedList to save.
        /// <param name="fileName"></param> the file name.
        /// <returns></returns> true or false indicating success.
        public bool Save(LinkedList<int> data, string fileName)
        {
            try
            {
                FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter file = new StreamWriter(writer);
                for (int i = 0; i < data.Size(); i++)
                {
                    int item = data.Get(i);
                    file.WriteLine(item);
                }

                file.Close();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (ArrayTypeMismatchException)
            {
                return false;
            }
        }

        /// <summary>
        /// Saves a LinkedList of strings to a file with a specified file name.
        /// </summary>
        /// <param name="data"></param> the LinkedList to save.
        /// <param name="fileName"></param> the file name.
        /// <returns></returns> true or false indicating success.
        public bool Save(LinkedList<string> data, string fileName)
        {
            try
            {
                FileStream writer = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamWriter file = new StreamWriter(writer);
                for (int i = 0; i < data.Size(); i++)
                {
                    string item = data.Get(i);
                    file.WriteLine(item);
                }

                file.Close();
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        /// <summary>
        /// Opens a LinkedList of integers from a file.
        /// </summary>
        /// <param name="fileName"></param> The name of the file.
        /// <returns></returns> A LinkedList of integers from the file.
        public LinkedList<int> OpenIntList(string fileName)
        {
            try
            {
                FileStream reader = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamReader file = new StreamReader(reader);
                string line = file.ReadLine();
                LinkedList<int> list = new LinkedList<int>();
                while (line != null)
                {
                    list.Add(Convert.ToInt32(line));
                    line = file.ReadLine();
                }
                file.Close();
                return list;
                
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (IOException)
            {
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
   
        }

        /// <summary>
        /// Opens a LinkedList of strings from a file.
        /// </summary>
        /// <param name="fileName"></param> The name of the file.
        /// <returns></returns> A LinkedList of strings from the file.
        public LinkedList<string> OpenStringList(string fileName)
        {
            try
            {
                FileStream reader = new FileStream(fileName, FileMode.OpenOrCreate);
                StreamReader file = new StreamReader(reader);
                string line = file.ReadLine();
                LinkedList<string> list = new LinkedList<string>();
                while (line != null)
                {
                    list.Add(line);
                    line = file.ReadLine();
                }
                file.Close();
                return list;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (IOException)
            {
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }

        }

    }

   

}
        


