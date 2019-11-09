using System;
using System.Collections;
using System.Collections.Generic;

namespace EFCoreEntityWithDictionarySample
{
    public class DictionaryProxy<TKey, TValue> : ICollection<TValue>
    {
        private readonly Func<Dictionary<TKey, TValue>> _proxiedAccessor;
        private readonly Func<TValue, TKey> _keyAccessor;

        public DictionaryProxy(Func<Dictionary<TKey, TValue>> proxiedDictionaryAccessor, Func<TValue, TKey> keyAccessor)
        {
            _proxiedAccessor = proxiedDictionaryAccessor;
            _keyAccessor = keyAccessor;
        }

        public int Count => _proxiedAccessor().Count;

        public bool IsReadOnly => false;

        public void Add(TValue item) => _proxiedAccessor().Add(_keyAccessor(item), item);

        public void Clear() => _proxiedAccessor().Clear();

        public bool Contains(TValue item) => _proxiedAccessor().ContainsKey(_keyAccessor(item));

        public void CopyTo(TValue[] array, int arrayIndex) => _proxiedAccessor().Values.CopyTo(array, arrayIndex);

        public IEnumerator<TValue> GetEnumerator() => _proxiedAccessor().Values.GetEnumerator();

        public bool Remove(TValue item) => _proxiedAccessor().Remove(_keyAccessor(item));

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
