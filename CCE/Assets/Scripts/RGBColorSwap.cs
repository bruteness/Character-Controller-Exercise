using System.Collections;
using UnityEngine;
using TMPro;

public class RGBColorSwap : MonoBehaviour
{
    public float changeSpeed;
    public TextMeshProUGUI text;
    private bool _isChanging;
    private int _colorChangeState = 0; // Represents values 0-5 for the RedInc = 0, RedDec = 1, BlueInc = 2, BlueDec = 3, GreenInc = 4, GreenDec = 5
    private float[] rbg = new float[3]{0, 0, 0}; // {red, blue, green}

    private void Start() {
        text = GetComponent<TextMeshProUGUI>(); //get the text component of the object
        _isChanging = false; //make sure it will always be false at the start of the game
    }
    // Update is called once per frame
    void Update()
    {
        if(!_isChanging)
        {
            StartCoroutine(ChangeColor());
        }
    }
    public IEnumerator ChangeColor()
    {
        _isChanging = true; // don't allow it to change again until it's finished
        text.color = ChangeColorValue();
        yield return new WaitForSeconds(changeSpeed);
        _isChanging = false; // allow the color to change again
    }

    public void IncrementColorValue(int colorValue)
    {
        if(rbg[colorValue] < 1)
        {
            rbg[colorValue] += .1f;
        }
        else
        {
            _colorChangeState++;
        }
    }
    public void DecrementColorValue(int colorValue)
    {
        if(rbg[colorValue] > 0)
        {
            rbg[colorValue] -= .1f;
        }
        else
        {
            if(_colorChangeState < 5)
            {
                _colorChangeState++;
            }
            else
            {
                _colorChangeState = 0;
            }
        }
    }
    // 
    public Color ChangeColorValue()
    {
        switch(_colorChangeState)
        {
            case 0: // Red Increment
                IncrementColorValue(0);
            break;
            case 1: // Blue Decrement
                DecrementColorValue(1);
            break;
            case 2: // Green Increment
                IncrementColorValue(2);
            break;
            case 3: // Red Decrement
                DecrementColorValue(0);
            break;
            case 4: // Blue Increment
                IncrementColorValue(1);
            break;
            case 5: // Green Decrement
                DecrementColorValue(2);
            break;
            default:
                Debug.Log("_colorChangeState not accepted!");
            break;
        }
        return new Color(rbg[0], rbg[1], rbg[2]);
    }
}
