using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOnButton : MonoBehaviour
{
    public Button button;
    public GameObject targetBox;
    // Start is called before the first frame update
    void Start()
    {
        var btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        Debug.Log("Clicou");
        var targetBoxRenderer = targetBox.GetComponent<MeshRenderer>();
        Color newColor = new Color(Random.Range(0.0f, 1.0f),
            Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        targetBoxRenderer.material.color = newColor;
    }
}
