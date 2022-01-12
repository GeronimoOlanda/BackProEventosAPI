using System;
using System.Linq;
namespace Estudos1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //variaveis
            string firstName = "Geronimo";
            string middleName = "José";
            string lastName = "Olanda";
            string fullName = firstName + middleName + lastName;
            string gender = "Male";

            int age = 23;
            int days = 30;
            int month = 12;
            int years = 2022;

            double kg = 98.2;
            double lifespaw = 199.234;

            bool activeTrap = false;
            bool accessLiberate = false;
            bool openTheDoor = true;


            Console.WriteLine("Digite o seu nome: ");
            string ploatName = Console.ReadLine();

            Console.WriteLine("Digite a sua idade: ");
            int age2 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine($"My name is {ploatName} and my age is {age2}");

            //Math 
            Console.WriteLine(Math.Sqrt(64));
            Console.WriteLine(Math.Abs(-29.2));

            Console.WriteLine(Math.Round(20.5));
            Console.WriteLine(Math.Floor(20.6));
            Console.WriteLine(Math.PI);


            //string
            string nome = "Geronimo José de Lima de Olanda";
            Console.WriteLine(nome.Length);
            Console.WriteLine(nome.ToUpper());
            Console.WriteLine(nome.ToLower());
            Console.WriteLine(nome.Trim());
            Console.WriteLine(nome.IndexOf("G"));
            Console.WriteLine(nome.Replace("Lima", "Aparecida"));
            Console.WriteLine(nome.Split(' '));

            double value1 = 20;
            double value3 = 20;

            if( value1 != value3 || value3 != value1)
            {
                Console.WriteLine("O valor mencionado não bate com o que esta armazenado em banco de dados, confira e tente novamente");
            }
            else
            {
                Console.WriteLine("Pode continuar fazendo o que estava fazendo.");
            }

            //arrays

            string[] cars = { "Volvo", "BMW", "Safira", "Mustang"};
            double[] numbers = { 20, 32, 42, 22, 234, 11, 4, 5 };
            foreach(string car in cars)
            {
                Console.WriteLine($"Name = {car}");
            }

            Console.WriteLine(cars.Length);
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Sum());

            myMethod method = new myMethod();
            Console.WriteLine(method.nome);
            Console.WriteLine(method.gender);
            Console.WriteLine(method.idade);
            Console.WriteLine(method.kg);
        }
    }
}
