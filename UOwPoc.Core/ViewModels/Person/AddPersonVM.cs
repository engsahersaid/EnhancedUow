using UOwPoc.Core.ViewModels.Address;

namespace UOwPoc.Core.ViewModels.Person
{
    public class AddPersonVM
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }
        public int Age { get; set; }
        public IList<AddAddressVM>? Addresses { get; init; }
    }
}