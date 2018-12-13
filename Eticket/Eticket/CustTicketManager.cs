using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Eticket
{
    public class CustTicketManager
    {
        //CRUD for Customer Tickets
        #region
        public void SubmitNewTicket(string username)
        {
            CustTicketForm form = new CustTicketForm();
            CustTicket newTicket = new CustTicket();
            newTicket = form.CustTicketFormEmpty(username);
            using (var db = new EticketContext())
            {
                db.CustTickets.Add(newTicket);
                db.SaveChanges();
            }
            string newTicketToText = ($" Date: {newTicket.Date}  - CustomerName: {newTicket.CustomerName} - Customer Email: {newTicket.CustomerEmail} - Customer Phone: {newTicket.CustomerPhone} - Description: {newTicket.Description} - TicketID: {newTicket.TicketID}\n");
            File.AppendAllText("CustTicketArchive.txt", newTicketToText);
        }
        public void SearchAllTicketsByEmail(string customerEmail)
        {
            CustTicketForm form = new CustTicketForm();
            List<CustTicket> tickets = new List<CustTicket>();
            using (var db = new EticketContext())
            {
                tickets = db.CustTickets.Where(x => x.CustomerEmail == customerEmail).ToList();
            }
            if (tickets == null)
            {
                Console.WriteLine("No tickets found with these criteria.");
            }
            else
            {
                foreach (var item in tickets)
                {
                    form.CustTicketFormFilled(item);
                }
            }
        }
        public void SearchAllTicketsByName(string customerName)
        {
            CustTicketForm form = new CustTicketForm();
            List<CustTicket> tickets = new List<CustTicket>();
            using (var db = new EticketContext())
            {
                tickets = db.CustTickets.Where(x => x.CustomerName == customerName).ToList();
            }
            if (tickets == null)
            {
                Console.WriteLine("No tickets found with these criteria.");
            }
            else
            {
                foreach (var item in tickets)
                {
                    form.CustTicketFormFilled(item);
                }
            }
        }
        public void FindOpenTicketsByEmail(string customerEmail)
        {
            CustTicketForm form = new CustTicketForm();
            List<CustTicket> tickets = new List<CustTicket>();
            using (var db = new EticketContext())
            {
                tickets = db.CustTickets.Where(x => x.CustomerEmail == customerEmail && x.Closed == false).ToList();
            }
            if (tickets == null)
            {
                Console.WriteLine("No tickets found with these criteria.");
            }
            else
            {
                foreach (var item in tickets)
                {
                    form.CustTicketFormFilled(item);
                }
            }
        }
        public void FindOpenTicketsByName(string customerName)
        {
            CustTicketForm form = new CustTicketForm();
            List<CustTicket> tickets = new List<CustTicket>();
            using (var db = new EticketContext())
            {
                tickets = db.CustTickets.Where(x => x.CustomerName == customerName && x.Closed == false).ToList();
            }
            if (tickets == null)
            {
                Console.WriteLine("No tickets found with these criteria.");
            }
            else
            {
                foreach (var item in tickets)
                {
                    form.CustTicketFormFilled(item);
                }
            }
            
        }
        public void ListAllTickets()
        {
            CustTicketForm form = new CustTicketForm();
            List<CustTicket> tickets = new List<CustTicket>();
            using (var db = new EticketContext())
            {
                tickets = db.CustTickets.ToList();
            }
            if (tickets == null)
            {
                Console.WriteLine("No tickets found in database.");
            }
            else
            {
                foreach (var item in tickets)
                {
                    form.CustTicketFormFilled(item);
                }
            }
        }
        public void UpdateTicket(int ticketID)
        {
            CustTicketForm form = new CustTicketForm();
            CustTicket ticket = new CustTicket();
            using (var db = new EticketContext())
            {
                ticket = db.CustTickets.FirstOrDefault(x => x.TicketID == ticketID && x.Closed == false);
            }
            if (ticket == null)
            {
                Console.WriteLine("Ticket couldn't be found. Press any key to return.");
                Console.ReadKey();
            }
            else
            {
                CustTicket updatedTicket = form.CustTicketFormUpdate(ticket);
                using (var db = new EticketContext())
                {
                    ticket = db.CustTickets.SingleOrDefault(s => s.TicketID == ticket.TicketID);
                    ticket.CustomerName = updatedTicket.CustomerName;
                    ticket.CustomerEmail = updatedTicket.CustomerEmail;
                    ticket.CustomerPhone = updatedTicket.CustomerPhone;
                    ticket.Description = updatedTicket.Description;
                    ticket.Closed = updatedTicket.Closed;
                    db.SaveChanges();
                }
                string updatedTicketToText = ($" Date: {updatedTicket.Date}  - CustomerName: {updatedTicket.CustomerName} - Customer Email: {updatedTicket.CustomerEmail} - Customer Phone: {updatedTicket.CustomerPhone} - Description: {updatedTicket.Description} - TicketID: {updatedTicket.TicketID}\n");
                File.AppendAllText("CustTicketArchive.txt", updatedTicketToText);
            }
            

        }
        public void assignUsersToTicket(int ticketID)
        {
            CustTicketForm form = new CustTicketForm();
            CustTicket ticket = new CustTicket();
            using (var db = new EticketContext())
            {
                ticket = db.CustTickets.FirstOrDefault(x => x.TicketID == ticketID);
            }
            if (ticket == null)
            {
                Console.WriteLine("Ticket couldn't be found. Press any key to return.");
                Console.ReadKey();
            }
            else
            {
                CustTicket updatedTicket = form.CustTicketFormAssignUsers(ticket);
                using (var db = new EticketContext())
                {
                    ticket = db.CustTickets.SingleOrDefault(s => s.TicketID == ticket.TicketID);
                    ticket.CSAgent = updatedTicket.CSAgent;
                    ticket.TechSupport = updatedTicket.TechSupport;
                    ticket.Closed = updatedTicket.Closed;
                    db.SaveChanges();
                }
                string updatedTicketToText = ($" Date: {updatedTicket.Date}  - CustomerName: {updatedTicket.CustomerName} - Customer Email: {updatedTicket.CustomerEmail} - Customer Phone: {updatedTicket.CustomerPhone} - Description: {updatedTicket.Description} - TicketID: {updatedTicket.TicketID} \n");
                File.AppendAllText("CustTicketArchive.txt", updatedTicketToText);
            }


        }
        public void DeleteTicket(int ticketID)
        {
            CustTicket ticket = new CustTicket();
            using (var db = new EticketContext())
            {
                ticket = db.CustTickets.FirstOrDefault(x => x.TicketID == ticketID && x.Closed == true);

                if (ticket == null)
                {
                    Console.WriteLine("Ticket not found under the specified criteria. Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write($"Are you sure you want to delete Customer Ticket with ID- {ticket.TicketID}? (Y/N) ");
                    string selection = Console.ReadLine();
                    if (selection == "Y" || selection == "y")
                    {
                        db.CustTickets.Remove(ticket);
                        db.SaveChanges();
                        ticket = db.CustTickets.SingleOrDefault(s => s.TicketID == ticketID);
                        if (ticket == null)
                        {
                            Console.WriteLine("Ticket deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Ticket couldn't be deleted.");
                        }
                    }
                }
            }
        }
        #endregion
    }
}
