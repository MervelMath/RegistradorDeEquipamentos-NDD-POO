using System;
using System.Collections.Generic;

namespace RegistradorDeEquipamentos.ConsoleApp
{
    internal class Menu
    {
        public Menu(List<Equipment> equipmentList, List<Calls> callsList)
        {
            while (true)
            {
                Console.WriteLine($"O que deseja fazer?(Digite o número.)\n1 - Adicionar novo equipamento\n" +
                    $"2 - Visualizar equipamentos\n3 - Editar equipamento\n4 - Remover equipamento\n" +
                    $"5 - Adicionar chamado de manutenção\n6 - Visualizar chamados\n7 - Editar chamado\n" +
                    $"8 - Remover chamado\n0 - Finalizar aplicação");

                string check = Console.ReadLine();
                Console.Clear();
                if (check != "1" && equipmentList.Count == 0 && check != "0")
                {
                    VerifyIfEquipmentListIsClean();
                    continue;
                }

                int count = 0;
                int veryfyExistence = 0;
                switch (check)
                {
                    case "1":
                        AddNovoEquipamento(equipmentList);
                        break;

                    case "2":
                        count = MenuMostrarEquipamento(equipmentList);
                        break;

                    case "3":
                        count = MenuEditarEquipamento(equipmentList);
                        break;

                    case "4":
                        count = MenuRemoverEquipamento(equipmentList);
                        break;

                    case "5":
                        count = MenuAddChamado(equipmentList, callsList);
                        break;

                    case "6":
                        count = MenuVerChamado(equipmentList, callsList, ref veryfyExistence);
                        break;

                    case "7":
                        count = MenuEditarChamado(equipmentList, callsList, ref veryfyExistence);
                        break;

                    case "8":
                        count = MenuRemoverChamado(equipmentList, callsList, ref veryfyExistence);
                        break;
                }

                if (check == "0")
                    break;
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Refatoração:
        private static int MenuRemoverChamado(List<Equipment> equipmentList, List<Calls> callsList, ref int veryfyExistence)
        {
            int count;
            do
            {
                count = 0;
                Console.WriteLine("O chamado de qual equipamento você deseja remover?");
                foreach (Equipment equipment in equipmentList)
                {
                    count++;
                    Console.WriteLine($"{count} - {equipment.Name}");
                }

                count = int.Parse(Console.ReadLine());

                if (count > equipmentList.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Índice não existente.");
                    Console.ResetColor();
                }
            } while (count > equipmentList.Count);

            if (count != 0)
            {
                foreach (Calls calls in callsList)
                {
                    if (calls.EquipmentName.Equals(equipmentList[count - 1].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        callsList.Remove(calls);
                        veryfyExistence = -2;
                    }
                    if (callsList.Count == 0)
                    {
                        break;
                    }
                }
                if (veryfyExistence != -2)
                    Console.WriteLine("Não existe chamado registrado para esse equipamento.");
            }

            return count;
        }

        private static int MenuEditarChamado(List<Equipment> equipmentList, List<Calls> callsList, ref int veryfyExistence)
        {
            int count;
            do
            {
                count = 0;
                Console.WriteLine("O chamado de qual equipamento deseja editar?(0 - Calcelar)");
                foreach (Equipment equipment in equipmentList)
                {
                    count++;
                    Console.WriteLine($"{count} - {equipment.Name}");
                }

                count = int.Parse(Console.ReadLine());

                if (count > equipmentList.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Índice não existente.");
                    Console.ResetColor();
                }
            } while (count > equipmentList.Count);

            if (count != 0)
            {

                foreach (Calls calls in callsList)
                {
                    if (calls.EquipmentName.Equals(equipmentList[count - 1].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        calls.EditCalls();
                        veryfyExistence = -2;
                    }
                }
                if (veryfyExistence != -2)
                    Console.WriteLine("Não existe chamado registrado para esse equipamento.");

            }

            return count;
        }

        private static int MenuVerChamado(List<Equipment> equipmentList, List<Calls> callsList, ref int veryfyExistence)
        {
            int count;
            do
            {
                count = 0;
                Console.WriteLine("O chamado de qual equipamento deseja visualizar?(0 - Calcelar)");
                foreach (Equipment equipment in equipmentList)
                {
                    count++;
                    Console.WriteLine($"{count} - {equipment.Name}");
                }

                count = int.Parse(Console.ReadLine());

                if (count > equipmentList.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Índice não existente.");
                    Console.ResetColor();
                }
            } while (count > equipmentList.Count);

            if (count != 0)
            {
                foreach (Calls calls in callsList)
                {
                    if (calls.EquipmentName.Equals(equipmentList[count - 1].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        calls.ShowCalls();
                        veryfyExistence = -2;
                    }
                }
                if (veryfyExistence != -2)
                    Console.WriteLine("Não existe chamado registrado para esse equipamento.");
            }

            return count;
        }

        private static int MenuAddChamado(List<Equipment> equipmentList, List<Calls> callsList)
        {
            int count;
            Calls call = new Calls();
            do
            {
                count = 0;
                Console.WriteLine("Para qual equipamento deseja adicionar um chamado?");
                foreach (Equipment equipment in equipmentList)
                {
                    count++;
                    Console.WriteLine($"{count} - {equipment.Name}");
                }

                count = int.Parse(Console.ReadLine());
                if (count > equipmentList.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Índice não existente.");
                    Console.ResetColor();
                }
            } while (count > equipmentList.Count);


            call.AddCall(equipmentList[count - 1].Name);
            callsList.Add(call);
            return count;
        }

        private static int MenuRemoverEquipamento(List<Equipment> equipmentList)
        {
            int count;
            do
            {
                count = 0;
                Console.WriteLine("Qual equipamento deseja remover?(Digite '0' para cancelar)");

                foreach (Equipment equipment in equipmentList)
                {
                    count++;
                    Console.WriteLine($"{count} - {equipment.Name}");
                }

                count = int.Parse(Console.ReadLine());

                if (count > equipmentList.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Índice não existente.");
                    Console.ResetColor();
                }
            } while (count > equipmentList.Count);

            if (count != 0)
                equipmentList.RemoveAt(count - 1);
            return count;
        }

        private static int MenuEditarEquipamento(List<Equipment> equipmentList)
        {
            int count;
            do
            {
                count = 0;
                Console.WriteLine("Qual equipamento deseja editar?(0 - Calcelar)");
                foreach (Equipment equipment in equipmentList)
                {
                    count++;
                    Console.WriteLine($"{count} - {equipment.Name}");
                }

                count = int.Parse(Console.ReadLine());
                if (count > equipmentList.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Índice não existente.");
                    Console.ResetColor();
                }
            } while (count > equipmentList.Count);

            if (count != 0)
                equipmentList[count - 1].EditEquip();
            return count;
        }

        private static int MenuMostrarEquipamento(List<Equipment> equipmentList)
        {
            int count;
            do
            {
                count = 0;
                Console.WriteLine("Qual equipamento deseja visualizar?(0 - Calcelar)");
                foreach (Equipment equipment in equipmentList)
                {
                    count++;
                    Console.WriteLine($"{count} - {equipment.Name}");
                }

                count = int.Parse(Console.ReadLine());

                if (count > equipmentList.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Índice não existente.");
                    Console.ResetColor();
                }
            } while (count > equipmentList.Count);
            if (count != 0)
                equipmentList[count - 1].ShowEquipament();
            return count;
        }

        private static void AddNovoEquipamento(List<Equipment> equipmentList)
        {
            Equipment eq = new Equipment();
            eq.AddEquip();
            equipmentList.Add(eq);
        }

        private static void VerifyIfEquipmentListIsClean()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum equipamento registrado.");
            Console.ResetColor();
        }
    }
}