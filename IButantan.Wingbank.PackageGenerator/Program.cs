using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.IO.Compression;

namespace IButantan.Wingbank.PackageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var wingbankPackageProcess = new WingbankPackageProcess();
            var arquivo1 = wingbankPackageProcess.GerarPacote(8652);
            var lista = new List<int>() { 8652, 8653, 8654, 8655, 8656, 8658, 8660 };
            var arquivo2 = wingbankPackageProcess.GerarPacote(lista);
        }
    }

  
}

