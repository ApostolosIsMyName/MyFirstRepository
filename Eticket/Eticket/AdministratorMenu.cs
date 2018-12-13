using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticket
{
    public class AdministratorMenu
    {
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        public static void InvalidSelection()
        {
            Console.WriteLine("Invalid selection.Press any key to go back.");
            Console.ReadKey();
        }
        public AdministratorMenu(Administrator administrator)
        {
            bool logout = false;
            do
            {
                Console.Clear();
                HidePassword.Logo();
                Console.Write("Select a category: \n 1. Administrator \n 2. Supervisor\n 3. TechSupport \n 4. CSAgent \n 5. New users \n 6. Tickets \n 7. Logout \n");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Select action: \n 1. Show all Administrators \n 2. Find an Administrator \n 3. Update Administrator data \n 4. Delete Administrator \n 5. Exit \n");
                        string selection1 = Console.ReadLine();
                        UserManager user = new UserManager();

                        switch (selection1)
                        {
                            case "1":
                                Console.Clear();
                                List<Administrator> allAdmins = new List<Administrator>();
                                allAdmins = user.GetAllAdministrators();
                                foreach (var item in allAdmins)
                                {
                                    Console.WriteLine($"{item.Name}, {item.Username}, {item.Email}, {item.PhoneNumber}");
                                }
                                PressAnyKey();
                                break;
                            case "2":
                                Console.Clear();
                                Administrator resultAdmin = new Administrator();
                                Console.Write("Search by username (leave blank if you want to continue by searching with Email and Name): ");
                                string searchCriteria = Console.ReadLine();
                                if (searchCriteria != "")
                                {
                                    resultAdmin = user.GetAdministrator(searchCriteria);
                                    if (resultAdmin == null)
                                    {
                                        Console.WriteLine("No user found under this criteria. Press any key to continue");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{resultAdmin.Name}, {resultAdmin.Username}, {resultAdmin.Email}, {resultAdmin.Password}, {resultAdmin.PhoneNumber}");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write("Search by Email and Name. \n Email: ");
                                    string searchEmail = Console.ReadLine();
                                    Console.Clear();

                                    Console.Write($"Search by Email and Name. \n Email: {searchEmail} \n Name: ");
                                    string searchName = Console.ReadLine();
                                    resultAdmin = user.GetAdministrator(searchEmail, searchName);
                                    if (resultAdmin == null)
                                    {
                                        Console.WriteLine("No user found under this criteria. Press any key to continue");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{resultAdmin.Name}, {resultAdmin.Username}, {resultAdmin.Password}, {resultAdmin.Email}, {resultAdmin.PhoneNumber}");
                                    }
                                }
                                PressAnyKey();
                                break;
                            case "3":
                                Console.Clear();
                                Administrator updateAdmin = new Administrator();
                                Console.Write("Provide the Username of the Administrator you want to update: ");
                                string updateUsername = Console.ReadLine();
                                updateAdmin = user.GetAdministrator(updateUsername);
                                if (updateAdmin == null)
                                {
                                    Console.WriteLine("No user found under this criteria. Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"{updateAdmin.Name}, {updateAdmin.Username}, {updateAdmin.Email}, {updateAdmin.PhoneNumber}");
                                    Console.Clear();

                                    Console.Write("Provide the new data to update. \n Name: ");
                                    string updateName = Console.ReadLine();
                                    if (updateName == "")
                                    {
                                        updateName = updateAdmin.Name;
                                    }
                                    Console.Clear();

                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: ");
                                    string updateEmail = Console.ReadLine();
                                    if (updateEmail == "")
                                    {
                                        updateEmail = updateAdmin.Email;
                                    }
                                    Console.Clear();

                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: {updateEmail} \n Phone Number: ");
                                    string updatePhone = Console.ReadLine();
                                    if (updatePhone == "")
                                    {
                                        updatePhone = updateAdmin.PhoneNumber;
                                    }
                                    Console.Clear();
                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: {updateEmail} \n Phone Number: {updatePhone} \n Password (must have exactly 8 characters): ");
                                    string updatePassword = Console.ReadLine();
                                    if (updatePassword == "")
                                    {
                                        updatePassword = updateAdmin.Password;
                                        updateAdmin = user.updateAdministratorInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateAdmin.Username} \n Password- {updateAdmin.Password} \n Name- {updateAdmin.Name} \n Email- {updateAdmin.Email} \n Phone Number- {updateAdmin.PhoneNumber} \n");
                                        PressAnyKey();
                                    }

                                    else if (updatePassword.Length == 8 && updatePassword != updateAdmin.Password)
                                    {

                                        updateAdmin = user.updateAdministratorInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateAdmin.Username} \n Password- {updateAdmin.Password} \n Name- {updateAdmin.Name} \n Email- {updateAdmin.Email} \n Phone Number- {updateAdmin.PhoneNumber} \n");
                                        PressAnyKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Couldn't update user. Check if password satisfies the demanded criteria.");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            case "4":
                                Console.Clear();
                                Console.Write("Provide the username of the Administrator you want to delete: ");
                                string usernameToDelete = Console.ReadLine();
                                Console.Write($"Are you sure you want to delete the Administrator with username: {usernameToDelete}? (Y/N)");
                                string confirmation = Console.ReadLine();
                                if (confirmation == "Y" || confirmation == "y")
                                {
                                    bool deleted = user.DeleteAdministrator(usernameToDelete);
                                    if (deleted)
                                    {
                                        Console.WriteLine("User has been deleted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("User couldn't be deleted.");
                                    }
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            case "5":
                                break;
                            default:
                                InvalidSelection();
                                break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Select action: \n 1. Show all Supervisors \n 2. Find a Supervisor \n 3. Update Supervisor data \n 4. Delete Supervisor \n 5. Exit \n");
                        string selection2 = Console.ReadLine();
                        UserManager user1 = new UserManager();

                        switch (selection2)
                        {
                            case "1":
                                Console.Clear();
                                List<Supervisor> allSupervisors = new List<Supervisor>();
                                allSupervisors = user1.GetAllSupervisors();
                                foreach (var item in allSupervisors)
                                {
                                    Console.WriteLine($"{item.Name}, {item.Username}, {item.Email}, {item.PhoneNumber}");
                                }
                                PressAnyKey();
                                break;
                            case "2":
                                Console.Clear();
                                Supervisor resultSupervisor = new Supervisor();
                                Console.Write("Search by username (leave blank if you want to continue by searching with Email and Name): ");
                                string searchCriteria = Console.ReadLine();
                                if (searchCriteria != "")
                                {
                                    resultSupervisor = user1.GetSupervisor(searchCriteria);
                                    if (resultSupervisor == null)
                                    {
                                        Console.WriteLine("No user found under this criteria. Press any key to continue");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{resultSupervisor.Name}, {resultSupervisor.Username}, {resultSupervisor.Password}, {resultSupervisor.Email}, {resultSupervisor.PhoneNumber}");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write("Search by Email and Name. \n Email: ");
                                    string searchEmail = Console.ReadLine();
                                    Console.Clear();

                                    Console.Write($"Search by Email and Name. \n Email: {searchEmail} \n Name: ");
                                    string searchName = Console.ReadLine();
                                    resultSupervisor = user1.GetSupervisor(searchEmail, searchName);
                                    if (resultSupervisor == null)
                                    {
                                        Console.WriteLine("No user found under this criteria. Press any key to continue");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{resultSupervisor.Name}, {resultSupervisor.Username}, {resultSupervisor.Email}, {resultSupervisor.Password}, {resultSupervisor.PhoneNumber}");
                                    }
                                }
                                PressAnyKey();
                                break;
                            case "3":
                                Console.Clear();
                                Supervisor updateSupervisor = new Supervisor();
                                Console.Write("Provide the Username of the Supervisor you want to update: ");
                                string updateUsername = Console.ReadLine();
                                updateSupervisor = user1.GetSupervisor(updateUsername);
                                if (updateSupervisor == null)
                                {
                                    Console.WriteLine("No user found under this criteria. Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"{updateSupervisor.Name}, {updateSupervisor.Username}, {updateSupervisor.Email}, {updateSupervisor.PhoneNumber}");
                                    Console.Clear();

                                    Console.Write("Provide the new data to update. \n Name: ");
                                    string updateName = Console.ReadLine();
                                    if (updateName == "")
                                    {
                                        updateName = updateSupervisor.Name;
                                    }
                                    Console.Clear();

                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: ");
                                    string updateEmail = Console.ReadLine();
                                    if (updateEmail == "")
                                    {
                                        updateEmail = updateSupervisor.Email;
                                    }
                                    Console.Clear();

                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: {updateEmail} \n Phone Number: ");
                                    string updatePhone = Console.ReadLine();
                                    if (updatePhone == "")
                                    {
                                        updatePhone = updateSupervisor.PhoneNumber;
                                    }
                                    Console.Clear();
                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: {updateEmail} \n Phone Number: {updatePhone} \n Password (must have exactly 8 characters): ");
                                    string updatePassword = Console.ReadLine();
                                    if (updatePassword == "")
                                    {
                                        updatePassword = updateSupervisor.Password;
                                        updateSupervisor = user1.updateSupervisorInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateSupervisor.Username} \n Password- {updateSupervisor.Password} \n Name- {updateSupervisor.Name} \n Email- {updateSupervisor.Email} \n Phone Number- {updateSupervisor.PhoneNumber} \n");
                                        PressAnyKey();
                                    }

                                    else if (updatePassword.Length == 8 && updatePassword != updateSupervisor.Password)
                                    {

                                        updateSupervisor = user1.updateSupervisorInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateSupervisor.Username} \n Password- {updateSupervisor.Password} \n Name- {updateSupervisor.Name} \n Email- {updateSupervisor.Email} \n Phone Number- {updateSupervisor.PhoneNumber} \n");
                                        PressAnyKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Couldn't update user. Check if password satisfies the demanded criteria.");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            case "4":
                                Console.Clear();
                                Console.Write("Provide the username of the Supervisor you want to delete: ");
                                string usernameToDelete = Console.ReadLine();
                                Console.Write($"Are you sure you want to delete the Supervisor with username: {usernameToDelete}? (Y/N)");
                                string confirmation = Console.ReadLine();
                                if (confirmation == "Y" || confirmation == "y")
                                {
                                    bool deleted = user1.DeleteSupervisor(usernameToDelete);
                                    if (deleted)
                                    {
                                        Console.WriteLine("User has been deleted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("User couldn't be deleted.");
                                    }
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            case "5":
                                break;
                            default:
                                InvalidSelection();
                                break;
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Select action: \n 1. Show all TechSupportUsers \n 2. Find a TechSupportUser \n 3. Update TechSupportUser data \n 4. Delete TechSupportUser \n 5. Exit \n");
                        string selection3 = Console.ReadLine();
                        UserManager user2 = new UserManager();

                        switch (selection3)
                        {
                            case "1":
                                Console.Clear();
                                List<TechSupportUser> allTechSupportUsers = new List<TechSupportUser>();
                                allTechSupportUsers = user2.GetAllTechSupportUsers();
                                foreach (var item in allTechSupportUsers)
                                {
                                    Console.WriteLine($"{item.Name}, {item.Username}, {item.Email}, {item.PhoneNumber}");
                                }
                                PressAnyKey();
                                break;
                            case "2":
                                Console.Clear();
                                TechSupportUser resultTechSupportUser = new TechSupportUser();
                                Console.Write("Search by username (leave blank if you want to continue by searching with Email and Name): ");
                                string searchCriteria = Console.ReadLine();
                                if (searchCriteria != "")
                                {
                                    resultTechSupportUser = user2.GetTechSupportUser(searchCriteria);
                                    Console.WriteLine($"{resultTechSupportUser.Name}, {resultTechSupportUser.Username}, {resultTechSupportUser.Password}, {resultTechSupportUser.Email}, {resultTechSupportUser.PhoneNumber}");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write("Search by Email and Name. \n Email: ");
                                    string searchEmail = Console.ReadLine();
                                    Console.Clear();

                                    Console.Write($"Search by Email and Name. \n Email: {searchEmail} \n Name: ");
                                    string searchName = Console.ReadLine();
                                    resultTechSupportUser = user2.GetTechSupportUser(searchEmail, searchName);
                                    Console.WriteLine($"{resultTechSupportUser.Name}, {resultTechSupportUser.Username}, {resultTechSupportUser.Email}, {resultTechSupportUser.Password}, {resultTechSupportUser.PhoneNumber}");
                                }
                                PressAnyKey();
                                break;
                            case "3":
                                Console.Clear();
                                TechSupportUser updateTechSupportUser = new TechSupportUser();
                                Console.Write("Provide the Username of the Technical Support User you want to update: ");
                                string updateUsername = Console.ReadLine();
                                updateTechSupportUser = user2.GetTechSupportUser(updateUsername);
                                if (updateTechSupportUser == null)
                                {
                                    Console.WriteLine("No user found under this criteria. Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"{updateTechSupportUser.Name}, {updateTechSupportUser.Username}, {updateTechSupportUser.Email}, {updateTechSupportUser.PhoneNumber}");
                                    Console.Clear();

                                    Console.Write("Provide the new data to update. \n Name: ");
                                    string updateName = Console.ReadLine();
                                    if (updateName == "")
                                    {
                                        updateName = updateTechSupportUser.Name;
                                    }
                                    Console.Clear();

                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: ");
                                    string updateEmail = Console.ReadLine();
                                    if (updateEmail == "")
                                    {
                                        updateEmail = updateTechSupportUser.Email;
                                    }
                                    Console.Clear();

                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: {updateEmail} \n Phone Number: ");
                                    string updatePhone = Console.ReadLine();
                                    if (updatePhone == "")
                                    {
                                        updatePhone = updateTechSupportUser.PhoneNumber;
                                    }
                                    Console.Clear();
                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: {updateEmail} \n Phone Number: {updatePhone} \n Password (must have exactly 8 characters): ");
                                    string updatePassword = Console.ReadLine();
                                    if (updatePassword == "")
                                    {
                                        updatePassword = updateTechSupportUser.Password;
                                        updateTechSupportUser = user2.updateTechSupportUserInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateTechSupportUser.Username} \n Password- {updateTechSupportUser.Password} \n Name- {updateTechSupportUser.Name} \n Email- {updateTechSupportUser.Email} \n Phone Number- {updateTechSupportUser.PhoneNumber} \n");
                                        PressAnyKey();
                                    }

                                    else if (updatePassword.Length == 8 && updatePassword != updateTechSupportUser.Password)
                                    {

                                        updateTechSupportUser = user2.updateTechSupportUserInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateTechSupportUser.Username} \n Password- {updateTechSupportUser.Password} \n Name- {updateTechSupportUser.Name} \n Email- {updateTechSupportUser.Email} \n Phone Number- {updateTechSupportUser.PhoneNumber} \n");
                                        PressAnyKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Couldn't update user. Check if password satisfies the demanded criteria.");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            case "4":
                                Console.Clear();
                                Console.Write("Provide the username of the Administrator you want to delete: ");
                                string usernameToDelete = Console.ReadLine();
                                Console.Write($"Are you sure you want to delete the Administrator with username: {usernameToDelete}? (Y/N)");
                                string confirmation = Console.ReadLine();
                                if (confirmation == "Y" || confirmation == "y")
                                {
                                    bool deleted = user2.DeleteTechSupportUser(usernameToDelete);
                                    if (deleted)
                                    {
                                        Console.WriteLine("User has been deleted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("User couldn't be deleted.");
                                    }
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            case "5":
                                break;
                            default:
                                InvalidSelection();
                                break;
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Select action: \n 1. Show all CSAgents \n 2. Find a CSAgent \n 3. Update CSAgent data \n 4. Delete CSAgent \n 5. Exit \n");
                        string selection4 = Console.ReadLine();
                        UserManager user3 = new UserManager();

                        switch (selection4)
                        {
                            case "1":
                                Console.Clear();
                                List<CSAgent> allCSAgents = new List<CSAgent>();
                                allCSAgents = user3.GetAllCSAgents();
                                foreach (var item in allCSAgents)
                                {
                                    Console.WriteLine($"{item.Name}, {item.Username}, {item.Email}, {item.PhoneNumber}");
                                }
                                PressAnyKey();
                                break;
                            case "2":
                                Console.Clear();
                                CSAgent resultCSAgent = new CSAgent();
                                Console.Write("Search by username (leave blank if you want to continue by searching with Email and Name): ");
                                string searchCriteria = Console.ReadLine();
                                if (searchCriteria != "")
                                {
                                    resultCSAgent = user3.GetCSAgent(searchCriteria);
                                    if (resultCSAgent == null)
                                    {
                                        Console.WriteLine("No user found under this criteria. Press any key to continue");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{resultCSAgent.Name}, {resultCSAgent.Username}, {resultCSAgent.Email}, {resultCSAgent.Password}, {resultCSAgent.PhoneNumber}");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write("Search by Email and Name. \n Email: ");
                                    string searchEmail = Console.ReadLine();
                                    Console.Clear();

                                    Console.Write($"Search by Email and Name. \n Email: {searchEmail} \n Name: ");
                                    string searchName = Console.ReadLine();
                                    resultCSAgent = user3.GetCSAgent(searchEmail, searchName);
                                    if (resultCSAgent == null)
                                    {
                                        Console.WriteLine("No user found under this criteria. Press any key to continue");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{resultCSAgent.Name}, {resultCSAgent.Username}, {resultCSAgent.Password}, {resultCSAgent.Email}, {resultCSAgent.PhoneNumber}");
                                    }
                                }
                                PressAnyKey();
                                break;
                            case "3":
                                Console.Clear();
                                CSAgent updateCSAgent = new CSAgent();
                                Console.Write("Provide the Username of the Customer Service Agent you want to update: ");
                                string updateUsername = Console.ReadLine();
                                updateCSAgent = user3.GetCSAgent(updateUsername);
                                if (updateCSAgent == null)
                                {
                                    Console.WriteLine("No user found under this criteria. Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"{updateCSAgent.Name}, {updateCSAgent.Username}, {updateCSAgent.Email}, {updateCSAgent.PhoneNumber}");
                                    Console.Clear();

                                    Console.Write("Provide the new data to update. \n Name: ");
                                    string updateName = Console.ReadLine();
                                    if (updateName == "")
                                    {
                                        updateName = updateCSAgent.Name;
                                    }
                                    Console.Clear();

                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: ");
                                    string updateEmail = Console.ReadLine();
                                    if (updateEmail == "")
                                    {
                                        updateEmail = updateCSAgent.Email;
                                    }
                                    Console.Clear();

                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: {updateEmail} \n Phone Number: ");
                                    string updatePhone = Console.ReadLine();
                                    if (updatePhone == "")
                                    {
                                        updatePhone = updateCSAgent.PhoneNumber;
                                    }
                                    Console.Clear();
                                    Console.Write($"Provide the new data to update. \n Name: {updateName} \n Email: {updateEmail} \n Phone Number: {updatePhone} \n Password (must have exactly 8 characters): ");
                                    string updatePassword = Console.ReadLine();
                                    if (updatePassword == "")
                                    {
                                        updatePassword = updateCSAgent.Password;
                                        updateCSAgent = user3.updateCSAgentInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateCSAgent.Username} \n Password- {updateCSAgent.Password} \n Name- {updateCSAgent.Name} \n Email- {updateCSAgent.Email} \n Phone Number- {updateCSAgent.PhoneNumber} \n");
                                        PressAnyKey();
                                    }

                                    else if (updatePassword.Length == 8 && updatePassword != updateCSAgent.Password)
                                    {

                                        updateCSAgent = user3.updateCSAgentInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateCSAgent.Username} \n Password- {updateCSAgent.Password} \n Name- {updateCSAgent.Name} \n Email- {updateCSAgent.Email} \n Phone Number- {updateCSAgent.PhoneNumber} \n");
                                        PressAnyKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Couldn't update user. Check if password satisfies the demanded criteria.");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            case "4":
                                Console.Clear();
                                Console.Write("Provide the username of the CSAgent you want to delete: ");
                                string usernameToDelete = Console.ReadLine();
                                Console.Write($"Are you sure you want to delete the CSAgent with username: {usernameToDelete}? (Y/N)");
                                string confirmation = Console.ReadLine();
                                if (confirmation == "Y" || confirmation == "y")
                                {
                                    bool deleted = user3.DeleteCSAgent(usernameToDelete);
                                    if (deleted)
                                    {
                                        Console.WriteLine("User has been deleted.");
                                        PressAnyKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("User couldn't be deleted.");
                                        PressAnyKey();
                                    }
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            case "5":
                                break;
                            default:
                                InvalidSelection();
                                break;
                        }
                        break;
                    case "5":
                        Console.Clear();
                        Console.Write("Select action: \n 1. Show all New Users \n 2. Register a New User \n 3. Delete a New User \n 4. Exit \n");
                        string selection5 = Console.ReadLine();
                        UserManager user4 = new UserManager();
                        switch (selection5)
                        {
                            case "1":
                                Console.Clear();
                                List<NewUser> allNewUser = new List<NewUser>();
                                allNewUser = user4.GetNewUser();
                                foreach (var item in allNewUser)
                                {
                                    Console.WriteLine($" Requested role: {item.Role} \n Username: {item.Username} \n Password: {item.Password} \n Name: {item.Name} \n Email: {item.Email} \n Phone Number: {item.PhoneNumber} \n");
                                }
                                PressAnyKey();
                                break;
                            case "2":
                                Console.Clear();
                                user4.RegisterUser();
                                PressAnyKey();
                                break;
                            case "3":
                                Console.Clear();
                                Console.Write("Provide the username of the New User you want to delete: ");
                                string usernameToDelete = Console.ReadLine();
                                Console.Write($"Are you sure you want to delete the New User with username: {usernameToDelete}? (Y/N)");
                                string confirmation = Console.ReadLine();
                                if (confirmation == "Y" || confirmation == "y")
                                {
                                    bool deleted = user4.DeleteNewUser(usernameToDelete);
                                    if (deleted)
                                    {
                                        Console.WriteLine("User has been deleted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("User couldn't be deleted.");
                                    }
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            case "4":
                                break;
                            default:
                                InvalidSelection();
                                break;
                        }
                        break;
                    case "6":
                        Console.Clear();
                        Console.Write("Select a function: \n 1. Search Tickets \n 2. Update Ticket \n 3. Delete Ticket \n 4. Go Back \n ");
                        string selection6 = Console.ReadLine();
                        switch (selection6)
                        {
                            
                            case "1":
                                Console.Clear();
                                Console.Write("Select a function: \n 1. Search all Tickets \n 2. Search only Open Tickets \n 3.Go Back \n");
                                string selection7=Console.ReadLine();
                                switch (selection7)
                                {
                                    case "1":

                                        Console.Clear();
                                        Console.Write("Search by: 1. Customer Name, 2. Customer Email, 3. Go Back \n");
                                        string selection8 = Console.ReadLine();
                                        CustTicketForm resultForm = new CustTicketForm();
                                        List<CustTicket> resultTickets = new List<CustTicket>();
                                        CustTicketManager resultManager = new CustTicketManager();
                                        switch (selection8)
                                        {
                                            case "1":
                                                Console.Write("What is the Customer's Name? \n");
                                                string customerName = Console.ReadLine();
                                                resultManager.SearchAllTicketsByName(customerName);
                                                PressAnyKey();
                                                break;
                                            case "2":
                                                Console.Write("What is the Customer's Email? \n");
                                                string customerEmail = Console.ReadLine();
                                                resultManager.SearchAllTicketsByEmail(customerEmail);
                                                PressAnyKey();
                                                break;

                                            case "3":
                                                break;
                                            default:
                                                InvalidSelection();
                                                break;
                                        }
                                        break;
                                    case "2":
                                        Console.Clear();
                                        Console.Write("Search by: 1. Customer Name, 2. Customer Email, 3. Go Back \n");
                                        string selection9 = Console.ReadLine();
                                        CustTicketForm resultForm2 = new CustTicketForm();
                                        List<CustTicket> resultTickets2 = new List<CustTicket>();
                                        CustTicketManager resultManager2 = new CustTicketManager();
                                        switch (selection9)
                                        {
                                            case "1":
                                                Console.Write("What is the Customer's Name? \n");
                                                string customerName = Console.ReadLine();
                                                resultManager2.FindOpenTicketsByName(customerName);
                                                PressAnyKey();
                                                break;
                                            case "2":
                                                Console.Write("What is the Customer's Email? \n");
                                                string customerEmail = Console.ReadLine();
                                                resultManager2.FindOpenTicketsByEmail(customerEmail);
                                                PressAnyKey();
                                                break;

                                            case "3":
                                                break;
                                            default:
                                                InvalidSelection();
                                                break;
                                        }
                                        break;

                                    case "3":
                                        break;
                                    default:
                                        InvalidSelection();
                                        break;
                                }
                                break;
                            case "2":
                                
                                Console.Clear();
                                Console.Write("What is the TicketID of the Customer Ticket you want to update: ");
                                if (int.TryParse(Console.ReadLine(), out int ticketID))
                                {
                                    CustTicketManager updateManager = new CustTicketManager();
                                    updateManager.UpdateTicket(ticketID);
                                }
                                else
                                {
                                    Console.Write("Invalid TicketID, all ticket IDs are numerals.");
                                }
                                PressAnyKey();
                                break;
                            case "3":
                                Console.Clear();
                                Console.Write("What is the TicketID of the Customer Ticket you want to delete: ");
                                if (int.TryParse(Console.ReadLine(), out int deleteTicketID))
                                {
                                    CustTicketManager deleteManager = new CustTicketManager();
                                    deleteManager.DeleteTicket(deleteTicketID);
                                }
                                else
                                {
                                    Console.Write("Invalid TicketID, all ticket IDs are numerals.");
                                }
                                PressAnyKey();
                                break;
                            case "4":
                                break;
                            default:
                                InvalidSelection();
                                break;
                        }

                        break;

                    case "7":
                        logout = true;
                        break;
                    default:
                        Console.WriteLine("You have made an invalid choice. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            } while (!logout);
        }
    }
}
