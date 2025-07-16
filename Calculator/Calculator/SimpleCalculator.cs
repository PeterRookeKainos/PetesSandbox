namespace Calculator;

public static class SimpleCalculator
{
    // create a static method called Calculate that takes two integers and a char as parameters
    // the method should return an integer
    // the char can be '+', '-', '*', or '/'
    public static int Calculate(int a, int b, char operation)
    {
        try
        {
            if (operation != '+' && operation != '-' && operation != '*' && operation != '/')
            {
                throw new InvalidOperationException("Invalid operation. Use '+', '-', '*', or '/'.");
            }
            if (operation == '/' && b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            //check for operation is not null or empty
            if (operation == '\0')
            {
                throw new ArgumentNullException("operation", "Operation cannot be null or empty.");
            }
            
            return operation switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => a / b,
                _ => throw new InvalidOperationException("Invalid operation.")
            };
        } catch(DivideByZeroException e) {
            Console.WriteLine(e.Message);
            return 0; // Return 0 or handle as needed
        } catch (InvalidOperationException e) {
            Console.WriteLine(e.Message);
            return 0; // Return 0 or handle as needed
        }
        catch (Exception e)
        {
            Console.WriteLine($"An unexpected error occurred: {e.Message}");
            return 0; // Return 0 or handle as needed
        }
    }
}

