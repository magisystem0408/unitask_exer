using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine.UI;

public class lesson02 : MonoBehaviour
{
    private const string URL_1 = "https://placehold.jp/3d4070/ffffff/150x150.png";
    private const string URL_2 = "https://placehold.jp/5e6c10/ffffff/150x150.png";
    [SerializeField] private RawImage image1;
    [SerializeField] private RawImage image2;

    async void Start()
    {
        // Debug.Log("ダウンロード開始");
        // var request_1 = UnityWebRequestTexture.GetTexture(URL_1);
        // await request_1.SendWebRequest();
        // // ダウンロードした画像を紐付け
        // image1.texture = DownloadHandlerTexture.GetContent(request_1);
        // Debug.Log("ダウンロード完了");
        //
        //
        // Debug.Log("ダウンロード開始");
        // var request_2 = UnityWebRequestTexture.GetTexture(URL_2);
        // await request_2.SendWebRequest();
        // image2.texture = DownloadHandlerTexture.GetContent(request_2);
        // Debug.Log("ダウンロード完了");

        // image1.texture = await DownloadText
        
        
        // 並列実行させる
        // どちらの処理も終わってから表示する
        (image1.texture, image2.texture) = await UniTask.WhenAll(DownloadTexture(URL_1), DownloadTexture(URL_2));
        
    }

    private async UniTask<Texture2D> DownloadTexture(string url)
    {
        Debug.Log("ダウンロード開始");
        var request = UnityWebRequestTexture.GetTexture(url);
        await request.SendWebRequest();
        Debug.Log("ダウンロード完了");
        return DownloadHandlerTexture.GetContent(request);
    }
}