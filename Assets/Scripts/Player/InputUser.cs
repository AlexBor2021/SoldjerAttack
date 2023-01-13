using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputUser : MonoBehaviour
{
    private MoverPlayer _moverPlayer;

    protected Vector2 InputVector;  
    protected Vector3 Direction;

    protected virtual float Horizontal => InputVector.x;
    protected virtual float Vertical => InputVector.y;

    public virtual void Init(MoverPlayer moverPlayer)
    {
        _moverPlayer = moverPlayer;
    }

    private void Update()
    {
        if (_moverPlayer == null)
            return;


        GetInputVector();
        SetInputVector();
    }

    protected abstract void GetInputVector();

    private void SetInputVector()
    {
        Direction = new Vector3(Horizontal, 0, Vertical);
        _moverPlayer.SetDiractionMove(Direction);
    }
}
