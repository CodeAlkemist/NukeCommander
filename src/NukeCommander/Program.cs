using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using CodeAlkemy;
using Newtonsoft.Json.Linq;

namespace NukeCommander
{
    public class Program
    {
        private enum GameState
        {
            Halt = 0x00,

        }
        public static int Main(string[] args)
        {
            Console.WriteLine("Copyright (c) 2016-{0} CodeAlkemy\nThe use of this software is subject to its license\nThis Software Comes with absolutely no warranty", DateTime.Now.Year.ToString());
            string cmd = "";
            var enA = Assembly.GetEntryAssembly();
            string enAs = enA.ToString();
            Console.WriteLine(enAs);
            
            while (true)
            {
                Console.Write(">");
                cmd = Console.ReadLine();
                FileStream fs = new FileStream("atlas.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                BsonWriter bs = new BsonWriter(bw);
                GameObject.LoadCountriesAtlas();
                if (cmd == "exit" || cmd == "Exit")
                {
                    bs.Flush();
                    return 0;
                }
                else
                {
                    var pCmd = Processor.ProcessCmd(cmd);
                    using (bs)
                    {
                        JsonSerializer js = new JsonSerializer();
                        js.Serialize(bs, pCmd);
                    }
                    typeof(GameObject).GetMethod(pCmd._cmd).Invoke(null, pCmd._args);
                }
            }
        }
    }

    static class GameObject
    {
        private static JObject _countries;

        public static void LoadCountriesAtlas()
        {
            FileStream fs = new FileStream("countries.atlas", FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(fs);
            using (BsonReader br = new BsonReader(brs))
            {
                _countries = (JObject) JToken.ReadFrom(br);
            }
        }
    }
}
