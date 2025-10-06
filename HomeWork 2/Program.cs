using static System.Console;
//Marcos Adrian Feliz 2025-0934

class program
{
    static void Main ()
    {
        bool success = false;
       
            WriteLine("Type an int number and I will tell you if is even or odd");
        do 
        {    
            try
            {

                int num = int.Parse(ReadLine());
                WriteLine((num % 2 == 0) ? "The number is even " : "The number is odd");
                success = true;
            }
       
            catch (OverflowException)
            {
                WriteLine("The number inserted is way too big, insert a smaller number");
                success = false;
            }
            catch (FormatException){
                WriteLine("You have inserted something that is not a number, please insert an int number");
                success= false;
            }
            catch (Exception ex)
            { 
                WriteLine("An unexpected error has occurred" + ex.Message);
            }
        } while (!success);
    }
}
