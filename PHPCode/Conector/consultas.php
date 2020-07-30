<?php
include_once 'conexion.php';

class Proyecto extends DB{
    
    function obtenerProyecto(){
        $query = $this->connect()->query('SELECT * FROM proyecto');
        return $query;
    }
}

class Ambiente extends DB{
    
    function obtenerAmbiente(){
        $query = $this->connect()->query('SELECT * FROM ambiente');  
        return $query;
    }
}

class Ducto extends DB{
    
    function obtenerDucto(){
        //$query = $this->connect()->query('SELECT * FROM ducto JOIN ductopass ON ducto.id = ductopass.idDucto INNER JOIN ductoex ON ductoex.idDucto = ductopass.idDucto');  
        $query = $this->connect()->query('SELECT * FROM ducto INNER JOIN ductoex ON ducto.id = ductoex.idDucto');  
		return $query;
    }
}

class Ductopass extends DB{
    
    function obtenerDuctopass(){
        $query = $this->connect()->query('SELECT * FROM ductopass');  
        return $query;
    }
}

class Equipo extends DB{
    
    function obtenerEquipo(){
        $query = $this->connect()->query('SELECT * FROM equipov INNER JOIN equipoesp ON equipov.id = equipoesp.idEquipoV');  
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