using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class BoardModel : NotifiableModelObject
    {
        private UserModel user;
        public ObservableCollection<IntModel> BoardsIds { get; set; }
        public BoardModel(BackendController bc, UserModel UserModel) : base(bc)
        {
            this.user = UserModel;
            BoardsIds = new ObservableCollection<IntModel>(((List<int>)(bc.getBoards(user.Email).ReturnValue)).
                Select((c, i) => new IntModel(bc, i)));
            // boardIds = (List<int>)(bc.getBoards(user.Email).ReturnValue);
        }
    }
}
