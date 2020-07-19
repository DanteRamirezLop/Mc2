<?php
     include_once 'Conexion.php';	 
	 
	 //$id = $_POST["id"];
	 $idEquipo =$_POST["idEquipo"];
	 $dima =$_POST["dima"];
	 $dimb =$_POST["dimb"];
	 $tipo =$_POST["tipo"];
	 $multi =$_POST["multi"];
	 
	$sql ="INSERT INTO metradoex (idEquipo,dima,dimb,tipo,multi) 
	VALUES ('".$idEquipo."','".$dima."','".$dimb."','".$tipo."','".$multi."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>