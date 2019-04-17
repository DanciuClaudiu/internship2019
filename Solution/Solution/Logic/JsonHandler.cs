using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Solution.Model;

namespace Solution.Logic
{
    public class JsonHandler<T>
    {
        public static T ReadJson(string path)
        {
            string inputString = File.ReadAllText(path, Encoding.UTF8);
            inputString = inputString.Substring(20, inputString.Length-21);

            return JsonConvert.DeserializeObject<T>(inputString);

        }
        public static void WriteJson(string path, T value)
        {
            string inputString = File.ReadAllText(path, Encoding.UTF8);
            inputString = inputString.Substring(20, inputString.Length - 21);

            string output = JsonConvert.SerializeObject(value, Formatting.Indented);


            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"..\..\", "output.json"), output);
        }



    }
}
