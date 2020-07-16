<?php
     $host     = "127.0.0.1";
     $db       = "bd_mc2";
     $user     = "root";
     $password = "";
     //$charset  = 'utf8mb4';

	 $idProyecto = $_POST["idProyecto"];
	 $nAmbiente = $_POST["nAmbiente"];
	 $largo =$_POST["largo"];
	 $ancho =$_POST["ancho"];
	 $altura =$_POST["altura"];
	 $area =$_POST["area"];
	 $recambios =$_POST["recambios"];
	 $flujo =$_POST["flujo"];
	 $cfm =$_POST["cfm"];
	 $coordenadas =$_POST["coordenadas"];
	 
	 $conn = new mysqli($host,$user,$password,$db);
	 
	 if($conn->connect_error){
		 die("Connection failed: ". $con->connect_error);
	 }
		
	//$sql ="INSERT INTO proyecto (nombre) VALUES ('".$nombre ."')";	
	$sql = "INSERT INTO ambiente(idProyecto, nAmbiente, largo, ancho, altura, area,recambios,flujo,cfm,coordenadas)
	VALUES ('".$idProyecto."','".$nAmbiente."','".$largo."','".$ancho."','".$altura."','".$area."','".$recambios."','".$flujo."','".$cfm."','".$coordenadas."')";
	
	if($conn->query($sql)===TRUE){
		echo "MENSAJE API: Registro exitoso en la BD";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>