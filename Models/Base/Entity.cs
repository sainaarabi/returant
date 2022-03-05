using System;
namespace Models.Base
{
    public abstract class Entity : Object
    {
        public Entity() : base()
        {
            ID = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid ID { get; set; }
       
    }
}
