<?php
     include_once 'Conexion.php';	 
	 
	 //$idEquipoV = $_POST["idEquipoV"];
	 $potencia =$_POST["potencia"];
	 $voltaje =$_POST["voltaje"];
	 $sistema =$_POST["sistema"];
	 $enfEntrada1 =$_POST["enfEntrada1"];
	 $enfEntrada2 =$_POST["enfEntrada2"];
	 $enfSalida1 =$_POST["enfSalida1"];
	 $enfSalida2 =$_POST["enfSalida2"];
	 $tipo =$_POST["tipo"];
	 $Hz =$_POST["Hz"];
	 $CSensible =$_POST["CSensible"];
	 $CLatente =$_POST["CLatente"];
	 $ESensible =$_POST["ESensible"];
	 $ELatente =$_POST["ELatente"];
	 $caudal =$_POST["caudal"];
	 
	$sql ="INSERT INTO equipoesp (potencia,voltaje,sistema,enfEntrada1,enfEntrada2,enfSalida1,enfSalida2,tipo,Hz,CSensible,CLatente,ESensible,ELatente,caudal)
	VALUES ('".$potencia."','".$voltaje."','".$sistema."','".$enfEntrada1."','".$enfEntrada2."','".$enfSalida1."','".$tipo."','".$Hz."','".$CSensible."','".$CLatente."','".$ESensible."','".$ELatente."','".$caudal."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>