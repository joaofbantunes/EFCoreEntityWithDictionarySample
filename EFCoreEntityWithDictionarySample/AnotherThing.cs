using System;

namespace EFCoreEntityWithDictionarySample
{
    public class AnotherThing
    {
        public AnotherThing()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
