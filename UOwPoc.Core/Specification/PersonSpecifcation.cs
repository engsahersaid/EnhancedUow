using UOWPoc.Entities;

namespace UOwPoc.Core.Specification
{
    public class PersonNationalitySpecifcation : BaseSpecifications<Person>
    {
        public PersonNationalitySpecifcation(int nationalityId) : base(x => x.NationalityId == nationalityId)
        {
            AddInclude(x => x.Addresses);
            AddInclude(x => x.Nationality);
            ApplyOrderBy(x => x.Age);
            ApplyOrderByDescending(x => x.CreatedAt);
        }
    }

    public class PersonWithoutAddressSpecification : BaseSpecifications<Person>
    {
        public PersonWithoutAddressSpecification() : base()
        {
            SetFilterCondition(person => person.Addresses.Count == 0);
        }
    }

    public class PersonIsAdultSpecification : BaseSpecifications<Person>
    {
        public PersonIsAdultSpecification() : base()
        {
            SetFilterCondition(person => person.Age >= 18);
            var spec = this.And(Person => Person.Age < 90);

            SetFilterCondition(spec.FilterCondition);

            AddInclude(x => x.Addresses);
            AddInclude(x => x.Nationality);
        }
    }
}