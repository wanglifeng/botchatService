using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCore.Filters;

namespace DomainCore
{
    public class Reboter
    {

        public static Reboter _Reboter { get; set; }

        public  List<IFilter> _Filters { get; set; }

        private Reboter()
        {
            _Filters = new List<IFilter>();
            _Filters.Add(new ConstContentFilter());
            _Filters.Add(new BeginTransaction());
            _Filters.Add(new KeyWordFilter());
            _Filters.Add(new LocationFilters());
            _Filters.Add(new UnKnowFilter());
        }

        public static Reboter Instance
        {
            get
            {
                if (_Reboter == null)
                    _Reboter = new Reboter();

                return _Reboter;
            }
        }

        public static String TryToUnderStand(String from, string content)
        {
            String resultContent=string.Empty;

            foreach (var t in Reboter.Instance._Filters)
            {
                if (t.Filters(from, content, out resultContent))
                {
                    break;
                }
            }

            return resultContent;
            
        }
    }
}
