using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hwless8
{
   public class worker
    {
        /// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
        /// уникальный номер, размер оплаты труда, количество закрепленным за ним.

        public string lastName;
        public string firstName;
        public byte age;
        public department department;
        public int workerNumber;
        public int salary;
        public byte projectAmount;

        //Конструктор класса
        public worker()
        {

        }

        public worker(string lastName, string firstName, byte age, department department, int workerNumber, int salary, byte projectAmount)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.age = age;
            this.department = department;
            this.workerNumber = workerNumber;
            this.salary = salary;
            this.projectAmount = projectAmount;

        }



        //public worker createWorker(int numbWorker, byte ageWorker, department depNumb)
        //{


        //    worker newWorker = new worker("Фамилия_" + numbWorker, "Имя_" + numbWorker, ageWorker, depNumb, numbWorker, (ageWorker / 5) * 100, (byte)(ageWorker / 5));


        //    return newWorker;
        //}
        //Метод для печати информации об отделе

        public void printWorker()
        {
            Console.WriteLine("{0,5} {1,15} {2,10} {3,3} {4,10} {5,6} {6,4}",
            this.workerNumber,
            this.lastName,
            this.firstName,
            this.age,
            this.department.nameDepartment,
            this.salary,
            this.projectAmount);


        }


    }
}
