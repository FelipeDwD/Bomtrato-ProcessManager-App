using System;

namespace Bomtrato.ProcessManager.App.WebAPI.Application.ViewModels
{
    public class ProcessViewModel
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal CasueValue { get; set; }
        public Guid IdOffice { get; set; }
        public OfficeViewModel Office { get; set; }
        public string ComplainingName { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
    }
}