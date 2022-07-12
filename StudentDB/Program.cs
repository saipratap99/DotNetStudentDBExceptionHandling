using StudentDB;
using CustomExceptions;

FileOperations fo = new FileOperations();
string path = "C:/Users/VC/source/repos/StudentDB/StudentDB/students.txt";

while (true)
{

    Console.WriteLine("\n*****************************************");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Print Student Details");
    Console.WriteLine("3. Exit");
    Console.Write("Enter option: ");

    int option = 0;

    try
    {
        option = ReadInt();
    }catch(FormatException ex)
    { 
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
    }


    switch (option)
    {

        case 1:
            try
            {
                Student student = createStudent();
                fo.AppendToFile(path, student.ToString());
            }
            catch(InvalidMarksException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                var innerException = ex.InnerException;
                while(innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    Console.WriteLine(innerException.StackTrace);
                    innerException = innerException.InnerException; 
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            break;
        case 2:
            fo.ReadFromFile(path);
            break;
        case 3:
            Console.WriteLine("Bye");
            break;
        default:
            Console.WriteLine("Enter valid option");
            break;
    }

    if (option == 3)
        break;

}


int ReadInt()
{
    return Convert.ToInt32(Console.ReadLine());
}

Student createStudent()
{
    Student student = new Student();
    Console.Write("Enter student id: ");
    student.Id = ReadInt();
    Console.Write("Enter student Name: ");
    student.Name = Console.ReadLine();
    Console.Write("Enter student Marks: ");
    student.Marks = parseToDoubleArray(Console.ReadLine());
    return student;
}

double[] parseToDoubleArray(string input)
{
    string[] arr = input.Split(" ");
    
    double[] res = new double[arr.Length];
    
    for(int i = 0; i < arr.Length; i++){
        try
        {
            res[i] = Convert.ToDouble(arr[i]);
        }
        catch(FormatException ex)
        {
            throw new InvalidMarksException("Invalid marks", ex);
        }
    }

    return res;
} 
