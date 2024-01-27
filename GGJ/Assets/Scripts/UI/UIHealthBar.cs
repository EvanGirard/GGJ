using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIHealthBar : MonoBehaviour
{
    #region Attributes

    [SerializeField] private RectTransform fillRectTransform;
    [SerializeField] private Image fillColor;
    [SerializeField] private AnimationCurve moveBarAnimationCurve;

    private static float _capacity = 50f; //Max 100f
    private float _fill = 1f;

    #endregion


    #region Other Methods

    public float GetCapacity()
    {
        return _capacity;
    }
    
    public void SetCapacity(float newCap)
    {
        StartCoroutine(MoveBarCoroutine(newCap));
    }

    private IEnumerator MoveBarCoroutine(float newCap)
    {
        var duration = moveBarAnimationCurve.keys[^1].time;
        var timeLeft = duration;
        
        while (timeLeft > 0)
        {
            _fill = Mathf.Lerp(_capacity / 100f, newCap / 100f, duration - timeLeft);
        
            var anchorMax = new Vector2(x: fillRectTransform.anchorMax.x, _fill);
            fillRectTransform.anchorMax = anchorMax;
            
            fillColor.color = Color.Lerp(Color.blue, Color.green, _fill);
            
            yield return null;
            timeLeft -= Time.deltaTime;
        }

        _capacity = newCap;
    }
    
    #endregion



    #region Unity Event
    
    protected void Start()
    {
        fillColor.color = Color.Lerp(Color.blue, Color.green, _fill);
        
        
        _fill = _capacity / 100f;
        
        var anchorMax = new Vector2(x: fillRectTransform.anchorMax.x, _fill);
        fillRectTransform.anchorMax = anchorMax;
    }

    #endregion
}