<?php
     include_once 'Conexion.php';	 
	 
	 //$id = $_POST["id"];
	 $longitud =$_POST["longitud"];
	 $paso =$_POST["paso"];
	 $dibujar =$_POST["dibujar"];
	 //---------------
	 $tipo =(int)$_POST["tipo"];
	 $nombre =$_POST["nombre"];
	 $dimA =$_POST["dimA"];
	 $dimB =$_POST["dimB"];
	 $flujoCFM =$_POST["flujoCFM"];
	 $damAb100 =$_POST["damAb100"];
	 $damCer10 =$_POST["damCer10"];
	 $damCer50 =$_POST["damCer50"];
	 $tranRec =$_POST["tranRec"];
	 $conVen =$_POST["conVen"];
	 $lumAli =$_POST["lumAli"];
	  //--------------
	 $idItem =$_POST["idItem"];
	 $idEquipo =$_POST["idEquipo"];
	 $conexion =$_POST["conexion"];
	 
	 
	$sql ="INSERT INTO ducto (id,longitud,paso,dibujar) 
	VALUES ('".$idItem."','".$longitud."','".$paso."','".$dibujar."')";	
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso Ducto";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
    $sql_2 ="INSERT INTO ductoex (idDucto,tipo,nombre,dimA,dimB,flujoCFM,damAb100,damCer10,damCer50,tranRec,conVen,lumAli) 
	VALUES ('".$idItem."','".$tipo."','".$nombre."','".$dimA."','".$dimB."','".$flujoCFM."','".$damAb100."','".$damCer10."','".$damCer50."','".$tranRec."','".$conVen."','".$lumAli."')";
	
	if($conn->query($sql_2)===TRUE){
		echo "Registro exitoso Ductoex";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	
   $sql_3 ="INSERT INTO item (idItem,idEquipo,conexion) 
	VALUES ('".$idItem."','".$idEquipo."','".$conexion."')";
	
	if($conn->query($sql_3)===TRUE){
		echo "Registro exitoso Item";
	}else{
		echo "Error:".$sql_3."<br>".$conn->error;
	}
	
	$conn->close();
?>