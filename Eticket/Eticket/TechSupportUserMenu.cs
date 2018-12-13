﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticket
{
    public class TechSupportUserMenu
    {
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        public static void InvalidSelection()
        {
            Console.WriteLine("Invalid selection.Press any key to Go Back.");
            Console.ReadKey();
        }
        public TechSupportUserMenu(TechSupportUser user)
        {
            bool logout = false;
            do
            {
                Console.Clear();
                HidePassword.Logo();

                Console.Write("Select a function: \n 1. Get new Customer Ticket \n 2. Search for a Customer Ticket \n 3. Update Customer Ticket \n 4. See all your tickets \n 5. Logout \n");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        CustTicketManager getTicket = new CustTicketManager();
                        CustTicketForm form = new CustTicketForm();
                        CustTicket ticket = new CustTicket();
                        using (var db = new EticketContext())
                        {
                            ticket = db.CustTickets.FirstOrDefault(x => x.TechSupport == null && x.Closed == false);
                        }
                        CustTicket updatedTicket = form.CustTicketFormUpdate(ticket);
                        using (var db = new EticketContext())
                        {
                            ticket = db.CustTickets.SingleOrDefault(s => s.TicketID == ticket.TicketID);
                            ticket.CustomerName = updatedTicket.CustomerName;
                            ticket.CustomerEmail = updatedTicket.CustomerEmail;
                            ticket.CustomerPhone = updatedTicket.CustomerPhone;
                            ticket.Description = updatedTicket.Description;
                            ticket.TechSupport = user.Username;
                            db.SaveChanges();
                        }

                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Select a function: \n 1. Search all Tickets \n 2. Search only Open Tickets \n 3.Go Back \n");
                        string selection1 = Console.ReadLine();
                        switch (selection1)
                        {
                            case "1":

                                Console.Clear();
                                Console.Write("Search by: 1. Customer Name, 2. Customer Email, 3. Go Back \n");
                                string selection2 = Console.ReadLine();
                                CustTicketForm resultForm = new CustTicketForm();
                                List<CustTicket> resultTickets = new List<CustTicket>();
                                CustTicketManager resultManager = new CustTicketManager();
                                switch (selection1)
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
                                string selection3 = Console.ReadLine();
                                CustTicketForm resultForm2 = new CustTicketForm();
                                List<CustTicket> resultTickets2 = new List<CustTicket>();
                                CustTicketManager resultManager2 = new CustTicketManager();
                                switch (selection1)
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

                    case "3":
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



                    case "4":
                        CustTicketForm form1 = new CustTicketForm();
                        List<CustTicket> myTickets = new List<CustTicket>();
                        using (var db = new EticketContext())
                        {
                            myTickets = db.CustTickets.Where(x => x.TechSupport == user.Username && x.Closed == false).ToList();
                        }
                        foreach (var item in myTickets)
                        {
                            form1.CustTicketFormFilled(item);
                        }
                        Console.ReadKey();
                        break;
                    case "5":
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
