using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<SkinControl>ButtonInf  = new List<SkinControl>();

    public void Awake() 
    {
        foreach (var b in ButtonInf) 
        {
            b.Onclicked += UpdateAll;
        }
    }

    private void OnDestroy() 
    {
        foreach (var b in ButtonInf)
        {
            b.Onclicked -= UpdateAll;
        }
    }

    public void UpdateAll() 
    {
        foreach (var b in ButtonInf)
        {
            b.UpdateButtonState();
        }
    }


}
