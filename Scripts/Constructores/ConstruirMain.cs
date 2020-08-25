using UnityEngine;

public abstract class ConstruirMain
{
    public abstract void FormFill(WWWForm form, bool registrar);
    public abstract void FormFillElim(WWWForm form);
    public abstract string FormType();
}
