using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.BackendDev
{
    public class FileManager
    {
        public FileManager() { }
        static string dirFromRoot = "\\Recources\\";

        public List<string> ReadCSVData(string fileName)
        {
            List<string> readData = new List<string>();
            string dir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length)  + dirFromRoot + fileName;
            TextReader f = new StreamReader(dir);

            string data;
            while ((data = f.ReadLine()) != null)
            {
                string[] newData = data.Split(',');
                for (int i = 0; i < newData.Length; i++)
                {
                    readData.Add(newData[i]);

                }
            }
            f.Close();
            return readData;
        }


        public List<string> ReadDataLineByLine(string fileName)
        {

            List<string> readData = new List<string>();
            string dir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length) + dirFromRoot + "\\SavedData\\" + fileName;
            TextReader f = new StreamReader(dir);

            string data;
            while ((data = f.ReadLine()) != null)
            {
                readData.Add(data);
            }
            return readData;
        }

        public void writeLineToFile(string fileName, string data)
        {
            string dir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length) + dirFromRoot + "\\SavedData\\" + fileName;
            TextWriter f = new StreamWriter(dir);
            f.WriteLine($"{data}");
            f.Close();
        }

        public char[,] ReadMapFile(string fileName)
        {
            char[,] readData = new char[100, 100];
            string dir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length) + dirFromRoot+ "\\Maps\\" + fileName;
            TextReader f = new StreamReader(dir);

            int j = 0;

            string[] objIDList;

            string data;
            while ((data = f.ReadLine()) != null)
            {
                objIDList = new string[data.Length];

                for (int i = 0; i < data.Length; i++)
                {
                    objIDList[i] = data.Substring(i, 1);
                }

                
                for(int k = 0; k < objIDList.Length; k++)
                {
                    readData[j, k] = Convert.ToChar(objIDList[k]);
                }
                
                j++;
                
            }

            return readData;
        }


    }



    
}
