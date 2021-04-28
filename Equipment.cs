using System;

namespace RegistradorDeEquipamentos.ConsoleApp
{
    public class Equipment
    {
        private string name;
        private string serieNumber;
        private double aquisitionPrice;
        private string producerName;
        private DateTime manufacturingDate;

        public string Name { get => name;}

        //Adicionar novo equipamento.
        public void AddEquip()
        {
            do
            {
                Console.Write("Nome do quipamento: ");
                this.name = Console.ReadLine();
                if (name.Length < 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O nome do equipamento precisa ter mais de 6 caracteres.");
                    Console.ResetColor();
                }
            } while (name.Length < 6);
         
         
           Console.Write("Nome do fabricante: ");
           this.producerName = Console.ReadLine();
          
           Console.Write("Número de série: ");
           this.serieNumber = Console.ReadLine();
         
           bool testInput = false;
           do
           {
               Console.Write("Preço de aquisição(números e vírgula, somente): ");
               string test = Console.ReadLine();
          
               testInput = double.TryParse(test, out this.aquisitionPrice);
          
               if (testInput == false)
               {
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Entrada inválida, tente novamente. ");
                   Console.ResetColor();
               }
           } while (testInput == false);

            Console.Write("Digite a data de fabricação do equipamento(Use o formato padrão brasileiro (dia/mês/ano): ");
            string inputDate = Console.ReadLine();
            string[] separeDate = inputDate.Split('/');
            this.manufacturingDate = new DateTime(int.Parse(separeDate[2]),
                int.Parse(separeDate[1]), int.Parse(separeDate[0]));
        }

        //Mostrar equipamento.
        public void ShowEquipament()
        {
            Console.WriteLine($"Nome: {name}\nNome do fabricante: {producerName}\n" +
                $"Data de fabricação: {manufacturingDate.ToString("dd/MM/yyyy")}\nPreço de aquisição: R${aquisitionPrice}\n" +
                $"Número de série: {serieNumber}");
        }

        //Editar informações do equipamento.
        public void EditEquip()
        {
            Console.WriteLine($"O que deseja alterar (escolha o número)?\n1 - Nome do equipamento\n" +
                $"2 - Nome do fabricante\n3 - Número de série\n4 - Preço\n5 - Data");
            string check = Console.ReadLine();
            switch (check)
            {
                case "1":
                    do
                    {
                        Console.Write("Nome do quipamento: ");
                        this.name = Console.ReadLine();
                        if (name.Length < 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("O nome do equipamento precisa ter mais de 6 caracteres.");
                            Console.ResetColor();
                        }
                    } while (name.Length < 6);
                    break;

                case "2":
                    Console.Write("Nome do fabricante: ");
                    this.producerName = Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Número de série: ");
                    this.serieNumber = Console.ReadLine();
                    break;

                case "4":
                    bool testInput = false;
                    do
                    {
                        Console.Write("Preço de aquisição(números e vírgula, somente)");
                        string test = Console.ReadLine();

                        testInput = double.TryParse(test, out this.aquisitionPrice);

                        if (testInput == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Entrada inválida, tente novamente: ");
                        }
                    } while (testInput == false);
                    break;

                case "5":
                    Console.Write("Digite a data de fabricação do equipamento(Use o formato padrão brasileiro (dia/mês/ano): ");
                    string inputDate = Console.ReadLine();
                    string[] separeDate = inputDate.Split('/');
                    this.manufacturingDate = new DateTime(int.Parse(separeDate[2]),
                        int.Parse(separeDate[1]), int.Parse(separeDate[0]));
                    break;
            }
        }
    }
}