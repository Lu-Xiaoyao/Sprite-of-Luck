using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StroyControl : MonoBehaviour
{
    // 台词和人名
    public List<string> lines = new List<string>();
    public List<string> names = new List<string>();

    public Button nameTagButton; 
    public TextMeshProUGUI dialogText; // 对话内容Text
    public TextMeshProUGUI nameText;   // 人名Text
    public PlayerControl[] playerControls;

    private int index = 0;
    [SerializeField] private AudioSource storySound;

    // Start is called before the first frame update
    void Start()
    {
        nameTagButton = transform.Find("NameTag").GetComponent<Button>();
        dialogText = transform.Find("Content").GetComponent<TextMeshProUGUI>();
        nameText = transform.Find("NameTag/Content").GetComponent<TextMeshProUGUI>();
        playerControls = GameObject.FindObjectsOfType<PlayerControl>();
        foreach (PlayerControl playerControl in playerControls)
        {
            playerControl.enabled = false;
        }
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            lines = new List<string> {
                "都离我远点，靠近我的人都会变得不幸。",
                "哈哈，没事！我的运气最好了，刚好分你一些。"
            };
            names = new List<string> {
                "雅雅", 
                "杉杉"
            };
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            lines = new List<string> {
                "不要再靠近了。我说的厄运是认真的，不是什么玩笑话……你不会懂的。",
                "我知道。半妖，“禁忌的结合，世人乃至自身都无法理解的能力，不该存在之物”——",
                "因为，我也是。"
            };
            names = new List<string> {
                "雅雅", 
                "杉杉",
                "杉杉"
            };
        }
        else if(SceneManager.GetActiveScene().name == "Level3")
        {
            lines = new List<string> {
                "怎么样，真没事吧？所以要不要——试着靠近一点？",
                "……"
            };
            names = new List<string> {
                "杉杉",
                "雅雅"
            };
        }
        // 初始化显示第一句
        ShowCurrentLine();
        // 监听点击
        GetComponent<Button>().onClick.AddListener(NextLine);
    }

    void ShowCurrentLine()
    {
        if (index < lines.Count)
        {
            dialogText.text = lines[index];
            nameText.text = names[index];
        }
    }

    void NextLine()
    {
        storySound.Play();
        index++;
        if (index < lines.Count)
        {
            ShowCurrentLine();
        }
        else
        {
            // 播放音效后延迟隐藏
            StartCoroutine(HideAfterSound());
        }
    }

    IEnumerator HideAfterSound()
    {
        yield return new WaitForSeconds(storySound.clip.length);
        gameObject.SetActive(false);
        if (nameTagButton != null)
            nameTagButton.gameObject.SetActive(false);
        foreach (PlayerControl playerControl in playerControls)
        {
            playerControl.enabled = true;
        }
    }
}
