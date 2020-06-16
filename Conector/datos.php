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

}else{
                    echo 'solicitud no encontrada';
     }


?>