using System;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Domain
{
    public class ProcessDomain : Entity
    {
        public string Number { get; set; }
        public decimal CasueValue { get; set; }
        public Guid IdOffice { get; set; }
        public virtual OfficeDomain Office { get; set; }
        public string ComplainingName { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
        
    }
}