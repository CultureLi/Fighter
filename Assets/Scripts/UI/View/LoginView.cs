/// <summary>
///以下代码为自动生成，请勿编辑！！
/// <summary>
using UnityEngine;

namespace GameFrameWork.UI
{
	public class LoginView
	{
		public UnityEngine.UI.RawImage BkRImg;
		public GameObject EmptyGO;
		public UnityEngine.UI.InputField AccInput;
		public UnityEngine.UI.InputField PassInput;
		public UnityEngine.UI.Button LogInBtn;


		public LoginView(UIExporter exporter)
		{
			BkRImg = exporter.Get<UnityEngine.UI.RawImage>(0);
			EmptyGO = exporter.Get(1);
			AccInput = exporter.Get<UnityEngine.UI.InputField>(2);
			PassInput = exporter.Get<UnityEngine.UI.InputField>(3);
			LogInBtn = exporter.Get<UnityEngine.UI.Button>(4);

		}
	}
}