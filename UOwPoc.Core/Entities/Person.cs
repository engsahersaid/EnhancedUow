using System.Text;
using UOwPoc.Core.Entities;
using UOwPoc.Core.Entities.Base;

namespace UOWPoc.Entities
{
    public class Person : BaseAuditableEntity
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }
        public int Age { get; init; }
        public virtual Nationality Nationality { get; init; }
        public virtual ICollection<Address> Addresses { get; init; }

        public Person() : base(Guid.NewGuid())
        {
        }

        public Person(Guid id, string firstName, string lastName, int nationalityId, int age) : base(id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NationalityId = nationalityId;
            Age = age;
        }

        public Person(Guid id, string firstName, string lastName, int nationalityId, List<Address> addresses, int age) : this(id, firstName, lastName, nationalityId, age)
        {
            Addresses = addresses;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Id: {Id}, Name: {FirstName + " " + LastName}");
            return builder.ToString();
        }
    }
}