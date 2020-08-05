<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 
	$sql ="DELETE FROM metradoex WHERE id= '".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Eliminacion exitoso - metradoex";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>