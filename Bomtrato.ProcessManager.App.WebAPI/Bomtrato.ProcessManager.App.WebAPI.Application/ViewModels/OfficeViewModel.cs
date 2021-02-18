using System;

namespace Bomtrato.ProcessManager.App.WebAPI.Application.ViewModels
{
    public class OfficeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}