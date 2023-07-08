using System.Collections;
using System.Collections.Generic;
using Unity.Netcode.Components;
using UnityEngine;

public class ClientNetworkTransform : NetworkTransform
{
    #region Overrides of NetworkTransform

    /// <inheritdoc />
    protected override bool OnIsServerAuthoritative() => false;

    #endregion
}
