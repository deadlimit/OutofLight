using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIFuelText : MonoBehaviour
{
    public Text fuelBarT;
    public Slider fuelSlider;
    public IntVariable stepAmount;
    public Scene currentscene;
    public FuelUI fuel;
    private void Awake()
    {
        currentscene = SceneManager.GetActiveScene();
    }
    private void FixedUpdate()
    {
        fuelBarT.text = stepAmount.GetValue().ToString() + "/" + fuelSlider.maxValue.ToString();
        fuelBarT.color = fuel.currentColor;
        if (currentscene == SceneManager.GetSceneByBuildIndex(1) || currentscene == SceneManager.GetSceneByBuildIndex(5) || currentscene == SceneManager.GetSceneByBuildIndex(6))
        {
            fuelBarT.text = "-";
        }
    }

    

}
