using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Proyecto : ConstruirMain
{
    public string id;
    public string nombre;

    public override void FormFill(WWWForm form, bool registrar)
    {
        form.AddField("nombre", nombre);
    }

    public override void FormFillElim(WWWForm form)
    {
        form.AddField("id", id.ToString());
    }

    public override string FormType()
    {
        return "Proyecto";
    }

    public override string ToString()
    {
        return string.Format("{0},{1}", id, nombre);
    }
}

[System.Serializable]
public class ListaProyectos
{
    public List<Proyecto> proyectos;

}
