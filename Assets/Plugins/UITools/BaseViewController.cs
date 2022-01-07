using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class BaseViewController : UIControllerBase
    {
        protected UIExporter exporter;
        private bool bInit = false;

        public void Open(params object[] args)
        {
            if (!bInit)
            {
                exporter = GetComponent<UIExporter>();
                Init(args);
            }
            OnOpen(args);
        }

        protected virtual void Init(params object[] args) { }
        protected virtual void OnOpen(params object[] args) { }
        protected virtual void OnClose(params object[] args) { }
    }
}

