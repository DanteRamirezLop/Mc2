<?php
     include_once 'Conexion.php';	 
	 
	 $idItem =$_POST["idItem"];
	 $idEquipo =$_POST["idEquipo"];
	 $conexion =$_POST["conexion"];
	 //-------------
	 $id = $_POST["id"];
	 $giroX =$_POST["giroX"];
	 $giroY =$_POST["giroY"];
	 
	$sql ="UPDATE multiple SET giroX='".$giroX."',giroY='".$giroY."'WHERE id='".$idItem."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso multiple";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
    $sql_2 ="UPDATE item SET idItem='".$idItem."',idEquipo='".$idEquipo."',conexion='".$conexion."' WHERE id='".$id."'";
	
	if($conn->query($sql_2)===TRUE){
		echo "Registro exitoso item";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	
	$conn->close();
?>