using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.BusinessLayer;
using log4net;


namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class DataService
    {
        private UserController userController;
        private BoardController boardController;
        private TaskController taskController;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public DataService(UserController userController, BoardController boardController, TaskController taskController)
        {
            this.userController = userController;
            this.boardController = boardController;
            this.taskController = taskController;
        }

        public Response LoadData()
        {
            try
            {
                userController.loadData();
                boardController.loadData();
                log.Info("Data has been loaded successfully");
                return new Response(null, null);
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
                return new Response(e.Message, null);
            }
        }

        public Response DeleteData()
        {
            try
            {
                userController.resetData();
                boardController.resetData();
                taskController.resetData();
                log.Info("Data has been deleted successfully");
                return new Response(null, null);
            }
            catch (Exception e)
            {
                log.Debug(e.Message);
                return new Response(e.Message, null);
            }
        }

    }
}
