using System.Collections.Generic;

namespace Bomtrato.ProcessManager.App.WebAPI.Domain.Domain
{
    public class OfficeDomain : Entity
    {
        public string Name { get; set; }
        public virtual List<ProcessDomain> Processes { get; set; }

    }
}