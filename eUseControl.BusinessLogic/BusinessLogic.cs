using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }

       
    }
} 