<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $idItem =$_POST["idItem"];
	 $idEquipo =$_POST["idEquipo"];
	 $conexion =$_POST["conexion"];
	 
	$sql ="UPDATE item SET idItem='".$idItem."','idEquipo=".$idEquipo."','conexion=".$conexion."' WHERE id='".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>