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
 
                    'id'=> (int)$row['id'],
                    'nombre'=> $row['nombre'],
					'estado'=> false, // extra
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
 
                    'id'=>(int) $row['id'],
                    'idProyecto'=>(int) $row['idProyecto'],
					'nAmbiente'=> $row['nAmbiente'],
					'largo'=> (double)$row['largo'],
					'ancho'=> (double)$row['ancho'],
					'altura'=> (double)$row['altura'],
					'area'=> (double)$row['area'],
					'recambios'=> (double)$row['altura'],
					'flujo'=> (double)$row['flujo'],
					'cfm'=> (double)$row['cfm'],
					'coordenada'=> $row['coordenada'],
					'estado'=> false, // extra
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
 
                    'id'=> (int)$row['id'],
                    'longitud'=> (double)$row['longitud'],
					'paso'=> (int)$row['paso'],
					'dibujar'=> (int)$row['dibujar'],
				    //--------
					'idDucto'=> (int)$row['idDucto'],
                    'tipo'=> (int)$row['tipo'],
					'nombre'=> $row['nombre'],
					'dimA'=> (double)$row['dimA'],
					'dimB'=>(double) $row['dimB'],
                    'flujoCFM'=> (double)$row['flujoCFM'],
					'damAb100'=> (double)$row['damAb100'],
					'damCer10'=>(double) $row['damCer10'],
                    'damCer50'=> (double)$row['damCer50'],
                    'tranRec'=>(double) $row['tranRec'],
					'conVen'=> (double)$row['conVen'],
					'lumAli'=> (double)$row['lumAli'],
					'estado'=> false, // extra
					
                );
                array_push($ductos["ductos"], $item);
            }
        
            echo json_encode($ductos);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}
if($_GET['variable']== 'ductopass'){
	
	    //$Id_foraneo=$_GET['variable2']; //utilizar solo en las consultas complejas
	    //echo($Id_foraneo);
	
        $ductopass = new Ductopass();
        $ductopasss= array();
        $ductopasss["ductopasss"] = array();
		
        $res = $ductopass->obtenerDuctopass();
        if($res->rowCount()){
            while ($row = $res->fetch(PDO::FETCH_ASSOC)){
    
                $item=array(
 
                    'idDucto'=> (int)$row['idDucto'],
                    'ccx'=> (float)$row['ccx'],
					'ccy'=> (float)$row['ccy'],
					'ccz'=> (float)$row['ccz'],
					'paso'=> (int)$row['paso'],
					'dibujar'=> (int)$row['dibujar'],
					'estado'=> false, // extra
					
                );
                array_push($ductopasss["ductopasss"], $item);
            }
        
            echo json_encode($ductopasss);

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
				    'id'=> (int)$row['id'],
                    'idProyecto'=> (int)$row['idProyecto'],
					'codigo'=> $row['codigo'],
					'tipo'=> (int)$row['tipo'],
					'velocidadIny'=> (double)$row['velocidadIny'],
					'velocidadExt'=> (double)$row['velocidadExt'],
					'porcentajeIny'=> (double)$row['porcentajeIny'],
					'porcentajeExt'=> (double)$row['porcentajeExt'],
					'calculo'=> (int)$row['calculo'],
					'vinculo'=> (int)$row['vinculo'],
					'nivel'=> $row['nivel'],
					'idAmbiente'=> (int)$row['idAmbiente'],
				    'ccx'=> (float)$row['ccx'],
					'ccy'=> (float)$row['ccy'],
					'ccz'=> (float)$row['ccz'],
					//------
                    'idEquipoV'=> (int)$row['idEquipoV'],
                    'potencia'=> (double)$row['potencia'],
					'voltaje'=> (double)$row['voltaje'],
					'sistema'=> (int)$row['sistema'],
					'enfEntrada1'=> (double)$row['enfEntrada1'],
					'enfEntrada2'=> (double)$row['enfEntrada2'],
					'enfSalida1'=> (double)$row['enfSalida1'],
					'enfSalida2'=> (double)$row['enfSalida2'],
					'tipo2'=> $row['tipo'],
					'Hz'=> (double)$row['Hz'],
					'CSensible'=> (double)$row['CSensible'],
				    'CLatente'=> (double)$row['CLatente'],
					'ESensible'=> (double)$row['ESensible'],
					'ELatente'=> (double)$row['ELatente'],
					'caudal'=> (double)$row['caudal'],
					'estado'=> false, // extra
					
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
 
                    'idEquip'=>(int) $row['idEquip'],
                    'idFiltro'=> (int)$row['idFiltro'],
					'estado'=> false, // extra					
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
 
                    'id'=> (int)$row['id'],
                    'nombre'=> $row['nombre'],
					'estado'=> false, // extra
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
 
                    'id'=>(int)$row['id'],
                    'idItem'=> (int)$row['idItem'],
					'idEquipo'=>(int)$row['idEquipo'],
					'conexion'=>(int)$row['conexion'],
					'estado'=> false, // extra
					
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
 
                    'id'=> (int)$row['id'],
                    'idEquipo'=> (int)$row['idEquipo'],
					'dima'=>(int) $row['dima'],
					'dimb'=> (int)$row['dimb'],
					'tipo'=> (int)$row['tipo'],
					'multi'=> (double)$row['multi'],
					'estado'=> false, // extra
					
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
 
                    'id'=> (int)$row['id'],
					'nombre'=> $row['nombre'],
					'cfm'=> (double)$row['cfm'],
					'estado'=> false, // extra
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
 
                    'id'=> (int)$row['id'],
					'giroX'=> (float)$row['giroX'],
					'giroY'=> (float)$row['giroY'],
					'estado'=> false, // extra
					
                );
                array_push($multiples["multiples"], $item);
            }
        
            echo json_encode($multiples);

        }else{
            echo json_encode(array('mensaje' => 'No hay elementos'));
        }
}


?>