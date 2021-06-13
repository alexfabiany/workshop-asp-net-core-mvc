﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            this.Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            this.Sales.Remove(sr);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {

            return this.Sales
                .Where(sr => sr.Date >= initialDate && sr.Date <= finalDate)
                .Sum(sr => sr.Amount);
        }
    }
}