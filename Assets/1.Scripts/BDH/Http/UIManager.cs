using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Image url를 반영하는 Image UI 
    public Image downLoadImage;

    // Todos_List UI 버튼 클릭 리스너 -> RequestType.GET
    public void OnClickTodos()
    {
        HttpInfo info = new HttpInfo();
        info.SetInfo(RequestType.GET, "/todos", (DownloadHandler downLoadHandler) => {
            print("todos : " + downLoadHandler.text);
        });

        HttpManager.Get().SendRequest(info);

    }

    // Comments UI 버튼 클릭 리스너 -> RequestType.GET
    public List<CommentInfo> comments;
    public void OnClickComments()
    {
        HttpInfo info = new HttpInfo();
        info.SetInfo(RequestType.GET, "/comments", (DownloadHandler downLoadHandler) =>
        {
            print("comments : " + downLoadHandler.text);
            string jsonData = "{\"data\" : " + downLoadHandler.text + "}";

            //응답 받은 jsonData 를 변수에 parsing 
            JsonList<CommentInfo> commentList = JsonUtility.FromJson<JsonList<CommentInfo>>(jsonData);

            comments = commentList.data;
        });

        HttpManager.Get().SendRequest(info);
    }

    // 회원가입 SignUp UI 버튼 클릭 리스너 -> RequestType.POST
    public void PostTest()
    {
        HttpInfo info = new HttpInfo();
        info.SetInfo(RequestType.POST, "/create/signUp", (DownloadHandler downLoadHandler) =>
        {
            // Post 데이터 전송했을 때 서버로부터 응답.
        });

        SignUpInfo signUpInfo = new SignUpInfo();
        signUpInfo.userName = "test";
        signUpInfo.birthday = "test";
        signUpInfo.age = 22;


        info.body = JsonUtility.ToJson(signUpInfo);

        HttpManager.Get().SendRequest(info);
    }

    // ImageDownLoad UI 버튼 클릭 리스너 -> RequestType.GET
    public void OnClickDownLoadImage()
    {
        //https://via.placeholder.com/150/f9cee5

        HttpInfo info = new HttpInfo();
        info.SetInfo(RequestType.TEXTURE, "https://via.placeholder.com/150/f9cee5", (DownloadHandler downloadHandler) =>
        {
            // 다운로드된 Image 데이터를 Sprite로 만든다. 
            // Texture2D - > Sprite
            Texture2D texture = ((DownloadHandlerTexture)downloadHandler).texture;
            downLoadImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }, false);
        
        HttpManager.Get().SendRequest(info);
    }

}
