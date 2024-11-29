using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Session
{
    public void WrongPassUser(string passUser)
    {
        // Example: Log the failed password attempt
        Console.WriteLine($"Incorrect password attempt for user: {passUser}");

        // You could implement more logic here, such as logging attempts to a file or a database
        // You might also want to track the number of failed attempts and trigger some action if it's too many
    }
}
    namespace Infocare_Project
    {
            public static class Session
            {
                public static User LoggedInUser { get; set; }
            }

    

}


