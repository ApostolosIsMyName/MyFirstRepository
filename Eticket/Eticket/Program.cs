using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* A program that represents a ticketing service app in a customer service department. It has 4 kinds of users: 
 -Tickets are messages submitted by 4th level users containing information about the customer and a description of his problem. They are 
 submited by a receiver (4th level users) and processed by a handler (3rd level users). After submitted they can be updated, marked as closed
 (for closed cases) and deleted if necessary (only by a 1st level user). After a ticket is created or updated it is also recorder in a text 
 file (default file is: CustTicketsArchive.txt)
 -4th level role is CSAgent (customer service agent) with responsibilities of creating and updating tickets, as he is the one in direct contact
 with the customer (the CSAgent is automatically registered as the receiver of any tickets he submits). He also has the abilities to search
 the ticket database and update existing tickets. He can also immediately get a list of every ticket that he has been registered as a receiver.

 -3rd level role is Technical Support User with responsibilities of getting submitted tickets and doing the necessary procedures to solve the 
 customers' problems. He has the ability to get an unassigned ticket, which automatically brings him a ticket and assigns it to him. He also
 has the ability to search for and update tickets and he can immediately get a list of all the tickets assigned to him. 
 
 - 2nd level role is SUpervisor with responsibilities of updating 3rd and 4th level users' data, updating ticket data and assigning tickets to
 3rd and 4th level users. He has the abilities to read and search 3rd and 4th level users and tickets submitted.
 
 -1st level role is Administrator with responsibilities of creating, updating and deleting users of all levels and updating and deleting tickets.*/
namespace Eticket
{
    class Program
    {
        static void Showmenu()
        {
            HidePassword.Logo();

            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Exit");
        }
        // UserLogin
        #region
        static void LoginMenu()
        {
            
            Console.Clear();
            HidePassword.Logo();

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = HidePassword.HideString();
            Console.WriteLine();
            Console.WriteLine("Login as: 1. Customer Service Agent, 2. Tech Support User, 3. Supervisor, 4. Administrator");
            string selection = Console.ReadLine();

            UserManager userLogin = new UserManager();
            switch (selection)
            {

                case "1":

                    CSAgent user = new CSAgent();
                    bool userLogged = false;
                    using (var db = new EticketContext())
                    {
                        user = userLogin.GetCSAgent(username);
                        if (user != null && user.Password == password)
                        {
                            userLogged = true;
                        }
                        else if (user != null)
                        {
                            Console.WriteLine("Wrong Password, try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Username not found, try again.");
                            Console.ReadKey();
                        }
                    }
                    if (userLogged)
                    {
                        CSAgentMenu agentMenu = new CSAgentMenu(user);
                    }
                    break;
                case "2":
                    TechSupportUser techSupportUser = new TechSupportUser();
                    bool techSupportUserLogged = false;
                    using (var db = new EticketContext())
                    {
                        techSupportUser = userLogin.GetTechSupportUser(username);
                        if (techSupportUser != null && techSupportUser.Password == password)
                        {
                            techSupportUserLogged = true;
                        }
                        else if (techSupportUser != null)
                        {
                            Console.WriteLine("Wrong Password, try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Username not found, try again.");
                            Console.ReadKey();
                        }
                    }
                    if (techSupportUserLogged)
                    {
                        TechSupportUserMenu TechSupportMenu = new TechSupportUserMenu(techSupportUser);
                    }
                    break;
                case "3":
                    Supervisor supervisor = new Supervisor();
                    bool supervisorLogged = false;

                    using (var db = new EticketContext())
                    {
                        supervisor = userLogin.GetSupervisor(username);
                        if (supervisor != null && supervisor.Password == password)
                        {
                            supervisorLogged = true;
                        }
                        else if (supervisor != null)
                        {
                            Console.WriteLine("Wrong Password, try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Username not found, try again");
                            Console.ReadKey();
                        }
                    }
                    if (supervisorLogged)
                    {
                        SupervisorMenu SupervisorMenu = new SupervisorMenu(supervisor);
                    }
                    break;
                case "4":
                    Administrator admin = new Administrator();
                    bool adminLogged = false;

                    using (var db = new EticketContext())
                    {
                        admin = userLogin.GetAdministrator(username);
                        if (admin != null && admin.Password == password)
                        {
                            adminLogged = true;
                        }
                        else if (admin != null)
                        {
                            Console.WriteLine("Wrong Password, try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Username not found, try again");
                            Console.ReadKey();
                        }
                    }
                    if (adminLogged)
                    {
                        AdministratorMenu AdminMenu = new AdministratorMenu(admin);
                    }
                    break;
            }
        }
        #endregion

