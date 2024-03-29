using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIHealthBar : MonoBehaviour
{
    #region Attributes

    [SerializeField] private Image fillImage;
    [SerializeField] private AnimationCurve moveBarAnimationCurve;
    [SerializeField] private Player playerScript;
    [SerializeField] private BossManager bossScript;

    private float _capacity = 100f; //Max 200f
    private float _tmpCapacity = 0f;
    private bool _inTransition = false;

    #endregion


    #region Other Methods

    public float GetCapacity()
    {
        return _capacity;
    }
    
    public void ChangeCapacity(float delta)
    {
        if (_inTransition)
        {
            _tmpCapacity += delta;
        }
        else
        {
            if (_capacity >= 200f)
            {
                bossScript.enabled = false;
                return;
            }
            if (_capacity <= 0f) return;
            
            var newCap = _capacity + _tmpCapacity + delta;
            if (newCap >= 200f) newCap = 200f;
            if (newCap <= 0f) newCap = 0f;
            
            _tmpCapacity = 0f;
            StartCoroutine(MoveBarCoroutine(_capacity, newCap));
        }
    }

    private IEnumerator MoveBarCoroutine(float cap, float newCap)
    {
        _inTransition = true;
        
        var duration = moveBarAnimationCurve.keys[^1].time;
        var timeLeft = duration;
        
        while (timeLeft > 0)
        {
            fillImage.fillAmount = Mathf.Lerp(cap / 200f, newCap / 200f, duration - timeLeft);
            
            fillImage.color = Color.Lerp(Color.blue, Color.green, fillImage.fillAmount);
            
            yield return null;
            timeLeft -= Time.deltaTime;
        }

        _capacity = newCap;
        if (_capacity <= 0 || _capacity >= 200f)
        {
            playerScript.SetCanMove(false);
        }
        
        _inTransition = false;
        if (_tmpCapacity != 0)
        {
            ChangeCapacity(0f);
        }
    }
    
    #endregion



    #region Unity Event
    
    protected void Start()
    {
        fillImage.fillAmount = _capacity / 200f;
        fillImage.color = Color.Lerp(Color.blue, Color.green, fillImage.fillAmount);
    }

    #endregion
}