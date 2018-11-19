using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public class InsuranceRepository
    {
        private List<InsuranceContent> _insuranceContentList = new List<InsuranceContent>();
        public void AddInsuranceContentToList(InsuranceContent content)
        {
            _insuranceContentList.Add(content);
        }
        public List<InsuranceContent> GetInsuranceContentList()
        {
            return _insuranceContentList;
        }
        public void RemoveMenuContentFromList(InsuranceContent content)
        {
            _insuranceContentList.Remove(content);
        }
    }
}
