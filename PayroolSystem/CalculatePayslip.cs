using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayroolSystem
{
    class Calculation_of_salary
    {
        private int baseSal;
        private int hours;
        private int sale;
        private int rate;
        private int commisionRate;

        public Calculation_of_salary(int baseSal)
        {
            this.baseSal = baseSal;
        }

        public Calculation_of_salary(int hours, int rate)
        {
            this.hours = hours;
            this.rate = rate;
        }

        public Calculation_of_salary(int baseSal, int sale, int commisionRate)
        {
            this.baseSal = baseSal;
            this.sale = sale;
            this.commisionRate = commisionRate;


        }




        public double CalculateSalariedEmployee()
        {
            double income = ((baseSal * 12) / 365) * 7;
            return income;
        }

        public double CalculateHourlyEmployee()
        {
            double income = 0;
            if (hours <= 40)
            {
                income += hours * rate;
            }
            else
            {
                income += (40 * rate);
                income += (hours - 40) * (rate * 2.5);
            }
            return income;
        }


        public double CalculateCommissionEmployee()
        {
            double income = ((baseSal * 12) / 365) * 7;

            income += (sale * 10 / 100);
            return income;
        }


    }
}
