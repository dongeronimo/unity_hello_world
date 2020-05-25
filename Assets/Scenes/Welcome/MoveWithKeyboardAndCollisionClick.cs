using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class MoveWithKeyboardAndCollisionClick : MonoBehaviour
{
    public Button button;
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
        SceneManager.LoadScene("Scenes/CameraFollowing/CameraFollowing");
    }
}
