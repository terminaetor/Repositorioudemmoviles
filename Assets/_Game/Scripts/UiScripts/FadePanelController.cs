using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FadePanelController : MonoBehaviour
{

    [Header("Paneles de UI")]
    [SerializeField] private List<GameObject> panels;

    [Header("Overlay de Fade")]
    [SerializeField] private Image fadeOverlay;

    [Header("Configuración")]
    [SerializeField] private float fadeTime = 0.5f;

    /// <summary>
    /// Llama a esta función desde un botón para hacer fade al panel deseado.
    /// </summary>
    /// <param name="newIndex">Índice del panel al que deseas cambiar (según el orden en la lista).</param>
    public void SwitchPanelWithFade(int newIndex)
    {
        if (newIndex < 0 || newIndex >= panels.Count)
        {
            Debug.LogWarning("El índice del panel está fuera de rango.");
            return;
        }

        StartCoroutine(FadeToPanel(newIndex));
    }

    private IEnumerator FadeToPanel(int newIndex)
    {
        yield return StartCoroutine(Fade(0f, 1f)); // Fade IN

        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        panels[newIndex].SetActive(true);

        yield return StartCoroutine(Fade(1f, 0f)); // Fade OUT
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float timer = 0f;
        Color color = fadeOverlay.color;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, timer / fadeTime);
            fadeOverlay.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        fadeOverlay.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
