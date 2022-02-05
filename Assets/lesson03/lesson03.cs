using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class lesson03 : MonoBehaviour
{
    async void Start()
    {
        // 当たり判定のトリガー取得
        var collision_enter_trigger = this.GetAsyncCollisionEnterTrigger();
        var collision_exit_trigger = this.GetAsyncCollisionEnterTrigger();
        
        Debug.Log("接触するまでまつ");
        await collision_enter_trigger.OnCollisionEnterAsync();
        Debug.Log("接触した");
        Debug.Log("外れるまでまつ");
        await collision_exit_trigger.OnCollisionEnterAsync();
        Debug.Log("外れたよ");
    }
}
