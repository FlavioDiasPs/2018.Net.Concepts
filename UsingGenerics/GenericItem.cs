using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UsingGenerics
{
    public class GenericItem<K, V>
    {
        private struct ItemStruct
        {
            public K key;
            public V value;
        }

        private List<ItemStruct> _ListItens { get; set; } = new List<ItemStruct>();

        public GenericItem()
        {            
        }

        public GenericItem(K key, V value)
        {
            this.Add(key, value);
        }

        public GenericItem(K[] key, V[] value)
        {
            this.AddRange(key, value);
        }



        public V FindFirst(K key)
        {
            V value = default(V);
            foreach (var currentItem in _ListItens)
            {
                if (currentItem.key.Equals(key))
                {
                    value = currentItem.value;
                    break;
                }
            }
            return value;
        }

        public void Add(K key, V value)
        {
            var item = new ItemStruct
            {
                key = key,
                value = value
            };

            _ListItens.Add(item);
        }

        public void AddRange(K[] key, V[] value)
        {          
            for(int i = 0; i < key.Length; i++)
            {
                var item = new ItemStruct
                {
                    key = (K)key.GetValue(i),
                    value = (V)value.GetValue(i)
                };
               
                _ListItens.Add(item);
            }            
        }

        public V this[K key]
        {
            get { return FindFirst(key); }
        }

    }
}
