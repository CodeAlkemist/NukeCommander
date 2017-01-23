using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace CodeAlkemy
{
    /// <summary>
    /// 
    /// </summary>
    public static class Processor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inCmd"></param>
        /// <returns></returns>
        public static Command ProcessCmd(string inCmd)
        {
            string[] exploded = inCmd.Split(' ');
            // Tokenize the input
            Command cmd = new Command(exploded[0], exploded);
            cmd.Shift();
            return cmd;
        }
    }
}