        //UserRegistration
        #region
        static void RegisterMenu()
        {
            HidePassword.Logo();

            NewUser newUser = new NewUser();
            string name;
            do 
            {
                Console.Clear();
                Console.Write("Name (Must have at least 3 characters): ");
                name = Console.ReadLine();
                if (name.Length < 3)
                {
                    Console.WriteLine("Name must have at least 3 characters, press any key to try again.");
                    Console.ReadKey();
                }
            } while (name.Length < 3) ;
            string email;
            do 
            {
                Console.Clear();
                Console.WriteLine($"Name: {name}");
                Console.Write("Email (Must have at least 3 characters): ");
                email = Console.ReadLine();
                if(email.Length < 3)
                {
                    Console.WriteLine("Email must have at least 3 characters, press any key to try again.");
                    Console.ReadKey();

                }
            } while (email.Length < 3) ;
            Console.Clear();
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Email: {email}");
            Console.Write("Phone number: ");
            string phone = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Phone number: {phone}");
            Console.Write("Specify your role (Administrator, Supervisor, TechSupport User, Customer Service Agent): ");
            string role = Console.ReadLine();
            
            string username;
            bool usernameExists;
            do
            {
                Console.Clear();
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone number: {phone}");
                Console.WriteLine($"Specify your role (Administrator, Supervisor, TechSupport User, Customer Service Agent): {role} ");
                Console.Write("Username (Must have at least 5 characters): ");
                username = Console.ReadLine();
                if (username.Length < 5)
                {
                    usernameExists = true;
                    Console.WriteLine("Username must have at least 5 characters, press any key to try again.");
                    Console.ReadKey();
                }
                else
                {
                    using (var db = new EticketContext())
                    {
                        if (db.Administrators.Any(x => x.Username == username) || db.CSAgents.Any(x => x.Username == username) || db.Supervisors.Any(x => x.Username == username) || db.TechSupportUsers.Any(x => x.Username == username) || db.NewUsers.Any(x => x.Username == username))
                        {
                            usernameExists = true;
                        }
                        else
                        {
                            usernameExists = false;
                        }
                    }
                    if (usernameExists)
                    {
                        Console.WriteLine("The username you gave is already being used, please provide another. Press any key to continue.");
                        Console.ReadKey();
                    }
                }
            } while (username.Length < 5 || usernameExists);
            
            string password1;
            do
            {
                Console.Clear();
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone number: {phone}");
                Console.WriteLine($"Specify your role (Administrator, Supervisor, TechSupport User, Customer Service Agent): {role} ");
                Console.WriteLine($"Username: {username}");
                Console.Write("Password (Must have exactly 8 characters): ");
                password1 = Console.ReadLine();
                if (password1.Length != 8)
                {
                    Console.WriteLine("Password must have exactly 8 characters, press any key to try again.");
                    Console.ReadKey();
                }
            } while (password1.Length != 8);
            string password2;
            do
            {
                Console.Clear();
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone number: {phone}");
                Console.WriteLine($"Specify your role (Administrator, Supervisor, TechSupport User, Customer Service Agent): {role} ");
                Console.WriteLine($"Username: {username}");
                Console.WriteLine($"Password: {password1}");
                Console.Write("Confirm Password: ");
                password2 = Console.ReadLine();
                if(password1!=password2)
                {
                    Console.WriteLine("The passwords did not match, press any key to try again.");
                    Console.ReadKey();
                }
            } while (password1 != password2);

                if (password1 == password2)
                {
                    newUser.Name = name;
                    newUser.Email = email;
                    newUser.PhoneNumber = phone;
                    newUser.Role = role;
                    newUser.Username = username;
                    newUser.Password = password1;
                    using (var db = new EticketContext())
                    {
                        db.NewUsers.Add(newUser);
                        db.SaveChanges();
                    }
                    Console.WriteLine("A message has been sent to your supervisor. You will be notified when your account is active.");
                }
               
            Console.ReadKey();

        }
        #endregion
        static void Main(string[] args)
        {
            while (true)
            {
                
               
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Title = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ E-Ticket ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

                Showmenu();
                var selection = Console.ReadLine();
                switch (selection)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        RegisterMenu();
                        break;
                    default:
                        Console.WriteLine("You have made an invalid selection. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
