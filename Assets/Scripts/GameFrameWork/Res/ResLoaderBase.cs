using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameWork.Res
{
    public class ResLoaderBase
    {
        public virtual T Load<T>(string path) where T : UnityEngine.Object
        {
            return null;
        }

        public virtual T LoadAsync<T>(string path, System.Action<T> callBack) where T : UnityEngine.Object
        {
            return null;
        }
    }

}
