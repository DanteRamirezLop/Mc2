<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $idEquipo =$_POST["idEquipo"];
	 $dima =$_POST["dima"];
	 $dimb =$_POST["dimb"];
	 $tipo =(int)$_POST["tipo"];
	 $multi =$_POST["multi"];
	 
	$sql ="UPDATE metradoex SET idEquipo='".$idEquipo."',dima='".$dima."',dimb='".$dimb."',tipo='".$tipo."',multi='".$multi."' WHERE id='". $id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>