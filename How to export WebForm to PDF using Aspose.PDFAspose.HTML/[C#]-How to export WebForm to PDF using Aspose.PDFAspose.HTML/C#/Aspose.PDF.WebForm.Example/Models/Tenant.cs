using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebForms.Example.Models
{
    public class Tenant
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Tenant's Full Name")]
        [StringLength(65)]
        public string FullName { get; set; }
        [Display(Name = "Rental Property Address")]
        [StringLength(65)]
        public string RentalPropertyAddress { get; set; }

        [Display(Name = "Move-In Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]

        public DateTime MoveInDate { get; set; }
        [Display(Name = "Lease-End Date")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime LeaseEndDate { get; set; }

        [Display(Name = "Monthly Payment")]
        [DataType(DataType.Currency)]
        public decimal MonthlyPayment { get; set; }

        //Standard Select
        public List<Tenant> GetAllTenants()
        {
            var db = new TenantContext();
            return db.Tenants.ToList();
        }

        //Insert
        public void CreateTenant(string fullname, 
            string rentalPropertyAddress, 
            DateTime moveInDate, 
            DateTime leaseEndDate, 
            decimal monthlyPayment)
        {
            var db = new TenantContext();
            db.Tenants.Add(
                new Tenant
                {
                    FullName= fullname,
                    RentalPropertyAddress= rentalPropertyAddress,
                    MoveInDate= moveInDate,
                    LeaseEndDate =  leaseEndDate,
                    MonthlyPayment = monthlyPayment
                });
            db.SaveChanges();
        }

        //Edit
        public void EditTenant(int id, string fullname,
            string rentalPropertyAddress,
            DateTime moveInDate,
            DateTime leaseEndDate,
            decimal monthlyPayment)
        {
            var db = new TenantContext();
            var p = db.Tenants.SingleOrDefault(t => t.Id == id);
            if (p != null)
            {
                p.FullName = fullname;
                p.RentalPropertyAddress = rentalPropertyAddress;
                p.MoveInDate = moveInDate;
                p.LeaseEndDate = leaseEndDate;
                p.MonthlyPayment = monthlyPayment;
                db.SaveChanges();
            }
            else
            {
                throw new ApplicationException("Can not find the tenant");
            }
        }

        //Delete
        public void DeleteTenant(int tenantId)
        {
            var db = new TenantContext();
            var p = db.Tenants.SingleOrDefault(t => t.Id == tenantId);
            if (p != null)
            {
                db.Tenants.Remove(p);
                db.SaveChanges();
            }
            else
            {
                throw new ApplicationException("Can not find the tenant");
            }
        }
    }

}