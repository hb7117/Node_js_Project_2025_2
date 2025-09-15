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
    public string host;                        //IP �ּ�(���ÿ��� 127.0.0.1)
    public int port;                           //��Ʈ �ּ� (3000������ express ����)
    public string route;                       //about �ּ�

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
    private IEnumerator GetData(string url, System.Action<string> callback)   //GET ��û�ϴ� �ڷ�ƾ �Լ� 
    {
        var webRequest = UnityWebRequest.Get(url);                            //�� ��û Get
        yield return webRequest.SendWebRequest();                             //��û�� ���ƿö����� ���

        Debug.Log("Get :" + webRequest.downloadHandler.text);
        if (webRequest.result == UnityWebRequest.Result.ConnectionError
            || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("��Ʈ��ũ ȯ���� ���� �ʾ� ��� �Ұ���");
        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }
    }



    private IEnumerator PostData(string url, System.Action<string> callback)   //GET ��û�ϴ� �ڷ�ƾ �Լ� 
    {
        var webRequest = new UnityWebRequest(url, "POST");                            //�� ��û POST
        var bodyRaw = Encoding.UTF8.GetBytes(json);                                   //����ȭ

        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();                             //��û�� ���ƿö����� ���

        if (webRequest.result == UnityWebRequest.Result.ConnectionError
            || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("��Ʈ��ũ ȯ���� ���� �ʾ� ��� �Ұ���");
        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }

        webRequest.Dispose();                                                  //�� ��û�� �޸𸮿��� ����
    }
}
