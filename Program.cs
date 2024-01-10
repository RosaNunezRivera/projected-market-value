using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
         /// <summary>
         /// Laboratory 1: Program to calculate:
         ///               a) Growth level of stock 
         ///               b) Projected market value for the investment 
         ///               
         /// Growth level of stock estimated based on (Inputs by user):
         /// 1. Projected interest rate level - high, medium, low 
         /// 2. Projected growth level of the stock - high, medium, low  
         /// 3. Most recent dividend - integer greater than cero and less than 100 
         /// 4. Number of shares - interger treater than cero 
         /// </summary>
        static void Main(string[] args)
        {
            //Adding titles of company and program
            Console.WriteLine("\nRegent Private Wealth");
            Console.WriteLine("Winnipeg, Canada.\n");
            Console.WriteLine("Projected of Growth level of the stock & market value for the investment");
            Console.WriteLine("------------------------------------------------------------------------\n");
            
            //Declaring variables 
            char projectedRateLevel;
            char projectedGrowthLevel;
            decimal projectedInteres;
            decimal projectedGrowth;
            decimal valueStock;
            int dividens;
            decimal marketValue;
            int shares;

            //Input to get the projected rate level - valid caracthers 'h','m', and 'l'
            do
            {
                Console.WriteLine("Please enter the letter that corresponds to the projected interes rate level");
                Console.WriteLine("(h) high  (m) medium (l) low");
                projectedRateLevel = Convert.ToChar(Console.ReadLine());
            } while (projectedRateLevel !='h' && projectedRateLevel !='H' && projectedRateLevel !='m' && projectedRateLevel !='M' && projectedRateLevel !='l' && projectedRateLevel !='L');

            //Input to get the projected growth level of the stock - valid caracthers 'h','m', and 'l'
            do
            {
                Console.WriteLine("Please enter the letter that corresponds to the projected growth level of the stock");
                Console.WriteLine("(h) high  (m) medium (l) low");
                projectedGrowthLevel = Convert.ToChar(Console.ReadLine());
            } while (projectedGrowthLevel != 'h' && projectedGrowthLevel != 'H' && projectedGrowthLevel != 'm' && projectedGrowthLevel != 'M' && projectedGrowthLevel != 'l' && projectedGrowthLevel != 'L');


            //Input to get the dividens - Integer > 0 and < 100
            do
            {
                Console.WriteLine("Please enter the most recent dividens value ($):");
                dividens = Convert.ToInt32(Console.ReadLine());
            } while (dividens <= 0 || dividens > 99);


            //Input to get shares - Integer > 0
            do
            {
                Console.WriteLine("Please enter the number of shares:");
                shares = Convert.ToInt32(Console.ReadLine());
            } while (shares <= 0);

            //Getting the projected interes and projected growth based on scenarios 
            projectedInteres = getProjectedRateInteres(projectedRateLevel);
            projectedGrowth  = getProjectedGrowth(projectedGrowthLevel); ;

            //Getting estimated ValueStock using a function   
            valueStock = valueStockProjection(projectedInteres, projectedGrowth, dividens);

            //Getting estimated marketValue using a function   
            marketValue = marketValueProjection(valueStock, shares);

            //Printing the estimated values
            Console.WriteLine("\nProjected values");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Value of stock : $ {0:#,##0.00}", valueStock);
            Console.WriteLine("Market value   : $ {0:#,##0.00}", marketValue);
            Console.ReadKey();
        }

        //Function to get the rate level and return the percentage of interest rate based on projected scenarios
        static decimal getProjectedRateInteres(char rateLevel) 
        {
            decimal projectedInteres=0.0m;
            switch (Char.ToLower(rateLevel))
            {
                case 'h':
                    projectedInteres = 0.20m;  //High Level 
                    break;
                case 'm':
                    projectedInteres = 0.10m;  //Medium Level
                    break;
                case 'l':
                    projectedInteres = 0.08m;  //Low Level
                    break;
            }
            return projectedInteres;
        }

        ///Function to get the growth level and retunr the percentage base of projected growth rate scenarios  
        static decimal getProjectedGrowth(char growthLevel)
        {
            decimal projectedGrowth = 0.0m;
            switch (Char.ToLower(growthLevel))
            {
                case 'h':
                    projectedGrowth = 0.075m;  //High Level 
                    break;
                case 'm':
                    projectedGrowth = 0.05m;  //Medium Level
                    break;
                case 'l':
                    projectedGrowth = 0.025m;  //Low Level
                    break;
            }
            return projectedGrowth;
        }


        //Function to calculate & return the projected value Stock 
        static decimal valueStockProjection(decimal projectedInteres, decimal projectedGrowth, int dividens)
        {
            //Calculating value of a stock | P = D / (R - G)
            //valueStock (P) = dividens / ( projectedInteres - projectedGrowth )
            decimal valueStock = dividens / (projectedInteres - projectedGrowth);
            return valueStock;
        }

        //Function to calculate & return the projected market Value 
        static decimal marketValueProjection(decimal valueStock, int shares)
        {
            //Calculating projected market value MV = P  * S Where
            //MarketValue = P * shares 
            decimal marketValue = valueStock * shares;
            return marketValue;
        }
    }
}
