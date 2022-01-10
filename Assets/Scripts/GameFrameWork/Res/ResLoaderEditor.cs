using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace GameFrameWork.Res
{
    public class ResLoaderEditor:ResLoaderBase
    {
        public ResLoaderEditor()
        { }

        public override T Load<T>(string path)
        {
            T res = AssetDatabase.LoadAssetAtPath<T>(path);
            return res;
        }

        public override T LoadAsync<T>(string path, System.Action<T> callBack)
        {
            return null;
        }
    }

}
