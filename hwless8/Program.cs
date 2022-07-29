﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace hwless8
{
   
    class Program
    {
        /// <summary>
        /// Метод для сериализации в XML файл структуры list
        /// </summary>
        /// <param name="currentDepartmentList"></param>
        /// <param name="path"></param>
        static void SerializeDepartments(List<department> currentDepartmentList, string path)
        {
            //Создаем сериализатор на основе указанного типа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<department>));

            //Создаем поток для сохранения данных
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);

            //Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, currentDepartmentList);

            //Закрываем поток
            fStream.Close();

            Console.WriteLine($"Сериализация списка отделов завершилась");
        }

        /// <summary>
        /// Метод для сериализации из XML-файла в структуру list
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static List<department> DeserializeDepartmentList (string path)
        {
            //Структура для хранения извлеченных данных
            List<department> tempDepartments = new List<department>();

            //Создаем сериализатор на основе указанного типа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<department>));

            //Открываем поток для хранения данных
            Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            //Запускаем процесс десериализации
            tempDepartments = xmlSerializer.Deserialize(fStream) as List<department>;

            //Закрываем поток
            fStream.Close();

            Console.WriteLine("Десериализация файла со списком отделов завершилась");
            //Возвращаем дерсериализованный лист
            return tempDepartments;

            
        }

        /// <summary>
        /// Метод для печати list
        /// </summary>
        /// <param name="currentList">Принимает list в качестве параметра</param>
        static void printList(List<department> currentList)
        {
            foreach (department e in currentList)
            {
                e.printDepartment();
            }
        }
        
        /// <summary>
        /// Метод для удаления отдела
        /// </summary>
        /// <param name="currentListDepartment">Текущий список отделов</param>
        static void removeElement(List<department> currentListDepartment)
        {
            Console.WriteLine("Введите отдел, который необходимо удалить");

            string delDepStr = Console.ReadLine();
            department delDep = new department();


            for (int i = 0; i < currentListDepartment.Count; i++)
            {
                if (currentListDepartment[i].nameDepartment == delDepStr)
                {
                    delDep = currentListDepartment[i];
                    currentListDepartment.Remove(delDep);

                }
            }
            Console.WriteLine("\nСписок отделов после удаления");

        }


        /// <summary>
        /// Метод для поиска индекса элемента в list
        /// </summary>
        /// <param name="departmentName"></param>
        /// <param name="currentListDepartment"></param>
        /// <returns></returns>
        static int findIndex(string departmentName, List<department> currentListDepartment)
        {
            //int departmentIndex;
            department currentlDep = new department();
            for (int i = 0; i < currentListDepartment.Count; i++)
            {
                if (currentListDepartment[i].nameDepartment == departmentName)
                {
                    currentlDep = currentListDepartment[i];
                    

                }
            }

            return currentListDepartment.IndexOf(currentlDep); 
        }

        static void modifyList(List<department> currentList)
        {
            Console.WriteLine("Введите отдел, который необходимо редактировать");

            string modifyDepStr = Console.ReadLine();
            //department delDep = new department();

            int oldIndex = findIndex(modifyDepStr, currentList);

            Console.WriteLine($"Индекс в исходном списке отделов: {oldIndex}");

            Console.WriteLine("Введите новое название");

            string newNameDep = Console.ReadLine();

            Console.WriteLine("Введите новую дату создания ");

            DateTime newDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Введите новое количество сотрудников ");

            int newAmount = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Ввод информации для редактирования окончен");


            department current = new department(newNameDep, newDate, newAmount);

            currentList.Insert(oldIndex, current);
            currentList.RemoveAt(oldIndex + 1);
        }

        static List<department> sortedList(List<department> currentList)
        {
           List<department> sorted = currentList.OrderBy(x => x.nameDepartment).ThenBy(x => x.workersAmount).ToList();
            return sorted;
        }

        static void Main(string[] args)
        {
            /// Создать прототип информационной системы, в которой есть возможност работать со структурой организации
            /// В структуре присутствуют департаменты и сотрудники
            /// Каждый департамент может содержать не более 1_000_000 сотрудников.
            /// У каждого департамента есть поля: наименование, дата создания,
            /// количество сотрудников числящихся в нём 
            /// (можно добавить свои пожелания)
            /// 
            /// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
            /// уникальный номер, размер оплаты труда, количество закрепленным за ним.
            ///
            /// В данной информаиционной системе должна быть возможность 
            /// - импорта и экспорта всей информации в xml и json
            /// Добавление, удаление, редактирование сотрудников и департаментов
            /// 
            /// * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
            /// по нескольким полям, например возрасту и оплате труда
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            /// 
            /// 
            /// Упорядочивание по одному полю возраст
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 
            ///
            /// Упорядочивание по полям возраст и оплате труда
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 
            /// 
            /// Упорядочивание по полям возраст и оплате труда в рамках одного департамента
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            /// 

            department current = new department();

            Random newNumber = new Random();
            Random newNumberDay = new Random();
            Random newNumberMonth = new Random();
            Random newNumberYear = new Random();

            //Формирование списка отделов
            List<department> newListDepartment = new List<department>();


            //for (int i = 1; i <= 3; i++)
            //{

            //    int newNumberResult = newNumber.Next(1_000_000);

            //    int newNumberDayResult = newNumberDay.Next(1, 31);

            //    int newNumberMonthResult = newNumberDay.Next(1, 13);

            //    int newNumberYearResult = newNumberDay.Next(2000, 2022);



            //    newListDepartment.Add(current.createDepertment(i, newNumberResult, newNumberDayResult, newNumberMonthResult, newNumberYearResult));
            //    //Console.WriteLine($"number: {i} new number:{newNumberResult}  day: {newNumberDayResult} month:{newNumberMonthResult} year: {newNumberYearResult}");
            //}

            newListDepartment.Add(current.createDepertment(1, 10, 1, 3, 2007));
            newListDepartment.Add(current.createDepertment(2, 33, 14, 8, 2003));
            newListDepartment.Add(current.createDepertment(3, 75, 30, 12, 2019));
            newListDepartment.Add(current.createDepertment(2, 18, 30, 12, 2019));
            newListDepartment.Add(current.createDepertment(3, 180, 30, 12, 2019));
            newListDepartment.Add(current.createDepertment(2, 18, 30, 12, 2019));

            Console.WriteLine("До упорядочивания");
            printList(newListDepartment);
                                
            Console.WriteLine("\nПосле упорядочивания");
            printList(sortedList(newListDepartment));

            //Работа метода сериализации
            SerializeDepartments(newListDepartment, "newListDepartments.xml");

            //Сериализация в json
            string jsonDepartment = JsonConvert.SerializeObject(newListDepartment);
            File.WriteAllText("jsonListDepartment", jsonDepartment);
            Console.ReadKey();

            //Работа метода десериализации
            List<department> newList = new List<department>();
            newList = DeserializeDepartmentList("newListDepartments.xml");
            Console.WriteLine("\nДесериализация из xml");
            printList(newList);

            //Работа метода десериализации из json
            List<department> newList2 = new List<department>();
            string fromJsom = File.ReadAllText("jsonListDepartment");
            newList2 = JsonConvert.DeserializeObject<List<department>>(fromJsom);
            Console.WriteLine("\nДесериализация изjson");
            printList(newList2);


            modifyList(newListDepartment);

            printList(newListDepartment);



            removeElement(newListDepartment);
            printList(newListDepartment);



            Console.ReadKey();

        }

    }
}
