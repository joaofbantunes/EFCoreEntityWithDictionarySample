using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreEntityWithDictionarySample
{
    public class Something
    {
        private readonly DictionaryProxy<Guid, AnotherThing> _efTargetThings;
        private Dictionary<Guid, AnotherThing> _things;

        public Something()
        {
            Id = Guid.NewGuid();
            _things = new Dictionary<Guid, AnotherThing>();
            _efTargetThings = new DictionaryProxy<Guid, AnotherThing>(() => _things, thing => thing.Id);
        }

        private DictionaryProxy<Guid, AnotherThing> EfTargetThings
        {
            get => _efTargetThings;
            set => _things = value is null || value.Count == 0 ? _things : value.ToDictionary(t => t.Id, t => t);
        }

        public Guid Id { get; private set; }

        public IReadOnlyCollection<AnotherThing> Things => _things.Values;

        public void AddAnotherThing(AnotherThing anotherThing)
        {
            _things.Add(anotherThing.Id, anotherThing);
        }
    }
}
