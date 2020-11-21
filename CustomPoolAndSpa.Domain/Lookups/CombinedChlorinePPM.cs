using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain.Lookups
{
    public class CombinedChlorinePPM : ILookupItem<int>
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
