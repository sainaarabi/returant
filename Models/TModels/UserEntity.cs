

namespace Models.TModels
{
    public class UserEntity : Base.ExtendedEntity
    {

        public string Name { get; set; }
        public string Family { get; set; }
        public string NationCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool Role { get; set; }
    }
}
