using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingOpenClose : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    private bool _open = false;
    
    
    public void ChekOpenOrClose()
    {
        if (!_open)
        {
            setting.SetActive(true);
            _open = true;
        }
        else
        {
            setting.SetActive(false);
            _open = false;
        }
        
    }
}
