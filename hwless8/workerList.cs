using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace hwless8
{
    public class workerList
    {
        public List<worker> newList;
       

        //Конструктор


        public workerList()
        {
            this.newList = new List<worker>();
           
        }
        public workerList(List<worker> currentWorkerList)
        {
            this.newList = currentWorkerList;

        }


        //Создание нового объекта типа worker
        public void createWorker(int numbWorker, byte ageWorker, department depNumb)
        {

            worker newWorker = new worker("Фамилия_" + numbWorker, "Имя_" + numbWorker, ageWorker, depNumb, numbWorker, (ageWorker / 5) * 100, (byte)(ageWorker / 5));

            addWorkerList( newWorker);
        }

        /// <summary>
        /// Метод для добавления объекта worker в список
        /// </summary>
        /// <param name="currentWorker"></param>
        private void addWorkerList (worker currentWorker)
        {
            this.newList.Add(currentWorker);
        }

        /// <summary>
        /// Метод для печати списка сотрудников
        /// </summary>
        public void printWorkerList()
        {
            Console.WriteLine("\nСписок сотрудников:");

            foreach (worker e in this.newList)
            {
                e.printWorker();
            }


        }

        /// <summary>
        /// Метод для сортировки списка сотрудников
        /// </summary>
        public void sorted()
        {
            this.newList = this.newList.OrderBy(i => i.department.nameDepartment).ThenBy(i => i.age).ThenBy(i => i.salary).ToList();
        }

        /// <summary>
        /// Метод для удаления сотрудника из списка
        /// </summary>
        public void removeWorker()
        {
            Console.WriteLine("\nВведите номер сотрудника, которого необходимо удалить");

            int delWorkerNumber = Convert.ToInt32(Console.ReadLine());
            worker delWorker = new worker();


            for (int i = 0; i < this.newList.Count; i++)
            {
                if (this.newList[i].workerNumber == delWorkerNumber)
                {
                    delWorker = this.newList[i];
                    this.newList.Remove(delWorker);

                }
            }
        }


        private int findIndex(int numberWorker)
        {

            worker modifyWorker = new worker();


            for (int i = 0; i < this.newList.Count; i++)
            {
                if (this.newList[i].workerNumber == numberWorker)
                {
                    modifyWorker = this.newList[i];

                }
            }

            return this.newList.IndexOf(modifyWorker);
        }

        /// <summary>
        /// Метод для изменения информации
        /// </summary>
        /// <param name="currentListDepartment"></param>
        public void modifyWorkerList(List<department> currentListDepartment)
        {
            Console.WriteLine("\nВведите номер сотрудника, информацию о котором необходимо отредактировать");

            int modifyWorkerNumber = Convert.ToInt32(Console.ReadLine());

            int workeIndex =  findIndex(modifyWorkerNumber);

            Console.WriteLine("\nВыберите поле, которое необходимо отредактировать:");
            Console.WriteLine("\n1 - Фамилия;\n2 - Имя;\n3 - Возраст;\n4 - Отдел;\n5 - Заработная плата;\n6 - Количество проектов; ");
            byte numberField = Convert.ToByte(Console.ReadLine());

            switch (numberField)
            {
                case 1:
                    {
                        Console.WriteLine("\nВведите новую фамилию:");
                        string newLastName = Console.ReadLine();
                        this.newList[workeIndex].lastName = newLastName;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("\nВведите новое имя:");
                        string newFirstName = Console.ReadLine();
                        this.newList[workeIndex].firstName = newFirstName;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("\nВведите новый возраст:");
                        byte newAge = Convert.ToByte(Console.ReadLine());
                        this.newList[workeIndex].age = newAge;
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("\nВведите название нового отдела:");
                        string newDepartment = Console.ReadLine();
                        department changeDepartment = new department();
                        bool marker = false;
                        foreach (department e in currentListDepartment)
                        {
                            if (e.nameDepartment == newDepartment)
                            {
                                changeDepartment = e;
                                this.newList[workeIndex].department = changeDepartment;
                                marker = true;
                            }

                        }
                         if (!marker)
                        {
                            Console.WriteLine("\nВыбранный вами отдел не существует");
                        }

                        
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("\nВведите новую заработную плату");
                        int newSalary = Convert.ToInt32(Console.ReadLine());
                        this.newList[workeIndex].salary = newSalary;
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("\nВведите новое количество проектов:");
                        byte newProjectAmount = Convert.ToByte(Console.ReadLine());
                        this.newList[workeIndex].projectAmount = newProjectAmount;
                        break;
                    }
            }

            Console.WriteLine("\nРедактирование завершено");
        }


        /// <summary>
        /// Метод сериализации списка сотрудников в xml
        /// </summary>
        public void Serialize()
        {
            //Создаем сериализатор на основе указанного типа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<worker>));

            //Создаем поток для сохранения данных
            Stream fStream = new FileStream("workerList.xml", FileMode.Create, FileAccess.Write);

            //Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, newList);

            //Закрываем поток
            fStream.Close();

            Console.WriteLine($"\nСериализация списка сотрудников завершилась");
        }

        /// <summary>
        /// Метод десериализации списка сотрудников из xml
        /// </summary>
        /// <returns></returns>
        public List<worker> Deserialize()
        {
            //Структура для хранения извлеченных данных
            List<worker> tempWorkers = new List<worker>();

            //Создаем сериализатор на основе указанного типа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<worker>));

            //Открываем поток для хранения данных
            Stream fStream = new FileStream("workerList.xml", FileMode.Open, FileAccess.Read);

            //Запускаем процесс десериализации
            tempWorkers = xmlSerializer.Deserialize(fStream) as List<worker>;

            //Закрываем поток
            fStream.Close();

            Console.WriteLine("Десериализация файла со списком сотрудников завершилась");
            //Возвращаем дерсериализованный лист
            return tempWorkers;


        }


        /// <summary>
        /// Сериализация и десериализация json
        /// </summary>
        public void SerializeJson()
        {
            string jsonWorkers = JsonConvert.SerializeObject(this.newList);
            File.WriteAllText("jsonListWORKERS", jsonWorkers);
            Console.WriteLine($"\nСериализация списка сотрудников в json завершилась");
        }

        public List<worker> DeserializeJson()
        {

            List<worker> newList2 = new List<worker>();
            string fromJson = File.ReadAllText("jsonListWORKERS");
            newList2 = JsonConvert.DeserializeObject<List<worker>>(fromJson);
            Console.WriteLine("\nДесериализация из json завершилась");
            return newList2;
        }
    }
}
