using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public string surfaceSceneName = "SurfaceScene";
    public string undergroundSceneName = "UndergroundScene";
    
    private bool isInUnderground = false;
    
    void Update()
    {
        // 检测玩家是否需要切换场景
        CheckSceneTransition();
    }
    
    void CheckSceneTransition()
    {
        // 简单的高度检测，低于某个阈值切换到地下场景
        float playerY = transform.position.y;
        
        if (playerY < -5 && !isInUnderground)
        {
            // 切换到地下场景
            LoadScene(undergroundSceneName);
            isInUnderground = true;
        }
        else if (playerY >= -5 && isInUnderground)
        {
            // 切换到地表场景
            LoadScene(surfaceSceneName);
            isInUnderground = false;
        }
    }
    
    void LoadScene(string sceneName)
    {
        // 异步加载场景，保持玩家位置
        Vector3 playerPosition = transform.position;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        // 加载完成后恢复玩家位置
        StartCoroutine(SetPlayerPosition(playerPosition));
    }
    
    System.Collections.IEnumerator SetPlayerPosition(Vector3 position)
    {
        yield return new WaitForEndOfFrame();
        transform.position = position;
    }
}