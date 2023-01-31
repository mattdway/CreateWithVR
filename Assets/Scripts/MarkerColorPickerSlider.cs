using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarkerColorPickerSlider : MonoBehaviour
{
    public GameObject largerCylinderLid;
    public GameObject smallerCylinderLid;
    public GameObject handleMiddle;
    public GameObject visibleTip;
    public GameObject hiddenTip;
    public GameObject expoFontOneOvalFront;
    public GameObject expoFontTwoOvalFront;
    public GameObject expoFontOneOvalBack;
    public GameObject expoFontTwoOvalBack;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public TextMeshProUGUI redValueDisplay;
    public TextMeshProUGUI greenValueDisplay;
    public TextMeshProUGUI blueValueDisplay;
    private Material largerCylinderLidMaterial;
    private Material smallerCylinderLidMaterial;
    private Material handleMiddleMaterial;
    private Material visibleTipMaterial;
    private Material hiddenTipMaterial;
    private TextMeshProUGUI expoFontOneOvalFrontTMP;
    private TextMeshProUGUI expoFontTwoOvalFrontTMP;
    private TextMeshProUGUI expoFontOneOvalBackTMP;
    private TextMeshProUGUI expoFontTwoOvalBackTMP;

    void Start()
    {
        Renderer largerCylinderLidRenderer = largerCylinderLid.GetComponent<Renderer>();
        largerCylinderLidMaterial = largerCylinderLidRenderer.material;

        Renderer smallerCylinderLidRenderer = smallerCylinderLid.GetComponent<Renderer>();
        smallerCylinderLidMaterial = smallerCylinderLidRenderer.material;

        Renderer handleMiddleRenderer = handleMiddle.GetComponent<Renderer>();
        handleMiddleMaterial = handleMiddleRenderer.material;

        Renderer visibleTipRenderer = visibleTip.GetComponent<Renderer>();
        visibleTipMaterial = visibleTipRenderer.material;

        Renderer hiddenTipRenderer = hiddenTip.GetComponent<Renderer>();
        hiddenTipMaterial = hiddenTipRenderer.material;

        expoFontOneOvalFrontTMP = expoFontOneOvalFront.GetComponentInChildren<TextMeshProUGUI>();
        expoFontTwoOvalFrontTMP = expoFontTwoOvalFront.GetComponentInChildren<TextMeshProUGUI>();
        expoFontOneOvalBackTMP = expoFontOneOvalBack.GetComponentInChildren<TextMeshProUGUI>();
        expoFontTwoOvalBackTMP = expoFontTwoOvalBack.GetComponentInChildren<TextMeshProUGUI>();

        redSlider.onValueChanged.AddListener(UpdateRedValueDisplay);
        greenSlider.onValueChanged.AddListener(UpdateGreenValueDisplay);
        blueSlider.onValueChanged.AddListener(UpdateBlueValueDisplay);
    }

    void Update()
    {
        Color color = new Color(redSlider.value, greenSlider.value, blueSlider.value, 1.0f);
        color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));

        largerCylinderLidMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        smallerCylinderLidMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        handleMiddleMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        visibleTipMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        hiddenTipMaterial.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));

        expoFontOneOvalFrontTMP.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        expoFontTwoOvalFrontTMP.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        expoFontOneOvalBackTMP.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
        expoFontTwoOvalBackTMP.color = new Color(Mathf.GammaToLinearSpace(color.r), Mathf.GammaToLinearSpace(color.g), Mathf.GammaToLinearSpace(color.b));
    }

    private void UpdateRedValueDisplay(float value)
    {
        redValueDisplay.text = value.ToString();
    }

    private void UpdateGreenValueDisplay(float value)
    {
        greenValueDisplay.text = value.ToString();
    }

    private void UpdateBlueValueDisplay(float value)
    {
        blueValueDisplay.text = value.ToString();
    }
}