using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldToLoad : MonoBehaviour
{
    public float holdDuration = 1f; // How long you have to hold down for
    public UnityEngine.UI.Image fillCircle;
    private bool isHolding = false;
    private float holdTimer = 0;
    public static event Action OnHoldComplete;

    // Update is called once per frame
    void Update()
    {
        if(isHolding)
        {
            holdTimer += Time.deltaTime;
            fillCircle.fillAmount = holdTimer / holdDuration;
            if(holdTimer >= holdDuration)
            {
                // Load next level
                OnHoldComplete.Invoke();
                ResetHold();
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            isHolding = true;
        }
        else if(context.canceled)
        {
            ResetHold();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0;
        fillCircle.fillAmount = 0;
    }
}
