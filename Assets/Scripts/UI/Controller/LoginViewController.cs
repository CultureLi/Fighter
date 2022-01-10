using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameWork.UI
{
    public class LoginViewController : ViewControllerBase
    {
        private LoginView view;

        protected override void Init(params object[] args)
        {
            base.Init(args);
            view = new LoginView(exporter);
            BindUIEvent(view.LogInBtn.gameObject, UIEventTrigger.UIEventType.Click,OnBgnClick);
        }

        public void OnBgnClick()
        {
            Debug.Log("rrrrrrrrr");
            UnbindUIEvent(view.LogInBtn.gameObject, UIEventTrigger.UIEventType.Click, OnBgnClick);
        }

        protected override void OnOpen(params object[] args)
        {
            base.OnOpen(args);
        }

        protected override void OnClose(params object[] args)
        {
            base.OnClose(args);
        }
    }
}