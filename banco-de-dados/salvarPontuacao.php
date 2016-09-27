<?php 
include('conectar.php');

/* Recuperação das informações passadas via URL */
$nome = mysql_real_escape_string($_GET['nome'], $db);  
$pontos = mysql_real_escape_string($_GET['pontos'], $db); 
$hash = $_GET['hash']; 

/* Verificar se a chave secreta confere */
$chaveSecreta = "titanic-each-usp"; // o valor da chave secreta deve ser o mesmo do script conexaoBanco.cs
$real_hash = md5($nome . $pontos . $secretKey); 

if($real_hash == $hash) { 
$query = "insert into scores values (NULL, '$nome', '$pontos');"; // edite de acordo com a sua tabela
$result = mysql_query($query) or die('Ocorreu um erro ao salvar: ' . mysql_error()); 
} 

?>
