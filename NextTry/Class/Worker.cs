using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using NextTry.Interface;

namespace NextTry.Class
{
    public class ExceptionString : ActionResult
    {
        public string Message { get; set; }
    }
    public class Worker
    {
        private ContractDbContext _DBContext;
        private EFRepository<Customer> _customers;
        private EFRepository<Invoice> _invoices;
        private EFRepository<Employer> _employers;
        private EFRepository<Contract> _contracts;
        private EFRepository<TimeSheet> _timeSheets;
        public Worker(ContractDbContext context)
        {
            _DBContext = context;
            _customers = new EFRepository<Customer>(_DBContext);
            _invoices = new EFRepository<Invoice>(_DBContext);
            _employers = new EFRepository<Employer>(_DBContext);
            _contracts = new EFRepository<Contract>(_DBContext);
            _timeSheets = new EFRepository<TimeSheet>(_DBContext);
        }
        //system---------------------------------------------------------------------------------------------------------------------------------------------
        public bool Exist(object entity)
        {
            switch (entity.GetType().Name)
            {
                case "Customer":    return _customers.FindByIdNoTracking(((Customer)entity).Id)!=null;
                case "Invoice":     return _invoices.FindByIdNoTracking(((Invoice)entity).Id) != null;
                case "Employer":    return _employers.FindByIdNoTracking(((Employer)entity).Id) != null;
                case "Contract":    return _contracts.FindByIdNoTracking(((Contract)entity).Id) != null;
                case "TimeSheet":   return _timeSheets.FindByIdNoTracking(((TimeSheet)entity).Id) != null;
                default: return false;
            }
        }


        //create---------------------------------------------------------------------------------------------------------------------------------------------
        public bool CreateNewEmptyEntity<T>(T entity) where T : class
        {
            switch (entity.GetType().Name)
            {
                case "Customer":
                    _customers.Create(new Customer());
                    _customers.
                case "Invoice": 
                case "Employer": 
                case "Contract": 
                case "TimeSheet": 
                default:
                    break;
            }
        }

        public void CreateNewContract(int customerId) => _contracts.Create(new Contract() { CustomerId = customerId });
        public void CreateNewCustomer(string name) => _customers.Create(new Customer() { Name = name });
        public void CreateNewEmployer(string name) => _employers.Create(new Employer() { Name = name });
        public void CreateNewInvoice() => _invoices.Create(new Invoice());
        public void CreateNewTimeSheet(int employerId, string title) => _timeSheets.Create(new TimeSheet() { EmployerId = employerId, Title = title });

        //update---------------------------------------------------------------------------------------------------------------------------------------------
        public void AddInvoiceToContract(int contractId, int invoiceId)
        {
            IEnumerable<Invoice> invoices = _invoices.GetTracking(p => p.ContractId == 0);
            if (invoices.Count() > 0)
            {
                invoices.FirstOrDefault().ContractId = contractId;
                _invoices.SaveChanges();
            }
            else
            {
                //not added
            }
        }
        public void AddTimeSheetToInvoice(int timeSheetId, int invoiceId)
        {
            var timeSheet = _timeSheets.FindById(timeSheetId);
            var invoice = _invoices.FindById(invoiceId);
            if (timeSheet != null & invoice != null)
            {
                invoice.Tasks.Add(timeSheet.Id);
                _invoices.SaveChanges();
            }
        }
        public void AddEmployerToTimeSheet(int timeSheetId, int employerId)
        {
            var timeSheet = _timeSheets.FindById(timeSheetId);
            timeSheet.EmployerId = employerId;
            _timeSheets.Update(timeSheet);
        }

        //read-----------------------------------------------------------------------------------------------------------------------------------------------

