using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameWork.Res
{
    public class ResManager:Basic.Singleton<ResManager>
    {
        private static ResLoaderBase loader;

        public ResManager()
        {
            Init();
        }

        public void Init()
        {
            if (Application.isEditor)
                loader = new ResLoaderEditor();
        }

        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            return loader.Load<T>(path);
        }
    };
    
}