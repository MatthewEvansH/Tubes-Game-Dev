using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    void Awake()
    {
        UnityEngine.UI.Image totalhealthBar = GetComponent<UnityEngine.UI.Image>();
        UnityEngine.UI.Image currenthealthBar = GetComponent<UnityEngine.UI.Image>();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
