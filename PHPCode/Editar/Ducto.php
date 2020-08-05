<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
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
	 
	 
	$sql ="UPDATE ducto SET longitud='".$longitud."',paso='".$paso."',dibujar='".$dibujar."'WHERE id='".$idItem."'";	
	
	if($conn->query($sql)===TRUE){
		echo "Modificacion exitosa - Ducto";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
	$sql_2 ="UPDATE ductoex SET tipo='"
	.$tipo."',nombre='".$nombre."',dimA='".$dimA."',dimB='".$dimB."',flujoCFM='".$flujoCFM."',damAb100='".$damAb100."',damCer10='".$damCer10."',damCer50='".$damCer50."',tranRec='".$tranRec."',conVen='".$conVen."',lumAli='".$lumAli.
	 "' WHERE idDucto='".$idItem."'";
	
	if($conn->query($sql_2)===TRUE){
		echo "Modificacion exitoso - Ductoex";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	
	$sql_3 ="UPDATE item SET idItem='".$idItem."',idEquipo='".$idEquipo."',conexion='".$conexion."' WHERE id='".$id."'";
	
	if($conn->query($sql_3)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql_3."<br>".$conn->error;
	}
	
	$conn->close();
?>