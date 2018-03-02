/**
 * A Class to solve the Birthday-Day Challenge of the Blundell Challenges
 * @author Salford Computing Society
 */
public class BirthdayDay
{
    /**
     * Create a blank BirthDay object which will run the testMethod() at creation
     */
    public BirthdayDay()
    {
        testMethod();
    }

    /**
     * A method to test that both methods return the same value. The method utilises a loop to iterate through every day in february of 2016 (a leap year). February of a leap year was
     * chosen as it is the month most likely to show any issues in the implementation.
     */
    public void testMethod()
    {
        for(int day = 1; day < 31; day ++)
        {
            String algorithm = zellersAlgorithm(day, 1, 2016);
            String congruence = zellersCongruence(day, 1, 20, 16);
            if(algorithm.equalsIgnoreCase(congruence))
            {
                System.out.println(day + " was a success \t" + algorithm); // '\t' will print a tab (4 spaces) and is used to format the output
            }
            else
            {
                System.out.println(day + " failed.\t\tAlgorithm: " + algorithm + "\t Congruence: " + congruence);
            }
        }
    }

    /**
     * A method to implement the zellersAlgorithm part of the challenge
     * 
     * @param (int) inpDay: the day to be tested, (int) month: the month to be tested, (int) year: the year to be tested
     */
    public String zellersAlgorithm(int inpDay, int month, int year)
    {
        String day;
        int y = year;
        int d = inpDay;

        /**
         * For each day of the months before the inputted date, tally up the amount of days
         */
        for(int i = 1; i < month; i++)
        {
            switch(i)
            {
                case 2:
                    if(year % 4 == 0)
                    {
                        d += 29;
                    }
                    else
                    {
                        d += 28;
                    }
                break;
                case 4: case 6: case 9: case 11:
                    d += 30;
                    break;
                default:
                    d += 31;
                    break;
            }
        }

        int f = (y-1) / 4;
        int b = (y + d + f) % 7;
        
        switch(b)
        {
            case 0:
                day = "Friday";
                break;
            case 1:
                day = "Saturday";
                break;
            case 2:
                day = "Sunday";
                break;
            case 3:
                day = "Monday";
                break;
            case 4:
                day = "Tuesday";
                break;
            case 5:
                day = "Wednesday";
                break;
            case 6:
                day = "Thursday";
                break;
            default:
                day = "Could not calculate day";
                break;
        }
        
        return day;
    }
    
    /**
     * A method to implement the zellersAlgorithm part of the challenge
     * 
     * @param (int) inpDay: the day to be tested, (int) monthInp: the month to be tested, (int) centInp: the century to be tested, (int) yearInp: the year to be tested
     */
    public String zellersCongruence(int dayInp, int monthInp, int centInp, int yearInp)
    {
        String day = null;
        int m, k, c, y = 0;
        double result;
        
        if(monthInp > 0 && monthInp <= 12)
        {
            if(monthInp == 1 || monthInp == 2)
            {
                m = monthInp + 10;
            }
            else
            {
                m = monthInp - 2;
            }
        }
        else
        {
            m = 0;
        }
        
        k = dayInp;
        c = centInp;
        y = yearInp;

        result = (((Math.abs(2.6 * m) - 0.2) + k + y + (y / 4) + (c / 4) - (2 * c)) % 7) + 1;
        switch ((int)result)
        {
            case 1:
                day = "Sunday";
                break;
            case 2:
                day = "Monday";
                break;
            case 3:
                day = "Tuesday";
                break;
            case 4:
                day = "Wednesday";
                break;
            case 5:
                day = "Thursday";
                break;
            case 6:
                day = "Friday";
                break;
            case 7:
                day = "Saturday";
                break;
            default:
                day = "Could not calculate day: " + result;
                break;
        }

        return day;
    }
}
