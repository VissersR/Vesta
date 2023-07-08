using System.Collections;
using System.Collections.Generic;
using Unity.Netcode.Components;
using UnityEngine;

public class OwnerNetworkAnimator : NetworkAnimator
{
    #region Overrides of NetworkAnimator

    /// <inheritdoc />
    protected override bool OnIsServerAuthoritative() => false;

    #endregion
}
