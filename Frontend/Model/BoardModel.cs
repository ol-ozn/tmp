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
        // public int Id { get; set; }
        public BoardModel(BackendController bc, UserModel UserModel) : base(bc)
        {
            this.user = UserModel;
            // Id=1000;
            List<int> list = (List<int>)(bc.getBoards(user.Email).ReturnValue);
            BoardsIds = new ObservableCollection<IntModel>(list.
            Select((c, i) => new IntModel(bc, list[i])));
            // BoardsIds = new ObservableCollection<IntModel>();
            // IntModel model = new IntModel(bc, 100);
            // BoardsIds.Add(model);
            // boardIds = (List<int>)(bc.getBoards(user.Email).ReturnValue);
        }
    }
}
