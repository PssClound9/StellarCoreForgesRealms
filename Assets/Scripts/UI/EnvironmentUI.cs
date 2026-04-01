using UnityEngine;
using UnityEngine.UI;

public class EnvironmentUI : MonoBehaviour
{
    public EnvironmentManager environmentManager;
    public Text temperatureText;
    public Text radiationText;
    public Text toxicGasText;
    
    void Update()
    {
        if (environmentManager != null)
        {
            // 更新环境参数显示
            temperatureText.text = "温度: " + environmentManager.GetParameterValue("Temperature").ToString("F1") + "°C";
            radiationText.text = "辐射: " + environmentManager.GetParameterValue("Radiation").ToString("F1") + " mSv";
            toxicGasText.text = "有毒气体: " + environmentManager.GetParameterValue("ToxicGas").ToString("F1") + "%";
        }
    }
}