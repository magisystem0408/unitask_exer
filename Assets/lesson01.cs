using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class lesson01 : MonoBehaviour
{
    async void Start()
    {
        Debug.Log("Start");
        Debug.Log("5秒後に次のログを出します。");
        // sleepする
        await UniTask.Delay(TimeSpan.FromSeconds(5)); 
        Debug.Log("5秒経ちました");
        
        Debug.Log("wait five Seconds Method");
        await WaitFiveSecondMethod();
    }

    private async UniTask WaitFiveSecondMethod()
    {
        Debug.Log("5秒まつ");
        await UniTask.Delay(TimeSpan.FromSeconds(5));
        Debug.Log("5秒経ちました");
    }
}
