using UnityEngine;
using Unity.Mathematics;

public class LightCycle : MonoBehaviour
{
    public Light directionalLight;
    public Light[] pointLight;
    private Transform player;
    private float colorTemp;
    private float intensity;
    private float playerHeight;
    private float targetRotX;
    private float cooldownBlink = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        DayCycle();
        if (cooldownBlink <= 0)
        {
			pointLight[0].intensity = UnityEngine.Random.Range(0, 100);
        }
        else
        {
            cooldownBlink-= Time.deltaTime;
        }
        
    }

    private void DayCycle()
    {
        playerHeight = player.transform.position.y;
        targetRotX = math.remap(0, 90, 50, -50, playerHeight);
        colorTemp = math.remap(0, 90, 5000, 1500, playerHeight);
        intensity = math.remap(50, 90, 2, 0, playerHeight);
		foreach(Light light in pointLight)
        {
			light.intensity = math.remap(100, 104, 0, 100, playerHeight);
		}
        
		directionalLight.transform.eulerAngles = new Vector3(targetRotX,-30,0);
        directionalLight.intensity = intensity;
        directionalLight.colorTemperature = colorTemp;
    }
}
