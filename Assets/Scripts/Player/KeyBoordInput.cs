using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoordInput : InputUser
{
    private KeyMove _keymove;

    public override void Init(MoverPlayer moverPlayer)
    {
        _keymove = new KeyMove();
        _keymove.Enable();
        base.Init(moverPlayer);
    }

    protected override void GetInputVector()
    {
        InputVector = _keymove.Player.Move.ReadValue<Vector2>();
    }
}
