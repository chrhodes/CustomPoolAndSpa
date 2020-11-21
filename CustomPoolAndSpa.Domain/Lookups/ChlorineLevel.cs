using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain.Lookups
{
    public class ChlorineLevel : ILookupItem<int>
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
