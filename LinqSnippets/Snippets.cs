using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{

    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "Audi A3",
                "Mercedes Benz Clase A",
                "Audi A7",
                "Seat Ibiza"
            };

            //1. Hacer SELECT de coches

            var carList = from car in cars select car;

            foreach(var car in carList)
            {
                Console.WriteLine(car);
            }


            //1. Hacer SELECT WHERE

            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }
        }

        // Number examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 0,1,2,3,4,5,6,7,8,9};

            //OBTENER CADA NUMERO MULTIPLICADO POR 3
            //OBTENER TODOS LOS NUMEROS MENOS EL NUEVE
            //ORDENAR ASCENDENTEMENTE

            var processedNumberList =
                numbers.Select(num => num * 3)
                .Where(num => num != 0)
                .OrderBy(num => num);
        }


        static public void searchEamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c",
            };

            // 1. Buscar todos los elementos
            var first = textList.First();

            // 2. Buscar los elementos que sea C
            var cText = textList.First(text => text.Equals("c"));

            // 3. Primer elemento que contenga la J
            var jText = textList.First(text => text.Contains("j"));

            // 4. Primer elemento que contenga la Z y si no coger un valor por zefecto
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. Ulitmo elemento que contenga la Z y si no coger un valor por zefecto
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Valores unicos
            var uniqueText = textList.Single();
            var uniqueOrDefaultText = textList.SingleOrDefault();


            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            // OBTENER EL 4 y 8 que no se repiten
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); 

        }


        public static void MultipleSelect()
        {
            // SELECT VARIOS
            string[] myOpinions =
            {
                "Opinion 1, Text 1",
                "Opinion 2, Text 2",
                "Opinion 3, Text 3",
                "Opinion 4, Text 4",
                "Opinion 5, Text 5",
                "Opinion 6, Text 6"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));


            var entreprises = new[]
            {
                new Entreprise()
                {
                    Id = 1,
                    Name = "Empresa 1",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Manuel",
                            Email = "manuel@manuel.com",
                            Salary = 1200
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Antonio",
                            Email = "Antonio@manuel.com",
                            Salary = 1500
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Pedro",
                            Email = "Pedro@manuel.com",
                            Salary = 1600
                        },
                        new Employee
                        {
                            Id = 4,
                            Name = "Flor",
                            Email = "Flor@manuel.com",
                            Salary = 1800
                        },
                    }
                },
                new Entreprise()
                {
                    Id = 2,
                    Name = "Empresa 2",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "Ana@manuel.com",
                            Salary = 1100
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "Maria@manuel.com",
                            Salary = 1300
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "Marta@manuel.com",
                            Salary = 950
                        },
                    }
                }
            };

            //Obtener todos los empleados de todas las empresas
            var employeeList = entreprises.SelectMany(enterprise => enterprise.Employees);

            // Saber si tenemos una lista vacia
            bool hasEnterprise = entreprises.Any();

            bool hasEmployees = entreprises.Any(enterprise => enterprise.Employees.Any());

            //Todas las empresas que tenga empleados con un salario mayor de 1000€
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 =
                entreprises.Any(enterprise => 
                enterprise.Employees.Any(Employee => Employee.Salary >= 1000));

        }

        static public void linqCollection()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // inner join
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement });


            // outter join - left
            var leftOuterJoin = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               into temporalList
                               from temporalElement in temporalList.DefaultIfEmpty()
                               where element != temporalElement
                               select new {Element = element};

            // outter join - left
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };


            //UNION 
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }


        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10,
            };

            var skipTwoFirstValues = myList.Skip(2);
            var skipLastTwoFirstValues = myList.SkipLast(2);
            var skipWhile = myList.SkipWhile(num => num < 4);

            var takeFirst4Values = myList.Take(4);
            var takeLast4Values = myList.TakeLast(4);
            var takeWhile = myList.TakeWhile(num => num > 4);
        }
    }
}