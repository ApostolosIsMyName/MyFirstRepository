using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticket
{
    public class SupervisorMenu
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
        public SupervisorMenu(Supervisor supervisor)
        {
            bool logout = false;
            do
            {
                Console.Clear();
                HidePassword.Logo();

                Console.Write("Select an action: \n 1. See Customer Service Agents menu \n 2. See Tech Support Users menu \n 3. See Customer Tickets menu \n 4. Logout \n");
                string selection = Console.ReadLine();
                UserManager user = new UserManager();

                switch (selection)
                {
                    case "1":
                        Console.Clear();

                        Console.Write("Select an action: \n 1. See all Customer Service Agents \n 2. Find a Customer Service Agent \n 3. Update Customer Service Agent info \n 4. Go Back \n");
                        string selection1 = Console.ReadLine();
                        switch(selection1)
                        {
                            case "1":
                                Console.Clear();
                                List<CSAgent> allCSAgents = new List<CSAgent>();
                                allCSAgents = user.GetAllCSAgents();
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
                                    resultCSAgent = user.GetCSAgent(searchCriteria);
                                    Console.WriteLine($"{resultCSAgent.Name}, {resultCSAgent.Username}, {resultCSAgent.Email}, {resultCSAgent.Password}, {resultCSAgent.PhoneNumber}");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write("Search by Email and Name. \n Email: ");
                                    string searchEmail = Console.ReadLine();
                                    Console.Clear();

                                    Console.Write($"Search by Email and Name. \n Email: {searchEmail} \n Name: ");
                                    string searchName = Console.ReadLine();
                                    resultCSAgent = user.GetCSAgent(searchEmail, searchName);
                                    Console.WriteLine($"{resultCSAgent.Name}, {resultCSAgent.Username}, {resultCSAgent.Password}, {resultCSAgent.Email}, {resultCSAgent.PhoneNumber}");
                                }
                                PressAnyKey();
                                break;
                            case "3":
                                Console.Clear();
                                CSAgent updateCSAgent = new CSAgent();
                                Console.Write("Provide the Username of the Customer Service Agent you want to update: ");
                                string updateUsername = Console.ReadLine();
                                updateCSAgent = user.GetCSAgent(updateUsername);
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
                                        updateCSAgent = user.updateCSAgentInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateCSAgent.Username} \n Password- {updateCSAgent.Password} \n Name- {updateCSAgent.Name} \n Email- {updateCSAgent.Email} \n Phone Number- {updateCSAgent.PhoneNumber} \n");
                                        Console.WriteLine("Press any key to return");
                                        Console.ReadKey();
                                    }

                                    else if (updatePassword.Length == 8 && updatePassword != updateCSAgent.Password)
                                    {

                                        updateCSAgent = user.updateCSAgentInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateCSAgent.Username} \n Password- {updateCSAgent.Password} \n Name- {updateCSAgent.Name} \n Email- {updateCSAgent.Email} \n Phone Number- {updateCSAgent.PhoneNumber} \n");
                                        Console.WriteLine("Press any key to return");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Couldn't update user. Check if password satisfies the demanded criteria.");
                                        Console.ReadKey();
                                    }
                                }
                                break;
                            case "4":
                                break;
                            default:
                                InvalidSelection();
                                break;


                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Select an action: \n 1. See all Tech Support Users \n 2. Find a Tech Support User \n 3. Update Tech Support User info \n 4. Go Back \n");
                        string selection2 = Console.ReadLine();
                        switch (selection2)
                        {
                            case "1":
                                Console.Clear();
                                List<TechSupportUser> allTechSupportUsers = new List<TechSupportUser>();
                                allTechSupportUsers = user.GetAllTechSupportUsers();
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
                                    resultTechSupportUser = user.GetTechSupportUser(searchCriteria);
                                    Console.WriteLine($"{resultTechSupportUser.Name}, {resultTechSupportUser.Username}, {resultTechSupportUser.Email}, {resultTechSupportUser.Password}, {resultTechSupportUser.PhoneNumber}");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write("Search by Email and Name. \n Email: ");
                                    string searchEmail = Console.ReadLine();
                                    Console.Clear();

                                    Console.Write($"Search by Email and Name. \n Email: {searchEmail} \n Name: ");
                                    string searchName = Console.ReadLine();
                                    resultTechSupportUser = user.GetTechSupportUser(searchEmail, searchName);
                                    Console.WriteLine($"{resultTechSupportUser.Name}, {resultTechSupportUser.Username}, {resultTechSupportUser.Password}, {resultTechSupportUser.Email}, {resultTechSupportUser.PhoneNumber}");
                                }
                                PressAnyKey();
                                break;
                            case "3":
                                Console.Clear();
                                TechSupportUser updateTechSupportUser = new TechSupportUser();
                                Console.Write("Provide the Username of the Technical Support User you want to update: ");
                                string updateUsername = Console.ReadLine();
                                updateTechSupportUser = user.GetTechSupportUser(updateUsername);
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
                                        updateTechSupportUser = user.updateTechSupportUserInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
                                        Console.Write($"Updated user, with new data: Username- {updateTechSupportUser.Username} \n Password- {updateTechSupportUser.Password} \n Name- {updateTechSupportUser.Name} \n Email- {updateTechSupportUser.Email} \n Phone Number- {updateTechSupportUser.PhoneNumber} \n");
                                        PressAnyKey();
                                    }

                                    else if (updatePassword.Length == 8 && updatePassword != updateTechSupportUser.Password)
                                    {

                                        updateTechSupportUser = user.updateTechSupportUserInfo(updateUsername, updatePassword, updateName, updatePhone, updateEmail);
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
                                break;
                            default:
                                InvalidSelection();
                                break;


                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Select a function: \n 1. Search for a Customer Ticket \n 2. Update Customer Ticket \n 3. Assign Ticket to User \n 4. Go Back \n");
                        string selection3 = Console.ReadLine();
                        switch (selection3)
                        {
                            

                            case "1":
                                Console.Clear();
                                Console.Write("Select a function: \n 1. Search all Tickets \n 2. Search only Open Tickets \n 3. Get a list of all Tickets \n 4.Go Back \n");
                                string selection4 = Console.ReadLine();
                                CustTicketForm resultForm = new CustTicketForm();
                                List<CustTicket> resultTickets = new List<CustTicket>();
                                CustTicketManager resultManager = new CustTicketManager();
                                switch (selection4)
                                {
                                    case "1":

                                        Console.Clear();
                                        Console.Write("Search by: 1. Customer Name, 2. Customer Email, 3. Go Back \n");
                                        string selection5 = Console.ReadLine();
                                        
                                        switch (selection5)
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
                                        string selection6 = Console.ReadLine();
                                        
                                        switch (selection6)
                                        {
                                            case "1":
                                                Console.Write("What is the Customer's Name? \n");
                                                string customerName = Console.ReadLine();
                                                resultManager.FindOpenTicketsByName(customerName);
                                                PressAnyKey();
                                                break;
                                            case "2":
                                                Console.Write("What is the Customer's Email? \n");
                                                string customerEmail = Console.ReadLine();
                                                resultManager.FindOpenTicketsByEmail(customerEmail);
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
                                        resultManager.ListAllTickets();
                                        PressAnyKey();
                                        break;
                                    case "4":
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
                                Console.Write("What is the TicketID of the Customer Ticket you want to assign handler and/or receiver: ");
                                if (int.TryParse(Console.ReadLine(), out int ticketID1))
                                {
                                    CustTicketManager updateManager = new CustTicketManager();
                                    updateManager.assignUsersToTicket(ticketID1);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid TicketID, all ticket IDs are numerals.");
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
                    
                    case "4":
                        logout = true;
                        break;
                    default:
                        InvalidSelection();
                        break;

                }
            } while (!logout);
        }
    }
}
