using UOwPoc.Core.ViewModels.Address;

namespace UOwPoc.Core.ViewModels.Person
{
    public class UpdatePersonVM
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }
        public int Age { get; set; }
        public IList<UpdateAddressVM>? Addresses { get; init; }
    }
}