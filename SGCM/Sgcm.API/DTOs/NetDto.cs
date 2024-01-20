using System.Collections.ObjectModel;

namespace Sgcm.App.DTOs
{
    public class PersonNets : ObservableCollection<NetDto>
    { }

    public class NetDto
    {
        public string Net_url { get; set; }
        public string Net_personid { get; set; }
        public int Net_nettype { get; set; }
        public int Net_state { get; set; }
    }
}