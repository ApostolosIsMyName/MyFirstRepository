using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticket
{
    public class CustTicketForm
    {
        public void ColourInput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public CustTicket CustTicketFormEmpty(string username)
        {

            CustTicket Ticket = new CustTicket();
            Console.Clear();
            Console.Write(" Customer Name: ");
            string name = Console.ReadLine();
            Console.Clear();

            Console.Write($" Customer Name: ");
            ColourInput(name);
            Console.Write("\n Customer Email: ");
            string email = Console.ReadLine();
            Console.Clear();

            Console.Write($" Customer Name: ");
            ColourInput(name);
            Console.Write("\n Customer Email: ");
            ColourInput(email);
            Console.Write("\n Customer Phone: ");
            string phone = Console.ReadLine();
            Console.Clear();

            Console.Write($" Customer Name: ");
            ColourInput(name);
            Console.Write("\n Customer Email: ");
            ColourInput(email);
            Console.Write("\n Customer Phone: ");
            ColourInput(phone);
            Console.WriteLine("\n Description: ");
            string description = Console.ReadLine();

            Console.Clear();

            Console.Write($" Customer Name: ");
            ColourInput(name);
            Console.Write("\n Customer Email: ");
            ColourInput(email);
            Console.Write("\n Customer Phone: ");
            ColourInput(phone);
            Console.WriteLine("\n Description: ");
            ColourInput(description);


            Console.WriteLine("\nSubmit ticket? (Y/N) ");
            string selection = Console.ReadLine();
            if (selection != "N" && selection != "n")
            {
                Ticket.CustomerName = name;
                Ticket.CustomerEmail = email;
                Ticket.CustomerPhone = phone;
                Ticket.Description = description;
                Ticket.Date = DateTime.Now;
                Ticket.Closed = false;
                Ticket.CSAgent = username;
                return Ticket;
            }
            else
            {
                Ticket.CustomerName = name;
                Ticket.CustomerEmail = email;
                Ticket.CustomerPhone = phone;
                Ticket.Description = ($" INVALID TICKET \n {description}");
                Ticket.Date = DateTime.Now;
                Ticket.Closed = true;
                Ticket.CSAgent = username;
                return Ticket;
            }

        }
        public void CustTicketFormFilled(CustTicket ticket)
        {
            string status = ticket.Closed ? "Closed" : "Active";

            Console.Write(" Customer Name: ");
            ColourInput(ticket.CustomerName);
            Console.Write("\n Customer Email: ");
            ColourInput(ticket.CustomerEmail);
            Console.Write("\n Customer Phone:");
            ColourInput(ticket.CustomerPhone);
            Console.WriteLine("\n Description: ");
            ColourInput(ticket.Description);
            Console.Write("\n Submission Date: ");
            ColourInput($"{ticket.Date}");
            Console.Write("\n Ticket Status: ");
            ColourInput(status);
            Console.Write("\n Receiver: ");
            ColourInput(ticket.CSAgent);
            Console.Write("\n Handler: ");
            ColourInput(ticket.TechSupport);
            Console.Write("\n TicketID: ");
            ColourInput($"{ticket.TicketID} \n");
        }
        public CustTicket CustTicketFormUpdate(CustTicket ticket)
        {
            Console.Clear();

            Console.Write(" Customer Name: ");
            ColourInput(ticket.CustomerName);
            string name = Console.ReadLine();
            if (name == "")
            {
                name = ticket.CustomerName;
            }
            Console.Clear();

            Console.Write(" Customer Name: ");
            ColourInput(ticket.CustomerName);
            Console.Write("\n Customer Email: ");
            ColourInput(ticket.CustomerEmail);
            string email = Console.ReadLine();
            if (email == "")
            {
                email = ticket.CustomerEmail;
            }
            Console.Clear();

            Console.Write(" Customer Name: ");
            ColourInput(ticket.CustomerName);
            Console.Write("\n Customer Email: ");
            ColourInput(ticket.CustomerEmail);
            Console.Write("\n Customer Phone:");
            ColourInput(ticket.CustomerPhone);
            string phone = Console.ReadLine();
            if (phone == "")
            {
                phone = ticket.CustomerPhone;
            }
            Console.Clear();

            Console.Write(" Customer Name: ");
            ColourInput(ticket.CustomerName);
            Console.Write("\n Customer Email: ");
            ColourInput(ticket.CustomerEmail);
            Console.Write("\n Customer Phone:");
            ColourInput(ticket.CustomerPhone);
            Console.WriteLine("\n Description: ");
            ColourInput(ticket.Description);
            Console.WriteLine("\n Added comments: ");
            string description = Console.ReadLine();
            string newDescription = ($"{ticket.Description} \n {DateTime.Now} -Added comments- \n {description}");
            Console.Clear();
            Console.Write(" Customer Name: ");
            ColourInput(ticket.CustomerName);
            Console.Write("\n Customer Email: ");
            ColourInput(ticket.CustomerEmail);
            Console.Write("\n Customer Phone:");
            ColourInput(ticket.CustomerPhone);
            Console.WriteLine("\n Description: ");
            ColourInput(ticket.Description);
            Console.WriteLine("\n Added comments: ");
            ColourInput(description);
            Console.WriteLine("\n Do you want to close this ticket? (Y/N)");
            string closeTicket = Console.ReadLine();
            bool close;
            if (closeTicket == "y" || closeTicket == "Y")
            {
                close = true;
            }
            else
            {
                close = ticket.Closed;
            }


            Console.WriteLine("\n Submit updated ticket? (Y/N) ");
            string selection = Console.ReadLine();


            if (selection != "N" || selection != "n")
            {
                ticket.CustomerName = name;
                ticket.CustomerEmail = email;
                ticket.CustomerPhone = phone;
                ticket.Description = newDescription;
                ticket.Closed = close;
                Console.WriteLine("Ticket Updated.");
                Console.ReadKey();
                return ticket;

            }
            else
            {
                Console.WriteLine("Couldn't update ticket.");
                Console.ReadKey();
                return ticket;
            }

        }

        public CustTicket CustTicketFormAssignUsers(CustTicket ticket)
        {

            Console.Clear();

            CustTicketFormFilled(ticket);

            if (ticket.Closed == true)
            {
                Console.Write("Ticket is closed, do you want to reopen case? (Y/N)");
                string submit = Console.ReadLine();
                if (submit != "N" || submit != "n")
                {
                    ticket.Closed = false;
                }
            }

            Console.Write("\n Assign new Receiver Username (press enter if you don't want to assign a new receiver): ");
            string csagent = Console.ReadLine();
            bool csagentExists;
            if (csagent == "")
            {
                csagent = ticket.CSAgent;
                csagentExists = true;
            }
            else
            {
                using (var db = new EticketContext())
                {
                    if (db.CSAgents.Any(x => x.Username == csagent))
                    {
                        csagentExists = true;
                    }
                    else
                    {
                        csagentExists = false;
                    }
                }
            }
            if (csagentExists && csagent != ticket.CSAgent)
            {
                Console.Write($"\n Do you want to change the receiver from ");
                ColourInput(ticket.CSAgent);
                Console.Write("to ");
                ColourInput(csagent);
                Console.Write(" ? (Y/N) \n");
                string submit = Console.ReadLine();
                if (submit != "N" || submit != "n")
                {
                    ticket.CSAgent = csagent;
                }
            }
            else if (!csagentExists)
            {
                Console.WriteLine("The username you provided does not exist in the Customer Service Agents database. Press any key to continue");
                Console.ReadKey();
            }
            Console.Write($" Assign new Handler Username (press enter if you don't want to assign a new handler): ");
            string techsupport = Console.ReadLine();
            bool techsupportExists = false;
            if (techsupport == "")
            {
                techsupport = ticket.TechSupport;
                techsupportExists = true;
            }
            else
            {
                using (var db = new EticketContext())
                {
                    if (db.TechSupportUsers.Any(x => x.Username == techsupport))
                    {
                        techsupportExists = true;
                    }
                    else
                    {
                        techsupportExists = false;
                    }
                }
            }
            if (techsupportExists && techsupport != ticket.TechSupport)
            {
                Console.Write($"\n Do you want to change the handler from ");
                ColourInput(ticket.TechSupport);
                Console.Write("to ");
                ColourInput(techsupport);
                Console.Write(" ? (Y/N) \n");
                string submit = Console.ReadLine();
                if (submit != "N" || submit != "n")
                {
                    ticket.TechSupport = techsupport;
                }
            }
            else if (!techsupportExists)
            {
                Console.WriteLine("The username you provided does not exist in the Technical Support Users database. Press any key to continue");
                Console.ReadKey();
            }
            return ticket;
        }
    }
}
