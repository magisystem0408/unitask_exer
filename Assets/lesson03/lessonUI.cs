using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class lessonUI : MonoBehaviour
{
    [SerializeField] private Button button;
    
    async void Start()
    {
        Debug.Log("ボタンが押されるまでまつ");
        var event_hander = button.GetAsyncClickEventHandler();
        
        // UIボタンが押されるまでまつ
        await event_hander.OnClickAsync();
        Debug.Log("押されたよ");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
