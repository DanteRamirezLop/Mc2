<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $idItem = $_POST["idItem"];

    $sql_3 ="DELETE FROM item WHERE idItem= '".$id."'";
	
	if($conn->query($sql_3)===TRUE){
		echo "Eliminacion exitoso - Item";
	}else{
		echo "Error:".$sql_3."<br>".$conn->error;
	} 
	 
	$sql_2 ="DELETE FROM ductoex WHERE idDucto = '".$idItem."'";
	
	if($conn->query($sql_2)===TRUE){
		echo "Eliminacion exitoso-Ductoex";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	 
	 
	$sql ="DELETE FROM ducto WHERE id= '".$idItem."'";	
	
	if($conn->query($sql)===TRUE){
		echo "Eliminacion exitoso - Ducto";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
	
	$conn->close();
?>