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
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $ambiente = new Ambiente();
        $ambientes= array();
        $ambientes["ambientes"] = array();
		
        $res = $ambiente->obtenerAmbiente();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'id'=> $row['id'],
                    'idProyecto'=> $row['idProyecto'],
					'nAmbiente'=> $row['nAmbiente'],
					'largo'=> $row['largo'],
					'ancho'=> $row['ancho'],
					'altura'=> $row['altura'],
					'area'=> $row['area'],
					'recambios'=> $row['altura'],
					'flujo'=> $row['flujo'],
					'cfm'=> $row['cfm'],
					'coordenada'=> $row['coordenada'],
					
					
                );
                array_push($ambientes["ambientes"], $item);
            }
        
            echo json_encode($ambientes);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}

if($_GET['variable']== 'ducto'){
	
	   // $Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $ducto = new Ducto();
        $ductos= array();
        $ductos["ductos"] = array();
		
        $res = $ducto->obtenerDucto();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'id'=> $row['id'],
                    'longitud'=> $row['longitud'],
					'paso'=> $row['paso'],
					'dibujar'=> $row['dibujar'],
				    //--------
					'idDucto2'=> $row['idDucto'],
                    'ccx'=> $row['ccx'],
					'ccy'=> $row['ccy'],
					'ccz'=> $row['ccz'],
					'paso2'=> $row['paso'],
					'dibujar2'=> $row['dibujar'],
					
                );
                array_push($ductos["ductos"], $item);
            }
        
            echo json_encode($ductos);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}

if($_GET['variable']== 'ductoex'){
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $ductoex = new Ductoex();
        $ductoexs= array();
        $ductoexs["ductoexs"] = array();
		
        $res = $ductoex->obtenerDuctoex();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'idDucto'=> $row['idDucto'],
                    'tipo'=> $row['tipo'],
					'nombre'=> $row['nombre'],
					'dimA'=> $row['dimA'],
					'dimB'=> $row['dimB'],
                    'flujoCFM'=> $row['flujoCFM'],
					'damAb100'=> $row['damAb100'],
					'damCer10'=> $row['damCer10'],
                    'damCer50'=> $row['damCer50'],
                    'tranRec'=> $row['tranRec'],
					'conVen'=> $row['conVen'],
					'lumAli'=> $row['lumAli'],
					
                );
                array_push($ductoexs["ductoexs"], $item);
            }
        
            echo json_encode($ductoexs);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}

if($_GET['variable']== 'equipo'){
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $equipo = new Equipo();
        $equipos= array();
        $equipos["equipos"] = array();
		
        $res = $equipo->obtenerEquipo();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
				    'id'=> $row['id'],
                    'idProyecto'=> $row['idProyecto'],
					'codigo'=> $row['codigo'],
					'tipo'=> $row['tipo'],
					'velocidadIny'=> $row['velocidadIny'],
					'velocidadExt'=> $row['velocidadExt'],
					'porcentajeIny'=> $row['porcentajeIny'],
					'porcentajeExt'=> $row['porcentajeExt'],
					'calculo'=> $row['calculo'],
					'vinculo'=> $row['vinculo'],
					'nivel'=> $row['nivel'],
					'idAmbiente'=> $row['idAmbiente'],
				    'ccx'=> $row['ccx'],
					'ccy'=> $row['ccy'],
					'ccz'=> $row['ccz'],
					//------
                    'idEquipoV'=> $row['idEquipoV'],
                    'potencia'=> $row['potencia'],
					'voltaje'=> $row['voltaje'],
					'sistema'=> $row['sistema'],
					'enfEntrada1'=> $row['enfEntrada1'],
					'enfEntrada2'=> $row['enfEntrada2'],
					'enfSalida1'=> $row['enfSalida1'],
					'enfSalida2'=> $row['enfSalida2'],
					'tipo2'=> $row['tipo'],
					'Hz'=> $row['Hz'],
					'CSensible'=> $row['CSensible'],
				    'CLatente'=> $row['CLatente'],
					'ESensible'=> $row['ESensible'],
					'ELatente'=> $row['ELatente'],
					'caudal'=> $row['caudal'],
					
                );
                array_push($equipos["equipos"], $item);
            }
        
            echo json_encode($equipos);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}


if($_GET['variable']== 'espfiltro'){
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $espfiltro = new Espfiltro();
        $espfiltros= array();
        $espfiltros["espfiltros"] = array();
		
        $res = $espfiltro->obtenerEspfiltro();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'idEquip'=> $row['idEquip'],
                    'idFiltro'=> $row['idFiltro'],					
                );
                array_push($espfiltros["espfiltros"], $item);
            }
        
            echo json_encode($espfiltros);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}

if($_GET['variable']== 'filtro'){
	
	   // $Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $filtro = new Filtro();
        $filtros= array();
        $filtros["filtros"] = array();
		
        $res = $filtro->obtenerFiltro();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'id'=> $row['id'],
                    'nombre'=> $row['nombre'],
                );
                array_push($filtros["filtros"], $item);
            }
        
            echo json_encode($filtros);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}



if($_GET['variable']== 'item'){
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $item = new Item();
        $items= array();
        $items["items"] = array();
		
        $res = $item->obtenerItem();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item2=array(
 
                    'id'=> $row['id'],
                    'idItem'=> $row['idItem'],
					'idEquipo'=> $row['idEquipo'],
					'conexion'=> $row['conexion'],
					
                );
                array_push($items["items"], $item2);
            }
        
            echo json_encode($items);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}


if($_GET['variable']== 'metradoex'){
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $metradoex = new Metradoex();
        $metradoexs= array();
        $metradoexs["metradoexs"] = array();
		
        $res = $metradoex->obtenerMetradoex();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'id'=> $row['id'],
                    'idEquipo'=> $row['idEquipo'],
					'dima'=> $row['dima'],
					'dimb'=> $row['dimb'],
					'tipo'=> $row['tipo'],
					'multi'=> $row['multi'],
					
                );
                array_push($metradoexs["metradoexs"], $item);
            }
        
            echo json_encode($metradoexs);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}

if($_GET['variable']== 'rejilla'){
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $rejilla = new Rejilla();
        $rejillas= array();
        $rejillas["rejillas"] = array();
		
        $res = $rejilla->obtenerRejilla();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'id'=> $row['id'],
					'nombre'=> $row['nombre'],
					'cfm'=> $row['cfm'],
                );
                array_push($rejillas["rejillas"], $item);
            }
        
            echo json_encode($rejillas);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}

if($_GET['variable']== 'multiple'){
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $multiple = new Multiple();
        $multiples= array();
        $multiples["multiples"] = array();
		
        $res = $multiple->obtenerMultiple();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'id'=> $row['id'],
					'giroX'=> $row['giroX'],
					'giroY'=> $row['giroY'],
					
                );
                array_push($multiples["multiples"], $item);
            }
        
            echo json_encode($multiples);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}


?>