using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = player.health / 100;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.health / 100;
    }
}
