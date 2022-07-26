using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwless8
{
    struct department
    {
        private string nameDepartment;
        private DateTime foundingDate;
        private int workersAmount;

        //Конструктор
        public department(string nameDepartment, DateTime foundingDate, int workersAmount)
        {
            this.nameDepartment = nameDepartment;
            this.foundingDate = foundingDate;
            this.workersAmount = workersAmount;
        }


        //Свойства для ввода данных
        public string NameDepartment
        {
            get { return this.nameDepartment; }
            set { this.nameDepartment = value; }
        }

        public DateTime FoundingDate
        {
            get { return this.foundingDate; }
            set { this.foundingDate = value; }
        }

        public int WorkersAmount
        {
            get { return this.workersAmount; }
            set { this.workersAmount = value; }
        }


        //Метод для создания отдела

        public department createDepertment()
        {


            Random newNumber = new Random();
            int newNumberResult = newNumber.Next(10);

            Random newNumberDay = new Random();
            int newNumberDayResult = newNumberDay.Next(31);

            Random newNumberMonth = new Random();
            int newNumberMonthResult = newNumberDay.Next(12);


            Random newNumberYear = new Random();
            int newNumberYearResult = newNumberDay.Next(2000, 2022);

            //department newDepartment = new department("Отдел_"+ newNumberResult,new DateTime(newNumberYearResult, newNumberMonthResult, newNumberDayResult, 00, 00, 00),newNumberResult + 3);



            department newDepartment = new department("Отдел_" + newNumberResult, new DateTime(newNumberYearResult, newNumberMonthResult, newNumberDayResult, 00, 00, 00), newNumberResult + 3);








            Console.WriteLine("{0} {1} {2}",
                newDepartment.NameDepartment,
                newDepartment.FoundingDate,
                newDepartment.WorkersAmount);


            return newDepartment;
        }
    }
}
