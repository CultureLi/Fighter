using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameWork.UI
{
    public class ViewControllerBase : UIControllerBase
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

        public void BindUIEvent(GameObject go, UIEventTrigger.UIEventType eType, System.Action callBack)
        {
            UIEventTrigger trigger = go.GetComponent<UIEventTrigger>();
            if (trigger == null)
            {
                trigger = go.AddComponent<UIEventTrigger>();
            }
            trigger.BindUIEvent(eType, callBack);
        
        }
        public void UnbindUIEvent(GameObject go, UIEventTrigger.UIEventType eType, System.Action callBack)
        {
            UIEventTrigger trigger = go.GetComponent<UIEventTrigger>();
            if (trigger == null)
            {
                trigger = go.AddComponent<UIEventTrigger>();
            }
            trigger.UnbindUIEvent(eType, callBack);
        }

        protected virtual void Init(params object[] args) { }
        protected virtual void OnOpen(params object[] args) { }
        protected virtual void OnClose(params object[] args) { }
    }
}

