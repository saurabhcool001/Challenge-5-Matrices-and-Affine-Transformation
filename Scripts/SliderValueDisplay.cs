using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueDisplay : MonoBehaviour
{
    // Slider and Text references
    public Slider rotationXSlider;
    public TMP_Text rotationXText;

    public Slider rotationYSlider;
    public TMP_Text rotationYText;

    public Slider rotationZSlider;
    public TMP_Text rotationZText;

    public Slider scaleSlider;
    public TMP_Text scaleText;

    public Slider translationXSlider;
    public TMP_Text translationXText;

    public Slider translationYSlider;
    public TMP_Text translationYText;

    public Slider translationZSlider;
    public TMP_Text translationZText;

    void Update()
    {
        // Update the text to show the current slider value
        //rotationXText.text = $"Rotation X: {rotationXSlider.value:F2}";
        //rotationYText.text = $"Rotation Y: {rotationYSlider.value:F2}";
        //rotationZText.text = $"Rotation Z: {rotationZSlider.value:F2}";

        //scaleText.text = $"Scale: {scaleSlider.value:F2}";

        //translationXText.text = $"Translation X: {translationXSlider.value:F2}";
        //translationYText.text = $"Translation Y: {translationYSlider.value:F2}";
        //translationZText.text = $"Translation Z: {translationZSlider.value:F2}";
        rotationXText.text = $"{rotationXSlider.value:F2}";
        rotationYText.text = $"{rotationYSlider.value:F2}";
        rotationZText.text = $"{rotationZSlider.value:F2}";

        scaleText.text = $"{scaleSlider.value:F2}";

        translationXText.text = $"{translationXSlider.value:F2}";
        translationYText.text = $"{translationYSlider.value:F2}";
        translationZText.text = $"{translationZSlider.value:F2}";
    }
}