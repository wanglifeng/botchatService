using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Me.WLF.Model;

namespace Me.WLF.IDAL
{
    public interface IStateRepostatry
    {
        void Save(State state);
        List<State> List();
        State GetById(int id);
    }
}
