using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwless8
{
    public class department
    {
        public string nameDepartment;
        public DateTime foundingDate;
        public int workersAmount;

        //Конструктор

        public department()
        {

        }
        public department(string nameDepartment, DateTime foundingDate, int workersAmount)
        {
            this.nameDepartment = nameDepartment;
            this.foundingDate = foundingDate;
            this.workersAmount = workersAmount;
        }


        


        //Метод для создания отдела

        public department createDepertment(int numbDep, int newNumberResult, int newNumberDayResult, int newNumberMonthResult, int newNumberYearResult)
        {



            //department newDepartment = new department("Отдел_"+ newNumberResult,new DateTime(newNumberYearResult, newNumberMonthResult, newNumberDayResult, 00, 00, 00),newNumberResult + 3);



            department newDepartment = new department("Отдел_" + numbDep, new DateTime(newNumberYearResult, newNumberMonthResult, newNumberDayResult, 00, 00, 00), newNumberResult);

            

            return newDepartment;
        }

       //Метод для печати информации об отделе

        public void printDepartment ()
        {
            Console.WriteLine("{0} {1} {2}",
                this.nameDepartment,
                this.foundingDate,
                this.workersAmount);
        }
    }
}
