using System.Collections.Generic;

namespace Limoee.Infrastructure.Domain
{
    public abstract class BaseEntity<TId>
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public virtual TId Id { get; set; }

        protected abstract void Validate();

        /// <summary>
        /// before persisting an entity this method will be callded to check count of 0  
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }


        public override bool Equals(object entity)
        {
            return entity != null && entity is BaseEntity<TId> && this == (BaseEntity<TId>)entity;
        }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        public static bool operator ==(BaseEntity<TId> entity1, BaseEntity<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }
            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }
            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return false;
            }
            return false;
        }
        public static bool operator !=(BaseEntity<TId> entity1, BaseEntity<TId> entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}
