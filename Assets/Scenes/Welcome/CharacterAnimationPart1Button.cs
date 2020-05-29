using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterAnimationPart1Button : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        var btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        SceneManager.LoadScene("Scenes/Character Animations/Character Animation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
