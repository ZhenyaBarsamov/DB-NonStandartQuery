using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace NonstandardQuery.MyWorkClasses {
    class FileManager {
        public Dictionary <string, string> GetTranslateDictionary() {
            Dictionary<string, string> res = new Dictionary<string, string>();
            //Открываем файл
            StreamReader inF;
            try {
                inF = new StreamReader("Dictionary.txt");
            }
            catch {
                return null;
            }
            //Заполняем словарь
            while (true) {
                string line = inF.ReadLine();
                //Если считали пустую строку - конец чтения
                if (string.IsNullOrWhiteSpace(line))
                    break;
                string[] parsedLine = line.Split(new string[] { " =!!!= " }, StringSplitOptions.None);
                res[parsedLine[0].ToLower()] = parsedLine[1];
            }
            return res;
        }
    }
}
