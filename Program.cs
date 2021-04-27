using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistradorDeEquipamentos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            List<Calls> callsList = new List<Calls>();

            Menu menu = new Menu(equipmentList, callsList);
        }
    }
}