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
        $query = $this->connect()->query('SELECT a. id ,a. idProyecto, a. nAmbiente, a. largo, a. ancho, a. altura, a. area, a. recambios, a. flujo, a. cfm, a. coordenada FROM ambiente a INNER JOIN proyecto p ON a.idProyecto = p.id WHERE p.id ='.$Id_foraneo);  
        return $query;
    }
}

class Ducto extends DB{
    
    function obtenerDucto(){
        $query = $this->connect()->query('SELECT * FROM ducto');  
        return $query;
    }
}
class Ductoex extends DB{
    
    function obtenerDuctoex(){
        $query = $this->connect()->query('SELECT * FROM ductoex');  
        return $query;
    }
}
class Ductopass extends DB{
    
    function obtenerDuctopass(){
        $query = $this->connect()->query('SELECT * FROM ductopass');  
        return $query;
    }
}
class Equipoesp extends DB{
    
    function obtenerEquipoesp(){
        $query = $this->connect()->query('SELECT * FROM equipoesp');  
        return $query;
    }
}
class Equipov extends DB{
    
    function obtenerEquipov($Id_foraneo){
        $query = $this->connect()->query('SELECT * FROM equipov WHERE idProyecto='.$Id_foraneo);  
        return $query;
    }
}
class Espfiltro extends DB{
    
    function obtenerEspfiltro(){
        $query = $this->connect()->query('SELECT * FROM espfiltro');  
        return $query;
    }
}
class Filtro extends DB{
    
    function obtenerFiltro(){
        $query = $this->connect()->query('SELECT * FROM filtro');  
        return $query;
    }
}

class Item extends DB{
    
    function obtenerItem(){
        $query = $this->connect()->query('SELECT * FROM item');  
        return $query;
    }
}

class Metradoex extends DB{
    
    function obtenerMetradoex(){
        $query = $this->connect()->query('SELECT * FROM metradoex');  
        return $query;
    }
}
class Rejilla extends DB{
    
    function obtenerRejilla(){
        $query = $this->connect()->query('SELECT * FROM rejilla');  
        return $query;
    }
}

class Multiple extends DB{
    
    function obtenerMultiple(){
        $query = $this->connect()->query('SELECT * FROM multiple ');  
        return $query;
    }
}

?>