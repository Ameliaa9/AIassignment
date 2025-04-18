using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class texttrigger : MonoBehaviour
{
    public GameObject UIObject;
    public TextMeshProUGUI fadeAwayText;
    public float fadeTime = 2f;
    private float alphaValue = 1f;
    private bool isFadingOut = false;
    private bool isDestroyed = false;

    void Start()
    {
        fadeAwayText = UIObject.GetComponent<TextMeshProUGUI>();
        UIObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDestroyed)
        {
            UIObject.SetActive(true);
            alphaValue = 1f;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);
            isFadingOut = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isDestroyed)
        {
            isFadingOut = true;
        }
    }

    void Update()
    {
        if (isFadingOut && alphaValue > 0f)
        {
            alphaValue -= Time.deltaTime / fadeTime;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, alphaValue);

            if (alphaValue <= 0f)
            {
                UIObject.SetActive(false);
                isDestroyed = true;
                Destroy(UIObject);
            }
        }
    }
}