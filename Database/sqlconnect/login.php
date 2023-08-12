<?php
$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
//check that connection happened
if(mysqli_connect_errno())
{
    echo "1: Connection failed"; //error code #1 = connection failed
    exit();
}

$username = $_POST["name"];
$password = $_POST["password"];

//check if name already exists
$namecheckquery = "SELECT username, salt, hash, score FROM players WHERE username='" . $username ."';";
// TODO ^ SQL injection risk - use prepared statements

$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //error code #2 = name check query failed
if(mysqli_num_rows($namecheck) != 1)
{
    echo "5: Either no user with name, or more than one"; //error code #5 - number of names matching != 1
    exit();
}
//get login info from query
$existinginfo = mysqli_fetch_assoc($namecheck);
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

if (!password_verify($password, $hash)) 
{
    echo "6: Incorrect password"; //error code #6 - password doesn not hash to match table
    exit();
} 

echo"0\t" . $existinginfo["score"];

?>