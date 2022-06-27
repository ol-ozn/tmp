using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class IntModel : NotifiableModelObject
    {
        public int Id { get; set; }

        public IntModel(BackendController bc, int id) : base(bc)
        {
            this.Id = id;
        }
    }
}
