using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private AudioSource hoverSound;

    public void OnPointerEnter()
    {
        hoverSound.Play();
    }

    public void Quit()
    {
        // 在编辑器中停止播放模式
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在构建版本中退出应用
        Application.Quit();
#endif
    }
}
