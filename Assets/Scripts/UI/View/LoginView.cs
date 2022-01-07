/// <summary>
///以下代码为自动生成，请勿编辑！！
/// <summary>
using UnityEngine;

namespace UIFrameWork
{
	public class LoginView
	{
		public UnityEngine.UI.RawImage BkRImg;
		public UnityEngine.UI.InputField AccInput;
		public UnityEngine.UI.InputField PassInput;
		public UnityEngine.UI.Button LogInBtn;


		public LoginView(UIExporter exporter)
		{
			BkRImg = exporter.Get<UnityEngine.UI.RawImage>(0);
			AccInput = exporter.Get<UnityEngine.UI.InputField>(1);
			PassInput = exporter.Get<UnityEngine.UI.InputField>(2);
			LogInBtn = exporter.Get<UnityEngine.UI.Button>(3);

		}
	}
}