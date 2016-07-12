using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cayzen_Program
{
    public static class FileManager
    {
        public static string[] ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("The file is not there in the given location" + fileName);
            return File.ReadAllLines(fileName);
        }

        public static bool IsExists(string fileName)
        {
            return File.Exists(fileName);
        }

        public static string[] TakeInputFromUser()
        {
            string[] fileContent = null;
            try
            {
                Console.WriteLine("Please enter a valid file name with path");
                string fileName = Console.ReadLine();
                if (!FileManager.IsExists(fileName))
                    throw new FileNotFoundException("The file is not there in the given location" + fileName);
                fileContent = FileManager.ReadFile(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TakeInputFromUser();
            }
            return fileContent;
        }
    }
}
