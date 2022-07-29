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

        public worker(int numbWorker, byte ageWorker, department depNumb)
        {

        }


        public worker createDepertment(int numbWorker, byte ageWorker, department depNumb)
        {
            

            worker newWorker = new worker("Фамилия_" + numbWorker, "Имя_" + numbWorker, ageWorker, depNumb, numbWorker, numbWorker * 1000, numbWorker * 5);


            return newWorker;
        }
        //Метод для печати информации об отделе

        public void printDepartment()
        {
            Console.WriteLine("{0} {1} {2}",
                this.nameDepartment,
                this.foundingDate,
                this.workersAmount);
        }


    }
}
