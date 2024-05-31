using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Assets.Scripts.Library
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [Serializable]
        class KeyValueClass
        {
            public TKey Key;
            public TValue Value;
        }

        [SerializeField]
        private List<KeyValueClass> structs = new List<KeyValueClass>();
        private TKey default_key;

        public SerializableDictionary(TKey default_key)
        {
            this.default_key = default_key;
        }

        public void OnBeforeSerialize()
        {
            structs.Clear();

            foreach (var kvp in this)
            {
                structs.Add(new KeyValueClass() { Key = kvp.Key, Value = kvp.Value });
            }
        }

        public void OnAfterDeserialize()
        {
            this.Clear();

            foreach (var item in structs)
            {
                if (this.ContainsKey(item.Key))
                {
                    this.Add(default_key, item.Value);
                }
                else
                {
                    this.Add(item.Key, item.Value);
                }
            }
        }
    }
}