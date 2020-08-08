using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registro : MonoBehaviour
{
    public RegistroAmbiente ScriptA;
    public RegistroDucto ScriptD;
    public RegistroDuctopass ScriptDP;
    public RegistroEquipo ScriptE;
    public RegistroFiltro ScriptF;
    public RegistroEspfiltro ScriptEF;
    public RegistroMetradoex ScriptME;
    public RegistroMultiple ScriptMU;
    public RegistroRejilla ScriptR;
    //---------------------------
    public EditarAmbiente ScriptA_E;
    public EditarDucto ScriptD_E;
    public EditarDuctopass ScriptDP_E;
    public EditarEquipo ScriptE_E;
    public EditarFiltro ScriptF_E;
    public EditarEspfiltro ScriptEF_E;
    public EditarMetradoex ScriptME_E;
    public EditarMultiple ScriptMU_E;
    public EditarRejilla ScriptR_E;
    //---------------------------
    public ElimiarAmbiente ScriptA_D;
    public EliminarDucto ScriptD_D;
    public EliminarDuctopass ScriptDP_D;
    public EliminarEquipo ScriptE_D;
    public EliminarFiltro ScriptF_D;
    public EliminarEspfiltro ScriptEF_D;
    public EliminarMetradoex ScriptME_D;
    public EliminarMultiple ScriptMU_D;
    public EliminarRejilla ScriptR_D;

    public void GuardarBD()
    {
        foreach (Ambiente items in DatosScena.Ambiente)
        {
            if (items.id != 0 && items.estado == true)
                ScriptA_E.Editar(items);

            if (items.id == 0 && items.estado == true)
                ScriptA.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Ambiente" && items_2.id == items.id)
                ScriptA_D.Eliminar(items.id);
            }
             
        }
        foreach (Ducto items in DatosScena.Ducto)
        {
            if (items.id != 0 && items.estado == true)
                ScriptD_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptD.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Ducto" && items_2.id == items.id)
                    ScriptD_D.Eliminar(items.id, items.idItem);
            }
        }
        foreach (Ductopass items in DatosScena.Ductopass)
        {
            if (items.idDucto != 0 && items.estado == true)
                ScriptDP_E.Editar(items);
            
            if (items.idDucto == 0 && items.estado == true)
                ScriptDP.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Ductopass" && items_2.id == items.idDucto)
                    ScriptDP_D.Eliminar(items.idDucto);
            }

        }
        foreach (Equipo items in DatosScena.Equipo)
        {
            if (items.id != 0 && items.estado == true)
                ScriptE_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptE.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Equipo" && items_2.id == items.id)
                    ScriptE_D.Eliminar(items.id);
            }

        }
        foreach (Filtro items in DatosScena.Filtro)
        {
            if (items.id != 0 && items.estado == true)
                ScriptF_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptF.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Filtro" && items_2.id == items.id)
                    ScriptF_D.Eliminar(items.id);
            }
        }
        foreach (Espfiltro items in DatosScena.Espfiltro)
        {
            if (items.idEquip != 0 && items.estado == true)
                ScriptEF_E.Editar(items);
            
            if (items.idEquip == 0 && items.estado == true)
                ScriptEF.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Espfiltro" && items_2.id == items.idEquip)
                    ScriptEF_D.Eliminar(items.idEquip, items.idFiltro);
            }
        }
        foreach (Metradoex items in DatosScena.Metradoex)
        {
            if (items.id != 0 && items.estado == true)
                ScriptME_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptME.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Metradoex" && items_2.id == items.id)
                    ScriptME_D.Eliminar(items.id);
            }

        }
        foreach (Multiple items in DatosScena.Multiple)
        {
            if (items.id != 0 && items.estado == true)
                ScriptMU_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptMU.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Multiple" && items_2.id == items.id)
                    ScriptMU_D.Eliminar(items.id, items.idItem);
            }
        }
        foreach (Rejilla items in DatosScena.Rejilla)
        {
            if (items.id != 0 && items.estado == true)
                ScriptR_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptR.Registrar(items);

            foreach (Eliminar items_2 in DatosScena.Eliminar)
            {
                if (items_2.nom_Tabla == "Rejilla" && items_2.id == items.id)
                    ScriptR_D.Eliminar(items.id, items.idItem);
            }
        }





    }




}
