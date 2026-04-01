using UnityEngine;

public interface Interactable
{
    void Interact();
}

// 资源交互实现
public class ResourceInteractable : MonoBehaviour, Interactable
{
    public string resourceType;
    public int amount = 1;
    
    public void Interact()
    {
        // 实现资源采集逻辑
        Debug.Log("采集到" + amount + "个" + resourceType);
        // 可以在这里添加资源到玩家 inventory 的逻辑
        Destroy(gameObject);
    }
}

// 建筑交互实现
public class BuildingInteractable : MonoBehaviour, Interactable
{
    public string buildingName;
    
    public void Interact()
    {
        // 实现建筑交互逻辑
        Debug.Log("与" + buildingName + "交互");
        // 可以在这里添加建筑功能逻辑，比如打开UI面板等
    }
}