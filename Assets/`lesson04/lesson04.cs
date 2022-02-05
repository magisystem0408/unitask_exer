using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class lesson04 : MonoBehaviour
{
    private CancellationTokenSource cancellationTokenSource;

    async void Start()
    {
        // キャンセルを発生させることができる
        
        cancellationTokenSource = new CancellationTokenSource();
        try
        {
            // 5sec後にgameobjectが破壊される
            // tokenはタスクのキャンセルが要求されたか知ることができる
            await LongTask(cancellationTokenSource.Token);
        }
        catch (OperationCanceledException canceledException)
        {
            Debug.Log("キャンセルされました");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // キャンセルを要求する
            cancellationTokenSource.Cancel();
        }
    }

    private async UniTask LongTask(CancellationToken cancellationToken)
    {
        while (true)
        {
            // キャンセルがリクエスト発生させたら例外を発生させる
            cancellationToken.ThrowIfCancellationRequested();
            Debug.Log(gameObject.name);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}