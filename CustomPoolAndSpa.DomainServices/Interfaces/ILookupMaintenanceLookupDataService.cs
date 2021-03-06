﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public interface ILookupMaintenanceLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetLookupMaintenanceLookupAsync();
    }
}