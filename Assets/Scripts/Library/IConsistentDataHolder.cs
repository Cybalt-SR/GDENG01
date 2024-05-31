using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Library
{
    public interface IConsistentDataHolder<TData> where TData : class
    {
        public static TData Data { get; set; }
    }
}