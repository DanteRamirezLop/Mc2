using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

    public class Item : ConstruirMain
    {
        public int id;
        public int idItem;
        public int idEquipo;
        public int conexion;

    public override void FormFill(WWWForm form, bool registrar)
    {
        if (registrar)
            form.AddField("id", id.ToString());
        form.AddField("idItem", idItem.ToString());
        form.AddField("idEquipo", idEquipo.ToString());
        form.AddField("conexion", conexion.ToString());
    }

    public override void FormFillElim(WWWForm form)
    {
        form.AddField("id", idItem.ToString());
        form.AddField("idItem", idItem.ToString());
    }

    public override string FormType()
    {
        return "Item";
    }
}

