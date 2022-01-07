using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class UIExporter : MonoBehaviour
    {
        public Component[] components;
        
       
        public T Get<T>(int index) where T:Component
        {
            if(index >=0 && index < components.Length)
            {
                return components[index] as T;
            }
            return null;
        }

        public GameObject Get(int index)
        {
            if (index >= 0 && index < components.Length)
            {
                return components[index].gameObject;
            }
            return null;
        }
    }

}