        public Contract GetContractById(int contractId) => _contracts.FindByIdNoTracking(contractId);
        public Contract GetContractByCustomerId(int customerId) => _contracts.Get(p => p.CustomerId == customerId).FirstOrDefault();
        public Customer GetCustomerById(int customerId) => _customers.FindByIdNoTracking(customerId);
        public Invoice GetInvoiceById(int invoiceId) => _invoices.FindByIdNoTracking(invoiceId);
        public Employer GetEmployerById(int employerId) => _employers.FindByIdNoTracking(employerId);
        public TimeSheet GetTimeSheetById(int timeSheetId) => _timeSheets.FindByIdNoTracking(timeSheetId);

        public IEnumerable<Customer> GetAllCustomers() => _customers.Get(p => p.Name != null);
        public IEnumerable<Employer> GetAllEmployers() => _employers.Get(p => p.Name != null);
        public IEnumerable<Contract> GetAllOpenContracts() => _contracts.Get(p => p.Status = true);
        public IEnumerable<Invoice> GetAllOpenInvoices() => _invoices.Get(p => p.IsClosed == false);
        public IEnumerable<TimeSheet> GeetAllTimeSheets() => _timeSheets.Get(p => p.Title != null);
        public IEnumerable<Invoice> GetAllInvoicesByEmployerId(int employerId) => _invoices.Get(p => p.EmployerId == employerId);
        public IEnumerable<Invoice> GetAllInvoicesInContract(int contractId) => _invoices.Get(p => p.ContractId == contractId);
        //delete---------------------------------------------------------------------------------------------------------------------------------------------

    }
    public class ManagerService
    {
        private ContractDbContext _DBContext;
        private EFRepository<Customer> _customers;
        private EFRepository<Invoice> _invoices;
        private EFRepository<Employer> _employers;
        private EFRepository<TimeSheet> _timeSheets;
        private EFRepository<Contract> _contracts;

        public ManagerService(ContractDbContext context)
        {
            _DBContext = context;
            _customers = new EFRepository<Customer>(_DBContext);
            _invoices = new EFRepository<Invoice>(_DBContext);
            _employers = new EFRepository<Employer>(_DBContext);
            _contracts = new EFRepository<Contract>(_DBContext);
            _timeSheets = new EFRepository<TimeSheet>(_DBContext);
        }

