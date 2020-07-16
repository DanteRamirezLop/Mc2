<?php
include_once 'conexion.php';

class Proyecto extends DB{
    
    function obtenerProyecto(){
        $query = $this->connect()->query('SELECT * FROM proyecto');
        return $query;
    }
}

class Ambiente extends DB{
    
    function obtenerAmbiente($Id_foraneo){
        $query = $this->connect()->query('SELECT a. id ,a. idProyecto, a. nAmbiente, a. largo, a. ancho, a. altura FROM ambiente a INNER JOIN proyecto p ON a.idProyecto = p.id WHERE p.id ='.$Id_foraneo);  
        return $query;
    }
}

/*
class Arista extends DB{
    
    function obtenerArista(){
        $query = $this->connect()->query('SELECT * FROM arista');
        return $query;
    }
}

class Destino extends DB{
    
    function obtenerDestino(){
        $query = $this->connect()->query('SELECT * FROM destino');
        return $query;
    }
}
*/

?>