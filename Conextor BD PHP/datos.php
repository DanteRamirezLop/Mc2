<?php
    header('Content-Type: application/json');
    header("Access-Control-Allow-Origin: *");
    include_once 'consultas.php';


if($_GET['variable']== 'proyecto'){
        $proyecto = new Proyecto();
        $proyectos= array();
        $proyectos["proyectos"] = array();
		
        $res = $proyecto->obtenerProyecto();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'id'=> $row['id'],
                    'nombre'=> $row['nombre'],
                );
                array_push($proyectos["proyectos"], $item);
            }
        
            echo json_encode($proyectos);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }

}

if($_GET['variable']== 'ambiente'){
	
	    $Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $ambiente = new Ambiente();
        $ambientes= array();
        $ambientes["ambientes"] = array();
		
        $res = $ambiente->obtenerAmbiente($Id_foraneo);
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'id'=> $row['id'],
                    'idProyecto'=> $row['idProyecto'],
					'nAmbiente'=> $row['nAmbiente'],
					'largo'=> $row['largo'],
					'ancho'=> $row['ancho'],
					'altura'=> $row['altura'],
					//*** agregar mas atributos si faltan y revisar la consulta si trae todos los atributos
                );
                array_push($ambientes["ambientes"], $item);
            }
        
            echo json_encode($ambientes);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }

}


?>