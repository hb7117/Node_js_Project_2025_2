using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;

public class UnityToNode : MonoBehaviour
{
    public Button btnGetExample;
    public string host;                        //IP 주소(로컬에서 127.0.0.1)
    public int port;                           //포트 주소 (3000번으로 express 동작)
    public string route;                       //about 주소

    public void Start()
    {
        btnGetExample.onClick.AddListener(() =>
        {

            var url = string.Format("{0}:{1}/{2}", host, port, route);

            Debug.Log(url);
            StartCoroutine(GetData(url, (raw) =>
            {
                var res = JsonConvert.DeserializeObject<Protocols.Packets.common>(raw);
                Debug.LogFormat("{0}, {1}", res.cmd, res.message);
            }));
        });


    }
    private IEnumerator GetData(string url, System.Action<string> callback)   //GET 요청하는 코루틴 함수 
    {
        var webRequest = UnityWebRequest.Get(url);                            //웹 요청 Get
        yield return webRequest.SendWebRequest();                             //요청이 돌아올때까지 대기

        Debug.Log("Get :" + webRequest.downloadHandler.text);
        if (webRequest.result == UnityWebRequest.Result.ConnectionError
            || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("네트워크 환경이 좋지 않아 통신 불가능");
        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }
    }



    private IEnumerator PostData(string url, System.Action<string> callback)   //GET 요청하는 코루틴 함수 
    {
        var webRequest = new UnityWebRequest(url, "POST");                            //웹 요청 POST
        var bodyRaw = Encoding.UTF8.GetBytes(json);                                   //적렬화

        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();                             //요청이 돌아올때까지 대기

        if (webRequest.result == UnityWebRequest.Result.ConnectionError
            || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("네트워크 환경이 좋지 않아 통신 불가능");
        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }

        webRequest.Dispose();                                                  //웹 요청후 메모리에서 삭제
    }
}
