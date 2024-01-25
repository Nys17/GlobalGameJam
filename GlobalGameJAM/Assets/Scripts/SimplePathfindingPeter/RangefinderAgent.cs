using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangefinderAgent : PathfindingAgent
{
    #region Variables

    [SerializeField] float targetDistance;

    #endregion

    #region Late/Update
    new protected void Update()
    {
        base.Update();
        MeasureDistanceToTarget();
    }
    #endregion

    #region Custom Methods
    public void MeasureDistanceToTarget()
    {
        if (isTargetCloserThen(targetDistance))
        {
            ExecuteDistanceMethod();
        }
    }

    protected virtual void ExecuteDistanceMethod()
    {
        Debug.Log("I'm within range to the target!");
    }
    #endregion
}
