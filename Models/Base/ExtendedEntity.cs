namespace Models.Base
{
    public abstract class ExtendedEntity : Base.Entity
    {
        public bool IsActive { get; set; }
        public System.DateTime UpdateDateTime { get; set; }
    }

}