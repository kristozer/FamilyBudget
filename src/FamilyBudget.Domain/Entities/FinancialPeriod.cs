namespace FamilyBudget.Domain.Entities
{
    public class FinancialPeriod : BaseEntity
    {
        public string Name { get; private set; }

        protected FinancialPeriod()
        {
        }
        
        public FinancialPeriod(string name)
        {
            Name = name;
        }
    }
}