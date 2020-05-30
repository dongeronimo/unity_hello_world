using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class IsInMobileWebGL : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    private bool _isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_isMobile() == false)
        {
            GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }
    }

}
