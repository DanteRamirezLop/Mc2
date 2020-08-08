<?php
     include_once 'Conexion.php';	 
	 
	$idItem =$_POST["idItem"];
	$idEquipo =$_POST["idEquipo"];
	$conexion =$_POST["conexion"];
	//---------------
	$id = $_POST["id"];
	$nombre =$_POST["nombre"];
	$cfm =$_POST["cfm"];
	 
	$sql =" UPDATE rejilla SET nombre='".$nombre."',cfm='".$cfm."' WHERE id ='".$idItem."'";
	
	if($conn->query($sql)===TRUE){
		echo "Modificacion exitoso rejilla ";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
    $sql_2 ="UPDATE item SET idItem='".$idItem."',idEquipo='".$idEquipo."',conexion='".$conexion."' WHERE id='".$id."'";
	
	if($conn->query($sql_2)===TRUE){
		echo "Modificacion exitoso item";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	
	$conn->close();
?>