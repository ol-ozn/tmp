using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class IntModel : NotifiableModelObject
    {
        public int id;

        public IntModel(BackendController bc, int id) : base(bc)
        {
            this.id = id;
        }
    }
}
