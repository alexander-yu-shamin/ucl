using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  UCL.Assets.Scripts.Extensions.ObjectExtension
{
    public static class ObjectExtension
    {
        public static bool IsNullOrEmpty<T>(this IList<T> value)
        {
            return value == null || value.Count == 0;
        }

    }
    
}
