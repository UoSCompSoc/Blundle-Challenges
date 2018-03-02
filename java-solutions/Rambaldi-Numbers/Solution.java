
/**
 * A class to provide a solution to the Rambaldi-Numbers problem
 * 
 * @author Computing Society
 */
import java.util.ArrayList;
public class Solution
{
    /**
     * Fields used by the program
     */
    private ArrayList<Integer> factors;
    private ArrayList<Integer> oddFactors;
    private ArrayList<Integer> evenFactors;

    /**
     * Constructor for objects of class Solution
     */
    public Solution()
    {
        factors = new ArrayList<Integer>();
        evenFactors = new ArrayList<Integer>();
        oddFactors = new ArrayList<Integer>();
        testMethod();
    }

    /**
     * Returns the value in factors
     * @return ArrayList<Integer>: factors
     */
    public ArrayList<Integer> getFactors()
    {
        return factors;
    }

    /**
     * Returns the value in oddFctors
     * @return ArrayList<Integer>: oddFactors
     */
    public ArrayList<Integer> getOddFactors()
    {
        return oddFactors;
    }

    /**
     * Returns the value in evenFactors
     * @return ArrayList<Integer>: evenFactors
     */
    public ArrayList<Integer> getEvenFactors()
    {
        return evenFactors;
    }

    /**
     * Set the value of factors
     * @param ArrayList<Integer>: newFactors
     */
    public void setFactors(ArrayList<Integer> newFactors)
    {
        factors = newFactors;
    }

    /**
     * Set the value of oddFactors
     * @param ArrayList<Integer>: newOddFactors
     */
    public void setOddFactors(ArrayList<Integer> newOddFactors)
    {
        oddFactors = newOddFactors;
    }

    /**
     * Set the value of evenFactors
     * @param ArrayList<Integer>: newEvenFactors
     */
    public void setEvenFactors(ArrayList<Integer> newEvenFactors)
    {
        evenFactors = newEvenFactors;
    }
    
    /**
     * Tests the 3 examples of Rambaldi numbers given in the problem
     */
    public void testMethod()
    {
        System.out.println("72: " + isRambaldi(72));
        System.out.println("08: " + isRambaldi(8));
        System.out.println("32: " + isRambaldi(32));
    }
    
    /**
     * A method which will call the methods to calculate factors then use this information
     * to check the 3 criteria of a Rambaldi number
     * @return isFactorCountEven & isOddFactorCountOdd & isHalfOfFactorsEven
     */
    public boolean isRambaldi(int numToTest)
    {
        factors.clear();
        evenFactors.clear();
        oddFactors.clear();
        
        findFactors(numToTest);
        oddAndEvenFactors(numToTest);

        boolean isFactorCountEven = (factors.size() % 2 == 0);
        boolean isOddFactorCountOdd = (oddFactors.size() % 2 != 0);
        boolean isHalfOfFactorsEven = (factors.size() / 2.0 >= oddFactors.size());

        return isFactorCountEven & isOddFactorCountOdd & isHalfOfFactorsEven;
    }

    /**
     * Find all the factors of a given number. Once a factor has been found, store it in the factors arrayList
     * @param (int): num 
     */
    public void findFactors(int num)
    {
        for(int i = 1; i <= num; i++)
        {
            if(num % i == 0)
            {
                factors.add(i);
            }
        }
    }

    /**
     * Go through each factor in the factors arrayList and determine whether it is
     * odd or even before adding it to the corresponding arrayList
     * @param (int): num
     */   
    public void oddAndEvenFactors(int num)
    {
        for(Integer factor : factors)
        {
            if(factor % 2 == 0)
            {
                evenFactors.add(factor);
            }
            else
            {
                oddFactors.add(factor);
            }
        }
    }
}
