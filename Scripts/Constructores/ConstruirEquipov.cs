using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruirEquipov : MonoBehaviour
{


    [System.Serializable]
    public class Equipov
    {
        public string id;
        public string idProyecto;
        public string codigo;
        public string tipo;
        public string velocidadlny;
        public string velocidadExt;
        public string porcentajelny;
		public string porcentajeExt;
        public string calculo;
        public string vinculo;
        public string nivel;
        public string idAmbiente;
        public string ccx;
        public string ccy;
        public string ccz;

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", id, idProyecto, codigo, tipo, velocidadlny, velocidadExt, porcentajelny,porcentajeExt, calculo, vinculo, nivel, idAmbiente, ccx, ccy, ccz);
        }
    }


    [System.Serializable]
    public class ListaEquipov
    {

        public List<Equipov> equipovs;

        public void CargarEquipov(string id_buscar)
        {
            foreach (Equipov equipov in equipovs)
            {

                if (id_buscar == equipov.id)
                {
                    Debug.Log(equipov.idProyecto);
                    Debug.Log(equipov.codigo);
                    Debug.Log(equipov.tipo);
                    Debug.Log(equipov.velocidadlny);
                    Debug.Log(equipov.velocidadExt);
                    Debug.Log(equipov.porcentajelny);
                    Debug.Log(equipov.porcentajeExt);
                    Debug.Log(equipov.calculo);
                    Debug.Log(equipov.vinculo);
                    Debug.Log(equipov.nivel);
                    Debug.Log(equipov.idAmbiente);
                    Debug.Log(equipov.ccx);
                    Debug.Log(equipov.ccy);
                    Debug.Log(equipov.ccz);

                }

            }
        }
    }
}
