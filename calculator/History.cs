using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class History
    {
        private readonly List<string> Operations = new List<string>();
        private readonly string path = @"F:\\soft\\calculator\\calculator\\history.txt";
        public History()
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string line = "";
                while (line != null)
                {
                    line = sr.ReadLine();
                    Operations.Add(line);
                }
                sr.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public void Push(string operation)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(operation);
                Operations.Add(operation);
                sw.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public string GetHistory()
        {
            string history = "Empty!";
            if (Operations.Count > 0)
            {
                history = "";
                for (int i = 0; i < Operations.Count; i++)
                {
                    history += Operations[i];
                    if (i >= Operations.Count - 2)
                    {
                        continue;
                    }
                    history += "\r\n";
                }
            }
            return history;
        }
        public void ClearHistory()
        {
            try
            {
                FileStream fs = File.Open(path, FileMode.Open);
                fs.SetLength(0);
                fs.Close();
                Operations.Clear();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
