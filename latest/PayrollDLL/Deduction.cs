//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PayrollDLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deduction
    {
        public string EmpClassID { get; set; }
        public decimal MedicalPremium { get; set; }
        public decimal ProvidentFund { get; set; }
        public decimal ProfessionalTax { get; set; }
        public Nullable<decimal> AttendenceDeductions { get; set; }
    
        public virtual PayrollMain PayrollMain { get; set; }
    }
}
