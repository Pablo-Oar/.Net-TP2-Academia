using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private States _State;
        private int _ID;


        public BusinessEntity()
        {
            this.State = States.New;
        }

        public States State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }


    }
}
