
using UnityEngine;
using UnityEngine.SceneManagement; //引用場景管理器API

public class MenuManager : MonoBehaviour
{
    //使用靜態方法處理 1.開始遊戲 2. 離開遊戲
    //如何讓按鈕跟程式溝通
    //需要一個公開的方法
    public void StartGame()
    {
        Player.Life = 3; 
        //MonoBehavior.(<-不用寫)Invoke 延遲呼叫
        Invoke("DelayStartGame", 1.1f);
    }

    public void DelayStartGame()
    {
        //場景管理.載入場景("場景名稱")
        //Application.LoadLevel("遊戲畫面");//綠色蚯蚓：過時的API，建議換新的
        //SceneManager.LoadScene("遊戲畫面");//也可以這樣
    
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        //Invoke 延遲呼叫
        Invoke("DelayQuitGame()", 1.1f);
    }

    private void DelayQuitGame()
    {
        //應用程式.離開()
        Application.Quit();
    }
}
