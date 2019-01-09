using System;
using System.Collections.Generic;
using System.Text;

namespace Limoee.Infrastructure.Domain
{
    public abstract class BaseValueObject 
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        protected static bool EqualOperator(BaseValueObject left, BaseValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }


        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();

            if (_brokenRules.Count <= 0) return;
            var issues = new StringBuilder();
            foreach (var businessRule in _brokenRules)
            {
                issues.AppendLine(businessRule.Rule);
            }
            throw new Exception(issues.ToString());
        }
        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        
    }
}
