<?php
$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
//check that connection happened
if(mysqli_connect_errno())
{
    echo "1: Connection failed"; //error code #1 = connection failed
    exit();
}

$username = $_POST["name"];
$newscore = $_POST["score"];


//double check there is only one user with this name
$namecheckquery = "SELECT username FROM players WHERE username ='" . $username ."';";

$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //error code #2 = name check query failed
if(mysqli_num_rows($namecheck) != 1)
{
    echo "5: Either no user with name, or more than one"; //error code #5 - number of names matching != 1
    exit();
}

$updatequery = "UPDATE players SET score = " . $newscore . " WHERE username = '" . $username . "';";
//echo $updatequery;
//mysqli_query($con, $updatequery) or die ("7: Save query failed"); // error code #7 - Update query failed

// update query (SQL injection safer)
$updateQry = $updateSmt = $con->prepare( "UPDATE `players` SET score = ? WHERE `username` = ?;" );
if ( !$updateQry ) {
    die("SQL syntax is wrong or connection is dead " . $con->error);
}
$updateQry->bind_param("is", $sql_score, $sql_username);

if ($con->query($updatequery) === TRUE) 
{
    echo "0";
  } 
else {
    echo "Error updating record: " . $con->error;
}

?>