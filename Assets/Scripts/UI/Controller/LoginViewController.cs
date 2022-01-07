using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class LoginViewController : BaseViewController
    {
        private LoginView view;

        protected override void Init(params object[] args)
        {
            base.Init(args);
            view = new LoginView(exporter);
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