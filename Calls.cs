using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistradorDeEquipamentos.ConsoleApp
{
    public class Calls
    {
        private string title;
        private string description;
        private string equipmentName;
        private DateTime openingDate;

        public string EquipmentName {get => equipmentName;}

        //Adicionar Chamado.
        public void AddCall(string equipName)
        {
            Console.Write("Título do chamado: ");
            this.title = Console.ReadLine();

            Console.Write("Descrição: ");
            this.description = Console.ReadLine();

            this.equipmentName = equipName;

            Console.Write("Data para abertura do chamado(Use o formato padrão brasileiro (dia/mês/ano): ");
            string inputDate = Console.ReadLine();
            string[] separeDate = inputDate.Split('/');
            this.openingDate = new DateTime(int.Parse(separeDate[2]),
                int.Parse(separeDate[1]), int.Parse(separeDate[0]));
        }
        //Mostrar chamados
        public void ShowCalls()
        {
            TimeSpan daysOpened = DateTime.Now.Subtract(openingDate);
            int days = Convert.ToInt32(daysOpened.TotalDays);
            Console.WriteLine($"Título do chamado: {title}\n" +
                $"Descrição: {description}\nData de abertura: {openingDate}\nDias em aberto: {days}");
        }
        //Editar chamados.
        public void EditCalls()
        {
            Console.WriteLine($"O que deseja alterar? (Escolha o número)\n" +
                $"1 - Título\n2 - Descrição\n3 - Mudar data de abertura");
            string check = Console.ReadLine();

            switch (check)
            {
                case "1":
                    Console.Write("Título do chamado: ");
                    this.title = Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Descrição: ");
                    this.description = Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Data para abertura do chamado(Use o formato padrão brasileiro (dia/mês/ano): ");
                    string inputDate = Console.ReadLine();
                    string[] separeDate = inputDate.Split('/');
                    this.openingDate = new DateTime(int.Parse(separeDate[2]),
                        int.Parse(separeDate[1]), int.Parse(separeDate[0]));
                    break;
            }
        }
    }
}
