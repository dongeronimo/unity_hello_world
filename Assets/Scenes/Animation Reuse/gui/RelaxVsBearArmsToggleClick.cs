using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RelaxVsBearArmsToggleClick : MonoBehaviour
{
    public Animator BonecoAnimator;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (IsBonecoRelaxed())
        {
            //TODO: Se está relaxado tem que ficar armado.
        }
        else
        {
            //TODO: Se está armado tem que ficar relaxado.
        }
    }
    private bool IsBonecoRelaxed()
    {
        return BonecoAnimator.GetBool("IsRelaxed");
    }
    void Update()
    {
        UpdateButtonAppearanceBasedOnAnimatorParameters();
    }
    private void UpdateButtonAppearanceBasedOnAnimatorParameters()
    {
        if (IsBonecoRelaxed())
        {
            SetButtonToRelaxed();
        }
        else
        {
            SetButtonToArmed();
        }
    }
    private void SetButtonToRelaxed()
    {
        var colors = GetComponent<Button>().colors;
        colors.normalColor = new Color(0.754f, 0.284f, 0.284f);
        colors.highlightedColor = new Color(0.962f, 0.699f, 0.699f);
        GetComponent<Button>().colors = colors;
        GetComponentInChildren<Text>().text = "Arm";
    }
    private void SetButtonToArmed()
    {
        var colors = GetComponent<Button>().colors;
        colors.normalColor = new Color(0.531f, 0.783f, 0.594f);
        colors.highlightedColor = new Color(0.699f, 0.962f, 0.699f);
        GetComponent<Button>().colors = colors;
        GetComponentInChildren<Text>().text = "Relax";
    }
}