        public void CreateNewCustomer(string name) => _customers.Create(new Customer() { Name = name });
        public void CreateNewEmployer(string name) => _employers.Create(new Employer() { Name = name });
        public void CreateNewInvoice() => _invoices.Create(new Invoice());
        public void CreateNewInvoice(Invoice invoice) => _invoices.Create(invoice);
        public void CreateNewInvoice(int contractId)
        {
            _invoices.Create(new Invoice() { ContractId = contractId });
        }
        public void CreateNewInvoice(int contractId, int employerId, decimal hourCost)
        {
            _invoices.Create(new Invoice()
            {
                ContractId = contractId,
                EmployerId = employerId,
                HourCost = hourCost,
                IsClosed = false
            });
        }
        public void AddInvoiceToContract(int contractId, int invoiceId)
        {
            IEnumerable<Invoice> invoices = _invoices.GetTracking(p => p.ContractId == 0);
            if (invoices.Count() > 0)
            {
                invoices.FirstOrDefault().ContractId = contractId;
                _invoices.SaveChanges();
            }
            else
            {
                //not added
            }
        }
        public void AddTimeSheetToInvoice(int timeSheetId, int invoiceId)
        {
            var timeSheet = _timeSheets.FindById(timeSheetId);
            var invoice = _invoices.FindById(invoiceId);
            if (timeSheet != null & invoice != null)
            {
                invoice.Tasks.Add(timeSheet.Id);
                _invoices.SaveChanges();
            }
        }
        public void SetPerHourCost(int invoiceId, decimal cost)
        {
            var invoice = _invoices.FindById(invoiceId);
            if (invoice != null) invoice.HourCost = cost;
        }
        public IEnumerable<Invoice> GetAllInvoicesByEmployerId(int employerId)
        {
            var invoices = _invoices.Get(p => p.EmployerId == employerId);
            return invoices;
        }
        public Invoice GetNoEmployerInvoice() => _invoices.Get(p => p.EmployerId == 0).FirstOrDefault();
        public Invoice GetEmptyInvoice()
        {
            Expression<Func<Invoice, object>>[] Filter = new Expression<Func<Invoice, object>>[]
            {
                predicate1 => predicate1.EmployerId == 0,
                predicate3 => predicate3.HourCost == 0,
                predicate2 => predicate2.IsClosed == false,
                predicate4 => predicate4.Tasks.Count == 0
            };
            IEnumerable<Invoice> invoices = _invoices.GetWithInclude(Filter);
            if (invoices.Count() > 0) return invoices.FirstOrDefault(); else return null;
        }
    }
    public class EmployerService
    {
        private ContractDbContext _DBContext;
        private EFRepository<Invoice> _invoices;
        private EFRepository<Employer> _employers;
        private EFRepository<TimeSheet> _timeSheets;
        //private EFRepository<Contract> _contracts;
        //private EFRepository<Customer> _customers;
        public EmployerService(ContractDbContext context)
        {
            _DBContext = context;
            _invoices = new EFRepository<Invoice>(_DBContext);
            _employers = new EFRepository<Employer>(_DBContext);
            _timeSheets = new EFRepository<TimeSheet>(_DBContext);
            //_contracts = new EFRepository<Contract>(_DBContext);
            //_customers = new EFRepository<Customer>(_DBContext);
        }
        public Invoice GetInvoiceById(int invoiceId) => _invoices.FindById(invoiceId);
        public TimeSheet GetTimeSheetById(int tsid) => _timeSheets.FindById(tsid);
        public Employer GetEmployerInfo(int employerId) => _employers.FindById(employerId);
        public void CreateNewTimeSheet(int employerId, string title, int totalHours)
        {
            _timeSheets.Create(new TimeSheet() { EmployerId = employerId, TotalHours = totalHours, Title = title });
        }
        public void CreateNewTimeSheet(TimeSheet ts) => _timeSheets.Create(ts);
    }
    public class CustomerService
    {
        private ContractDbContext _DBContext;
        private EFRepository<Invoice> _invoices;
        private EFRepository<Contract> _contracts;
        //private EFRepository<Customer> _customers;
        //private EFRepository<Employer> _employers;
        //private EFRepository<TimeSheet> _timeSheets;
        public CustomerService(ContractDbContext context)
        {
            _DBContext = context;
            _invoices = new EFRepository<Invoice>(_DBContext);
            _contracts = new EFRepository<Contract>(_DBContext);
            //_customers = new EFRepository<Customer>(_DBContext);
            //_employers = new EFRepository<Employer>(_DBContext);
            //_timeSheets = new EFRepository<TimeSheet>(_DBContext);
        }
        public void CreateNewContract(int customerId)
        {
            _contracts.Create(new Contract() { CustomerId = customerId, Status = true });
        }
        public void CloseContract(int contractId)
        {
            var contract = _contracts.FindById(contractId);
            IEnumerable<Invoice> invoices = _invoices.Get(p => p.ContractId == contractId).Where(p => p.IsClosed == false).ToList();
            if (invoices.Count() == 0)
            {
                contract.Status = false;
                _contracts.Update(contract);
            }
            else
            {
                //not closed
            }
        }
        public void CloseInvoice(int invoiceId)
        {
            _invoices.FindById(invoiceId).IsClosed = true;
            _invoices.SaveChanges();
        }
        public void CloseAllInvoicesInContract(int contractId)
        {
            IEnumerable<Invoice> invoices = _invoices.GetTracking(p => p.ContractId == contractId).Where(p => p.IsClosed == false).ToList();
            if (invoices.Count() > 0)
            {
                foreach (var item in invoices)
                {
                    item.IsClosed = true;
                    //_invoices.Update(item);
                }
                _invoices.SaveChanges();
            }
            else
            {
                //not closed
            }
        }
    }
}
