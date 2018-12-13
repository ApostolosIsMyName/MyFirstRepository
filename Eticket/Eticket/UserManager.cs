using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticket
{
    class UserManager
    {
        //csAgents CRUD
        #region
        public CSAgent CreateCSAgent(string name, string email, string phone, string username, string password)
        {
            CSAgent newCSAgent = new CSAgent()
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                Username = username,
                Password = password
            };
            using (var db = new EticketContext())
            {
                db.CSAgents.Add(newCSAgent);
                db.SaveChanges();
            }
            return newCSAgent;
        }

        public CSAgent GetCSAgent(string username)
        {
            CSAgent cSAgent;
            using (var db = new EticketContext())
            {
                cSAgent = db.CSAgents.SingleOrDefault(s => s.Username == username);
            }
            return cSAgent;
        }
        public CSAgent GetCSAgent(string email, string name)
        {
            CSAgent cSAgent;
            using (var db = new EticketContext())
            {
                cSAgent = db.CSAgents.SingleOrDefault(s => s.Email == email || s.Name == name);
            }
            return cSAgent;
        }

        public List<CSAgent> GetAllCSAgents()
        {
            List<CSAgent> allCSAgents = new List<CSAgent>();
            using (var db = new EticketContext())
            {
                allCSAgents = db.CSAgents.ToList();
            }
            return allCSAgents;
        }

        public CSAgent updateCSAgentInfo(string username, string password, string name, string phone, string email)
        {
            CSAgent cSAgent;
            using (var db = new EticketContext())
            {
                cSAgent = db.CSAgents.SingleOrDefault(s => s.Username == username);

                cSAgent.Name = name;
                cSAgent.PhoneNumber = phone;
                cSAgent.Email = email;
                cSAgent.Password = password;
                db.SaveChanges();
                cSAgent = db.CSAgents.SingleOrDefault(s => s.Username == username);

            }
            return cSAgent;

        }
        public bool DeleteCSAgent(string username)
        {
            List<CustTicket> deleteCSagentFromTicket = new List<CustTicket>();
            CSAgent cSAgent;
            using (var db = new EticketContext())
            {
                
                   
                    cSAgent = db.CSAgents.SingleOrDefault(s => s.Username == username);
                if (cSAgent == null)
                {
                    Console.WriteLine("User not found under the specified criteria. Press any key to continue");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    deleteCSagentFromTicket = db.CustTickets.Where(x => x.CSAgent == cSAgent.Username).ToList();
                    if (deleteCSagentFromTicket.Count > 0)
                    {
                        for (int i =0; i < deleteCSagentFromTicket.Count; i++)
                        {
                            deleteCSagentFromTicket[i].CSAgent = null;
                            db.SaveChanges();
                        }
                    }
                    
                    db.CSAgents.Remove(cSAgent);
                    db.SaveChanges();
                    cSAgent = db.CSAgents.SingleOrDefault(s => s.Username == username);
                    if (cSAgent == null)
                        return true;
                    else
                        return false;
                }

            }
        }
        #endregion

        //SupervisorsCRUD
        #region
        public Supervisor CreateSupervisor(string name, string email, string phone, string username, string password)
        {
            Supervisor newSupervisor = new Supervisor()
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                Username = username,
                Password = password
            };
            using (var db = new EticketContext())
            {
                db.Supervisors.Add(newSupervisor);
                db.SaveChanges();
            }
            return newSupervisor;
        }

        public Supervisor GetSupervisor(string username)
        {
            Supervisor supervisor;
            using (var db = new EticketContext())
            {
                supervisor = db.Supervisors.Find(username);
            }
            return supervisor;
        }
        public Supervisor GetSupervisor(string email, string name)
        {
            Supervisor supervisor;
            using (var db = new EticketContext())
            {
                supervisor = db.Supervisors.SingleOrDefault(s => s.Email == email || s.Name == name);
            }
            return supervisor;
        }

        public List<Supervisor> GetAllSupervisors()
        {
            List<Supervisor> allSupervisors = new List<Supervisor>();
            using (var db = new EticketContext())
            {
                allSupervisors = db.Supervisors.ToList();
            }
            return allSupervisors;
        }

        public Supervisor updateSupervisorInfo(string username, string password, string name, string phone, string email)
        {
            Supervisor supervisor;
            using (var db = new EticketContext())
            {
                supervisor = db.Supervisors.SingleOrDefault(s => s.Username == username);

                supervisor.Name = name;
                supervisor.PhoneNumber = phone;
                supervisor.Email = email;
                supervisor.Password = password;
                db.SaveChanges();
                supervisor = db.Supervisors.SingleOrDefault(s => s.Username == username);

            }
            return supervisor;

        }
        public bool DeleteSupervisor(string username)
        {
            Supervisor supervisor;
            using (var db = new EticketContext())
            {
                supervisor = db.Supervisors.SingleOrDefault(s => s.Username == username);
                if (supervisor == null)
                {
                    Console.WriteLine("User not found under the specified criteria. Press any key to continue");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    db.Supervisors.Remove(supervisor);
                    db.SaveChanges();
                    supervisor = db.Supervisors.SingleOrDefault(s => s.Username == username);
                    if (supervisor == null)
                        return true;
                    else
                        return false;
                }

            }

        }
        #endregion
        //TechSupportUsers CRUD
        #region
        public TechSupportUser CreateTechSupportUser(string name, string email, string phone, string username, string password)
        {
            TechSupportUser newTechSupportUser = new TechSupportUser()
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                Username = username,
                Password = password
            };
            using (var db = new EticketContext())
            {
                db.TechSupportUsers.Add(newTechSupportUser);
                db.SaveChanges();
            }
            return newTechSupportUser;
        }

        public TechSupportUser GetTechSupportUser(string username)
        {
            TechSupportUser techSupportUser;
            using (var db = new EticketContext())
            {
                techSupportUser = db.TechSupportUsers.Find(username);
            }
            return techSupportUser;
        }
        public TechSupportUser GetTechSupportUser(string email, string name)
        {
            TechSupportUser techSupportUser;
            using (var db = new EticketContext())
            {
                techSupportUser = db.TechSupportUsers.SingleOrDefault(s => s.Email == email || s.Name == name);
            }
            return techSupportUser;
        }

        public List<TechSupportUser> GetAllTechSupportUsers()
        {
            List<TechSupportUser> allTechSupportUsers = new List<TechSupportUser>();
            using (var db = new EticketContext())
            {
                allTechSupportUsers = db.TechSupportUsers.ToList();
            }
            return allTechSupportUsers;
        }

        public TechSupportUser updateTechSupportUserInfo(string username, string password, string name, string phone, string email)
        {
            TechSupportUser techSupportUser;
            using (var db = new EticketContext())
            {
                techSupportUser = db.TechSupportUsers.SingleOrDefault(s => s.Username == username);

                techSupportUser.Name = name;
                techSupportUser.PhoneNumber = phone;
                techSupportUser.Email = email;
                techSupportUser.Password = password;
                db.SaveChanges();
                techSupportUser = db.TechSupportUsers.SingleOrDefault(s => s.Username == username);

            }
            return techSupportUser;

        }
        public bool DeleteTechSupportUser(string username)
        {
            List<CustTicket> deleteTechSupportFromTicket = new List<CustTicket>();
            TechSupportUser techSupport;
            using (var db = new EticketContext())
            {


                techSupport = db.TechSupportUsers.SingleOrDefault(s => s.Username == username);
                if (techSupport == null)
                {
                    Console.WriteLine("User not found under the specified criteria. Press any key to continue");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    deleteTechSupportFromTicket = db.CustTickets.Where(x => x.TechSupport == techSupport.Username).ToList();
                    if (deleteTechSupportFromTicket.Count > 0)
                    {
                        for (int i = 0; i < deleteTechSupportFromTicket.Count; i++)
                        {
                            deleteTechSupportFromTicket[i].CSAgent = null;
                            db.SaveChanges();
                        }
                    }

                    db.TechSupportUsers.Remove(techSupport);
                    db.SaveChanges();
                    techSupport = db.TechSupportUsers.SingleOrDefault(s => s.Username == username);
                    if (techSupport == null)
                        return true;
                    else
                        return false;
                }

            }
        }
        #endregion
        // Administrators CRUD
        #region
        public Administrator CreateAdministrator(string name, string email, string phone, string username, string password)
        {
            Administrator newAdministrator = new Administrator()
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                Username = username,
                Password = password
            };
            using (var db = new EticketContext())
            {
                db.Administrators.Add(newAdministrator);
                db.SaveChanges();
            }
            return newAdministrator;
        }

        public Administrator GetAdministrator(string username)
        {
            Administrator administrator;
            using (var db = new EticketContext())
            {
                administrator = db.Administrators.Find(username);
            }
            return administrator;
        }
        public Administrator GetAdministrator(string email, string name)
        {
            Administrator administrator;
            using (var db = new EticketContext())
            {
                administrator = db.Administrators.SingleOrDefault(s => s.Email == email || s.Name == name);
            }
            return administrator;
        }

        public List<Administrator> GetAllAdministrators()
        {
            List<Administrator> allAdministrators = new List<Administrator>();
            using (var db = new EticketContext())
            {
                allAdministrators = db.Administrators.ToList();
            }
            return allAdministrators;
        }

        public Administrator updateAdministratorInfo(string username, string password, string name, string phone, string email)
        {
            Administrator administrator;
            using (var db = new EticketContext())
            {
                administrator = db.Administrators.SingleOrDefault(s => s.Username == username);


                administrator.Name = name;
                administrator.PhoneNumber = phone;
                administrator.Email = email;
                administrator.Password = password;
                db.SaveChanges();
                administrator = db.Administrators.SingleOrDefault(s => s.Username == username);

            }
            return administrator;

        }
        public bool DeleteAdministrator(string username)
        {
            Administrator administrator;
            using (var db = new EticketContext())
            {
                administrator = db.Administrators.SingleOrDefault(s => s.Username == username);
                if (administrator == null)
                {
                    Console.WriteLine("User not found under the specified criteria. Press any key to continue");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    db.Administrators.Remove(administrator);
                    db.SaveChanges();
                    administrator = db.Administrators.SingleOrDefault(s => s.Username == username);
                    if (administrator == null)
                        return true;
                    else
                        return false;
                }
            }

        }
        #endregion
        //newUser Registration 
        #region
        public List<NewUser> GetNewUser()
        {
            List<NewUser> allNewUsers = new List<NewUser>();
            using (var db = new EticketContext())
            {
                allNewUsers = db.NewUsers.ToList();
            }
            return allNewUsers;
        }
        public bool DeleteNewUser(string username)
        {
            NewUser newUser;
            using (var db = new EticketContext())
            {
                newUser = db.NewUsers.SingleOrDefault(s => s.Username == username);
                if (newUser != null)
                {
                    db.NewUsers.Remove(newUser);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("No users found with this username. Press any key to return");
                    Console.ReadKey();
                }
                newUser = db.NewUsers.SingleOrDefault(s => s.Username == username);
                if (newUser == null)
                    return true;
                else
                    return false;

            }
        }

        public void RegisterUser()
        {
            NewUser newUser = new NewUser();
            using (var db = new EticketContext())
            {
                newUser = db.NewUsers.FirstOrDefault();
                if (newUser != null)
                {
                    Console.Write($"The applicant user has selected a role of {newUser.Role}. \n Applicant info: Username - { newUser.Username} \n Password - { newUser.Password} \n" +
                        $" Name - {newUser.Name} \n Email - {newUser.Email} \n Phone Number - {newUser.PhoneNumber} \n Select what kind of user you want to register:" +
                        $" 1. Administrator, 2. Supervisor, 3. TechSupport User, 4. CSAgent \n");
                    string selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            CreateAdministrator(newUser.Name, newUser.Email, newUser.PhoneNumber, newUser.Username, newUser.Password);
                            DeleteNewUser(newUser.Username);
                            break;
                        case "2":
                            CreateSupervisor(newUser.Name, newUser.Email, newUser.PhoneNumber, newUser.Username, newUser.Password);
                            DeleteNewUser(newUser.Username);
                            break;
                        case "3":
                            CreateTechSupportUser(newUser.Name, newUser.Email, newUser.PhoneNumber, newUser.Username, newUser.Password);
                            DeleteNewUser(newUser.Username);
                            break;
                        case "4":
                            CreateCSAgent(newUser.Name, newUser.Email, newUser.PhoneNumber, newUser.Username, newUser.Password);
                            DeleteNewUser(newUser.Username);
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection");
                            break;
                    }
                }
            }

        }
        #endregion
    }

}
