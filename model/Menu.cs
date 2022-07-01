using System;
using System.Collections.Generic;


namespace Bank
{
    public class Menu
    {
        static List<Account> AccountList = new List<Account>();
        public static string UserOption()
        {
            string userOption = GetUserOption();
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1": ListAccount(); break;
                    case "2": RegisterAccount(); break;
                    case "3": TransferBalance(); break;
                    case "4": WithdrawnBalance(); break;
                    case "5": DepositBalance(); break;
                    case "C": Console.Clear(); break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.WriteLine("Até breve!");
            return userOption;
        }
        public static string GetUserOption()
        {

            Console.WriteLine("-------------------------");
            Console.WriteLine("Upper Bank à disposição!\n");
            Console.WriteLine("-------------------------");
            Console.WriteLine("O que deseja fazer?\n");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Cadastrar conta");
            Console.WriteLine("3 - Transferir saldo");
            Console.WriteLine("4 - Sacar saldo");
            Console.WriteLine("5 - Depositar saldo");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
        private static void RegisterAccount()
        {
            Console.WriteLine("Inserir uma nova conta\n");
            Console.WriteLine("Digite 1 para pessoa física.");
            Console.WriteLine("Digite 2 para pessoa jurídica");
            Console.Write("Opção: ");
            int inputAccountType = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string inputName = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double inputBalance = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito disponível: ");
            double inputCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account
            (accountType: (AccountType)inputAccountType,
            name: inputName,
            balance: inputBalance,
            credit: inputCredit);

            AccountList.Add(newAccount);
        }
        private static void ListAccount()
        {
            Console.WriteLine("Listar contas\n");
            if (AccountList.Count == 0)
            {
                Console.WriteLine("Nenhuma conta registrada");
                return;
            }
            for (int i = 0; i < AccountList.Count; i++)
            {
                Account account = AccountList[i];
                Console.Write($"# {i} - ");
                Console.WriteLine(account);
            }
        }
        private static void WithdrawnBalance()
        {
            Console.Write("Digite o número da conta: ");
            int numberAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que deseja sacar: ");
            double amountWithdrawn = double.Parse(Console.ReadLine());

            AccountList[numberAccount].Withdrawn(amountWithdrawn);
        }
        private static void DepositBalance()
        {
            Console.Write("Digite o número da conta: ");
            int numberAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que deseja depositar: ");
            double amountDeposit = double.Parse(Console.ReadLine());

            AccountList[numberAccount].Deposit(amountDeposit);
        }
        private static void TransferBalance()
        {
            Console.Write("Digite o número da conta de origem: ");
            int originNumberAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int destinationNumberAccount = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que deseja transferir: ");
            double amountTransfer = double.Parse(Console.ReadLine());

            AccountList[originNumberAccount].Transfer(amountTransfer,
            AccountList[destinationNumberAccount]);
        }

    }
}