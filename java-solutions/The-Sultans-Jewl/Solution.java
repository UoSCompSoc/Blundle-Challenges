
/**
 * A class which solves the Sultans Jewl challenge
 * 
 * @author Computing Society
 */
public class Solution
{
    /**
     * Create a new Solution object which will print the output of the sultansJewl method
     */
    public Solution()
    {
        System.out.println(sultansJewl(5.0, 1.25, 10 * 100));
    }

    /**
     * Diameter of largest box = 2.5 * amount of boxes + stone diameter
     * 2.5 not 1.25 as there is 1.25cm of thickness on each side of the box. 
     * Make the maths easier by halving everything (using the numbers given)
     *      2.5 + 1.25 * amount of boxes = 500
     * rearrange to give
     *      (((boxCollectionDiameterInCM / 2) - (stoneDiameter / 2)) / boxThickness)
     * 
     * @param (double) stoneDiameter, (double) boxThickness, (double) boxCollectionDiameterInCM
     * Parameters are passed as doubles as they may be decimal numbers
     * Answer is cast to a int as the jewl can't be surrounded by parts of a box
     */
    public int sultansJewl(double stoneDiameter, double boxThickness, double boxCollectionDiameterInCM)
    {
        return (int)(((boxCollectionDiameterInCM / 2) - (stoneDiameter / 2)) / boxThickness);
    }

}
