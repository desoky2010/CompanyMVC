﻿namespace CompanyMVC.ViewModel
{
    public class AddEmpViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Department { get; set; } = string.Empty;
    }
}
