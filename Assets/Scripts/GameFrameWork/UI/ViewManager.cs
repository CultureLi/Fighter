using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFrameWork.Res;
namespace GameFrameWork.UI
{
    public class ViewManager:Basic.Singleton<ViewManager>
    {
        public ViewManager()
        {
        
        }

        public void OpenView(string viewName)
        {
            string path = string.Format("{0}/{1}/{2}{3}","Assets", "Resources/UI/View",viewName,".prefab");
            var prefab = ResManager.Load<GameObject>(path);
            var go = GameObject.Instantiate<GameObject>(prefab);
            if (go != null)
                go.GetComponent<ViewControllerBase>().Open();
        }
    }
}
