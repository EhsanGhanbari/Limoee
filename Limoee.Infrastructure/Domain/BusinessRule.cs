namespace Limoee.Infrastructure.Domain
{
    public class BusinessRule
    {
        public BusinessRule(string property, string rule)
        {
            Rule = rule;
            Property = property;
        }

        public string Property { get; set; }

        public string Rule { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Property, Rule);
        }
    }
}
