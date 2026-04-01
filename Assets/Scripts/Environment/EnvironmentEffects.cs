using UnityEngine;

public class EnvironmentEffects : MonoBehaviour
{
    public EnvironmentManager environmentManager;
    public ParticleSystem radiationEffect;
    public ParticleSystem toxicGasEffect;
    public Light temperatureLight;
    
    void Update()
    {
        if (environmentManager != null)
        {
            // 控制辐射效果
            float radiationLevel = environmentManager.GetParameterValue("Radiation");
            if (radiationLevel > 50)
            {
                if (!radiationEffect.isPlaying)
                {
                    radiationEffect.Play();
                }
                radiationEffect.emissionRate = radiationLevel / 10;
            }
            else
            {
                if (radiationEffect.isPlaying)
                {
                    radiationEffect.Stop();
                }
            }
            
            // 控制有毒气体效果
            float toxicGasLevel = environmentManager.GetParameterValue("ToxicGas");
            if (toxicGasLevel > 30)
            {
                if (!toxicGasEffect.isPlaying)
                {
                    toxicGasEffect.Play();
                }
                toxicGasEffect.emissionRate = toxicGasLevel / 5;
            }
            else
            {
                if (toxicGasEffect.isPlaying)
                {
                    toxicGasEffect.Stop();
                }
            }
            
            // 控制温度灯光效果
            float temperature = environmentManager.GetParameterValue("Temperature");
            if (temperature > 40)
            {
                temperatureLight.color = new Color(1, 0.5f, 0); // 高温红色
                temperatureLight.intensity = (temperature - 40) / 20;
            }
            else if (temperature < 0)
            {
                temperatureLight.color = new Color(0, 0.5f, 1); // 低温蓝色
                temperatureLight.intensity = Mathf.Abs(temperature) / 20;
            }
            else
            {
                temperatureLight.color = new Color(1, 1, 1); // 正常温度白色
                temperatureLight.intensity = 0.5f;
            }
        }
    }
}