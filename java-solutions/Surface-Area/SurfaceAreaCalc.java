import java.util.*;

/**
 * A small program to work out the area of a set shapes.
 * Square, Cube, Pyramid, Cylinder
 *
 * @author (Stephen Agius)
 * @version (23/07/2017)
 */
public class SurfaceAreaCalc
{
    // instance variables
    private double area;
    private double height;
    private double width;
    private double sides;
    
    /**
     * Constructor
     */
    public SurfaceAreaCalc()
    {
        //shape();                                                                              // No code is run in this constructor. An Object is created to 
                                                                                                // interact with instead. As you can see it could be set to run
                                                                                                // on creation by removal of the commeting out
    }
    
    /**
     * Asks what shape you wish to work out the area of
     */
    public double shape()
    {
        // Asks for the type of shape to be measured
        Scanner scanner = new Scanner(System.in);                                               //creates a scanner to read input from user 
        System.out.print("Please indicate the type of Shape you req the surface area for!!");
        String input;                                                                           // creates a variable to place the input into
        input = scanner.nextLine();                                                             // Saves the user input to a variable
        switch (input)                                                                          // looks what was entered and then runs the relavent method
        {
            case "square"       :                                                               // This is where the input variable is checked against each case. here it will
                                                                                                // look to see if input variable equals square, if so it will run the code upto
                                                                                                // break else it will move to the next case
            System.out.println("Please input width or Height");
            width = scanner.nextDouble();
            area = width * width;
            break;
            
            
            case "cube"         :
            System.out.println("Please input width or Height of one side");
            width = scanner.nextDouble();
            area = (width * width) * 6;
            break;
            
            
            case "pyramid"      : 
            System.out.println("Please input length of one base edge");
            width = scanner.nextDouble();
            System.out.println("Please input height");
            height = scanner.nextDouble();
            double squared = ((width/2)*(width/2))+(height*height);
            area = (width * width) + .5 * (width * 4)*(Math.sqrt(squared));
            System.out.print(squared);
            break;
            
            
            case "cylinder"     :
            System.out.println("Please input Diameter");
            width = scanner.nextDouble();
            System.out.println("Please enter height");
            height = scanner.nextDouble();
            area = ((width * Math.PI) * height) + ((Math.PI*(width/2)*(width/2)*2));
            break;
            
            
            default             :                                                                   // This is the fall back. If no cases match the input this code will be run
            System.out.println(input +" isnt in my system!!!");  
            break;
        }        
            scanner.close();                                                                        // This closes the scanner that we set up and so it releases the memory or 
                                                                                                    // waiting for input
            return area;                                                                            // this will return the area variable
    }
}