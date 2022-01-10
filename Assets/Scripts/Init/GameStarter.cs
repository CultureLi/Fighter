using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFrameWork.UI;
using GameFrameWork.Res;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResManager.Instance.Init();
        ViewManager.Instance.OpenView("logInView");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
