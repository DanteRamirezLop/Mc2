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

    public void GuardarBD()
    {
        foreach (Ambiente items in DatosScena.Ambiente)
        {
            if (items.id != 0 && items.estado == true)
                ScriptA_E.Editar(items);

            if (items.id == 0 && items.estado == true)
                ScriptA.Registrar(items);
        }
        foreach (Ducto items in DatosScena.Ducto)
        {
            if (items.id != 0 && items.estado == true)
                ScriptD_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptD.Registrar(items);
        }
        foreach (Ductopass items in DatosScena.Ductopass)
        {
            if (items.idDucto != 0 && items.estado == true)
                ScriptDP_E.Editar(items);
            
            if (items.idDucto == 0 && items.estado == true)
                ScriptDP.Registrar(items);
        }
        foreach (Equipo items in DatosScena.Equipo)
        {
            if (items.id != 0 && items.estado == true)
                ScriptE_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptE.Registrar(items);

        }
        foreach (Filtro items in DatosScena.Filtro)
        {
            if (items.id != 0 && items.estado == true)
                ScriptF_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptF.Registrar(items);
        }
        foreach (Espfiltro items in DatosScena.Espfiltro)
        {
            if (items.idEquip != 0 && items.estado == true)
                ScriptEF_E.Editar(items);
            
            if (items.idEquip == 0 && items.estado == true)
                ScriptEF.Registrar(items);
        }
        foreach (Metradoex items in DatosScena.Metradoex)
        {
            if (items.id != 0 && items.estado == true)
                ScriptME_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptME.Registrar(items);
        }
        foreach (Multiple items in DatosScena.Multiple)
        {
            if (items.id != 0 && items.estado == true)
                ScriptMU_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptMU.Registrar(items);
        }
        foreach (Rejilla items in DatosScena.Rejilla)
        {
            if (items.id != 0 && items.estado == true)
                ScriptR_E.Editar(items);
            
            if (items.id == 0 && items.estado == true)
                ScriptR.Registrar(items);
        }
    }




}
