using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmBuy : MonoBehaviour
{
    public Action Confirm;

    public void CanConfirmBuy()
    {
        if (Confirm != null) Confirm();
    }
}
