<?php
     include_once 'Conexion.php';	 
	 
    $id = $_POST["id"];
	$idItem = $_POST["idItem"];
	 
	$sql_2 ="DELETE FROM item WHERE idItem= '".$id."'";
	
	if($conn->query($sql_2)===TRUE){
		echo "Eliminacion exitoso - Item";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	
	$sql ="DELETE FROM multiple WHERE id= '".$idItem."'";
	
	if($conn->query($sql)===TRUE){
		echo "Eliminacion exitosa-multiple";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>