<?php
     include_once 'Conexion.php';	 
	 
	 $idEquipoV = $_POST["idEquipoV"];
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
	 
	$sql ="UPDATE equipoesp SET potencia='".$potencia."','voltaje=".$voltaje."','sistema=".$sistema."','enfEntrada1=".$enfEntrada1."','enfEntrada2=".$enfEntrada2."','enfSalida1=".$enfSalida1."','tipo=".$tipo."','Hz=".$Hz."','=CSensible".$CSensible."','CLatente=".$CLatente."','ESensible=".$ESensible."','ESensible=".$ELatente."','caudal=".$caudal.
	"' WHERE idEquipoV= '".$idEquipoV ."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>