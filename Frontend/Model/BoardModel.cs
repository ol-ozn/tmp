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
        public int Id { get; set; }
        public BoardModel(BackendController bc, UserModel UserModel) : base(bc)
        {
            this.user = UserModel;
            Id=1000;
            // BoardsIds = new ObservableCollection<IntModel>(((List<int>)(bc.getBoards(user.Email).ReturnValue)).
            //     Select((c, i) => new IntModel(bc, i)));
            BoardsIds = new ObservableCollection<IntModel>();
            IntModel model = new IntModel(bc, 100);
            BoardsIds.Add(model);
            // boardIds = (List<int>)(bc.getBoards(user.Email).ReturnValue);
        }
    }
}
