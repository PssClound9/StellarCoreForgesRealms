using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [System.Serializable]
    public class EnvironmentParameter
    {
        public string name;
        public float currentValue;
        public float minValue;
        public float maxValue;
        public float changeRate;
    }
    
    public EnvironmentParameter temperature;
    public EnvironmentParameter radiation;
    public EnvironmentParameter toxicGas;
    
    void Start()
    {
        // 初始化环境参数
        temperature.currentValue = Random.Range(temperature.minValue, temperature.maxValue);
        radiation.currentValue = Random.Range(radiation.minValue, radiation.maxValue);
        toxicGas.currentValue = Random.Range(toxicGas.minValue, toxicGas.maxValue);
    }
    
    void Update()
    {
        // 动态更新环境参数
        UpdateEnvironmentParameter(ref temperature);
        UpdateEnvironmentParameter(ref radiation);
        UpdateEnvironmentParameter(ref toxicGas);
    }
    
    void UpdateEnvironmentParameter(ref EnvironmentParameter parameter)
    {
        // 随机波动
        float change = (Random.value - 0.5f) * parameter.changeRate * Time.deltaTime;
        parameter.currentValue += change;
        
        // 确保在范围内
        parameter.currentValue = Mathf.Clamp(parameter.currentValue, parameter.minValue, parameter.maxValue);
    }
    
    // 获取环境参数值
    public float GetParameterValue(string parameterName)
    {
        switch (parameterName)
        {
            case "Temperature":
                return temperature.currentValue;
            case "Radiation":
                return radiation.currentValue;
            case "ToxicGas":
                return toxicGas.currentValue;
            default:
                return 0;
        }
    }
}