using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonToXml_Lib;

namespace JsonToXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                JsonToXml_Lib.JsonToXml.RunJsonToXmlWithConfig();
            }
            catch
            {
                //throw;
            }
        }
    }
}
