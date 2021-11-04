using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;

namespace Business.Logic
{
    public class PlanLogic
    {

        private Data.Database.PlanAdapter _PlanData;

        public Data.Database.PlanAdapter PlanData
        {
            get
            {
                return _PlanData;
            }
            set
            {
                _PlanData = value;
            }
        }

        public PlanLogic()
        {
            this.PlanData = new Data.Database.PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public Plan GetOne(int IdPlan)
        {
            return PlanData.GetOne(IdPlan);
        }
        public void Delete(int IdPlan)
        {
            PlanData.Delete(IdPlan);
        }
        public void Save(Plan p)
        {
            PlanData.Save(p);
        }
    }
}
